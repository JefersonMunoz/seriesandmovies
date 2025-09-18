using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ContentGenresAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly ContentGenresAplicacion? ContentGenresAplicacion;
        private ContentGenres? entidad;

        public ContentGenresAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            ContentGenresAplicacion = new ContentGenresAplicacion(iConexion);
            ContentGenresAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = ContentGenresAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.ContentGenres()!;
            this.entidad = ContentGenresAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Content = 10;
            ContentGenresAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.ContentGenres!.Find(this.entidad.Id);
            return reloaded!.Content == 10;
        }

        public bool Borrar()
        {
            ContentGenresAplicacion.Borrar(this.entidad!);
            var gone = iConexion.ContentGenres!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}