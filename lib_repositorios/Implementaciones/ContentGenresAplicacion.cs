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
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.ContentGenres!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ContentGenres? Guardar(ContentGenres? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.ContentGenres!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ContentGenres> Listar()
        {
            return this.IConexion!.ContentGenres!.Take(20).ToList();
        }

        public ContentGenres? Modificar(ContentGenres? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<ContentGenres>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
