
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class AuditsAplicacion : IAuditsAplicacion
    {
        private IConexion? IConexion = null;

        public AuditsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        //public Audits? Borrar(Audits? entidad)
        //{
        //    if (entidad == null)
        //        throw new Exception("No se encontró la auditoria ingresada");

        //    if (entidad!.Id == 0)
        //        throw new Exception("Debe especificar el ID de la auditoria a eliminar");

        //    // Operaciones
        //    var existente = this.IConexion!.Audits!.Find(entidad.Id);
        //    if (existente == null)
        //        throw new Exception("La auditoria ingresada no existe");

        //    this.IConexion!.Audits!.Remove(entidad);
        //    this.IConexion.SaveChanges();
        //    return entidad;
        //}
        public List<Audits> Listar()
        {
            var lista = this.IConexion!.Audits!.Include(a => a._User).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen auditorias registradas.");

            return lista;
        }

        public Audits? Guardar(Audits? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Auditoria guardadda correctamente");

            // Operaciones
            //Validar que el usuario exista
            var auditoria = this.IConexion!.Users!.Find(entidad.User);
            if (auditoria == null)
                throw new Exception("El no usuario existe");

            //Guardar cambios
            this.IConexion!.Audits!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Audits> porAction(Audits? entidad)
        {
            return this.IConexion!.Audits!.Where(x => x.Action!.Contains(entidad!.Action!)).ToList();
        }

    }
}