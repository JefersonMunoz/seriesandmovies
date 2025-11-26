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
    public class SubtitlesController : ControllerBase
    {
        private ISubtitlesAplicacion? iAplicacion = null;
        private TokenAplicacion? iAplicacionToken = null;
        private IAuditsAplicacion? iAplicacionAudits = null;
        public SubtitlesController(ISubtitlesAplicacion? iAplicacion, TokenAplicacion iAplicacionToken, IAuditsAplicacion? iAplicacionAudits)
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
                    datos["Table"] = "Subtitles";
                    datos["Action"] = "Read";
                    iAplicacionAudits!.Guardar(datos);
                }
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string PorLanguage()
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
                var entidad = JsonConversor.ConvertirAObjeto<Subtitles>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                respuesta["Entidades"] = this.iAplicacion!.PorLanguage(entidad);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Subtitles";
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
                var entidad = JsonConversor.ConvertirAObjeto<Subtitles>(

                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                entidad = this.iAplicacion!.Guardar(entidad);
                respuesta["Respuesta"] = "Se guardó el subtítulo correctamente";
                respuesta["Entidad"] = entidad!;
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Subtitles";
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
                var entidad = JsonConversor.ConvertirAObjeto<Subtitles>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                entidad = this.iAplicacion!.Modificar(entidad);
                respuesta["Respuesta"] = "Se modificó el subtítulo correctamente";
                respuesta["Entidad"] = entidad!;
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Subtitles";
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

                var entidad = JsonConversor.ConvertirAObjeto<Subtitles>(
                JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                entidad = this.iAplicacion!.Borrar(entidad);
                respuesta["Respuesta"] = "Subtítulo eliminado correctamente";
                respuesta["Entidad"] = entidad!;
                respuesta["Fecha"] = DateTime.Now.ToString();
                //Create audits
                if (datos.ContainsKey("UserId"))
                {
                    datos["Table"] = "Subtitles";
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