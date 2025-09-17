using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Persons
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastame { get; set; }
        public DateTime Birthday { get; set; }
        public string? Description { get; set; }
    }
}