using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ContentsAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly ContentsAplicacion? ContentsAplicacion;
        private Contents? entidad;

        public ContentsAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            ContentsAplicacion = new ContentsAplicacion(iConexion);
            ContentsAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = ContentsAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Contents()!;
            this.entidad = ContentsAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Ben 10";
            ContentsAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Contents!.Find(this.entidad.Id);
            return reloaded!.Name == "Ben 10";
        }

        public bool Borrar()
        {
            ContentsAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Contents!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}