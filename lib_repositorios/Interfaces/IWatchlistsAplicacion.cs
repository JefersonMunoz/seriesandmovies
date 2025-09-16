using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IWatchlistsAplicacion
    {
        void Configurar(string StringConexion);

        List<Watchlists> Listar();
        Watchlists? Guardar(Watchlists? entidad);
        Watchlists? Modificar(Watchlists? entidad);
        Watchlists? Borrar(Watchlists? entidad);
    }
}