using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    [Table("Content_types")]
    public class ContentTypes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}