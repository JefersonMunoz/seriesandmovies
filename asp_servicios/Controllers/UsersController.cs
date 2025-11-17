
using asp_servicios.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private IUsersAplicacion? iAplicacion = null;
        //private TokenController? tokenController = null;

        public UsersController(IUsersAplicacion? iAplicacion /*, TokenController tokenController*/)
        {
            this.iAplicacion = iAplicacion;
            //this.tokenController = tokenController;
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
                var datos = ObtenerDatos();
                /*if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }*/
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
        public ActionResult<string> PorName([FromBody] Users entidad)
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
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this.iAplicacion!.PorName(entidad);
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message;
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

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

                var entidad = JsonConversor.ConvertirAObjeto<Users>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Guardar(entidad);
                respuesta["Respuesta"] = "Se guardardó el usuario correctamente";
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            return JsonConversor.ConvertirAString(respuesta);
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
                var entidad = JsonConversor.ConvertirAObjeto<Users>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                entidad = this.iAplicacion!.Modificar(entidad);
                respuesta["Respuesta"] = "Se modificó el usuario correctamente";
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

                var entidad = JsonConversor.ConvertirAObjeto<Users>(
                JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                entidad = this.iAplicacion!.Borrar(entidad);
                respuesta["Respuesta"] = "Usuario eliminado correctamente";
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