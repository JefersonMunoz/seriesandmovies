using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PersonsAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly PersonsAplicacion? PersonsAplicacion;
        private Persons? entidad;

        public PersonsAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            PersonsAplicacion = new PersonsAplicacion(iConexion);
            PersonsAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = PersonsAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Persons()!;
            this.entidad = PersonsAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Marcela";
            PersonsAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Persons!.Find(this.entidad.Id);
            return reloaded!.Name == "Marcela";
        }

        public bool Borrar()
        {
            PersonsAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Persons!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}