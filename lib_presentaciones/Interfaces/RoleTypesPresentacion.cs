
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IRoleTypesPresentacion
    {
        Task<List<RoleTypes>> Listar(string llave, int UserId);
        Task<RoleTypes?> Guardar(RoleTypes? entidad, string llave, int UserId);
        Task<RoleTypes?> Modificar(RoleTypes? entidad, string llave, int UserId);
        Task<RoleTypes?> Borrar(RoleTypes? entidad, string llave, int UserId);
    }
}