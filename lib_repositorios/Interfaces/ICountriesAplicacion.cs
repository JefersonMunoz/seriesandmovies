using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface ICountriesAplicacion
    {
        void Configurar(string StringConexion);
        List<Countries> Listar();
        Countries? Guardar(Countries? entidad);
        Countries? Modificar(Countries? entidad);
        Countries? Borrar(Countries? entidad);
    }
}
