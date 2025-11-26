using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAudioTracksPresentacion
    {
        Task<List<AudioTracks>> Listar(string llave, int UserId);
        Task<List<Contents>> Contents(string llave, int UserId);
        Task<List<Languages>> Languages(string llave, int UserId);
        Task<List<AudioTracks>> PorLanguage(AudioTracks? entidad, string llave, int UserId);
        Task<AudioTracks?> Guardar(AudioTracks? entidad, string llave, int UserId);
        Task<AudioTracks?> Modificar(AudioTracks? entidad, string llave, int UserId);
        Task<AudioTracks?> Borrar(AudioTracks? entidad, string llave, int UserId);
    }
}