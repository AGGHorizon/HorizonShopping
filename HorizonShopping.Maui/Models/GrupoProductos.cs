using HorizonShopping.Core.Models;

namespace HorizonShopping.Maui.Models
{
    public class GrupoProductos : List<Producto>
    {
        public SeccionModel Seccion { get; }

        public GrupoProductos(SeccionModel seccion, IEnumerable<Producto> productos): base(productos)
        {
            Seccion = seccion;
        }
    }
}


