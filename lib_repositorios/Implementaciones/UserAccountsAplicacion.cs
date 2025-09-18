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
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.UserAccounts!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public UserAccounts? Guardar(UserAccounts? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.UserAccounts!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<UserAccounts> Listar()
        {
            return this.IConexion!.UserAccounts!.Take(20).ToList();
        }

        public UserAccounts? Modificar(UserAccounts? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<UserAccounts>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
