using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class StudiosAplicacion : IStudiosAplicacion
    {
        private IConexion? IConexion = null;

        public StudiosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Studios? Borrar(Studios? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el estudio ingresada");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del estudio a eliminar");

            // Operaciones
            var existente = this.IConexion!.Studios!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El estudio ingresado no existe");

            this.IConexion!.Studios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Studios? Guardar(Studios? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Estudio guardado correctamente");

            // Operaciones
            //validar que la estudio existe
            var ciudad = this.IConexion!.Studios!.Find(entidad.Country);
            if (ciudad == null)
                throw new Exception("El estudio no existe");

            //validar estudio duplicada
            bool existe = this.IConexion.Studios!.Any(a => a.Name == entidad.Name && a.Country == entidad.Country);
            if (existe)
                throw new Exception("Ya existe resgistro del estudio");

            this.IConexion!.Studios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Studios> Listar()
        {
            var lista = this.IConexion!.Studios!.Include(a => a._Country).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen studios registrados.");

            return lista;
        }

        public List<Studios> PorDescripton(Studios? entidad)
        {
            var lista = this.IConexion!.Studios!.Include(a => a._Country).Where(x => x.Description!.Contains(entidad.Description!)).ToList();

            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No existen planes que contengan la descripción.");
            }
            return lista;
        }

        public Studios? Modificar(Studios? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Studios!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el estudio que intenta modificar.");

            //validar que el estudio existe
            var ciudad = this.IConexion!.Studios!.Find(entidad.Country);
            if (ciudad == null)
                throw new Exception("El estudio no existe");

            //validar ciudad duplicada
            bool existe = this.IConexion.Studios!.Any(a => a.Name == entidad.Name && a.Country == entidad.Country);
            if (existe)
                throw new Exception("Ya existe resgistro del estudio");

            var entry = this.IConexion!.Entry<Studios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
