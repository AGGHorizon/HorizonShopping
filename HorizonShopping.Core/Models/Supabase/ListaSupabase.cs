using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace HorizonShopping.Core.Models.Supabase
{
    [Table("listas")]
    public class ListaSupabase : BaseModel
    {
        [PrimaryKey("id", true)]
        public Guid Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}