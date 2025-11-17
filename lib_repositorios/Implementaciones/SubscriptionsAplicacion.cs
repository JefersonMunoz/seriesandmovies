using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
                throw new Exception("No se encontró la suscripción ingresada");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID de la suscripción a eliminar");

            // Operaciones
            var existente = this.IConexion!.Subscriptions!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("La suscripción ingresada no existe");

            if (existente.Status == true)
                throw new Exception("No se puede eliminar una suscripción activa");

            var entry = this.IConexion!.Subscriptions!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Subscriptions? Guardar(Subscriptions? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad!.Id != 0)
                throw new Exception("Subscripción guardada correctamente");

            // Operaciones
            if (entidad.StartedAt == null || entidad.FinishedAt == null)
                throw new Exception("Debe ingresar una fecha válida (MM/DD/YYYY)");

            if (entidad.FinishedAt < entidad.StartedAt)
                throw new Exception("La fecha final no puede ser menor que la fecha inicial.");

            if (entidad.User == null || entidad.Plan == null)
                throw new Exception("Debe ingresar el usuario o plan");

            //validar que usuario y el plan existan existe
            var usuario = this.IConexion!.UserAccounts!.Find(entidad.User);
            var plan = this.IConexion!.Plans!.Find(entidad.Plan);
            if (usuario == null || plan == null)
                throw new Exception("El usuario o plan no existe");

            bool existe = this.IConexion.Subscriptions!.Any(a => a.User == entidad.User && a.Plan == entidad.Plan);
            if (existe)
                throw new Exception("Ya existe resgistro del usuario para esta suscripción");

            this.IConexion!.Subscriptions!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Subscriptions> Listar()
        {
            var lista = this.IConexion!.Subscriptions!.Include(a => a._User).Include(a => a._Plan).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen suscripciones registradas.");

            return lista;
        }

        public List<Subscriptions> PorPlan(Subscriptions? entidad)
        {
            string name = entidad!._Plan!.Name!;
            var lista = this.IConexion!.Subscriptions!.Include(x => x._Plan).Where(x => x._Plan!.Name!.Contains(name)).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen suscripciones que coincidan con la búsqueda.");

            return lista;
        }


        public Subscriptions? Modificar(Subscriptions? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Subscriptions!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró la suscripción que intenta modificar.");

            if (entidad.StartedAt == null || entidad.FinishedAt == null)
                throw new Exception("Debe ingresar una fecha válida (MM/DD/YYYY)");

            if (entidad.FinishedAt < entidad.StartedAt)
                throw new Exception("La fecha final no puede ser menor que la fecha inicial.");

            //validar que usuario y el plan existan existe
            var usuario = this.IConexion!.UserAccounts!.Find(entidad.User);
            var plan = this.IConexion!.Plans!.Find(entidad.Plan);
            if (usuario == null || plan == null)
                throw new Exception("El usuario o plan no existe");

            //Validar suscripción duplicada
            //bool existe = this.IConexion.Subscriptions!.Any(a => a.User == entidad.User && a.Plan == entidad.Plan);
            //if (existe)
            //    throw new Exception("Ya existe resgistro del usuario para esta suscripción");

            var entry = this.IConexion!.Entry<Subscriptions>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
