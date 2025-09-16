using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Watchlists
    {
        [Key] public int Id { get; set; }
        public int User { get; set; }
        [ForeignKey("User")] public UserAccounts? _User { get; set; }
        public int Content { get; set; }
        [ForeignKey("Content")] public Contents? _Content { get; set; }
    }
}