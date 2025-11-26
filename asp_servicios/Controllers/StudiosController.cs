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
    public class StudiosController : ControllerBase
    {
        private IStudiosAplicacion? iAplicacion = null;
        private TokenAplicacion? iAplicacionToken = null;
        private IAuditsAplicacion? iAplicacionAudits = null;
        public StudiosController(IStudiosAplicacion? iAplicacion, TokenAplicacion iAplicacionToken, IAuditsAplicacion iAplicacionAudits)
        {
            this.iAplicacion = iAplicacion;
            this.iAplicacionToken = iAplicacionToken;
            this.iAplicacionAudits = iAplicacionAudits;
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
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this.iAplicacion!.Listar();
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Studios";
                    datos["Action"] = "Read";
                    iAplicacionAudits!.Guardar(datos);
                }
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string PorDescripton()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Studios>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this.iAplicacion!.PorDescripton(entidad);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Studios";
                    datos["Action"] = "Read";
                    iAplicacionAudits!.Guardar(datos);
                }
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
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
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Studios>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Guardar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Studios";
                    datos["Action"] = "Insert";
                    iAplicacionAudits!.Guardar(datos);
                }
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
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
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Studios>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Modificar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Studios";
                    datos["Action"] = "Update";
                    iAplicacionAudits!.Guardar(datos);
                }
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
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
                var entidad = JsonConversor.ConvertirAObjeto<Studios>(
                JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Borrar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Studios";
                    datos["Action"] = "Delete";
                    iAplicacionAudits!.Guardar(datos);
                }
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}