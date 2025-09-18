using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class CreditsAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly CreditsAplicacion? CreditsAplicacion;
        private Credits? entidad;

        public CreditsAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            CreditsAplicacion = new CreditsAplicacion(iConexion);
            CreditsAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = CreditsAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Credits()!;
            this.entidad = CreditsAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.RoleType = 2;
            CreditsAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Credits!.Find(this.entidad.Id);
            return reloaded!.RoleType == 2;
        }

        public bool Borrar()
        {
            CreditsAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Credits!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}