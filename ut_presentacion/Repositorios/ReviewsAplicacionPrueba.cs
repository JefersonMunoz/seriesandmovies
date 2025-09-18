using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ReviewsAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly ReviewsAplicacion? ReviewsAplicacion;
        private Reviews? entidad;

        public ReviewsAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            ReviewsAplicacion = new ReviewsAplicacion(iConexion);
            ReviewsAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = ReviewsAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Reviews()!;
            this.entidad = ReviewsAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Comment = "So cool";
            ReviewsAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Reviews!.Find(this.entidad.Id);
            return reloaded!.Comment == "So cool";
        }

        public bool Borrar()
        {
            ReviewsAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Reviews!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}