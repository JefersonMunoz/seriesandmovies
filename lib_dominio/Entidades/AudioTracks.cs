using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class AudioTracks
    {
        [Key] public int Id { get; set; }
        public int Content { get; set; }
        [ForeignKey("Content")] public Contents? _Content { get; set; }
        public int Language { get; set; }
        [ForeignKey("Language")] public Languages? _Language { get; set; }
    }
}