using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class CreditsAplicacion : ICreditsAplicacion
    {
        private IConexion? IConexion = null;

        public CreditsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Credits? Borrar(Credits? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el crédito ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del crédito a eliminar");

            // Operaciones
            var existente = this.IConexion!.Credits!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El crédito ingresado no existe");

            this.IConexion!.Credits!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Credits? Guardar(Credits? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Crédito guardado correctamente");

            // Operaciones
            //Validar que la persona, contenido y el tipo de rol exista
            var persona = this.IConexion!.Persons!.Find(entidad.Person);
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            var tipoRol = this.IConexion!.RoleTypes!.Find(entidad.RoleType);
            if (persona == null || contenido == null || tipoRol == null)
                throw new Exception("La persona, contenido o el tipo de rol no existe");

            //Validar audio duplicada
            bool existe = this.IConexion.Credits!.Any(a => a.Person == entidad.Person && a.Content == entidad.Content && a.RoleType == entidad.RoleType);
            if (existe)
                throw new Exception("Ya existe un crédito con la misma información");

            this.IConexion!.Credits!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Credits> Listar()
        {
            var lista = this.IConexion!.Credits!.Include(a => a._Person).Include(a => a._Content).Include(a => a._RoleType).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen Audios registrados.");

            return lista;
        }

        public List<Credits> PorPersons(Credits? entidad)
        {
            string name = entidad!._Person!.Name!;
            var lista = this.IConexion!.Credits!.Include(x => x._Person).Where(x => x._Person!.Name!.Contains(name)).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen creditos que coincidan con la búsqueda.");

            return lista;
        }

        public Credits? Modificar(Credits? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Credits!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el crédito que intenta modificar.");

            //Validar que el contenido y el lenguaje exista
            var persona = this.IConexion!.Persons!.Find(entidad.Person);
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            var tipoRol = this.IConexion!.RoleTypes!.Find(entidad.RoleType);
            if (persona == null || contenido == null || tipoRol == null)
                throw new Exception("La persona, contenido o el tipo de rol no existe");

            //Validar audio duplicada
            bool existe = this.IConexion.Credits!.Any(a => a.Person == entidad.Person && a.Content == entidad.Content && a.RoleType == entidad.RoleType);
            if (existe)
                throw new Exception("Ya existe un crédito con la misma información");

            var entry = this.IConexion!.Entry<Credits>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
