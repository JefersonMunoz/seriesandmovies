using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface ISubtitlesAplicacion
    {
        void Configurar(string StringConexion);

        List<Subtitles> Listar();
        Subtitles? Guardar(Subtitles? entidad);
        Subtitles? Modificar(Subtitles? entidad);
        Subtitles? Borrar(Subtitles? entidad);
    }
}
