using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Models;
using HorizonShopping.Core.Repositories;

namespace HorizonShopping.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Ruta Archivos
            string rutaLista = Path.Combine(AppContext.BaseDirectory, "lista.json");
            string rutaConfiguracion = Path.Combine(AppContext.BaseDirectory, "configuracion.json");

            //Lista
            ListaCompra listaCompra = new ListaCompra();

            //Configuración
            Configuracion configuracion = new Configuracion();
            ConfigurationRepository configuracionRepository = new ConfigurationRepository(configuracion, rutaConfiguracion);
            ConfigurationController configuracionController = new ConfigurationController(configuracionRepository);

            //Controlador            
            ShoppingRepository repository = new ShoppingRepository(listaCompra, rutaLista);
            ShoppingController controller = new ShoppingController(repository);

            //Cargas
            controller.Cargar();
            configuracionController.CargarConfiguracion();

            Application.Run(new FormMenuPrincipal(controller, configuracionController));
        }
    }
}