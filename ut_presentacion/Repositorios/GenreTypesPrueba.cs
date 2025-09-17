using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class GenreTypesPrueba
    {
        private readonly IConexion? iConexion;
        private List<GenreTypes>? lista;
        private GenreTypes? entidad;

        public GenreTypesPrueba()
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
            this.lista = this.iConexion!.GenreTypes!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.GenreTypes()!;
            this.iConexion!.GenreTypes!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            int id = 10;
            var exist = this.iConexion!.GenreTypes!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.GenreTypes()!;
            exist.Name = newData.Name;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.GenreTypes!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}