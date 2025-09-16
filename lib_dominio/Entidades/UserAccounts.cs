using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class UserAccounts
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime Birthday { get; set; }
    }
}

