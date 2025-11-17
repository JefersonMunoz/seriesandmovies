using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IPlansAplicacion
    {
        void Configurar(string StringConexion);

        List<Plans> Listar();
        List<Plans> PorPlan(Plans? entidad);
        Plans? Guardar(Plans? entidad);
        Plans? Modificar(Plans? entidad);
        Plans? Borrar(Plans? entidad);
    }
}
