using HorizonShopping.Core.Services;

namespace HorizonShopping.Maui
{
    public partial class App : Application
    {
        private readonly AppShell _appShell;
        private readonly SupabaseService _supabaseService;

        public App(AppShell appShell, SupabaseService supabaseService)
        {
            InitializeComponent();

            _appShell = appShell;
            _supabaseService = supabaseService;
        }

        //CREACIÓN DE LA VENTANA
        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new Window(_appShell);

            window.Created += async (sender, e) =>  
            { 
                await IniciarAplicacionAsync(window);
            };

            return window;
        }

        //INICIALIZACIÓN DE LA APLICACIÓN
        private async Task IniciarAplicacionAsync(Window window)
        {
            try
            {
                await _supabaseService.InicializarAsync();

                window.Page = _appShell;
            }
            catch (Exception ex)
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await window.Page!
                            .DisplayAlert(
                                "Error",
                                ex.Message,
                                "Aceptar");
                    });
            }
        }
    }
}