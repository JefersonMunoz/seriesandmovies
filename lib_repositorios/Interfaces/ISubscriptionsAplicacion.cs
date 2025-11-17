using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface ISubscriptionsAplicacion
    {
        void Configurar(string StringConexion);

        List<Subscriptions> Listar();
        List<Subscriptions> PorPlan(Subscriptions? entidad);
        Subscriptions? Guardar(Subscriptions? entidad);
        Subscriptions? Modificar(Subscriptions? entidad);
        Subscriptions? Borrar(Subscriptions? entidad);
    }
}
