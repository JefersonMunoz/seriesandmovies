using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ICreditsPresentacion
    {
        Task<List<Credits>> Listar(string llave);
        Task<List<Persons>> Persons(string llave);
        Task<List<Contents>> Contents(string llave);
        Task<List<RoleTypes>> RoleTypes(string llave);
        Task<List<Credits>> PorPersons(Credits? entidad, string llave);
        Task<Credits?> Guardar(Credits? entidad, string llave);
        Task<Credits?> Modificar(Credits? entidad, string llave);
        Task<Credits?> Borrar(Credits? entidad, string llave);
    }
}