using HorizonShopping.Core.Repositories;
using HorizonShopping.Core.Services;

namespace HorizonShopping.Maui;

public partial class SincronizacionPage : ContentPage
{
    private readonly SupabaseService _supabaseService;
    private readonly SincronizacionService _sincronizacionService;
    private readonly ShoppingRepository _shoppingRepository;
    private readonly SeccionRepository _seccionRepository;

    private IDispatcherTimer? _temporizadorEstado;

    public SincronizacionPage(SupabaseService supabaseService, SincronizacionService sincronizacionService, ShoppingRepository shoppingRepository,
        SeccionRepository seccionRepository)
    {
        InitializeComponent();

        _supabaseService = supabaseService;
        _sincronizacionService = sincronizacionService;
        _shoppingRepository = shoppingRepository;
        _seccionRepository = seccionRepository;

        _temporizadorEstado = Dispatcher.CreateTimer();

        _temporizadorEstado.Interval = TimeSpan.FromSeconds(5);

        _temporizadorEstado.Tick += OnTemporizadorEstadoTick;
    }

    //CICLO DE VIDA
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        lblCodigo.Text = "------";

        lblExpiracion.Text = "El código caduca en 10 minutos.";

        txtCodigo.Text = string.Empty;

        await ActualizarEstadoSincronizacionAsync();

        _temporizadorEstado?.Start();
    }

    protected override void OnDisappearing()
    {
        _temporizadorEstado?.Stop();

        base.OnDisappearing();
    }

    //ACTUALIZAR ESTADO
    private async void OnTemporizadorEstadoTick(object? sender, EventArgs e)
    {
        await ActualizarEstadoSincronizacionAsync();
    }

    private async Task ActualizarEstadoSincronizacionAsync()
    {
        try
        {
            int cantidad = await _supabaseService.ObtenerNumeroDispositivosVinculadosAsync();

            if (cantidad > 0)
            {
                brdEstado.BackgroundColor = Colors.Green;

                lblEstadoSincronizacion.Text = cantidad == 1 ? "Sincronizado con otro dispositivo" : $"Sincronizado con {cantidad} dispositivos";
            }
            else
            {
                brdEstado.BackgroundColor = Colors.Red;

                lblEstadoSincronizacion.Text = "No hay otros dispositivos vinculados";
            }
        }
        catch
        {
            /*
             * Si temporalmente no podemos consultar Supabase,
             * mantenemos el estado anterior sin mostrar errores.
             */
        }
    }

    //GENERAR CÓDIGO
    private async void OnGenerarCodigoClicked(object sender, EventArgs e)
    {
        try
        {
            Button boton = (Button)sender;

            boton.IsEnabled = false;

            (string codigo, DateTime expiraAt) = await _supabaseService.GenerarCodigoVinculacionAsync();

            lblCodigo.Text = codigo;

            TimeSpan restante = expiraAt.ToLocalTime() - DateTime.Now;

            if (restante.TotalSeconds < 0)
            {
                restante = TimeSpan.Zero;
            }

            lblExpiracion.Text = $"Caduca en {Math.Max(1, (int)restante.TotalMinutes)} minutos.";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }
        finally
        {
            ((Button)sender).IsEnabled = true;
        }
    }

    //VINCULAR DISPOSITIVO
    private async void OnVincularClicked(object sender, EventArgs e)
    {
        string codigo = txtCodigo.Text?.Trim() ?? string.Empty;

        if (codigo.Length != 6 || codigo.All(char.IsDigit))
        {
            await DisplayAlert(
                "Código incorrecto",
                "Introduce un código de 6 cifras.",
                "Aceptar");

            return;
        }

        try
        {
            Button boton = (Button)sender;

            boton.IsEnabled = false;

            /*
             * Primero vinculamos el dispositivo.
             */
            await _supabaseService.VincularDispositivoPorCodigoAsync(codigo);

            /*
             * IMPORTANTE:
             *
             * Al vincular un dispositivo, sus datos locales
             * anteriores dejan de pertenecer a su lista.
             *
             * Por tanto, no debemos intentar mezclarlos
             * con la lista compartida.
             *
             * Vaciamos completamente los datos locales
             * antes de descargar la lista compartida.
             */
            _shoppingRepository.ObtenerTodosCompletos().Clear();

            _shoppingRepository.Guardar();

            _seccionRepository.ObtenerTodasCompletas().Clear();

            _seccionRepository.Guardar();

            /*
             * Ahora descargamos la lista compartida.
             *
             * Como local está vacío, la sincronización
             * importará las secciones y productos de A
             * sin intentar subir datos antiguos de B.
             */
            await _sincronizacionService.SincronizarAsync();

            txtCodigo.Text = string.Empty;

            await ActualizarEstadoSincronizacionAsync();

            await DisplayAlert(
                "Dispositivo vinculado",
                "El dispositivo se ha vinculado correctamente.",
                "Aceptar");
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "No se ha podido vincular",
                ex.Message,
                "Aceptar");
        }
        finally
        {
            ((Button)sender).IsEnabled = true;
        }
    }

    //DESVINCULAR DISPOSITIVO
    private async void OnDejarDeVincularClicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert(
                "Dejar de vincular",
                "Este dispositivo dejará de compartir la lista actual con los demás dispositivos. La lista compartida y los demás dispositivos no se verán afectados. ¿Quieres continuar?",
                "Dejar de vincular",
                "Cancelar");

        if (!confirmar)
        {
            return;
        }

        try
        {
            Button boton = (Button)sender;

            boton.IsEnabled = false;

            await _supabaseService.DesvincularDispositivoAsync();

            /*
             * Eliminamos los datos locales de la lista anterior.
             */
            _shoppingRepository.ObtenerTodosCompletos().Clear();

            _shoppingRepository.Guardar();

            _seccionRepository.ObtenerTodasCompletas().Clear();

            _seccionRepository.Guardar();

            /*
             * Descargamos las nuevas secciones de la
             * lista independiente recién creada.
             */
            await _sincronizacionService.SincronizarAsync();

            await ActualizarEstadoSincronizacionAsync();

            await DisplayAlert(
                "Dispositivo desvinculado",
                "Este dispositivo ya tiene una lista independiente.",
                "Aceptar");
        }
        catch (Exception ex)
        {
            await DisplayAlert("No se ha podido desvincular", ex.Message, "Aceptar");
        }
        finally
        {
            ((Button)sender).IsEnabled = true;
        }
    }
}