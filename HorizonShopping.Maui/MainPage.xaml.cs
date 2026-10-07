using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Models;
using HorizonShopping.Core.Repositories;
using HorizonShopping.Core.Services;
using HorizonShopping.Maui.Behaviors;
using HorizonShopping.Maui.Models;
using HorizonShopping.Maui.Services;

namespace HorizonShopping.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly ShoppingController _controller;
        private readonly SeccionController _seccionController;
        private readonly ThemeService _themeService;
        private readonly SincronizacionService _sincronizacionService;
        private SeccionModel? _seccionActual;
        private Task? _tareaSincronizacion;
        private IDispatcherTimer? _temporizadorSincronizacion;

        public Color ColorPrincipal => _themeService.ColorPrincipal;

        public MainPage(ShoppingController controller, SeccionController seccionController, ThemeService themeService, SincronizacionService sincronizacionService)
        {
            InitializeComponent();

            _controller = controller;
            _seccionController = seccionController;
            _themeService = themeService;
            _sincronizacionService = sincronizacionService;

            _themeService.CargarTemaGuardado();

            logoHorizon.Source = _themeService.LogoActual;

            CargarBotonesSeccion();

            Loaded += MainPage_Loaded;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            logoHorizon.Source = _themeService.LogoActual;

            AplicarTemaInterfaz();
            CargarBotonesSeccion();
            CargarProductos(_seccionActual);

            IniciarTemporizadorSincronizacion();

            await SincronizarAlAparecerAsync(mostrarErrores: false);
        }

        protected override void OnDisappearing()
        {
            DetenerTemporizadorSincronizacion();

            base.OnDisappearing();
        }

        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            await SincronizarAlAparecerAsync(mostrarErrores: false);
        }

        
        // SINCRONIZACIÓN AUTOMÁTICA        
        private void IniciarTemporizadorSincronizacion()
        {
            if (_temporizadorSincronizacion is not null)
                return;

            _temporizadorSincronizacion = Dispatcher.CreateTimer();

            _temporizadorSincronizacion.Interval = TimeSpan.FromSeconds(5);

            _temporizadorSincronizacion.IsRepeating = true;

            _temporizadorSincronizacion.Tick += TemporizadorSincronizacion_Tick;

            _temporizadorSincronizacion.Start();
        }

        private void DetenerTemporizadorSincronizacion()
        {
            if (_temporizadorSincronizacion is null)
                return;

            _temporizadorSincronizacion.Stop();

            _temporizadorSincronizacion.Tick -= TemporizadorSincronizacion_Tick;

            _temporizadorSincronizacion = null;
        }

        private async void TemporizadorSincronizacion_Tick(object? sender, EventArgs e)
        {
            await SincronizarAlAparecerAsync(mostrarErrores: false);
        }

        private async Task SincronizarAlAparecerAsync(bool mostrarErrores = true)
        {   
            if (_tareaSincronizacion is not null)
            {
                await _tareaSincronizacion;
                return;
            }

            _tareaSincronizacion = InicializarDatosSupabaseAsync(mostrarErrores);

            try
            {
                await _tareaSincronizacion;
            }
            finally
            {
                _tareaSincronizacion = null;
            }
        }

        private async Task InicializarDatosSupabaseAsync(bool mostrarErrores)
        {
            try
            {
                bool huboCambios = await _sincronizacionService.SincronizarAsync();
                     
                if (_seccionActual is not null)
                {
                    SeccionModel? seccionActualizada = _seccionController.ObtenerTodas().FirstOrDefault(s => s.Id == _seccionActual.Id);

                    if (seccionActualizada is null)
                    {
                        _seccionActual = null;
                    }
                    else
                    {
                        _seccionActual = seccionActualizada;
                    }
                }

          
                if (huboCambios)
                {
                    CargarBotonesSeccion();
                    CargarProductos(_seccionActual);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR DE SINCRONIZACIÓN: " + ex);

           
                if (mostrarErrores)
                {
                    await DisplayAlert("Sincronización", "No se ha podido sincronizar con Supabase.\n\n" + ex.Message, "Aceptar");
                }
            }
        }

       // TEMA        

        private void AplicarTemaInterfaz()
        {
            Color color = _themeService.ColorPrincipal;

            btnAñadirProducto.BackgroundColor = color;

            btnAñadirProducto.TextColor = Colors.White;

            btnFinalizarCompra.BackgroundColor = color;

            btnFinalizarCompra.TextColor = Colors.White;

            btnAñadirSeccion.BackgroundColor = color;

            btnAñadirSeccion.TextColor = Colors.White;
        }

        
        // CARGAR PRODUCTOS        

        private void CargarProductos(SeccionModel? seccion)
        {
            listaProductos.ItemsSource = null;

            if (seccion is null)
            {
                listaProductos.ItemsSource = ObtenerGruposProductos();

                return;
            }

            List<Producto> productos = _controller.ObtenerProductos(seccion.Id);

            listaProductos.ItemsSource = new List<GrupoProductos>
                {
                    new GrupoProductos(
                        seccion,
                        productos)
                };
        }

        
        // CARGAR BOTONES DE SECCIÓN       
        private void CargarBotonesSeccion()
        {
            barraSecciones.Children.Clear();

            Button botonTodo = new Button
                {
                    Text = "Todo",
                    FontSize = 14,
                    Padding = new Thickness(15, 8),
                    CornerRadius = 20,
                    BackgroundColor =
                    _themeService.ColorPrincipal, TextColor = Colors.White
                };

            botonTodo.Clicked += BotonTodo_Clicked;

            barraSecciones.Children.Add(botonTodo);

            List<SeccionModel> secciones = _seccionController.ObtenerTodas();

            foreach (SeccionModel seccion in secciones)
            {
                Button boton = new Button
                    {
                        Text = seccion.Nombre,
                        FontSize = 14,
                        Padding = new Thickness(15, 8),
                        CornerRadius = 20,
                        BackgroundColor = 
                        _themeService.ColorPrincipal, TextColor = Colors.White
                    };

                boton.Clicked += BotonSeccion_Clicked;

                boton.CommandParameter = seccion;

                LongPressBehavior longPress = new LongPressBehavior();

                longPress.LongPressed += async (sender, e) =>
                    {
                        await MostrarMenuSeccion(
                            seccion);
                    };

                boton.Behaviors.Add(longPress);

                barraSecciones.Children.Add(boton);
            }

            ActualizarBotonesSeccion();
        }

        
        // BOTÓN TODO       

        private void BotonTodo_Clicked(object sender, EventArgs e)
        {
            _seccionActual = null;

            CargarProductos(_seccionActual);

            ActualizarBotonesSeccion();
        }

        
        // BOTÓN SECCIÓN       

        private void BotonSeccion_Clicked(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            if (boton.CommandParameter is not SeccionModel seccion)
            {
                return;
            }

            _seccionActual = seccion;

            CargarProductos(_seccionActual);

            ActualizarBotonesSeccion();
        }

        
        // ACTUALIZAR BOTONES       
        private void ActualizarBotonesSeccion()
        {
            foreach (View elemento in barraSecciones.Children)
            {
                if (elemento is not Button boton)
                    continue;

                if (boton.CommandParameter is null)
                {
                    if (_seccionActual is null)
                    {
                        boton.FontAttributes = FontAttributes.Bold;

                        boton.Opacity = 1;
                        boton.Scale = 1.05;
                    }
                    else
                    {
                        boton.FontAttributes = FontAttributes.None;

                        boton.Opacity = 0.65;
                        boton.Scale = 1;
                    }

                    continue;
                }

                if (boton.CommandParameter is SeccionModel seccion)
                {
                    if (_seccionActual?.Id == seccion.Id)
                    {
                        boton.FontAttributes = FontAttributes.Bold;

                        boton.Opacity = 1;
                        boton.Scale = 1.05;
                    }
                    else
                    {
                        boton.FontAttributes = FontAttributes.None;

                        boton.Opacity = 0.65;
                        boton.Scale = 1;
                    }
                }
            }
        }

        
        // OBTENER GRUPOS PARA TODO       

        private List<GrupoProductos> ObtenerGruposProductos()
        {
            List<Producto> productos = _controller.ObtenerTodos();

            List<SeccionModel> secciones = _seccionController.ObtenerTodas();

            List<GrupoProductos> grupos = new();

            foreach (SeccionModel seccion in secciones)
            {
                List<Producto> productosSeccion = productos.Where(producto =>producto.SeccionId == seccion.Id).ToList();

                if (productosSeccion.Count > 0)
                {
                    grupos.Add(new GrupoProductos(seccion, productosSeccion));
                }
            }

            return grupos;
        }

        
        // AÑADIR PRODUCTO       
        private async void OnAbrirAñadirProductoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AddProductPage");
        }

        
        // AÑADIR SECCIÓN        
        private async void OnAñadirSeccionClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AddSectionPage");
        }

        
        // MENÚ SECCIÓN       
        private async Task MostrarMenuSeccion(SeccionModel seccion)
        {
            string opcion = await DisplayActionSheet(seccion.Nombre, "Cancelar", null, "Editar sección", "Eliminar sección");

            if (opcion == "Editar sección")
            {
                var parametros = new Dictionary<string, object>
                    {
                        {
                            "Seccion",
                            seccion
                        }
                    };

                await Shell.Current.GoToAsync("EditSectionPage", parametros);
            }
            else if (opcion == "Eliminar sección")
            {
                await EliminarSeccion(seccion);
            }
        }

        
        // ELIMINAR SECCIÓN        
        private async Task EliminarSeccion(SeccionModel seccion)
        {
            List<Producto> productos = _controller.ObtenerProductos(seccion.Id);

            int cantidadProductos = productos.Count;

            string mensaje;

            if (cantidadProductos == 0)
            {
                mensaje =
                    $"La sección \"{seccion.Nombre}\" " +
                    "no tiene productos.\n\n" +
                    "¿Estás seguro de que deseas eliminarla?";
            }
            else
            {
                mensaje =
                    $"La sección \"{seccion.Nombre}\" " +
                    $"tiene {cantidadProductos} " +
                    $"producto{(cantidadProductos == 1 ? "" : "s")}.\n\n" +
                    "¿Estás seguro de que deseas eliminar " +
                    "la sección y sus productos?";
            }

            bool confirmar = await DisplayAlert(
                    "Eliminar sección",
                    mensaje,
                    "Eliminar",
                    "Cancelar");

            if (!confirmar)
                return;

            //Los productos se marcan como eliminados LOCALMENTE.
        
            foreach (Producto producto in productos)
            {
                _controller.BorrarProducto(producto);
            }

           
             // La sección también se marca como eliminada
             // LOCALMENTE.
            
            _seccionController.EliminarSeccion(seccion);

            _controller.Guardar();
            _seccionController.Guardar();

            if (_seccionActual?.Id == seccion.Id)
            {
                _seccionActual = null;
            }

            CargarBotonesSeccion();
            CargarProductos(_seccionActual);
        }

        
        // BORRAR PRODUCTO
        
        private async void OnBorrarProductoClicked(object sender, EventArgs e)
        {
            try
            {
                Button boton = (Button)sender;

                Producto producto = (Producto)boton.BindingContext;

                
                //Solo se marca como eliminado localmente.
                 
                _controller.BorrarProducto(producto);

                _controller.Guardar();

                CargarProductos(_seccionActual);
            }
            catch (Exception ex)
            {
                await DisplayAlert(
                    "Error",
                    ex.Message,
                    "Aceptar");
            }
        }

        
        // EDITAR PRODUCTO        

        private async void OnEditarProductoClicked(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            Producto producto = (Producto)boton.BindingContext;

            var parametros = new Dictionary<string, object>
                {
                    {
                        "Producto",
                        producto
                    }
                };

            await Shell.Current.GoToAsync("EditProductPage", parametros);
        }

        
        // FINALIZAR COMPRA       

        private async void OnFinalizarCompraClicked(object sender, EventArgs e)
        {
            bool confirmar;

            if (_seccionActual is null)
            {
                confirmar = await DisplayAlert(
                        "Finalizar compra",
                        "¿Estás seguro de que quieres " +
                        "eliminar todos los productos?",
                        "Sí",
                        "No");
            }
            else
            {
                confirmar = await DisplayAlert(
                        "Finalizar compra",
                        $"¿Estás seguro de que quieres " +
                        $"eliminar los productos de la sección " +
                        $"{_seccionActual.Nombre}?",
                        "Sí",
                        "No");
            }

            if (!confirmar)
                return;

            try
            {
                if (_seccionActual is null)
                {
                    /*
                     * Solo local.
                     */
                    _controller.BorrarTodo();
                }
                else
                {
                    /*
                     * Solo local.
                     */
                    _controller.BorrarTodo(_seccionActual.Id);
                }

                _controller.Guardar();

                CargarProductos(_seccionActual);
            }
            catch (Exception ex)
            {
                await DisplayAlert(
                    "Error",
                    $"No se ha podido finalizar " +
                    $"la compra.\n\n{ex.Message}",
                    "Aceptar");
            }
        }

        
        // CONFIGURACIÓN        

        private async void OnAbrirConfiguracionClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ConfiguracionPage");
        }

        
        // REINICIAR SINCRONIZACIÓN        

        public async Task ReiniciarSincronizacionAsync()
        {
            await SincronizarAlAparecerAsync();
        }
    }
}