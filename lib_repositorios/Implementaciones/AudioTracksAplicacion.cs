using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.AudioTracks!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public AudioTracks? Guardar(AudioTracks? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.AudioTracks!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<AudioTracks> Listar()
        {
            return this.IConexion!.AudioTracks!.Take(20).ToList();
        }

        public AudioTracks? Modificar(AudioTracks? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<AudioTracks>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
