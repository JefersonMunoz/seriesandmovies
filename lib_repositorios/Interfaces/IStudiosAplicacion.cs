using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IStudiosAplicacion
    {
        void Configurar(string StringConexion);

        List<Studios> Listar();
        List<Studios> PorDescripton(Studios? entidad);
        Studios? Guardar(Studios? entidad);
        Studios? Modificar(Studios? entidad);
        Studios? Borrar(Studios? entidad);
    }
}