using HorizonShopping.Core.Enums;

namespace HorizonShopping.Core.Models
{
    public class Configuracion
    {
        public bool Tema { get; set; } = true;
        public bool ConfirmacionFinalizar { get; set; } = true;
        public Seccion InicioPantalla { get; set; }       

    }
}
