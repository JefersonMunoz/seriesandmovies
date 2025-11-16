using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class CountriesAplicacion : ICountriesAplicacion
    {
        private IConexion? IConexion = null;

        public CountriesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Countries? Borrar(Countries? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró la ciudad ingresada");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID de la ciudad a eliminar");

            // Operaciones
            var existente = this.IConexion!.Countries!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("La ciudad ingresada no existe");

            this.IConexion!.Countries!.Attach(entidad);
            this.IConexion!.Countries!.Remove(entidad);
            this.IConexion.SaveChanges();
            return existente;
        }

        public Countries? Guardar(Countries? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Ciudad guardada correctamente");

            // Operaciones
            bool existe = this.IConexion.Countries!.Any(a => a.Name == entidad.Name);
            if (existe)
                throw new Exception("La ciudad ya existe");

            this.IConexion!.Countries!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Countries> Listar()
        {
            var lista = this.IConexion!.Countries!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen Audios registrados.");

            return lista;
        }

        public Countries? Modificar(Countries? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Countries!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró la ciudad que intenta modificar.");

            //Validar ciudad duplicada
            bool existe = this.IConexion.Countries!.Any(a => a.Name == entidad.Name && a.Code == entidad.Code);
            if (existe)
                throw new Exception("Ya existe una ciudad con la misma información");

            var entry = this.IConexion!.Entry<Countries>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
