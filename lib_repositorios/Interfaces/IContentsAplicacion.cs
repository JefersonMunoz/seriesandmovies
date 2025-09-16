using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IContentsAplicacion
    {
        void Configurar(string StringConexion);

        List<Contents> Listar();
        Contents? Guardar(Contents? entidad);
        Contents? Modificar(Contents? entidad);
        Contents? Borrar(Contents? entidad);
    }
}
