using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IGenreTypesPresentacion
    {
        Task<List<GenreTypes>> Listar(string llave, int UserId);
        Task<GenreTypes?> Guardar(GenreTypes? entidad, string llave, int UserId);
        Task<GenreTypes?> Modificar(GenreTypes? entidad, string llave, int UserId);
        Task<GenreTypes?> Borrar(GenreTypes? entidad, string llave, int UserId);
    }
}