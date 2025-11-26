
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IAuditsAplicacion
    {
        void Configurar(string StringConexion);
        List<Audits> Listar();
        Audits? Guardar(Dictionary<string, object> datos);
        List<Audits> porAction(Audits? entidad);
        //Audits? Modificar(Audits? entidad);
        //Audits? Borrar(Audits? entidad);
    }
}
