using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Countries
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
