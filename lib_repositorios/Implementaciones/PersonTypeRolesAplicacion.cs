using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

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
                throw new Exception("No se encontró el tipo de rol ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el id a eliminar");

            // Operaciones
            var existente = this.IConexion!.PersonTypeRoles!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El tipo de rol ingresado no existe");

            this.IConexion!.PersonTypeRoles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public PersonTypeRoles? Guardar(PersonTypeRoles? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Tipo de rol guardado correctamente");

            // Operaciones
            if(entidad._Person == null && entidad._RoleType == null )
                throw new Exception("Debe ingresar el tipo de persona o tipo de rol");

            //Validar que la persona,el tipo de rol exista
            var persona = this.IConexion!.Persons!.Find(entidad.Person);
            var tipoRol = this.IConexion!.RoleTypes!.Find(entidad.RoleType);
            if (persona == null || tipoRol == null)
                throw new Exception("La persona o el tipo de rol no existe");

           //Validar tipo de rol duplicado
            bool existe = this.IConexion.PersonTypeRoles!.Any(a => a.Person == entidad.Person && a.RoleType == entidad.RoleType);
            if (existe)
                throw new Exception("Ya existe una persona con la misma información");

            this.IConexion!.PersonTypeRoles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<PersonTypeRoles> Listar()
        {
            var lista = this.IConexion!.PersonTypeRoles!.Include(a => a._Person).Include(a => a._Person).Include(a => a._RoleType).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen Tipos de rol registrados.");

            return lista;
        }

        public List<PersonTypeRoles> PorTypeRoles(PersonTypeRoles? entidad)
        {
            string name = entidad!._RoleType!.Name!;
            var lista = this.IConexion!.PersonTypeRoles!.Include(x => x._RoleType).Include(a => a._Person).Where(x => x._RoleType!.Name!.Contains(name)).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen personas que coincidan con la búsqueda.");

            return lista;
        }

        public PersonTypeRoles? Modificar(PersonTypeRoles? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.PersonTypeRoles!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el tipo de rol que intenta modificar.");

            //Validar que la persona,el tipo de rol exista
            var persona = this.IConexion!.Persons!.Find(entidad.Person);
            var tipoRol = this.IConexion!.RoleTypes!.Find(entidad.RoleType);
            if (persona == null || tipoRol == null)
                throw new Exception("La persona o el tipo de rol no existe");

            //Validar tipo de rol duplicado
            bool existe = this.IConexion.Credits!.Any(a => a.Person == entidad.Person && a.RoleType == entidad.RoleType);
            if (existe)
                throw new Exception("Ya existe un tipo de rol con la misma información");

            var entry = this.IConexion!.Entry<PersonTypeRoles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
