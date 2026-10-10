using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Models;
using HorizonShopping.Core.Models.Supabase;
using HorizonShopping.Core.Repositories;

namespace HorizonShopping.Core.Services
{
    public class SincronizacionService
    {
        private readonly ShoppingController _controller;
        private readonly SeccionController _seccionController;
        private readonly SeccionSupabaseRepository _seccionRepository;
        private readonly ProductoSupabaseRepository _productoRepository;
        private readonly SupabaseService _supabaseService;

        public SincronizacionService(ShoppingController controller, SeccionController seccionController, SupabaseService supabaseService,
            SeccionSupabaseRepository seccionRepository, ProductoSupabaseRepository productoRepository)
        {
            _controller = controller;
            _seccionController = seccionController;
            _supabaseService = supabaseService;
            _seccionRepository = seccionRepository;
            _productoRepository = productoRepository;
        }


        // SINCRONIZACIÓN
        public async Task<bool> SincronizarAsync()
        {
            await _supabaseService.InicializarAsync();

            ListaSupabase? lista = await _supabaseService.ObtenerListaDispositivoAsync();

            if (lista is null)
                return false;

            bool huboCambios = false;

            List<SeccionModel> seccionesLocales = _seccionController.ObtenerTodasCompletas().ToList();

            List<Producto> productosLocales = _controller.ObtenerTodosCompletos().ToList();

            List<SeccionSupabase> seccionesRemotas = await _seccionRepository.ObtenerSeccionesAsync(lista.Id);
         

            if (EliminarSeccionesLocalesDuplicadas(seccionesLocales, productosLocales, seccionesRemotas))
            {
                huboCambios = true;

                seccionesLocales = _seccionController.ObtenerTodasCompletas().Where(s => s.DeletedAt is null).ToList();
            }

            
            // SECCIONES LOCALES -> SUPABASE            

            foreach (SeccionModel local in seccionesLocales)
            {
                SeccionSupabase? remoto = seccionesRemotas.FirstOrDefault(s => s.Id == local.Id);

                if (remoto is null)
                {
                    remoto = seccionesRemotas.FirstOrDefault(s => s.DeletedAt is null && s.Nombre.Equals(local.Nombre, StringComparison.OrdinalIgnoreCase));
                }

                if (remoto is null)
                {
                    if (local.DeletedAt.HasValue)
                        continue;

                    await _seccionRepository.GuardarSeccionAsync(lista.Id, local);

                    continue;
                }

                // Si la sección existe remotamente pero tiene otro ID,
                // usamos el ID remoto para mantener una única identidad.
                // MANTENER LA IDENTIDAD REMOTA DE LA SECCIÓN
                if (local.Id != remoto.Id)
                {
                    Guid idAntiguo = local.Id;

                    local.Id = remoto.Id;

                    foreach (Producto producto in productosLocales)
                    {
                        if (producto.SeccionId == idAntiguo)
                        {
                            producto.SeccionId = remoto.Id;
                            producto.UpdatedAt = DateTime.UtcNow;
                        }
                    }

                    huboCambios = true;
                }

                if (local.UpdatedAt.ToUniversalTime() > remoto.UpdatedAt.ToUniversalTime())
                {
                    await _seccionRepository.GuardarSeccionAsync(lista.Id, local);

                    if (local.DeletedAt.HasValue)
                    {
                        await _supabaseService.ConfirmarEliminacionAsync(lista.Id, "seccion", local.Id);
                    }

                    continue;
                }

                if (remoto.UpdatedAt.ToUniversalTime() > local.UpdatedAt.ToUniversalTime())
                {
                    SeccionModel importada = _seccionRepository.ConvertirASeccion(remoto);

                    _seccionController.ImportarSeccion(importada);

                    huboCambios = true;

                    if (remoto.DeletedAt.HasValue)
                    {
                        await _supabaseService.ConfirmarEliminacionAsync(lista.Id, "seccion", remoto.Id);
                    }
                }
                else if (remoto.DeletedAt.HasValue)
                {
                    await _supabaseService.ConfirmarEliminacionAsync(lista.Id, "seccion", remoto.Id);
                }
            }

           
            // PRODUCTOS LOCALES -> SUPABASE         

            seccionesRemotas = await _seccionRepository.ObtenerSeccionesAsync(lista.Id);

            List<ProductoSupabase> productosRemotos = await ObtenerTodosLosProductosRemotos(seccionesRemotas);

            foreach (Producto local in productosLocales)
            {
                ProductoSupabase? remoto = productosRemotos.FirstOrDefault(p => p.Id == local.Id);

                if (remoto is null)
                {
                    if (local.DeletedAt.HasValue)
                        continue;

                    await _productoRepository.GuardarProductoAsync(local);

                    continue;
                }
               

                if (local.UpdatedAt.ToUniversalTime() > remoto.UpdatedAt.ToUniversalTime())
                {
                    await _productoRepository.GuardarProductoAsync(local);

                    if (local.DeletedAt.HasValue)
                    {
                        await _supabaseService.ConfirmarEliminacionAsync(lista.Id, "producto", local.Id);
                    }

                    continue;
                }
                
                if (remoto.UpdatedAt.ToUniversalTime() > local.UpdatedAt.ToUniversalTime())
                {
                    Producto importado = _productoRepository.ConvertirAProducto(remoto);

                    _controller.ImportarProducto(importado);

                    huboCambios = true;                


                    if (remoto.DeletedAt.HasValue)
                    {
                        await _supabaseService.ConfirmarEliminacionAsync(
                            lista.Id,"producto",remoto.Id);
                    }
                }
                else if (remoto.DeletedAt.HasValue)
                {
                    await _supabaseService.ConfirmarEliminacionAsync(
                        lista.Id,"producto",remoto.Id);
                }
            }

          
            // RECARGAMOS EL ESTADO
           

            seccionesRemotas = await _seccionRepository.ObtenerSeccionesAsync(lista.Id);

            productosRemotos = await ObtenerTodosLosProductosRemotos(seccionesRemotas);

            seccionesLocales = _seccionController.ObtenerTodasCompletas().ToList();

            productosLocales = _controller.ObtenerTodosCompletos().ToList();

          
            // SECCIONES REMOTAS -> LOCAL
           

            foreach (SeccionSupabase remoto in seccionesRemotas)
            {
                if (remoto.DeletedAt.HasValue)
                    continue;

                SeccionModel? local = seccionesLocales.FirstOrDefault(s => s.Id == remoto.Id && s.DeletedAt is null);

                if (local is null)
                {
                    local = seccionesLocales.FirstOrDefault(s => s.DeletedAt is null && s.Nombre.Equals(remoto.Nombre, StringComparison.OrdinalIgnoreCase));
                }

                if (local is null)
                {
                    SeccionModel importada = _seccionRepository.ConvertirASeccion(remoto);

                    _seccionController.ImportarSeccion(importada);

                    huboCambios = true;
                }
            }

          
            // PRODUCTOS REMOTOS -> LOCAL
          

            foreach (ProductoSupabase remoto in productosRemotos)
            {
                if (remoto.DeletedAt.HasValue)
                    continue;

                Producto? local = productosLocales.FirstOrDefault(p => p.Id == remoto.Id);

                if (local is null)
                {
                    Producto importado = _productoRepository.ConvertirAProducto(remoto);

                    _controller.ImportarProducto(importado);

                    huboCambios = true;
                }
            }

          
            // GUARDAR CAMBIOS LOCALES
            

            _seccionController.Guardar();
            _controller.Guardar();

            await _supabaseService.RegistrarUltimoAccesoAsync();

            return huboCambios;
        }

        //OBTENER PRODUCTOS REMOTOS
        private async Task<List<ProductoSupabase>> ObtenerTodosLosProductosRemotos(List<SeccionSupabase> secciones)
        {
            List<ProductoSupabase> productos = new();

            foreach (SeccionSupabase seccion in secciones)
            {
                if (seccion.DeletedAt.HasValue)
                    continue;

                List<ProductoSupabase> productosSeccion = await _productoRepository.ObtenerProductosAsync(seccion.Id);

                productos.AddRange(productosSeccion);
            }

            return productos;
        }

        //ELIMINAR SECCIONES LOCALES DUPLICADAS
        private bool EliminarSeccionesLocalesDuplicadas(List<SeccionModel> seccionesLocales, List<Producto> productosLocales, List<SeccionSupabase> seccionesRemotas)
        {
            bool huboCambios = false;

            var grupos = seccionesLocales.Where(s => s.DeletedAt is null).GroupBy(s => s.Nombre.Trim(), StringComparer.OrdinalIgnoreCase);

            foreach (var grupo in grupos)
            {
                if (grupo.Count() <= 1)
                    continue;

                SeccionSupabase? remota = seccionesRemotas.FirstOrDefault(s => s.DeletedAt is null && s.Nombre.Equals(grupo.Key, StringComparison.OrdinalIgnoreCase));

                SeccionModel conservar;

                if (remota is not null)
                {
                    conservar = grupo.FirstOrDefault(s => s.Id == remota.Id) ?? grupo.First();
                }
                else
                {
                    conservar = grupo.First();
                }

                foreach (SeccionModel duplicada in grupo)
                {
                    if (duplicada.Id == conservar.Id)
                        continue;

                    foreach (Producto producto in productosLocales)
                    {
                        if (producto.SeccionId == duplicada.Id)
                        {
                            producto.SeccionId = conservar.Id;
                            producto.UpdatedAt = DateTime.UtcNow;
                        }
                    }

                    _seccionController.EliminarSeccion(duplicada);

                    huboCambios = true;
                }
            }

            return huboCambios;
        }
    }
}