using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IUserAccountsAplicacion
    {
        void Configurar(string StringConexion);

        List<UserAccounts> Listar();
        UserAccounts? Guardar(UserAccounts? entidad);
        UserAccounts? Modificar(UserAccounts? entidad);
        UserAccounts? Borrar(UserAccounts? entidad);
    }
}
