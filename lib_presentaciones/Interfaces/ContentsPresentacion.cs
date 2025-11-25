using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IContentsPresentacion
    {
        Task<List<Contents>> Listar(string llave);
        Task<List<ContentTypes>> ContentTypes(string llave);
        Task<List<Studios>> Studios(string llave);
        Task<List<Languages>> Languages(string llave);
        Task<List<Contents>> PorDescription(Contents? entidad, string llave);
        Task<Contents?> Guardar(Contents? entidad, string llave);
        Task<Contents?> Modificar(Contents? entidad, string llave);
        Task<Contents?> Borrar(Contents? entidad, string llave);
    }
}