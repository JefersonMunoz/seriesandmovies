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
                throw new Exception("No se encontró la lista de reproducción ingresada");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID de la lista de reproducción a eliminar");

            // Operaciones
            var existente = this.IConexion!.Watchlists!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("La lista de reproducción ingresada no existe");

            this.IConexion!.Watchlists!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Watchlists? Guardar(Watchlists? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Lista de reproducción guardada correctamente");

            //Validar que el usuario y el contenido exista
            var usuario = this.IConexion!.UserAccounts!.Find(entidad.User);
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            if (usuario == null || contenido == null)
                throw new Exception("El usuario o contenido no existe");

            //Validar lista duplicada
            bool existe = this.IConexion.Watchlists!.Any(a => a.User == entidad.User && a.Content == entidad.Content);
            if (existe)
                throw new Exception("Ya existe una Lista de reproducción del usuario para el mismo contenido");

            this.IConexion!.Watchlists!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Watchlists> Listar()
        {
            var lista = this.IConexion!.Watchlists!.Include(a => a._User).Include(a => a._Content).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen lista de reproducción registradas.");

            return lista;
        }

        public List<Watchlists> PorUser(Watchlists? entidad)
        {
            string name = entidad!._User!.Name!;
            var lista = this.IConexion!.Watchlists!.Include(x => x._User).Include(a => a._Content).Where(x => x._User!.Name!.Contains(name)).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen lista de reproducción que coincidan con la búsqueda.");

            return lista;
        }

        public Watchlists? Modificar(Watchlists? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Watchlists!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró la lista de reproducción que intenta modificar.");

            //Validar que el usuario y el contenido exista
            var usuario = this.IConexion!.UserAccounts!.Find(entidad.User);
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            if (usuario == null || contenido == null)
                throw new Exception("El usuario o contenido no existe");

            //Validar lista duplicada
            bool existe = this.IConexion.Watchlists!.Any(a => a.User == entidad.User && a.Content == entidad.Content);
            if (existe)
                throw new Exception("Ya existe una lista de reproducción del usuario para el mismo contenido película");

            var entry = this.IConexion!.Entry<Watchlists>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
