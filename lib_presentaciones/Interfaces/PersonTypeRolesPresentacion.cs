
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPersonTypeRolesPresentacion
    {
        Task<List<PersonTypeRoles>> Listar(string llave, int UserId);
        Task<List<Persons>> Persons(string llave, int UserId);
        Task<List<RoleTypes>> RoleTypes(string llave, int UserId);
        Task<List<PersonTypeRoles>> PorTypeRoles(PersonTypeRoles? entidad, string llave, int UserId);
        Task<PersonTypeRoles?> Guardar(PersonTypeRoles? entidad, string llave, int UserId);
        Task<PersonTypeRoles?> Modificar(PersonTypeRoles? entidad, string llave, int UserId);
        Task<PersonTypeRoles?> Borrar(PersonTypeRoles? entidad, string llave, int UserId);
    }
}