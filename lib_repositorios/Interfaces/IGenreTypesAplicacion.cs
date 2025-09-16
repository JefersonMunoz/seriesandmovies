using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IGenreTypesAplicacion
    {
        void Configurar(string StringConexion);

        List<GenreTypes> Listar();
        GenreTypes? Guardar(GenreTypes? entidad);
        GenreTypes? Modificar(GenreTypes? entidad);
        GenreTypes? Borrar(GenreTypes? entidad);
    }
}
