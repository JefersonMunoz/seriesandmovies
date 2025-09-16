using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace lib_dominio.Entidades
{
    public class Subscriptions
    {
        [Key] public int Id { get; set; }
        public int User { get; set; }
        [ForeignKey("User")] public UserAccounts? _User { get; set; }
        public int Plan { get; set; }
        [ForeignKey("Plan")] public Plans? _Plan { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public float Price { get; set; }
        public int Months { get; set; }
        public bool Status { get; set; }
    }
}