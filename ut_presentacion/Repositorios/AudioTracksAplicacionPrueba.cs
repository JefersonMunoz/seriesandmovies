using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class AudioTracksAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly AudioTracksAplicacion? AudioTracksAplicacion;
        private AudioTracks? entidad;

        public AudioTracksAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            AudioTracksAplicacion = new AudioTracksAplicacion(iConexion);
            AudioTracksAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = AudioTracksAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.AudioTracks()!;
            this.entidad = AudioTracksAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Content = 1;
            AudioTracksAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.AudioTracks!.Find(this.entidad.Id);
            return reloaded!.Content == 1;
        }

        public bool Borrar()
        {
            AudioTracksAplicacion.Borrar(this.entidad!);
            var gone = iConexion.AudioTracks!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}