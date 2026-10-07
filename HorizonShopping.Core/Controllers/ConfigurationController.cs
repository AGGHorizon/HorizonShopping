using HorizonShopping.Core.Models;
using HorizonShopping.Core.Repositories;

namespace HorizonShopping.Core.Controllers
{
    public class ConfigurationController
    {
        private readonly ConfigurationRepository _repoConfig;        

        public ConfigurationController(ConfigurationRepository configuracionRepositorio)
        {
            _repoConfig = configuracionRepositorio;
        }

        public void GuardarConfiguracion() => _repoConfig.Guardar();

        public void CargarConfiguracion() => _repoConfig.Cargar();

        public Configuracion ObtenerConfiguracion() => _repoConfig.ObtenerConfiguracion();

    }
}
