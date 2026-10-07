using HorizonShopping.Core.Models;
using HorizonShopping.Core.Repositories;

namespace HorizonShopping.Core.Controllers
{
    public class ShoppingController
    {
        private readonly ShoppingRepository _repo;

        public ShoppingController(ShoppingRepository repository)
        {
            _repo = repository;
        }

        public Producto CrearProducto(string nombre, int? cantidad, Guid seccionId)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Este campo no puede estar vacío. Por favor introduzca el nombre del producto.");

            if (cantidad != null && cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que 0.");

            Producto nuevoProducto = new Producto(nombre.Trim(), cantidad, seccionId);

            _repo.GuardarProducto(nuevoProducto);

            return nuevoProducto;
        }

        public Producto? BuscarProducto(string nombreProducto)
        {
            if (string.IsNullOrWhiteSpace(nombreProducto))
                throw new ArgumentException("Este campo no puede estar vacío. Por favor introduzca el nombre del producto.");

            return _repo.BuscarProducto(nombreProducto);
        }

        public Producto? BuscarProducto(Guid id)
        {
            return _repo.BuscarProducto(id);
        }

        public void ImportarProducto(Producto producto)
        {
            if (producto is null)
                throw new ArgumentNullException(nameof(producto));

            _repo.ReemplazarProducto(
                producto);
        }

        public void BorrarProducto(Producto producto)
        {
            if (producto is null)
                throw new ArgumentNullException(nameof(producto));

            _repo.EliminarProducto(producto);
        }

        public void BorrarTodo(Guid seccionId) => _repo.EliminarTodo(
                seccionId);

        public void BorrarTodo() => _repo.EliminarTodo();

        public List<Producto> ObtenerProductos(Guid seccionId) => _repo.ObtenerPorSeccion(seccionId);

        public List<Producto> ObtenerTodos() => _repo.ObtenerTodos();

        public List<Producto> ObtenerTodosCompletos() => _repo.ObtenerTodosCompletos();

        public Producto? ModificarProducto(Producto producto, string? newNombre, int? newCantidad, Guid? newSeccion)
        {
            if (producto is null)
                throw new ArgumentNullException(nameof(producto));

            bool modificado = false;

            if (newNombre != null)
            {
                if (string.IsNullOrWhiteSpace(newNombre))
                {
                    throw new ArgumentException("Este campo no puede estar vacío. Por favor introduzca el nombre del producto.");
                }

                producto.Nombre = newNombre.Trim();

                modificado = true;
            }

            if (newCantidad != null)
            {
                if (newCantidad <= 0)
                {
                    throw new ArgumentException("La cantidad debe ser mayor que 0.");
                }

                producto.Cantidad = newCantidad.Value;

                modificado = true;
            }

            if (newSeccion != null)
            {
                producto.SeccionId = newSeccion.Value;

                modificado = true;
            }

            if (modificado)
            {
                producto.UpdatedAt = DateTime.UtcNow;

                /*
                 * Si un producto que estaba marcado como
                 * eliminado vuelve a modificarse, deja de
                 * estar eliminado.
                 */
                producto.DeletedAt = null;
            }

            return producto;
        }

        public void Guardar() => _repo.Guardar();

        public void Cargar() => _repo.Cargar();
    }
}