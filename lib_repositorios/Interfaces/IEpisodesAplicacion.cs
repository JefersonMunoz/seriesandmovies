using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IEpisodesAplicacion
    {
        void Configurar(string StringConexion);

        List<Episodes> Listar();
        List<Episodes> PorEpisodes(Episodes? entidad);
        Episodes? Guardar(Episodes? entidad);
        Episodes? Modificar(Episodes? entidad);
        Episodes? Borrar(Episodes? entidad);
    }
}