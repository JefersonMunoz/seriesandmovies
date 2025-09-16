using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace lib_dominio.Entidades
{
    public class Studios
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public int Country { get; set; }
        [ForeignKey("Country")] public Countries? _Country { get; set; }
        public string? Description { get; set; }
    }
}
