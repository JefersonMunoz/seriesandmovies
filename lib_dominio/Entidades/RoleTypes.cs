using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class RoleTypes
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
    }
}