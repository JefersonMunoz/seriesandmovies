using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class UserAccountsAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly UsersAplicacion? UserAccountsAplicacion;
        private Users? entidad;

        public UserAccountsAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            UserAccountsAplicacion = new UsersAplicacion(iConexion);
            UserAccountsAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = UserAccountsAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.UserAccounts()!;
            this.entidad = UserAccountsAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Juan";
            UserAccountsAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.UserAccounts!.Find(this.entidad.Id);
            return reloaded!.Name == "Juan";
        }

        public bool Borrar()
        {
            UserAccountsAplicacion.Borrar(this.entidad!);
            var gone = iConexion.UserAccounts!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}