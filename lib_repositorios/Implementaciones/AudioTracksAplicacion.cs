using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class AudioTracksAplicacion : IAudioTracksAplicacion
    {
        private IConexion? IConexion = null;

        public AudioTracksAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public AudioTracks? Borrar(AudioTracks? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el audio ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del audio a eliminar");

            // Operaciones
            var existente = this.IConexion!.AudioTracks!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El audio ingresado no existe");
            
            this.IConexion!.AudioTracks!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }


        public AudioTracks? Guardar(AudioTracks? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Audio guardaddo correctamente");

            // Operaciones
            //Validar que el contenido y el lenguaje exista
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            var idioma = this.IConexion!.Languages!.Find(entidad.Language);
            if (contenido == null || idioma == null)
                throw new Exception("El contenido o el idioma no existen");

            //Validar audio duplicada
            bool existe = this.IConexion.AudioTracks!.Any(a => a.Content == entidad.Content && a.Language == entidad.Language);
            if (existe)
               throw new Exception("Ya existe un audio con la misma información");

            //Guardar cambios
            this.IConexion!.AudioTracks!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }


        public List<AudioTracks> Listar()
        {
            var lista = this.IConexion!.AudioTracks!.Include(a => a._Content).Include(a => a._Language).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen Audios registrados.");

            return lista;
        }

        public List<AudioTracks> PorLanguage(AudioTracks? entidad)
        {
            string name = entidad!._Language!.Name!;
            var lista = this.IConexion!.AudioTracks!.Include(x => x._Language).Include(a => a._Content).Where(x => x._Language!.Name!.Contains(name)).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen lenguajes que coincidan con la búsqueda.");

            return lista;
        }

        public AudioTracks? Modificar(AudioTracks? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.AudioTracks!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el audio que intenta modificar.");

            //Validar que el contenido y el lenguaje exista
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            var idioma = this.IConexion!.Languages!.Find(entidad.Language);
            if (contenido == null || idioma == null)
                throw new Exception("El contenido o el idioma no existen");

            //Validar audio duplicada
            bool existe = this.IConexion.AudioTracks!.Any(a => a.Content == entidad.Content && a.Language == entidad.Language);
            if (existe)
                throw new Exception("Ya existe un audio con la misma información");

            var entry = this.IConexion!.Entry<AudioTracks>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
