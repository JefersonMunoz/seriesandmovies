using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class CountriesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly CountriesAplicacion? CountriesAplicacion;
        private Countries? entidad;

        public CountriesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            CountriesAplicacion = new CountriesAplicacion(iConexion);
            CountriesAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = CountriesAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Countries()!;
            this.entidad = CountriesAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Switzerland";
            CountriesAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Countries!.Find(this.entidad.Id);
            return reloaded!.Name == "Switzerland";
        }

        public bool Borrar()
        {
            CountriesAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Countries!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}