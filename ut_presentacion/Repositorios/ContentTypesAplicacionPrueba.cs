using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ContentTypesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly ContentTypesAplicacion? ContentTypesAplicacion;
        private ContentTypes? entidad;

        public ContentTypesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            ContentTypesAplicacion = new ContentTypesAplicacion(iConexion);
            ContentTypesAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = ContentTypesAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.ContentTypes()!;
            this.entidad = ContentTypesAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Cortometraje";
            ContentTypesAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.ContentTypes!.Find(this.entidad.Id);
            return reloaded!.Name == "Cortometraje";
        }

        public bool Borrar()
        {
            ContentTypesAplicacion.Borrar(this.entidad!);
            var gone = iConexion.ContentTypes!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}