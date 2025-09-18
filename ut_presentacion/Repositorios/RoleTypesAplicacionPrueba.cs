using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class RoleTypesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly RoleTypesAplicacion? RoleTypesAplicacion;
        private RoleTypes? entidad;

        public RoleTypesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            RoleTypesAplicacion = new RoleTypesAplicacion(iConexion);
            RoleTypesAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = RoleTypesAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.RoleTypes()!;
            this.entidad = RoleTypesAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Name = "Actor";
            RoleTypesAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.RoleTypes!.Find(this.entidad.Id);
            return reloaded!.Name == "Actor";
        }

        public bool Borrar()
        {
            RoleTypesAplicacion.Borrar(this.entidad!);
            var gone = iConexion.RoleTypes!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}