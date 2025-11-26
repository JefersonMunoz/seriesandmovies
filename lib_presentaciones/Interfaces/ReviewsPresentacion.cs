using lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IReviewsPresentacion
    {
        Task<List<Reviews>> Listar(string llave, int UserId);
        Task<List<Contents>> Contents(string llave, int UserId);
        Task<List<Users>> Users(string llave, int UserId);
        Task<List<Reviews>> PorContent(Reviews? entidad, string llave, int UserId);
        Task<Reviews?> Guardar(Reviews? entidad, string llave, int UserId);
        Task<Reviews?> Modificar(Reviews? entidad, string llave, int UserId);
        Task<Reviews?> Borrar(Reviews? entidad, string llave, int UserId);
    }
}