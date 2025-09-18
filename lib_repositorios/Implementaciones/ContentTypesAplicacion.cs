using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ContentTypesAplicacion : IContentTypesAplicacion
    {
        private IConexion? IConexion = null;

        public ContentTypesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ContentTypes? Borrar(ContentTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.ContentTypes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ContentTypes? Guardar(ContentTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.ContentTypes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ContentTypes> Listar()
        {
            return this.IConexion!.ContentTypes!.Take(20).ToList();
        }

        public ContentTypes? Modificar(ContentTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<ContentTypes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
