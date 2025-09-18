using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class GenreTypesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly GenreTypesAplicacion? GenreTypesAplicacion;
        private GenreTypes? entidad;

        public GenreTypesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            GenreTypesAplicacion = new GenreTypesAplicacion(iConexion);
            GenreTypesAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = GenreTypesAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.GenreTypes()!;
            this.entidad = GenreTypesAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Suspenso";
            GenreTypesAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.GenreTypes!.Find(this.entidad.Id);
            return reloaded!.Name == "Suspenso";
        }

        public bool Borrar()
        {
            GenreTypesAplicacion.Borrar(this.entidad!);
            var gone = iConexion.GenreTypes!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}