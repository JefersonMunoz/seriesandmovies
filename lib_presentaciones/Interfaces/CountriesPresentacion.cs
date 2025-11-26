using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ICountriesPresentacion
    {
        Task<List<Countries>> Listar(string llave);
        Task<Countries?> Guardar(Countries? entidad, string llave);
        Task<Countries?> Modificar(Countries? entidad, string llave);
        Task<Countries?> Borrar(Countries? entidad, string llave);
    }
}