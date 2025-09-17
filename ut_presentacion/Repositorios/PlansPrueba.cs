using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PlansPrueba
    {
        private readonly IConexion? iConexion;
        private List<Plans>? lista;
        private Plans? entidad;

        public PlansPrueba()
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
            this.lista = this.iConexion!.Plans!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Plans()!;
            this.iConexion!.Plans!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            int id = 3;
            var exist = this.iConexion!.Plans!.FirstOrDefault(t => t.Id == id);
            var newData = EntidadesNucleo.Plans()!;
            exist.Name = newData.Name;
            exist.Description = newData.Description;
            exist.Price = newData.Price;
            exist.MaxPeople = newData.MaxPeople;
            this.iConexion.Entry(exist).State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Plans!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}