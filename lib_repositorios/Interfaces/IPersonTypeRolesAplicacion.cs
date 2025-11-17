using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IPersonTypeRolesAplicacion
    {
        void Configurar(string StringConexion);

        List<PersonTypeRoles> Listar();
        List<PersonTypeRoles> PorTypeRoles(PersonTypeRoles? entidad);
        PersonTypeRoles? Guardar(PersonTypeRoles? entidad);
        PersonTypeRoles? Modificar(PersonTypeRoles? entidad);
        PersonTypeRoles? Borrar(PersonTypeRoles? entidad);
    }
}
