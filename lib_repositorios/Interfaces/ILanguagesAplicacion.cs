using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface ILanguagesAplicacion
    {
        void Configurar(string StringConexion);

        List<Languages> Listar();
        Languages? Guardar(Languages? entidad);
        Languages? Modificar(Languages? entidad);
        Languages? Borrar(Languages? entidad);
    }
}