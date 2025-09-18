using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PersonTypeRolesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly PersonTypeRolesAplicacion? PersonTypeRolesAplicacion;
        private PersonTypeRoles? entidad;

        public PersonTypeRolesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            PersonTypeRolesAplicacion = new PersonTypeRolesAplicacion(iConexion);
            PersonTypeRolesAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = PersonTypeRolesAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.PersonTypeRoles()!;
            this.entidad = PersonTypeRolesAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Person = 1;
            PersonTypeRolesAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.PersonTypeRoles!.Find(this.entidad.Id);
            return reloaded!.Person == 1;
        }

        public bool Borrar()
        {
            PersonTypeRolesAplicacion.Borrar(this.entidad!);
            var gone = iConexion.PersonTypeRoles!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}