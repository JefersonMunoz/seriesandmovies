using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IContentGenresAplicacion
    {
        void Configurar(string StringConexion);

        List<ContentGenres> Listar();
        List<ContentGenres> PorGenreType(ContentGenres? entidad);
        ContentGenres? Guardar(ContentGenres? entidad);
        ContentGenres? Modificar(ContentGenres? entidad);
        ContentGenres? Borrar(ContentGenres? entidad);
    }
}