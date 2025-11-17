using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                throw new Exception("No se encontró el tipo de genero ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del tipo de genero  a eliminar");

            // Operaciones
            var existente = this.IConexion!.GenreTypes!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El tipo de género ingresado no existe");

            this.IConexion!.GenreTypes!.Remove(entidad);
            //this.IConexion!.Audits!.Add(new Audits()
            //{
            //    User = 1,
            //    Action = "DELETE",
            //    Table = "GENRETYPES",
            //    Date = DateTime.Now
            //});
            this.IConexion.SaveChanges();
            return entidad;
        }

        public GenreTypes? Guardar(GenreTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            if (entidad.Id != 0)
                throw new Exception("Tipo de genero guardado correctamente");

            // Operaciones
            
            bool existe = this.IConexion.GenreTypes!.Any(a => a.Name == entidad.Name);
            if (existe)
                throw new Exception("Ya existe registro con el tipo de contenido");

            if (string.IsNullOrEmpty(entidad.Name))
                throw new Exception("El nombre de tipo género es obligatorio");

            this.IConexion!.GenreTypes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<GenreTypes> Listar()
        {
            var lista = this.IConexion!.GenreTypes!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existe tipo de genero registrados.");

            return lista;
        }

        public GenreTypes? Modificar(GenreTypes? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            var existente = this.IConexion.GenreTypes!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el tipo de genero que intenta modificar.");

            var entry = this.IConexion!.Entry<GenreTypes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
