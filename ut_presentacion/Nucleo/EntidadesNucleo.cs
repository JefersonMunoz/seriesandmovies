using lib_dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

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

        public static AudioTracks? AudioTracks()
        {
            var entidad = new AudioTracks();
            entidad.Content = 2;
            entidad.Language = 4;
            return entidad;
        }
    }
}