using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ReviewsAplicacion : IReviewsAplicacion
    {
        private IConexion? IConexion = null;

        public ReviewsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Reviews? Borrar(Reviews? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Reviews!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Reviews? Guardar(Reviews? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Reviews!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Reviews> Listar()
        {
            return this.IConexion!.Reviews!.Take(20).ToList();
        }

        public Reviews? Modificar(Reviews? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Reviews>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
