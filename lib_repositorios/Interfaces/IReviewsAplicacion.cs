using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IReviewsAplicacion
    {
        void Configurar(string StringConexion);

        List<Reviews> Listar();
        List<Reviews> PorContent(Reviews? entidad);
        Reviews? Guardar(Reviews? entidad);
        Reviews? Modificar(Reviews? entidad);
        Reviews? Borrar(Reviews? entidad);
    }
}
