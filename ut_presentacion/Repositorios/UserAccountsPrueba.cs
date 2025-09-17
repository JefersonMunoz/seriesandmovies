using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class UserAccountsPrueba
    {
        private readonly IConexion? iConexion;
        private List<UserAccounts>? lista;
        private UserAccounts? entidad;

        public UserAccountsPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.UserAccounts!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.UserAccounts()!;
            this.iConexion!.UserAccounts!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            int id = 17;
            var exist = this.iConexion!.UserAccounts!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.UserAccounts()!;
            //exist.Name = newData.Name;
            //exist.Lastname = newData.Lastname;
            exist.Username = newData.Username;
            exist.PhoneNumber = newData.PhoneNumber;
            exist.Email = newData.Email;
            exist.Password = newData.Password;
            //exist.Birthday = newData.Birthday;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.UserAccounts!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}