using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class ContentGenres
    {
        [Key] public int Id { get; set; }
        public int GenreType { get; set; }
        [ForeignKey("GenreType")] public GenreTypes? _Genre_type { get; set; }
        public int Content { get; set; }
        [ForeignKey("Content")] public Contents? _Content { get; set; }
    }
}
