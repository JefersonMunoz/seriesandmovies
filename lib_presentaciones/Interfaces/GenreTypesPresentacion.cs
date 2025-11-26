using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IGenreTypesPresentacion
    {
        Task<List<GenreTypes>> Listar(string llave);
        Task<GenreTypes?> Guardar(GenreTypes? entidad, string llave);
        Task<GenreTypes?> Modificar(GenreTypes? entidad, string llave);
        Task<GenreTypes?> Borrar(GenreTypes? entidad, string llave);
    }
}