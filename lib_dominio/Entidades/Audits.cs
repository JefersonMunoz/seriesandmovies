using lib_dominio.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Audits
    {
        public int Id { get; set; }
        public int? User { get; set; }
        [ForeignKey("User")] public Users? _User { get; set; }
        public string? Action { get; set; }
        public string? Table { get; set; }
        public DateTime? Date { get; set; }
    }
}