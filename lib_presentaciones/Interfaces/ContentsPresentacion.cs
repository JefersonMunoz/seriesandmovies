using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IContentsPresentacion
    {
        Task<List<Contents>> Listar();
        Task<List<ContentTypes>> ContentTypes();
        Task<List<Studios>> Studios();
        Task<List<Languages>> Languages();
        Task<List<Contents>> PorDescription(Contents? entidad);
        Task<Contents?> Guardar(Contents? entidad);
        Task<Contents?> Modificar(Contents? entidad);
        Task<Contents?> Borrar(Contents? entidad);
    }
}