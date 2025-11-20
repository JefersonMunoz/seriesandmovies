using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace lib_dominio.Entidades
{
    public class Contents
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ContentType { get; set; }
        [ForeignKey("ContentType")] public ContentTypes? _ContentType { get; set; }
        public DateTime? Year { get; set; }
        public int Language { get; set; }
        [ForeignKey("Language")] public Languages? _Language { get; set; }
        public int Studio { get; set; }
        [ForeignKey("Studio")] public Studios? _Studio { get; set; }
    }
}