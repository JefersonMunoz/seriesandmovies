using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Episodes
    {
        [Key] public int Id { get; set; }
        public int Season { get; set; }
        public string? Title { get; set; }
        public string?NumberEpisode { get; set; }
        public TimeOnly DurationTime { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleasedAt { get; set; }
    }
}
