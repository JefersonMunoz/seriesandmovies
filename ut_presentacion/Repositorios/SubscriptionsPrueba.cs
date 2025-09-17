using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class SubscriptionsPrueba
    {
        private readonly IConexion? iConexion;
        private List<Subscriptions>? lista;
        private Subscriptions? entidad;

        public SubscriptionsPrueba()
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
            this.lista = this.iConexion!.Subscriptions!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Subscriptions()!;
            this.iConexion!.Subscriptions!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            int id = 4;
            var exist = this.iConexion!.Subscriptions!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.Subscriptions()!;
            exist.User = newData.User;
            exist.Plan = newData.Plan;
            exist.StartedAt = newData.StartedAt;
            exist.FinishedAt = newData.FinishedAt;
            exist.StartedAt = newData.StartedAt;
            exist.Price = newData.Price;
            exist.Months = newData.Months;
            exist.Status = newData.Status;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Subscriptions!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}