using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class WatchlistsAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly WatchlistsAplicacion? WatchlistsAplicacion;
        private Watchlists? entidad;

        public WatchlistsAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            WatchlistsAplicacion = new WatchlistsAplicacion(iConexion);
            WatchlistsAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = WatchlistsAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Watchlists()!;
            this.entidad = WatchlistsAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Content = 1;
            WatchlistsAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Watchlists!.Find(this.entidad.Id);
            return reloaded!.Content == 1;
        }

        public bool Borrar()
        {
            WatchlistsAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Watchlists!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}