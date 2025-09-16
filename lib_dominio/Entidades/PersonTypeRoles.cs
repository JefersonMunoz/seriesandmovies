using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class PersonTypeRoles
    {
        [Key] public int Id { get; set; }
        public int Person { get; set; }
        [ForeignKey("Person")] public Persons? _Person { get; set; }
        public int RoleType { get; set; }
        [ForeignKey("RoleType")] public RoleTypes? _RoleType { get; set; }
    }
}