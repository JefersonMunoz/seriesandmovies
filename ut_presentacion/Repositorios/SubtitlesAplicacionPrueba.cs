using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class SubtitlesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly SubtitlesAplicacion? SubtitlesAplicacion;
        private Subtitles? entidad;

        public SubtitlesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            SubtitlesAplicacion = new SubtitlesAplicacion(iConexion);
            SubtitlesAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = SubtitlesAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Subtitles()!;
            this.entidad = SubtitlesAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Language = 1;
            SubtitlesAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Subtitles!.Find(this.entidad.Id);
            return reloaded!.Language == 1;
        }

        public bool Borrar()
        {
            SubtitlesAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Subtitles!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}