using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class GenreTypesAplicacion : IGenreTypesAplicacion
    {
        private IConexion? IConexion = null;

        public GenreTypesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public GenreTypes? Borrar(GenreTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.GenreTypes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public GenreTypes? Guardar(GenreTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.GenreTypes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<GenreTypes> Listar()
        {
            return this.IConexion!.GenreTypes!.Take(20).ToList();
        }

        public GenreTypes? Modificar(GenreTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<GenreTypes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
