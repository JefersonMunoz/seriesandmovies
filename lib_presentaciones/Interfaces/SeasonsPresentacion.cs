
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ISeasonsPresentacion
    {
        Task<List<Seasons>> Listar(string llave, int UserId);
        Task<List<Seasons>> PorTitle(Seasons? entidad, string llave, int UserId);
        Task<Seasons?> Guardar(Seasons? entidad, string llave, int UserId);
        Task<Seasons?> Modificar(Seasons? entidad, string llave, int UserId);
        Task<Seasons?> Borrar(Seasons? entidad, string llave, int UserId);
    }
}