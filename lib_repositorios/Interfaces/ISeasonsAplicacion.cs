using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface ISeasonsAplicacion
    {
        void Configurar(string StringConexion);

        List<Seasons> Listar();
        Seasons? Guardar(Seasons? entidad);
        Seasons? Modificar(Seasons? entidad);
        Seasons? Borrar(Seasons? entidad);
    }
}
