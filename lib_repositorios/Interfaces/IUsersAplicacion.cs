using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IUsersAplicacion
    {
        void Configurar(string StringConexion);

        List<Users> Listar();
        List<Users> PorName(Users? entidad);
        Users? Guardar(Users? entidad);
        Users? Modificar(Users? entidad);
        Users? Borrar(Users? entidad);
    }
}
