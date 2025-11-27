using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ISubscriptionsPresentacion
    {
        Task<List<Subscriptions>> Listar(string llave, int UserId);
        Task<List<Users>> Users(string llave, int UserId);
        Task<List<Plans>> Plans(string llave, int UserId);
        Task<List<Subscriptions>> PorPlan(Subscriptions? entidad, string llave, int UserId);
        Task<Subscriptions?> Guardar(Subscriptions? entidad, string llave, int UserId);
        Task<Subscriptions?> Modificar(Subscriptions? entidad, string llave, int UserId);
        Task<Subscriptions?> Borrar(Subscriptions? entidad, string llave, int UserId);
    }
}