using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace HorizonShopping.Core.Models.Supabase
{
    [Table("secciones")]
    public class SeccionSupabase : BaseModel
    {
        [PrimaryKey("id", true)]
        public Guid Id { get; set; }

        [Column("lista_id")]
        public Guid ListaId { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("predeterminada")]
        public bool Predeterminada { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}