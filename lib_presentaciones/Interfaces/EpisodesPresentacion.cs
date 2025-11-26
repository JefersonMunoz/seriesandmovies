using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEpisodesPresentacion
    {
        Task<List<Episodes>> Listar(string llave, int UserId);
        Task<List<Episodes>> PorEpisodes(Episodes? entidad, string llave, int UserId);
        Task<Episodes?> Guardar(Episodes? entidad, string llave, int UserId);
        Task<Episodes?> Modificar(Episodes? entidad, string llave, int UserId);
        Task<Episodes?> Borrar(Episodes? entidad, string llave, int UserId);
    }
}