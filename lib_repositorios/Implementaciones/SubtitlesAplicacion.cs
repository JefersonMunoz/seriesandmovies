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
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Subtitles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Subtitles? Guardar(Subtitles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Subtitles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Subtitles> Listar()
        {
            return this.IConexion!.Subtitles!.Take(20).ToList();
        }

        public Subtitles? Modificar(Subtitles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Subtitles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
