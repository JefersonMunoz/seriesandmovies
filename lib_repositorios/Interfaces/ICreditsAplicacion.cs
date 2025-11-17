using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface ICreditsAplicacion
    {
        void Configurar(string StringConexion);

        List<Credits> Listar();
        List<Credits> PorPersons(Credits? entidad);
        Credits? Guardar(Credits? entidad);
        Credits? Modificar(Credits? entidad);
        Credits? Borrar(Credits? entidad);
    }
}
