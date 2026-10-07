namespace HorizonShopping.Core.Models
{
    public class ListaCompra
    {
        private List<Producto> _listaCompra;

        public ListaCompra()
        {
            _listaCompra = new List<Producto>();
        }

        //PRODUCTOS
        public void AnyadirProducto(Producto producto)
        {
            _listaCompra.Add(producto);
        }

        public Producto? BuscarProducto(Guid id)
        {
            return _listaCompra.FirstOrDefault(producto => producto.Id == id && producto.DeletedAt is null);
        }

        public List<Producto> ObtenerPorSeccion(Guid seccionId)
        {
            return _listaCompra.Where(producto => producto.SeccionId == seccionId && producto.DeletedAt is null).ToList();
        }

        public Producto? BuscarProducto(string nombre)
        {
            return _listaCompra.FirstOrDefault(producto => producto.DeletedAt is null && producto.Nombre.Equals(nombre,StringComparison.OrdinalIgnoreCase));
        }



        //ELIMINACIÓN
        public void BorrarProducto(Producto producto)
        {
            Producto? productoReal = _listaCompra.FirstOrDefault(p => p.Id == producto.Id);

            if (productoReal is null)
                return;

            productoReal.DeletedAt = DateTime.UtcNow;
            productoReal.UpdatedAt = DateTime.UtcNow;
        }

        
        public void BorrarTodo()
        {
            DateTime ahora = DateTime.UtcNow;

            foreach (Producto producto in _listaCompra)
            {
                if (producto.DeletedAt is null)
                {
                    producto.DeletedAt = ahora;
                    producto.UpdatedAt = ahora;
                }
            }
        }

        public void BorrarTodo(Guid seccionId)
        {
            DateTime ahora = DateTime.UtcNow;

            foreach (Producto producto in _listaCompra)
            {
                if (producto.SeccionId == seccionId && producto.DeletedAt is null)
                {
                    producto.DeletedAt = ahora;
                    producto.UpdatedAt = ahora;
                }
            }
        }

        //CONSULTAS
        public List<Producto> ObtenerLista()
        {
            return _listaCompra.Where(producto => producto.DeletedAt is null).ToList();
        }

        public List<Producto> ObtenerListaCompleta()
        {
            return _listaCompra;
        }


        //GESTIÓN DE LA LISTA
        public void EstablecerLista(List<Producto> nuevaLista)
        {
            _listaCompra = nuevaLista;
        }

        public void Vaciar()
        {
            _listaCompra.Clear();
        }
    }
}