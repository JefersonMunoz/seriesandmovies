using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                throw new Exception("No se encontró el Episorio ingresado");

            if (entidad!.Id == 0)
                throw new Exception("Debe especificar el ID del episodio a eliminar");

            // Operaciones
            var existente = this.IConexion!.Episodes!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("El episodio ingresado no existe");

            this.IConexion!.Episodes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Episodes? Guardar(Episodes? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            // Operaciones
            //if (entidad.ReleasedAt == null || entidad.ReleasedAt > DateTime.Now)
            //    throw new Exception("Debe ingresar una fecha de nacimiento válida (MMMM/DD/YY)");

            if (entidad.DurationTime == default(TimeOnly))
                throw new Exception("Debe ingresar la duración del episodio");

            bool existe = this.IConexion.Episodes!.Any(a => a.Title == entidad.Title);
            if (existe)
                throw new Exception("Ya existe registro del episodio");

            this.IConexion!.Episodes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Episodes> Listar()
        {
            var lista = this.IConexion!.Episodes!.ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen episodios registrados.");

            return lista;
        }

        public List<Episodes> PorEpisodes(Episodes? entidad)
        {
            var lista = this.IConexion!.Episodes!.Where(x => x.Description!.Contains(entidad.Description!)).ToList();

            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No existen episodios que contengan la descripción.");
            }
            return lista;
        }

        public Episodes? Modificar(Episodes? entidad)
        {
            if (entidad == null)
                throw new Exception("Ingrese toda la información");

            var existente = this.IConexion.Episodes!.Find(entidad.Id);
            if (existente == null)
                throw new Exception("No se encontró el episodio que intenta modificar.");
            
            //Validar que el registro existe
            bool existe = this.IConexion.Episodes!.Any(a => a.Title == entidad.Title && a.Id != entidad.Id);
            if (existe)
                throw new Exception("Ya existe registro del episodio");

            var entry = this.IConexion!.Entry<Episodes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
