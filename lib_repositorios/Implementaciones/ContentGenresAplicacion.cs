using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ContentGenresAplicacion : IContentGenresAplicacion
    {
        private IConexion? IConexion = null;

        public ContentGenresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ContentGenres? Borrar(ContentGenres? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el audio ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del audio a eliminar");

            // Operaciones
            var existente = this.IConexion!.ContentGenres!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El contenido ingresado no existe");

            this.IConexion!.ContentGenres!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ContentGenres? Guardar(ContentGenres? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Contenido guardaddo correctamente");

            // Operaciones
            //Validar que el contenido y el tipo de contenido exista
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            var genero = this.IConexion!.GenreTypes!.Find(entidad.GenreType);
            if (contenido == null || genero == null)
                throw new Exception("El contenido o el tipo de contenido no existen");

            //Validar audio duplicada
            bool existe = this.IConexion.ContentGenres!.Any(a => a.Content == entidad.Content && a.GenreType == entidad.GenreType);
            if (existe)
                throw new Exception("Ya existe un contenido con la misma información");

            //Guardar cambios
            this.IConexion!.ContentGenres!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ContentGenres> Listar()
        {
            var lista = this.IConexion!.ContentGenres!.Include(a => a._Content).Include(a => a._GenreType).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen Audios registrados.");

            return lista;
        }

        public ContentGenres? Modificar(ContentGenres? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            //if (entidad!.Id == 0)
            //    throw new Exception("lbNoSeGuardo");

            // Operaciones
            var existente = this.IConexion.ContentGenres!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el contenido que intenta modificar.");

            //Validar que el contenido y el lenguaje exista
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            var idioma = this.IConexion!.GenreTypes!.Find(entidad.GenreType);
            if (contenido == null || idioma == null)
                throw new Exception("El contenido o el tipo de genero no existen");

            //Validar audio duplicada
            bool existe = this.IConexion.ContentGenres!.Any(a => a.Content == entidad.Content && a.GenreType == entidad.GenreType);
            if (existe)
                throw new Exception("Ya existe un contenido con la misma información");


            var entry = this.IConexion!.Entry<ContentGenres>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
