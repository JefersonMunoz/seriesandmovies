
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class UsersAplicacion : IUsersAplicacion
    {
        private IConexion? IConexion = null;

        public UsersAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Users? Borrar(Users? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el usuario ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del usuario a eliminar");

            // Operaciones
            var existente = this.IConexion!.Users!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El usuario ingresada no existe");

            this.IConexion!.Users!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Users> Listar()
        {
            var lista = this.IConexion!.Users!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen usuarios registrados.");

            return lista;
        }

        public List<Users> PorName(Users? entidad)
        {
            var lista = this.IConexion!.Users!.Where(x => x.Name!.Contains(entidad.Name!)).ToList();

            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No existen usuarios.");
            }
            return lista;
        }

        public Users? Guardar(Users? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Usuario guardado correctamente");

            //Validar usuario duplicado
            bool existe = this.IConexion.Users!.Any(a => a.Username == entidad.Username);
            if (existe)
                throw new Exception("Ya existe un usuario con la misma información");
            
            //Guardar cambios
            this.IConexion!.Users!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Users? Modificar(Users? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Users!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el usuario que intenta modificar.");

            //Validar usuario duplicado
            bool existe = this.IConexion.Users!.Any(a => a.Username == entidad.Username);
            if (existe)
                throw new Exception("Ya existe un usuario con la misma información");

            var entry = this.IConexion!.Entry<Users>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}