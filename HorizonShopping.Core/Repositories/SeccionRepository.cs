using System.Text.Json;
using HorizonShopping.Core.Models;

namespace HorizonShopping.Core.Repositories
{
    public class SeccionRepository
    {
        private readonly ListaSecciones _listaSecciones;
        private readonly string _rutaArchivo;

        public SeccionRepository(string rutaArchivo, ListaSecciones listaSecciones)
        {
            _rutaArchivo = rutaArchivo;
            _listaSecciones = listaSecciones;
        }

        //GESTIÓN SECCIONES
        public void AnyadirSeccion(SeccionModel seccion) => _listaSecciones.AnyadirSeccion(seccion);

        public void EliminarSeccion(SeccionModel seccion) => _listaSecciones.EliminarSeccion(seccion);

        public void EliminarTodas() => _listaSecciones.EliminarTodas();

        public List<SeccionModel> ObtenerTodas() => _listaSecciones.ObtenerTodas();

        public List<SeccionModel> ObtenerTodasCompletas() => _listaSecciones.ObtenerTodasCompletas();

        public SeccionModel? BuscarSeccion(string nombre) => _listaSecciones.BuscarSeccion(nombre);

        public bool ExisteSeccion(string nombre) => _listaSecciones.Existe(nombre);

        public void ModificarSeccion(SeccionModel seccion, string nuevoNombre) => _listaSecciones.ModificarSeccion(seccion, nuevoNombre);


        //PERSISTENCIA LOCAL
        public void Guardar()
        {
            string json = JsonSerializer.Serialize(_listaSecciones.ObtenerTodasCompletas(), new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

            File.WriteAllText(_rutaArchivo, json);
        }

        public void Cargar()
        {
            if (!File.Exists(_rutaArchivo)) 
                return;

            string json = File.ReadAllText(_rutaArchivo);

            if (string.IsNullOrWhiteSpace(json))
                return;

            List<SeccionModel>? secciones = JsonSerializer.Deserialize<List<SeccionModel>>(json);

            if (secciones is null) 
                return;

            _listaSecciones.Vaciar();

            foreach (SeccionModel seccion in secciones)
                _listaSecciones.AnyadirSeccion(seccion);
        }
    }
}