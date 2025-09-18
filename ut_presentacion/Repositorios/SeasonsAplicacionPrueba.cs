using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class SeasonsAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly SeasonsAplicacion? SeasonsAplicacion;
        private Seasons? entidad;

        public SeasonsAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            SeasonsAplicacion = new SeasonsAplicacion(iConexion);
            SeasonsAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = SeasonsAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Seasons()!;
            this.entidad = SeasonsAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Title = "El despertar";
            SeasonsAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Seasons!.Find(this.entidad.Id);
            return reloaded!.Title == "El despertar";
        }

        public bool Borrar()
        {
            SeasonsAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Seasons!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}