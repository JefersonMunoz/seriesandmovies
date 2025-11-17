using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PlansAplicacion : IPlansAplicacion
    {
        private IConexion? IConexion = null;

        public PlansAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Plans? Borrar(Plans? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el plan ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del plan a eliminar");

            // Operaciones
            var existente = this.IConexion!.Plans!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El plan ingresado no existe");

            this.IConexion!.Plans!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Plans? Guardar(Plans? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Plan guardado correctamente");

            // Operaciones
            bool existe = this.IConexion.Plans!.Any(a => a.Name == entidad.Name);
            if (existe)
                throw new Exception("Ya existe registro del plan");

            //if (string.IsNullOrEmpty(entidad.Name))
            //    throw new Exception("El nombre del plan es obligatorio");
            if (entidad.Name == "" && entidad.Price == null && entidad.MaxPeople == null)
                throw new Exception("Ingrese la información completa");

            this.IConexion!.Plans!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public List<Plans> Listar()
        {
            var lista = this.IConexion!.Plans!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen planes registrados.");

            return lista;
        }

        public List<Plans> PorPlan(Plans? entidad)
        {
            var lista = this.IConexion!.Plans!.Where(x => x.Description!.Contains(entidad.Description!)).ToList();

            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No existen planes que contengan la descripción.");
            }
            return lista;
        }

        public Plans? Modificar(Plans? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Plans!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el plan que intenta modificar.");

            var entry = this.IConexion!.Entry<Plans>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
