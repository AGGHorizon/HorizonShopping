using HorizonShopping.Core.Models;
using System.Text.Json;

namespace HorizonShopping.Core.Repositories
{
    public class ShoppingRepository
    {
        private readonly ListaCompra _listaCompra;
        private readonly string _rutaArchivo;

        public ShoppingRepository(ListaCompra listaCompra, string rutaArchivo)
        {
            _listaCompra = listaCompra;
            _rutaArchivo = rutaArchivo;
        }


        //GESTIÓN DE PRODUCTOS
        public void GuardarProducto(Producto producto)
        {
            Producto? existente = _listaCompra.ObtenerListaCompleta().FirstOrDefault(p => p.Id == producto.Id);

            if (existente is null)
            {
                _listaCompra.AnyadirProducto(producto);
            }
        }

        public void ReemplazarProducto(Producto producto)
        {
            List<Producto> productos = _listaCompra.ObtenerListaCompleta();

            int indice = productos.FindIndex(p => p.Id == producto.Id);

            if (indice >= 0)
            {
                productos[indice] = producto;
            }
            else
            {
                productos.Add(producto);
            }
        }

        public Producto? BuscarProducto(string nombreProducto) => _listaCompra.BuscarProducto(nombreProducto);

        public Producto? BuscarProducto(Guid id) => _listaCompra.BuscarProducto(id);

        public void EliminarProducto(Producto producto) => _listaCompra.BorrarProducto(producto);

        public void EliminarTodo() => _listaCompra.BorrarTodo();

        public void EliminarTodo(Guid seccionId) => _listaCompra.BorrarTodo(seccionId);

        public List<Producto> ObtenerPorSeccion(Guid seccionId) => _listaCompra.ObtenerPorSeccion(seccionId);

        public List<Producto> ObtenerTodos() => _listaCompra.ObtenerLista();

        public List<Producto> ObtenerTodosCompletos() => _listaCompra.ObtenerListaCompleta();


        //PERSISTENCIA LOCAL
        public void Guardar()
        {
            string json = JsonSerializer.Serialize(_listaCompra.ObtenerListaCompleta());

            File.WriteAllText(_rutaArchivo, json);
        }

        public void Cargar()
        {
            if (!File.Exists(_rutaArchivo))
                return;

            string json = File.ReadAllText(_rutaArchivo);

            List<Producto> productos = JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();

            _listaCompra.EstablecerLista(productos);
        }
    }
}