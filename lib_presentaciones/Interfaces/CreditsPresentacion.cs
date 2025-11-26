using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ICreditsPresentacion
    {
        Task<List<Credits>> Listar(string llave, int UserId);
        Task<List<Persons>> Persons(string llave, int UserId);
        Task<List<Contents>> Contents(string llave, int UserId);
        Task<List<RoleTypes>> RoleTypes(string llave, int UserId);
        Task<List<Credits>> PorPersons(Credits? entidad, string llave, int UserId);
        Task<Credits?> Guardar(Credits? entidad, string llave, int UserId);
        Task<Credits?> Modificar(Credits? entidad, string llave, int UserId);
        Task<Credits?> Borrar(Credits? entidad, string llave, int UserId);
    }
}