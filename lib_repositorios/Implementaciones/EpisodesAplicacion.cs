using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class EpisodesAplicacion : IEpisodesAplicacion
    {
        private IConexion? IConexion = null;

        public EpisodesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Episodes? Borrar(Episodes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Episodes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Episodes? Guardar(Episodes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Episodes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Episodes> Listar()
        {
            return this.IConexion!.Episodes!.Take(20).ToList();
        }

        public Episodes? Modificar(Episodes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Episodes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
