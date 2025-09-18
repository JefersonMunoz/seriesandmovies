using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Seasons!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Seasons? Guardar(Seasons? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Seasons!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Seasons> Listar()
        {
            return this.IConexion!.Seasons!.Take(20).ToList();
        }

        public Seasons? Modificar(Seasons? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Seasons>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
