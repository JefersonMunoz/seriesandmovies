using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class WatchlistsPrueba
    {
        private readonly IConexion? iConexion;
        private List<Watchlists>? lista;
        private Watchlists? entidad;

        public WatchlistsPrueba()
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
            this.lista = this.iConexion!.Watchlists!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Watchlists()!;
            this.iConexion!.Watchlists!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            int id = 5;
            var exist = this.iConexion!.Watchlists!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.Watchlists()!;
            exist.User = newData.User;
            exist.Content = newData.Content;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Watchlists!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}