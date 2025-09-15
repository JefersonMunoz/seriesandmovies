using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Habitaciones? Habitaciones()
        {
            var entidad = new Habitaciones();
            entidad.Numero = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Camas = 2;
            entidad.Capacidad = 4;
            entidad.Tipo = "Normal";    
            entidad.Activa = true;
            return entidad;
        }
    }
}