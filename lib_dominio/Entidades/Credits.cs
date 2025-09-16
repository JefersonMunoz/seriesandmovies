using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace lib_dominio.Entidades
{
    public class Credits
    {
        [Key] public int Id { get; set; }
        public int Person { get; set; }
        [ForeignKey("Person")] public Persons? _Person { get; set; }
        public int Content { get; set; }
        [ForeignKey("Content")] public Contents? _Content { get; set; }
        public int RoleType { get; set; }
        [ForeignKey("RoleType")] public RoleTypes? _Role_type { get; set; }
    }
}