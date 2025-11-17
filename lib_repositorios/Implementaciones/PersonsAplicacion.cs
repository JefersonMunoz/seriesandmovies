using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PersonsAplicacion : IPersonsAplicacion
    {
        private IConexion? IConexion = null;

        public PersonsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Persons? Borrar(Persons? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró la persona ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del contenido a eliminar");

            // Operaciones
            var existente = this.IConexion!.Persons!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("La persona ingresada no existe");

            this.IConexion!.Persons!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Persons? Guardar(Persons? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            if (string.IsNullOrWhiteSpace(entidad.Name))
                throw new Exception("Debe ingresar el nombre");

            if (entidad.Birthday == null || entidad.Birthday > DateTime.Now)
                throw new Exception("Debe ingresar una fecha de nacimiento válida (MMMM/DD/YY)");

            //if (entidad.Birthday == default(DateTime) || entidad.Birthday == DateTime.MinValue)
            //    throw new Exception("Debe ingresar una fecha válida");

            if (entidad.Id != 0)
                throw new Exception("Persona guardada correctamente");


            //Validar que la´persona ya exista
            bool existe = this.IConexion.Persons!.Any(a => a.Name == entidad.Name && a.Lastame == entidad.Lastame && a.Birthday == entidad.Birthday);
            if (existe)
                throw new Exception("Ya existe una persona con la misma información");

            this.IConexion!.Persons!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Persons> Listar()
        {
            var lista = this.IConexion!.Persons!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen personas registrados.");

            return lista;
        }

        public List<Persons> PorDescription(Persons? entidad)
        {
            var lista = this.IConexion!.Persons!.Where(x => x.Description!.Contains(entidad.Description!)).ToList();

            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No existen personas que contengan la descripción.");
            }
            return lista;
        }

        public Persons? Modificar(Persons? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            if (entidad.Birthday == null || entidad.Birthday > DateTime.Now)
                throw new Exception("Debe ingresar una fecha de nacimiento válida (MMMM/DD/YY)");

            var existente = this.IConexion!.Persons!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("La persona ingresada no existe");

            //Validar persona duplicada
            bool existe = this.IConexion.Persons!.Any(a => a.Name == entidad.Name && a.Lastame == entidad.Lastame && a.Id != entidad.Id);
            if (existe)
                throw new Exception("Ya existe una persona con la misma información");

            var entry = this.IConexion!.Entry<Persons>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
