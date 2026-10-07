using HorizonShopping.Core.Models;
using HorizonShopping.Core.Models.Supabase;
using HorizonShopping.Core.Services;

namespace HorizonShopping.Core.Repositories
{
    public class ProductoSupabaseRepository
    {
        private readonly SupabaseService _supabaseService;

        public ProductoSupabaseRepository(SupabaseService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        //CONSULTAS

        public async Task<List<ProductoSupabase>>ObtenerProductosAsync(Guid seccionId)
        {
            var resultado = await _supabaseService.Cliente.From<ProductoSupabase>().Where(x => x.SeccionId == seccionId).Get();

            return resultado.Models;
        }

        public async Task<ProductoSupabase?>ObtenerProductoAsync(Guid productoId)
        {
            var resultado = await _supabaseService.Cliente.From<ProductoSupabase>().Where(x => x.Id == productoId).Get();

            return resultado.Models.FirstOrDefault();
        }

        //GUARDADO
        public async Task GuardarProductoAsync(Producto producto)
        {
            ProductoSupabase productoSupabase = new ProductoSupabase
                {
                    Id = producto.Id,
                    SeccionId = producto.SeccionId,
                    Nombre = producto.Nombre,
                    Cantidad = producto.Cantidad,
                    UpdatedAt = producto.UpdatedAt,
                    DeletedAt = producto.DeletedAt
                };

            await _supabaseService.Cliente.From<ProductoSupabase>().Upsert(productoSupabase);
        }

        public async Task<ProductoSupabase>CrearProductoAsync(Producto producto)
        {
            await GuardarProductoAsync(producto);

            return new ProductoSupabase
            {
                Id = producto.Id,
                SeccionId = producto.SeccionId,
                Nombre = producto.Nombre,
                Cantidad = producto.Cantidad,
                UpdatedAt = producto.UpdatedAt,
                DeletedAt = producto.DeletedAt
            };
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            await GuardarProductoAsync(producto);
        }


        //ELIMINACIÓN
        public async Task EliminarProductoAsync(Guid productoId)
        {
            ProductoSupabase? producto = await ObtenerProductoAsync(productoId);

            if (producto is null)
                return;

            producto.DeletedAt = DateTime.UtcNow;
            producto.UpdatedAt = DateTime.UtcNow;

            await _supabaseService.Cliente.From<ProductoSupabase>().Where(x => x.Id == productoId).Update(producto);
        }

        
        // CONVERSIÓN SUPABASE -> LOCAL
      

        public Producto ConvertirAProducto(ProductoSupabase productoSupabase)
        {
            if (productoSupabase is null)
                throw new ArgumentNullException(nameof(productoSupabase));

            return new Producto
            {
                Id = productoSupabase.Id,
                SeccionId = productoSupabase.SeccionId,
                Nombre = productoSupabase.Nombre,
                Cantidad = productoSupabase.Cantidad,
                UpdatedAt = productoSupabase.UpdatedAt,
                DeletedAt = productoSupabase.DeletedAt
            };
        }
    }
}