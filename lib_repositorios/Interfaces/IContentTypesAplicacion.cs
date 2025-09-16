using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IContentTypesAplicacion
    {
        void Configurar(string StringConexion);

        List<ContentTypes> Listar();
        ContentTypes? Guardar(ContentTypes? entidad);
        ContentTypes? Modificar(ContentTypes? entidad);
        ContentTypes? Borrar(ContentTypes? entidad);
    }
}