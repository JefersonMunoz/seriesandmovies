using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IContentsPresentacion
    {
        Task<List<Contents>> Listar(string llave, int UserId);
        Task<List<ContentTypes>> ContentTypes(string llave, int UserId);
        Task<List<Studios>> Studios(string llave, int UserId);
        Task<List<Languages>> Languages(string llave, int UserId);
        Task<List<Contents>> Filtro(Contents? entidad, string llave, int UserId);
        Task<Contents?> Guardar(Contents? entidad, string llave, int UserId);
        Task<Contents?> Modificar(Contents? entidad, string llave, int UserId);
        Task<Contents?> Borrar(Contents? entidad, string llave, int UserId);
    }
}