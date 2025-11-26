
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IUsersPresentacion
    {
        Task<List<Users>> Listar(string llave, int UserId);
        Task<List<Users>> PorName(Users? entidad, string llave, int UserId);
        Task<Users?> Guardar(Users? entidad, string llave, int UserId);
        Task<Users?> Modificar(Users? entidad, string llave, int UserId);
        Task<Users?> Borrar(Users? entidad, string llave, int UserId);
    }
}