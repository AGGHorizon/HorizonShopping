namespace HorizonShopping.Core.Models
{
    public class SeccionModel
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public bool EsPredeterminada { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }

        public SeccionModel(string nombre, bool esPredeterminada = false)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            EsPredeterminada = esPredeterminada;
            UpdatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}