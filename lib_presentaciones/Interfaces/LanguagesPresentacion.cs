using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ILanguagesPresentacion
    {
        Task<List<Languages>> Listar(string llave, int UserId);
        Task<Languages?> Guardar(Languages? entidad, string llave, int UserId);
        Task<Languages?> Modificar(Languages? entidad, string llave, int UserId);
        Task<Languages?> Borrar(Languages? entidad, string llave, int UserId);
    }
}