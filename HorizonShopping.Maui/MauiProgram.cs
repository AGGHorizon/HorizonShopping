using Microsoft.Extensions.Logging;
using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Models;
using HorizonShopping.Core.Repositories;
using HorizonShopping.Core.Services;
using HorizonShopping.Maui.Services;
using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;

namespace HorizonShopping.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("DynaPuff-SemiBold.ttf", "DynaPuffSemiBold");
                });

            // Supabase
            builder.Services.AddSingleton<SupabaseService>();
            builder.Services.AddSingleton<IGotrueSessionPersistence<Session>, SupabaseSessionHandler>();
            builder.Services.AddSingleton<SeccionSupabaseRepository>();
            builder.Services.AddSingleton<ProductoSupabaseRepository>();
            builder.Services.AddSingleton<SincronizacionService>();

            // Aplicación
            builder.Services.AddSingleton<ListaCompra>();
            builder.Services.AddSingleton<ShoppingRepository>(serviceProvider =>
            {
                ListaCompra listaCompra = serviceProvider.GetRequiredService<ListaCompra>();

                string rutaLista = Path.Combine(FileSystem.AppDataDirectory, "lista.json");

                ShoppingRepository repository = new ShoppingRepository(listaCompra, rutaLista);

                repository.Cargar();

                return repository;
            });

            builder.Services.AddSingleton<ShoppingController>();

            // Secciones
            builder.Services.AddSingleton<ListaSecciones>();
            builder.Services.AddSingleton<SeccionRepository>(serviceProvider =>
            {
                ListaSecciones listaSecciones = serviceProvider.GetRequiredService<ListaSecciones>();

                string rutaSecciones = Path.Combine(FileSystem.AppDataDirectory, "secciones.json");

                SeccionRepository repository = new SeccionRepository(rutaSecciones, listaSecciones);

                repository.Cargar();

                return repository;
            });

            builder.Services.AddSingleton<SeccionController>(serviceProvider =>
            {
                SeccionRepository repository = serviceProvider.GetRequiredService<SeccionRepository>();

                SeccionController controller = new SeccionController(repository);               

                return controller;
            });

            // Configuración
            builder.Services.AddSingleton<Configuracion>();
            builder.Services.AddSingleton<ConfigurationRepository>(serviceProvider =>
            {
                Configuracion configuracion = serviceProvider.GetRequiredService<Configuracion>();

                string rutaConfiguracion = Path.Combine(FileSystem.AppDataDirectory, "configuracion.json");

                ConfigurationRepository repository = new ConfigurationRepository(configuracion, rutaConfiguracion);

                repository.Cargar();

                return repository;
            });

            builder.Services.AddSingleton<ConfigurationController>();
            builder.Services.AddSingleton<ThemeService>();

            // Páginas

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AppShell>();

            builder.Services.AddTransient<AddProductPage>();
            builder.Services.AddTransient<EditProductPage>();
            builder.Services.AddTransient<AddSectionPage>();
            builder.Services.AddTransient<EditSectionPage>();
            builder.Services.AddTransient<ConfiguracionPage>();
            builder.Services.AddTransient<AparienciaPage>();
            builder.Services.AddTransient<SincronizacionPage>();




#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}