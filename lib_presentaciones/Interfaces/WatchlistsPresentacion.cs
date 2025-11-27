
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IWatchlistsPresentacion
    {
        Task<List<Watchlists>> Listar(string llave, int UserId);
        Task<List<Users>> Users(string llave, int UserId);
        Task<List<Contents>> Contents(string llave, int UserId);
        Task<List<Watchlists>> PorUser(Watchlists? entidad, string llave, int UserId);
        Task<Watchlists?> Guardar(Watchlists? entidad, string llave, int UserId);
        Task<Watchlists?> Modificar(Watchlists? entidad, string llave, int UserId);
        Task<Watchlists?> Borrar(Watchlists? entidad, string llave, int UserId);
    }
}