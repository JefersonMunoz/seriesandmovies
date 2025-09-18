using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PlansAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly PlansAplicacion? PlansAplicacion;
        private Plans? entidad;

        public PlansAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            PlansAplicacion = new PlansAplicacion(iConexion);
            PlansAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = PlansAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Plans()!;
            this.entidad = PlansAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Individual pro";
            PlansAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Plans!.Find(this.entidad.Id);
            return reloaded!.Name == "Individual pro";
        }

        public bool Borrar()
        {
            PlansAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Plans!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}