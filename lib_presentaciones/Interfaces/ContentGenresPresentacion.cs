using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IContentGenresPresentacion
    {
        Task<List<ContentGenres>> Listar(string llave);
        Task<List<GenreTypes>> GenreTypes(string llave);
        Task<List<Contents>> Contents(string llave);
        Task<List<ContentGenres>> PorGenreType(ContentGenres? entidad, string llave);
        Task<ContentGenres?> Guardar(ContentGenres? entidad, string llave);
        Task<ContentGenres?> Modificar(ContentGenres? entidad, string llave);
        Task<ContentGenres?> Borrar(ContentGenres? entidad, string llave);
    }
}