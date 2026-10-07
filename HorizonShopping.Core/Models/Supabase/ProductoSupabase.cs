using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace HorizonShopping.Core.Models.Supabase
{
    [Table("productos")]
    public class ProductoSupabase : BaseModel
    {
        [PrimaryKey("id", true)]
        public Guid Id { get; set; }

        [Column("seccion_id")]
        public Guid SeccionId { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("cantidad")]
        public int? Cantidad { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}