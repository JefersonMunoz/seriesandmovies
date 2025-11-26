using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ICountriesPresentacion
    {
        Task<List<Countries>> Listar(string llave, int UserId);
        Task<Countries?> Guardar(Countries? entidad, string llave, int UserId);
        Task<Countries?> Modificar(Countries? entidad, string llave, int UserId);
        Task<Countries?> Borrar(Countries? entidad, string llave, int UserId);
    }
}