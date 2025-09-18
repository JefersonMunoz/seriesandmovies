using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class RoleTypesAplicacion : IRoleTypesAplicacion
    {
        private IConexion? IConexion = null;

        public RoleTypesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public RoleTypes? Borrar(RoleTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.RoleTypes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public RoleTypes? Guardar(RoleTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.RoleTypes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<RoleTypes> Listar()
        {
            return this.IConexion!.RoleTypes!.Take(20).ToList();
        }

        public RoleTypes? Modificar(RoleTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<RoleTypes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
