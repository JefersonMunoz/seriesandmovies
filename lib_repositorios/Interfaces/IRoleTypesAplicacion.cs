using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IRoleTypesAplicacion
    {
        void Configurar(string StringConexion);

        List<RoleTypes> Listar();
        RoleTypes? Guardar(RoleTypes? entidad);
        RoleTypes? Modificar(RoleTypes? entidad);
        RoleTypes? Borrar(RoleTypes? entidad);
    }
}
