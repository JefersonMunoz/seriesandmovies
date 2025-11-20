using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IContentsAplicacion
    {
        void Configurar(string StringConexion);

        List<Contents> Listar();
        List<Contents> PorDescription(Contents? entidad);
        //List<Contents> PorTipo(Contents? entidad);
        Contents? Guardar(Contents? entidad);
        Contents? Modificar(Contents? entidad);
        Contents? Borrar(Contents? entidad);
    }
}
