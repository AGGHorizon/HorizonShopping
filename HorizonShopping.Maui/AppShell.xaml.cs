namespace HorizonShopping.Maui
{
    public partial class AppShell : Shell
    {
        private readonly MainPage _mainPage;

        // CONSTRUCTOR Y RUTAS
        public AppShell(MainPage mainPage)
        {
            InitializeComponent();

            _mainPage = mainPage;

            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));

            Routing.RegisterRoute(nameof(EditProductPage), typeof(EditProductPage));

            Routing.RegisterRoute(nameof(AddSectionPage), typeof(AddSectionPage));

            Routing.RegisterRoute(nameof(EditSectionPage), typeof(EditSectionPage));

            Routing.RegisterRoute(nameof(ConfiguracionPage), typeof(ConfiguracionPage));

            Routing.RegisterRoute(nameof(AparienciaPage), typeof(AparienciaPage));

            Routing.RegisterRoute(nameof(AcercaDePage), typeof(AcercaDePage));

            Routing.RegisterRoute(nameof(SincronizacionPage), typeof(SincronizacionPage));

            Items.Add(new ShellContent
            {
                Content = mainPage,
                Route = nameof(MainPage)
            });
        }
    }
}