using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class LanguagesAplicacion : ILanguagesAplicacion
    {
        private IConexion? IConexion = null;

        public LanguagesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Languages? Borrar(Languages? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el lenguaje ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del lenguaje  a eliminar");

            // Operaciones
            var existente = this.IConexion!.Languages!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El lenguaje ingresado no existe");

            this.IConexion!.Languages!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Languages? Guardar(Languages? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Lenguaje guardado correctamente");

            // Operaciones

            bool existe = this.IConexion.Languages!.Any(a => a.Name == entidad.Name);
            if (existe)
                throw new Exception("Ya existe registro con el lenguaje");

            if (string.IsNullOrEmpty(entidad.Name))
                throw new Exception("El lenguaje es obligatorio");

            this.IConexion!.Languages!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Languages> Listar()
        {
            var lista = this.IConexion!.Languages!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existe lenguaje registrados.");

            return lista;
        }

        public Languages? Modificar(Languages? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.Languages!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el lenguaje que intenta modificar.");

            var entry = this.IConexion!.Entry<Languages>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
