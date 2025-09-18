using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class SubscriptionsAplicacion : ISubscriptionsAplicacion
    {
        private IConexion? IConexion = null;

        public SubscriptionsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Subscriptions? Borrar(Subscriptions? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Subscriptions!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Subscriptions? Guardar(Subscriptions? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Subscriptions!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Subscriptions> Listar()
        {
            return this.IConexion!.Subscriptions!.Take(20).ToList();
        }

        public Subscriptions? Modificar(Subscriptions? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Subscriptions>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
