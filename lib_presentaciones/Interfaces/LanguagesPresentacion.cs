using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ILanguagesPresentacion
    {
        Task<List<Languages>> Listar(string llave);
        Task<Languages?> Guardar(Languages? entidad, string llave);
        Task<Languages?> Modificar(Languages? entidad, string llave);
        Task<Languages?> Borrar(Languages? entidad, string llave);
    }
}