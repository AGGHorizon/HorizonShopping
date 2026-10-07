namespace HorizonShopping.Core.Models
{
    public class ListaSecciones
    {
        private List<SeccionModel> _listaSecciones;

        public ListaSecciones()
        {
            _listaSecciones = new List<SeccionModel>();
        }


        //SECCIONES

        public void AnyadirSeccion(SeccionModel seccion)
        {
            _listaSecciones.Add(seccion);
        }

        public SeccionModel? BuscarSeccion(string nombre)
        {
            return _listaSecciones.FirstOrDefault(seccion => seccion.DeletedAt is null && seccion.Nombre.Equals(nombre,StringComparison.OrdinalIgnoreCase));
        }

        public bool Existe(string nombre)
        {
            return _listaSecciones.Any(seccion => seccion.DeletedAt is null && seccion.Nombre.Equals(nombre,StringComparison.OrdinalIgnoreCase));
        }

        public void ModificarSeccion(SeccionModel seccion,string nuevoNombre)
        {
            seccion.Nombre = nuevoNombre;
            seccion.UpdatedAt = DateTime.UtcNow;
        }

        //ELIMINACIÓN
        public void EliminarSeccion(SeccionModel seccion)
        {
            SeccionModel? seccionReal = _listaSecciones.FirstOrDefault(s => s.Id == seccion.Id);

            if (seccionReal is null)
                return;

            seccionReal.DeletedAt = DateTime.UtcNow;
            seccionReal.UpdatedAt = DateTime.UtcNow;
        }

        public void EliminarTodas()
        {
            DateTime ahora = DateTime.UtcNow;

            foreach (SeccionModel seccion in _listaSecciones)
            {
                if (seccion.DeletedAt is null)
                {
                    seccion.DeletedAt = ahora;
                    seccion.UpdatedAt = ahora;
                }
            }
        }

        //CONSULTAS

        public List<SeccionModel> ObtenerTodas()
        {
            return _listaSecciones.Where(seccion => seccion.DeletedAt is null).ToList();
        }

        public List<SeccionModel> ObtenerTodasCompletas()
        {
            return _listaSecciones;
        }

        //GESTIÓN DE LA LISTA
        public void Vaciar()
        {
            _listaSecciones.Clear();
        }
    }
}