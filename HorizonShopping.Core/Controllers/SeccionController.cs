using HorizonShopping.Core.Models;
using HorizonShopping.Core.Repositories;

namespace HorizonShopping.Core.Controllers
{
    public class SeccionController
    {
        private readonly SeccionRepository _repo;

        public SeccionController(SeccionRepository repository)
        {
            _repo = repository;
        }

        public SeccionModel CrearSeccion(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (_repo.ExisteSeccion(nombre))
                throw new ArgumentException($"La sección {nombre} ya existe.");

            SeccionModel seccion = new SeccionModel(nombre.Trim());

            _repo.AnyadirSeccion(seccion);

            return seccion;
        }

        public void ImportarSeccion(SeccionModel seccion)
        {
            if (seccion is null)
                throw new ArgumentNullException(nameof(seccion));

            SeccionModel? existente = _repo.ObtenerTodasCompletas().FirstOrDefault(s => s.Id == seccion.Id);

            if (existente is null)
            {
                _repo.AnyadirSeccion(seccion);
                return;
            }

            existente.Nombre = seccion.Nombre;
            existente.EsPredeterminada = seccion.EsPredeterminada;
            existente.UpdatedAt = seccion.UpdatedAt;
            existente.DeletedAt = seccion.DeletedAt;
        }

        public void InicializarSeccionesPredeterminadas()
        {
            if (!_repo.ExisteSeccion("Supermercado"))
                _repo.AnyadirSeccion(new SeccionModel("Supermercado", true));

            if (!_repo.ExisteSeccion("Mercado"))
                _repo.AnyadirSeccion(new SeccionModel("Mercado", true));

            if (!_repo.ExisteSeccion("Farmacia"))
                _repo.AnyadirSeccion(new SeccionModel("Farmacia", true));

            if (!_repo.ExisteSeccion("Droguería"))
                _repo.AnyadirSeccion(new SeccionModel("Droguería", true));
        }

        public void EliminarSeccion(SeccionModel seccion)
        {
            if (seccion is null)
                throw new ArgumentNullException(nameof(seccion));

            _repo.EliminarSeccion(seccion);
        }

        public void BorrarTodas() => _repo.EliminarTodas();

        public void ModificarSeccion(SeccionModel seccion, string nuevoNombre)
        {
            if (seccion is null)
                throw new ArgumentNullException(nameof(seccion));

            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            nuevoNombre = nuevoNombre.Trim();

            if (_repo.ExisteSeccion(nuevoNombre) && !seccion.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"La sección {nuevoNombre} ya existe.");
            }

            _repo.ModificarSeccion(seccion, nuevoNombre);
        }

        public List<SeccionModel> ObtenerTodas() => _repo.ObtenerTodas();

        public List<SeccionModel> ObtenerTodasCompletas() => _repo.ObtenerTodasCompletas();

        public SeccionModel? BuscarSeccion(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            return _repo.BuscarSeccion(nombre);
        }

        public void Guardar() => _repo.Guardar();

        public void Cargar() => _repo.Cargar();
    }
}