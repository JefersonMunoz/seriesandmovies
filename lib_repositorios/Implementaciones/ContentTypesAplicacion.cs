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
                throw new Exception("No se encontró el contenido ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del contenido a eliminar");

            // Operaciones
            var existente = this.IConexion!.ContentTypes!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El Contenido ingresado no existe");

            this.IConexion!.ContentTypes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ContentTypes? Guardar(ContentTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Contenido guardado correctamente");

            // Operaciones
            //Validar contenido duplicado
            bool existe = this.IConexion.ContentTypes!.Any(a => a.Name == entidad.Name);
            if (existe)
                throw new Exception("Ya existe registro con el tipo de contenido");

            this.IConexion!.ContentTypes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ContentTypes> Listar()
        {
            var lista = this.IConexion!.ContentTypes!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen Audios registrados.");

            return lista;
        }

        public ContentTypes? Modificar(ContentTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.ContentTypes!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el contenido que intenta modificar.");

            //Validar audio duplicada
            bool existe = this.IConexion.ContentTypes!.Any(a => a.Name == entidad.Name && a.Description == entidad.Description);
            if (existe)
                throw new Exception("Ya existe un contenido con la misma información");

            var entry = this.IConexion!.Entry<ContentTypes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
