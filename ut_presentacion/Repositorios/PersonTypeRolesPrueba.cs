using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PersonTypeRolesPrueba
    {
        private readonly IConexion? iConexion;
        private List<PersonTypeRoles>? lista;
        private PersonTypeRoles? entidad;

        public PersonTypeRolesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
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
            this.lista = this.iConexion!.PersonTypeRoles!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.PersonTypeRoles()!;
            this.iConexion!.PersonTypeRoles!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            int id = 18;
            var exist = this.iConexion!.PersonTypeRoles!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.PersonTypeRoles()!;
            exist.Person = newData.Person;
            exist.RoleType = newData.RoleType;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.PersonTypeRoles!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}