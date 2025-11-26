
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IStudiosPresentacion
    {
        Task<List<Studios>> Listar(string llave, int UserId);
        Task<List<Studios>> PorDescription(Studios? entidad, string llave, int UserId);
        Task<Studios?> Guardar(Studios? entidad, string llave, int UserId);
        Task<Studios?> Modificar(Studios? entidad, string llave, int UserId);
        Task<Studios?> Borrar(Studios? entidad, string llave, int UserId);
    }
}