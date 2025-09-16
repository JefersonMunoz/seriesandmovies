using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Seasons
    {
        [Key] public int Id { get; set; }
        public int NumberSeason { get; set; }
        public string? Title { get; set; }
        public int Content { get; set; }
        [ForeignKey("Content")] public Contents? _Content { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleasedAt { get; set; }
    }
}