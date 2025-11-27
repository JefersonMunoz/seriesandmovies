using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_repositorios.Implementaciones
{
    public class SeasonsAplicacion : ISeasonsAplicacion
    {
        private IConexion? IConexion = null;

        public SeasonsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Seasons? Borrar(Seasons? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró la temporada ingresada");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID de la temporada a eliminar");

            // Operaciones
            var existente = this.IConexion!.Seasons!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("La reseña ingresada no existe");

            this.IConexion!.Seasons!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Seasons? Guardar(Seasons? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Temporada guardada correctamente");

            // Operaciones
            if (entidad.ReleasedAt == null || entidad.ReleasedAt > DateTime.Now)
                throw new Exception("Debe ingresar una fecha válida (MM/DD/YYYY)");

            //validar que el contenido existe
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            if (contenido == null)
                throw new Exception("El contenido no existe");

            bool existe = this.IConexion.Seasons!.Any(a => a.Title == entidad.Title && a.Content == entidad.Content && a.Description == entidad.Description);
            if (existe)
                throw new Exception("Ya existe resgistro de la temporada");

            this.IConexion!.Seasons!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Seasons> Listar()
        {
            var lista = this.IConexion!.Seasons!.Include(a => a._Content).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen temporadas registradas.");

            return lista;
        }

        public List<Seasons> PorTitle(Seasons? entidad)
        {
            var lista = this.IConexion!.Seasons!.Include(a => a._Content).Where(x => x.Title!.Contains(entidad.Title!)).ToList();

            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No existen planes que contengan la descripción.");
            }
            return lista;
        }
        public Seasons? Modificar(Seasons? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Seasons!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró la teamporada que intenta modificar.");

            //validar que el contenido existe
            var contenido = this.IConexion!.Contents!.Find(entidad.Content);
            if (contenido == null)
                throw new Exception("El contenido no existe");

            //Validar reseña duplicada
            bool existe = this.IConexion.Seasons!.Any(a => a.Title == entidad.Title && a.Content == entidad.Content && a.Description == entidad.Description);
            if (existe)
                throw new Exception("Ya existe resgistro de la temporada");

            var entry = this.IConexion!.Entry<Seasons>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
