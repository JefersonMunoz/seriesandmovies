using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class StudiosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly StudiosAplicacion? StudiosAplicacion;
        private Studios? entidad;

        public StudiosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            StudiosAplicacion = new StudiosAplicacion(iConexion);
            StudiosAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = StudiosAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Studios()!;
            this.entidad = StudiosAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Warner";
            StudiosAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Studios!.Find(this.entidad.Id);
            return reloaded!.Name == "Warner";
        }

        public bool Borrar()
        {
            StudiosAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Studios!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}