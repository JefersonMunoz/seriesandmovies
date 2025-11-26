using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAudioTracksPresentacion
    {
        Task<List<AudioTracks>> Listar();
        Task<List<Contents>> Contents();
        Task<List<Languages>> Languages();
        Task<List<AudioTracks>> PorLanguage(string name);
        Task<AudioTracks?> Guardar(AudioTracks? entidad);
        Task<AudioTracks?> Modificar(AudioTracks? entidad);
        Task<AudioTracks?> Borrar(AudioTracks? entidad);
    }
}