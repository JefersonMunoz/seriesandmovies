using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class EpisodesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly EpisodesAplicacion? EpisodesAplicacion;
        private Episodes? entidad;

        public EpisodesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            EpisodesAplicacion = new EpisodesAplicacion(iConexion);
            EpisodesAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = EpisodesAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Episodes()!;
            this.entidad = EpisodesAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Title = "The seventh wonder";
            EpisodesAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Episodes!.Find(this.entidad.Id);
            return reloaded!.Title == "The seventh wonder";
        }

        public bool Borrar()
        {
            EpisodesAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Episodes!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}