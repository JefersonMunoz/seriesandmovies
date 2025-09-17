using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ReviewsPrueba
    {
        private readonly IConexion? iConexion;
        private List<Reviews>? lista;
        private Reviews? entidad;

        public ReviewsPrueba()
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
            this.lista = this.iConexion!.Reviews!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Reviews()!;
            this.iConexion!.Reviews!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            int id = 7;
            var exist = this.iConexion!.Reviews!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.Reviews()!;
            exist.User = newData.User;
            exist.Comment = newData.Comment;
            exist.Rating = newData.Rating;
            exist.CreatedAt = newData.CreatedAt;
            exist.Content = newData.Content;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Reviews!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}