using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static ContentTypes? ContentTypes()
        {
            var entidad = new ContentTypes();
            entidad.Name = "Accion";
            entidad.Description = "Lo mejor en accion";
            return entidad;
        }

        public static Countries? Countries()
        {
            var entidad = new Countries();
            entidad.Name = "Colombia";
            entidad.Code = "CO";
            return entidad;
        }
    }
}