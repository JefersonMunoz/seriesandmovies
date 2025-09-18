using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class LanguagesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly LanguagesAplicacion? LanguagesAplicacion;
        private Languages? entidad;

        public LanguagesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            LanguagesAplicacion = new LanguagesAplicacion(iConexion);
            LanguagesAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = LanguagesAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Languages()!;
            this.entidad = LanguagesAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Mandarin";
            LanguagesAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Languages!.Find(this.entidad.Id);
            return reloaded!.Name == "Mandarin";
        }

        public bool Borrar()
        {
            LanguagesAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Languages!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}