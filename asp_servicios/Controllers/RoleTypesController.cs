using asp_servicios.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoleTypesController : ControllerBase
    {
        private IRoleTypesAplicacion? iAplicacion = null;
        //private TokenController? tokenController = null;
        //private TokenAplicacion? iAplicacionToken = null;

        public RoleTypesController(IRoleTypesAplicacion? iAplicacion, TokenAplicacion iAplicacionToken /*TokenController tokenController*/)
        {
            this.iAplicacion = iAplicacion;
            //this.tokenController = tokenController;
            //this.iAplicacionToken = iAplicacionToken;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                //var datos = ObtenerDatos();
                //if (!iAplicacionToken!.Validar(datos))
                //{
                //    respuesta["Error"] = "lbNoAutenticacion";
                //    return JsonConversor.ConvertirAString(respuesta);
                //}
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                
                respuesta["Entidades"] = this.iAplicacion!.Listar();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        //public string PorAutor()
        //{
        //    var respuesta = new Dictionary<string, object>();
        //    try
        //    {
        //        var datos = ObtenerDatos();
        //        /*if (!tokenController!.Validate(datos))
        //        {
        //            respuesta["Error"] = "lbNoAutenticacion";
        //            return JsonConversor.ConvertirAString(respuesta);
        //        }*/
        //        var entidad = JsonConversor.ConvertirAObjeto<RoleTypes>(
                
        //        JsonConversor.ConvertirAString(datos["Entidad"]));
        //        this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                
        //        respuesta["Entidades"] = this.iAplicacion!.Listar();
        //        respuesta["Respuesta"] = "OK";
        //        respuesta["Fecha"] = DateTime.Now.ToString();
        //        return JsonConversor.ConvertirAString(respuesta);
        //    }
        //    catch (Exception ex)
        //    {
        //        respuesta["Error"] = ex.Message.ToString();
        //        return JsonConversor.ConvertirAString(respuesta);
        //    }
        //}

        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();                
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                var entidad = JsonConversor.ConvertirAObjeto<RoleTypes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                
                entidad = this.iAplicacion!.Guardar(entidad);
                //------------------------------------------------------------
                respuesta["Respuesta"] = "Se guardó el tipo de rol correctamente";
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
                var entidad = JsonConversor.ConvertirAObjeto<RoleTypes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                entidad = this.iAplicacion!.Modificar(entidad);
                respuesta["Respuesta"] = "Se modificó el el tipo rol correctamente";
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/

                var entidad = JsonConversor.ConvertirAObjeto<RoleTypes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                entidad = this.iAplicacion!.Borrar(entidad);
                respuesta["Respuesta"] = "Tipo rol eliminado correctamente";
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}