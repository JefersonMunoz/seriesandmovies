namespace lib_dominio.Entidades
{
    public class Habitaciones
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public int Camas { get; set; }
        public int Capacidad { get; set; }
        public string? Tipo { get; set; }
        public bool Activa { get; set; }
    }
}