using HorizonShopping.Core.Models;
using System.Text.Json;

namespace HorizonShopping.Core.Repositories
{
    public class ConfigurationRepository
    {
        private readonly Configuracion _config;
        private readonly string _rutaArchivo;

        public ConfigurationRepository(Configuracion configuracion, string rutaArchivo)
        {
            _config = configuracion;
            _rutaArchivo = rutaArchivo;
        }

        //JSON
        public void Guardar()
        {
            string json = JsonSerializer.Serialize(_config);

            File.WriteAllText(_rutaArchivo, json);
        }

        public void Cargar()
        {
            if (!File.Exists(_rutaArchivo))
                return;

            string json = File.ReadAllText(_rutaArchivo);

            Configuracion? configLeida = JsonSerializer.Deserialize<Configuracion?>(json) ?? new Configuracion();

            _config.Tema = configLeida.Tema;
            _config.ConfirmacionFinalizar = configLeida.ConfirmacionFinalizar;
            _config.InicioPantalla = configLeida.InicioPantalla;
        }

        public Configuracion ObtenerConfiguracion() => _config;
        
    }
}
