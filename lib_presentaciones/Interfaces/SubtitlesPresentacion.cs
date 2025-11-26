
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ISubtitlesPresentacion
    {
        Task<List<Subtitles>> Listar(string llave, int UserId);
        Task<List<Subtitles>> PorLanguage(Subtitles? entidad, string llave, int UserId);
        Task<Subtitles?> Guardar(Subtitles? entidad, string llave, int UserId);
        Task<Subtitles?> Modificar(Subtitles? entidad, string llave, int UserId);
        Task<Subtitles?> Borrar(Subtitles? entidad, string llave, int UserId);
    }
}