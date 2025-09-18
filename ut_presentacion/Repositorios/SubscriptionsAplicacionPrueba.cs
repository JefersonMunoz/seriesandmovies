using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class SubscriptionsAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly SubscriptionsAplicacion? SubscriptionsAplicacion;
        private Subscriptions? entidad;

        public SubscriptionsAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            SubscriptionsAplicacion = new SubscriptionsAplicacion(iConexion);
            SubscriptionsAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = SubscriptionsAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Subscriptions()!;
            this.entidad = SubscriptionsAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Plan = 2;
            SubscriptionsAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Subscriptions!.Find(this.entidad.Id);
            return reloaded!.Plan == 2;
        }

        public bool Borrar()
        {
            SubscriptionsAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Subscriptions!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}