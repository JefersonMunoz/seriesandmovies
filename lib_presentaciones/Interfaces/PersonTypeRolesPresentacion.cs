
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPersonTypeRolesPresentacion
    {
        Task<List<PersonTypeRoles>> Listar(string llave);
        Task<List<Persons>> Persons(string llave);
        Task<List<RoleTypes>> RoleTypes(string llave);
        Task<List<PersonTypeRoles>> PorTypeRoles(PersonTypeRoles? entidad, string llave);
        Task<PersonTypeRoles?> Guardar(PersonTypeRoles? entidad, string llave);
        Task<PersonTypeRoles?> Modificar(PersonTypeRoles? entidad, string llave);
        Task<PersonTypeRoles?> Borrar(PersonTypeRoles? entidad, string llave);
    }
}