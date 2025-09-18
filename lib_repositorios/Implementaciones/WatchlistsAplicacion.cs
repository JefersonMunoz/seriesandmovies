using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class WatchlistsAplicacion : IWatchlistsAplicacion
    {
        private IConexion? IConexion = null;

        public WatchlistsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Watchlists? Borrar(Watchlists? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Watchlists!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Watchlists? Guardar(Watchlists? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Watchlists!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Watchlists> Listar()
        {
            return this.IConexion!.Watchlists!.Take(20).ToList();
        }

        public Watchlists? Modificar(Watchlists? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Watchlists>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
