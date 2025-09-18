using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PersonTypeRolesAplicacion : IPersonTypeRolesAplicacion
    {
        private IConexion? IConexion = null;

        public PersonTypeRolesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public PersonTypeRoles? Borrar(PersonTypeRoles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.PersonTypeRoles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public PersonTypeRoles? Guardar(PersonTypeRoles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.PersonTypeRoles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<PersonTypeRoles> Listar()
        {
            return this.IConexion!.PersonTypeRoles!.Take(20).ToList();
        }

        public PersonTypeRoles? Modificar(PersonTypeRoles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<PersonTypeRoles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
