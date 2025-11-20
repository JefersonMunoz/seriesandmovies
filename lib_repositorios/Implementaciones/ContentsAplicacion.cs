using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class ContentsAplicacion : IContentsAplicacion
    {
        private IConexion? IConexion = null;

        public ContentsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Contents? Borrar(Contents? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el contenido ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del contenido a eliminar");

            // Operaciones
            var existente = this.IConexion!.Contents!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El Contenido ingresado no existe");

            this.IConexion!.Contents!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Contents? Guardar(Contents? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Year == null || entidad.Year > DateTime.Now)
                throw new Exception("Debe ingresar una fecha de nacimiento válida (MM/DD/YYYY)");

            if (entidad.Id != 0)
                throw new Exception("Contenido existente");

            // Operaciones
            //Validar que el tipoContenido y el lenguaje exista
            var tipoContenido = this.IConexion!.ContentTypes!.Find(entidad.ContentType);
            var idioma = this.IConexion!.Languages!.Find(entidad.Language);
            var studio = this.IConexion!.Studios!.Find(entidad.Studio);
            if (tipoContenido == null || idioma == null || studio == null)
                throw new Exception("El tipoContenido, el idioma o el estudio no existen");

        //Validar contenido duplicado
        bool existe = this.IConexion.Contents!.Any(a => a.Name == entidad.Name && a.Description == entidad.Description && a.ContentType == entidad.ContentType
                                    && a.Year == entidad.Year && a.Language == entidad.Language && a.Studio == entidad.Studio);
            if (existe)
                throw new Exception("Ya existe un contenido con la misma información");

            this.IConexion!.Contents!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Contents> Listar()
        {
            var lista = this.IConexion!.Contents!.Include(a => a._ContentType).Include(a => a._Language).Include(a => a._Studio).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen Audios registrados.");

            return lista;
        }

        public List<Contents> PorDescription(Contents? entidad)
        {
            var lista = this.IConexion!.Contents!.Include(a => a._ContentType).Include(a => a._Language).Include(a => a._Studio).Where(x => x.Description!.Contains(entidad!.Description!)).ToList();

            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No existen contenidos que contengan la descripción.");
            }
            return lista;
        }

        //public List<Contents> PorTipo(Contents? entidad)
        //{
        //    return this.IConexion!.Contents!
        //        .Where(x => x.ContentType!.Contains(entidad!.ContentType!))
        //        .Take(50)
        //        .ToList();
        //}

        public Contents? Modificar(Contents? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            if (entidad.Year == null || entidad.Year > DateTime.Now)
                throw new Exception("Debe ingresar una fecha de nacimiento válida (MM/DD/YYYY)");

            var existente = this.IConexion.Contents!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el contenido que intenta modificar.");

            var tipoContenido = this.IConexion!.ContentTypes!.Find(entidad.ContentType);
            var idioma = this.IConexion!.Languages!.Find(entidad.Language);
            var studio = this.IConexion!.Studios!.Find(entidad.Studio);
            if (tipoContenido == null || idioma == null || studio == null)
                throw new Exception("El tipoContenido, el idioma o el studio no existen");

            //Validar contenido duplicado
            bool existe = this.IConexion.Contents!.Any(a => a.Name == entidad.Name && a.Description == entidad.Description && a.ContentType == entidad.ContentType
                                    && a.Year == entidad.Year && a.Language == entidad.Language && a.Studio == entidad.Studio);
            if (existe)
                throw new Exception("Ya existe un contenido con la misma información");


            var entry = this.IConexion!.Entry<Contents>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
