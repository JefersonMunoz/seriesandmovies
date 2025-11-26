using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPlansPresentacion
    {
        Task<List<Plans>> Listar(string llave, int UserId);
        Task<List<Plans>> PorPlan(Plans? entidad, string llave, int UserId);
        Task<Plans?> Guardar(Plans? entidad, string llave, int UserId);
        Task<Plans?> Modificar(Plans? entidad, string llave, int UserId);
        Task<Plans?> Borrar(Plans? entidad, string llave, int UserId);
    }
}