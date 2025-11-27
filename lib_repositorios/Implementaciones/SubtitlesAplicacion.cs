using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class SubtitlesAplicacion : ISubtitlesAplicacion
    {
        private IConexion? IConexion = null;

        public SubtitlesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Subtitles? Borrar(Subtitles? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el subtítulo ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del subtítulo a eliminar");

            // Operaciones
            var existente = this.IConexion!.Subtitles!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El subtítulo ingresado no existe");

            this.IConexion!.Subtitles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }


        public Subtitles? Guardar(Subtitles? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Subtítulo guardaddo correctamente");

            // Operaciones
            //Validar que el contenido y el lenguaje exista
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            var idioma = this.IConexion!.Languages!.Find(entidad.Language);
            if (contenido == null || idioma == null)
                throw new Exception("El contenido o el idioma no existen");

            //Validar subtítulo duplicada
            bool existe = this.IConexion.Subtitles!.Any(a => a.Content == entidad.Content && a.Language == entidad.Language);
            if (existe)
                throw new Exception("Ya existe un subtítulo con la misma información");

            //Guardar cambios
            this.IConexion!.Subtitles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }


        public List<Subtitles> Listar()
        {
            var lista = this.IConexion!.Subtitles!.Include(a => a._Content).Include(a => a._Language).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen subtítulo registrados.");

            return lista;
        }

        public List<Subtitles> PorLanguage(Subtitles? entidad)
        {
            string name = entidad!._Language!.Name!;
            var lista = this.IConexion!.Subtitles!.Include(x => x._Language).Include(a => a._Content).Where(x => x._Language!.Name!.Contains(name)).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen lenguajes que coincidan con la búsqueda.");

            return lista;
        }

        public Subtitles? Modificar(Subtitles? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Subtitles!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el subtítulo que intenta modificar.");

            //Validar que el contenido y el lenguaje exista
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            var idioma = this.IConexion!.Languages!.Find(entidad.Language);
            if (contenido == null || idioma == null)
                throw new Exception("El contenido o el idioma no existen");

            //Validar subtítulo duplicada
            bool existe = this.IConexion.Subtitles!.Any(a => a.Content == entidad.Content && a.Language == entidad.Language);
            if (existe)
                throw new Exception("Ya existe un subtítulo con la misma información");

            var entry = this.IConexion!.Entry<Subtitles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
