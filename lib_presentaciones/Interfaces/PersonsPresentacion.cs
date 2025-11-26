using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPersonsPresentacion
    {
        Task<List<Persons>> Listar(string llave);
        Task<List<Persons>> PorDescription(Persons? entidad, string llave);
        Task<Persons?> Guardar(Persons? entidad, string llave);
        Task<Persons?> Modificar(Persons? entidad, string llave);
        Task<Persons?> Borrar(Persons? entidad, string llave);
    }
}