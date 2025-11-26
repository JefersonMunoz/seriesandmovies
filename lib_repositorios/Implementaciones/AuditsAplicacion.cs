
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace lib_repositorios.Implementaciones
{
    public class AuditsAplicacion : IAuditsAplicacion
    {
        private IConexion? IConexion = null;

        public AuditsAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        //public Audits? Borrar(Audits? entidad)
        //{
        //    if (entidad == null)
        //        throw new Exception("No se encontró la auditoria ingresada");

        //    if (entidad!.Id == 0)
        //        throw new Exception("Debe especificar el ID de la auditoria a eliminar");

        //    // Operaciones
        //    var existente = this.IConexion!.Audits!.Find(entidad.Id);
        //    if (existente == null)
        //        throw new Exception("La auditoria ingresada no existe");

        //    this.IConexion!.Audits!.Remove(entidad);
        //    this.IConexion.SaveChanges();
        //    return entidad;
        //}
        public List<Audits> Listar()
        {
            var lista = this.IConexion!.Audits!.Include(a => a._User).ToList();

            if (lista == null || lista.Count == 0)
                throw new Exception("No existen auditorias registradas.");

            return lista;
        }

        public Audits? Guardar(Dictionary<string, object> datos)
        {
            if (datos["UserId"] == null)
                throw new Exception("Id requerido para la auditoria");

            // Operaciones
            //Validar que el usuario exista
            var auditoria = this.IConexion!.Users!.Find(Convert.ToInt32(datos["UserId"]));
            if (auditoria != null)
            {

                var audit = new Audits()
                {
                    User = Convert.ToInt32(datos["UserId"]), //Tomar usuario que realizó la acción
                    Action = datos["Action"].ToString(),
                    Table = datos["Table"].ToString(),
                    Date = DateTime.Now
                };
                //Guardar cambios
                this.IConexion!.Audits!.Add(audit);
                this.IConexion.SaveChanges();
                return audit;
            }
            return new Audits();
        }

        public List<Audits> porAction(Audits? entidad)
        {
            return this.IConexion!.Audits!.Where(x => x.Action!.Contains(entidad!.Action!)).ToList();
        }

    }
}