using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IPersonsAplicacion
    {
        void Configurar(string StringConexion);

        List<Persons> Listar();
        List<Persons> PorDescription(Persons? entidad);
        Persons? Guardar(Persons? entidad);
        Persons? Modificar(Persons? entidad);
        Persons? Borrar(Persons? entidad);
    }
}
