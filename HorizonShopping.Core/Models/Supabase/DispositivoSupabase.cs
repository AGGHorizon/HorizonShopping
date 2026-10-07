using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace HorizonShopping.Core.Models.Supabase
{
    [Table("dispositivos")]
    public class DispositivoSupabase : BaseModel
    {
        [PrimaryKey("id", true)]
        public Guid Id { get; set; }

        [Column("lista_id")]
        public Guid? ListaId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("ultimo_acceso")]
        public DateTime UltimoAcceso { get; set; }
    }
}