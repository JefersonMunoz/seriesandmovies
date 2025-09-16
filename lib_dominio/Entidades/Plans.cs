using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Plans
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int MaxPeople { get; set; }
    }
}

