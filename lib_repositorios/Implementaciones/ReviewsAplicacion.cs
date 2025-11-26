using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ReviewsAplicacion : IReviewsAplicacion
    {
        private IConexion? IConexion = null;

        public ReviewsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Reviews? Borrar(Reviews? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró la reseña ingresada");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID de la reseña a eliminar");

            // Operaciones
            var existente = this.IConexion!.Reviews!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("La reseña ingresada no existe");

            this.IConexion!.Reviews!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Reviews? Guardar(Reviews? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Reseña guardada correctamente");

            // Operaciones
            if (entidad.CreatedAt == null || entidad.CreatedAt > DateTime.Now)
                throw new Exception("Debe ingresar una fecha de válida (MM/DD/YYYY)");

            //Validar que el usuario y el contenido exista
            var usuario = this.IConexion!.UserAccounts!.Find(entidad.User);
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            if (usuario == null || contenido == null)
                throw new Exception("Debe ingresar el usuario o contenido");

            //Validar reseña duplicada
            bool existe = this.IConexion.Reviews!.Any(a => a.User == entidad.User && a.Content == entidad.Content);
            if (existe)
            throw new Exception("Ya existe una reseña del usuario para el mismo contenido película");
            
            this.IConexion!.Reviews!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Reviews> Listar()
        {
            var lista = this.IConexion!.Reviews!.Include(a => a._User).Include(a => a._Content).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen reseñas registradas.");

            return lista;
        }

        public List<Reviews> PorContent(Reviews? entidad)
        {
            string name = entidad!._Content!.Name!;
            var lista = this.IConexion!.Reviews!.Include(x => x._Content).Include(a => a._User).Where(x => x._Content!.Name!.Contains(name)).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen reseñas que coincidan con la búsqueda.");

            return lista;
        }

        public Reviews? Modificar(Reviews? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Reviews!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró la reseña que intenta modificar.");

            //Validar que el usuario y el contenido exista
            var usuario = this.IConexion!.UserAccounts!.Find(entidad.User);
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            if (usuario == null || contenido == null)
                throw new Exception("El usuario o contenido no existe");

            //Validar reseña duplicada
            bool existe = this.IConexion.Reviews!.Any(a => a.User == entidad.User && a.Content == entidad.Content);
            if (existe)
            throw new Exception("Ya existe una reseña del usuario para el mismo contenido película");

            var entry = this.IConexion!.Entry<Reviews>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
