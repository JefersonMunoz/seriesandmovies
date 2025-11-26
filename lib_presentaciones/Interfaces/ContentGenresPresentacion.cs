using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IContentGenresPresentacion
    {
        Task<List<ContentGenres>> Listar(string llave, int UserId);
        Task<List<GenreTypes>> GenreTypes(string llave, int UserId);
        Task<List<Contents>> Contents(string llave, int UserId);
        Task<List<ContentGenres>> PorGenreType(ContentGenres? entidad, string llave, int UserId);
        Task<ContentGenres?> Guardar(ContentGenres? entidad, string llave, int UserId);
        Task<ContentGenres?> Modificar(ContentGenres? entidad, string llave, int UserId);
        Task<ContentGenres?> Borrar(ContentGenres? entidad, string llave, int UserId);
    }
}