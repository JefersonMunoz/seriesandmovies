using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class RoleTypesAplicacion : IRoleTypesAplicacion
    {
        private IConexion? IConexion = null;

        public RoleTypesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public RoleTypes? Borrar(RoleTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("No se encontró el tipo de rol ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del tipo de rol a eliminar");

            // Operaciones
            var existente = this.IConexion!.RoleTypes!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El tipo de rol ingresado no existe");

            this.IConexion!.RoleTypes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public RoleTypes? Guardar(RoleTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Tipo de rol guardado correctamente");

            // Operaciones
            //Validar contenido duplicado
            bool existe = this.IConexion.RoleTypes!.Any(a => a.Name == entidad.Name);
            if (existe)
                throw new Exception("Ya existe tipo de rol");

            this.IConexion!.RoleTypes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<RoleTypes> Listar()
        {
            var lista = this.IConexion!.RoleTypes!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen Audios registrados.");

            return lista;
        }

        public RoleTypes? Modificar(RoleTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion!.RoleTypes!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El tipo de rol ingresado no existe");

            bool existe = this.IConexion.RoleTypes!.Any(a => a.Name == entidad.Name);
            if (existe)
                throw new Exception("Ya existe tipo de rol");

            var entry = this.IConexion!.Entry<RoleTypes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
