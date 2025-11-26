using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPersonsPresentacion
    {
        Task<List<Persons>> Listar(string llave, int UserId);
        Task<List<Persons>> PorDescription(Persons? entidad, string llave, int UserId);
        Task<Persons?> Guardar(Persons? entidad, string llave, int UserId);
        Task<Persons?> Modificar(Persons? entidad, string llave, int UserId);
        Task<Persons?> Borrar(Persons? entidad, string llave, int UserId);
    }
}