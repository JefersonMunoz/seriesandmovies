using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEpisodesPresentacion
    {
        Task<List<Episodes>> Listar(string llave);
        Task<List<Episodes>> PorEpisodes(Episodes? entidad, string llave);
        Task<Episodes?> Guardar(Episodes? entidad, string llave);
        Task<Episodes?> Modificar(Episodes? entidad, string llave);
        Task<Episodes?> Borrar(Episodes? entidad, string llave);
    }
}