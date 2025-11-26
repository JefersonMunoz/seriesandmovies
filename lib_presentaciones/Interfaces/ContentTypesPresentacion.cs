using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IContentTypesPresentacion
    {
        Task<List<ContentTypes>> Listar(string llave);
        Task<List<ContentTypes>> PorName(ContentTypes? entidad, string llave);
        Task<ContentTypes?> Guardar(ContentTypes? entidad, string llave);
        Task<ContentTypes?> Modificar(ContentTypes? entidad, string llave);
        Task<ContentTypes?> Borrar(ContentTypes? entidad, string llave);
    }
}