using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PersonsPrueba
    {
        private readonly IConexion? iConexion;
        private List<Persons>? lista;
        private Persons? entidad;

        public PersonsPrueba()
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
            this.lista = this.iConexion!.Persons!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Persons()!;
            this.iConexion!.Persons!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            int id = 12;
            var exist = this.iConexion!.Persons!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.Persons()!;
            exist.Name = newData.Name;
            exist.Lastame = newData.Lastame;
            exist.Birthday = newData.Birthday;
            exist.Description = newData.Description;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Persons!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}