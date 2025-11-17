using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class UserAccountsAplicacion : IUserAccountsAplicacion
    {
        private IConexion? IConexion = null;

        public UserAccountsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public UserAccounts? Borrar(UserAccounts? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el usuario ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del usuario a eliminar");

            // Operaciones
            var existente = this.IConexion!.UserAccounts!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El usuario ingresado no existe");

            this.IConexion!.UserAccounts!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public UserAccounts? Guardar(UserAccounts? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            if (entidad.Birthday == null)
                throw new Exception("Debe ingresar la fecha de nacimiento (MM/DD/YYYY)");

            bool existe = this.IConexion.UserAccounts!.Any(a => a.Username == entidad.Username);
            if (existe)
                throw new Exception("Ya existe una cuenta con el nombre de usuario");

            this.IConexion!.UserAccounts!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<UserAccounts> Listar()
        {
            var lista = this.IConexion!.UserAccounts!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen episodios registrados.");

            return lista;
        }

        public List<UserAccounts> PorName(UserAccounts? entidad)
        {
            var lista = this.IConexion!.UserAccounts!.Where(x => x.Name!.Contains(entidad.Name!)).ToList();

            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No existen usuarios.");
            }
            return lista;
        }

        public UserAccounts? Modificar(UserAccounts? entidad)
        {

            if(entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.UserAccounts!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el usuario que intenta modificar.");

            //Validar que el registro existe
            bool existe = this.IConexion.UserAccounts!.Any(a => a.Username == entidad.Username);
            if (existe)
                throw new Exception("Ya existe una cuenta con el nombre de usuario");

            var entry = this.IConexion!.Entry<UserAccounts>(entidad);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Birthday).IsModified = false; //evitar que modifiique la fecha
            entry.Property(e => e.Username).IsModified = false; //evitar que modifiique el usuario
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
