namespace HorizonShopping.Core.Models
{
    public class Producto
    {
        private string _nombre = string.Empty;
        private int? _cantidad;

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid SeccionId { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("El nombre no puede estar vacío.");

                _nombre = value;
            }
        }

        public int? Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value.HasValue && value <= 0)
                    throw new Exception("La cantidad debe de ser mayor que 0.");

                _cantidad = value;
            }
        }

        public Producto()
        {
        }

        public Producto(string nombre, int? cantidad, Guid seccionId)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            SeccionId = seccionId;
            UpdatedAt = DateTime.UtcNow;
        }

        public override string ToString() => $"{Nombre}    -     Cantidad: {Cantidad}";
    }
}