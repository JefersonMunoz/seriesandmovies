using lib_dominio.Nucleo;
using System.Collections.Generic;
using System.Net.Http; // Added for HttpClient
using System.Threading.Tasks; // Added for async/await

namespace lib_presentaciones
{
    public class Comunicaciones
    {
        private string? URL = string.Empty;
        // private string? llave = null; 

        public Comunicaciones(string url = "http://localhost:5123/")
        {
            URL = url;
        }

        public Dictionary<string, object> ConstruirUrl(Dictionary<string, object> data, string Metodo)
        {
            data["Url"] = URL + Metodo;
            data["UrlLlave"] = URL + "Token/Llave";
            return data;
        }

        public async Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos, string llave, int UserId)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                if (string.IsNullOrEmpty(llave))
                {
                    respuesta.Add("Error", "lbErrorComunicacion: Llave no proporcionada");
                    return respuesta;
                }

                var url = datos["Url"].ToString();
                datos.Remove("Url");
                datos.Remove("UrlLlave");
                datos["Llave"] = llave;
                datos["UserId"] = UserId;
                var stringData = JsonConversor.ConvertirAString(datos);

                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 4, 0);
                var message = await httpClient.PostAsync(url, new StringContent(stringData));
                if (!message.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                var resp = await message.Content.ReadAsStringAsync();
                httpClient.Dispose(); httpClient = null;
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                //resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }

        public async Task<Dictionary<string, object>> ObtenerLlave(string username, string password)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var url = URL + "Token/Llave";
                var temp = new Dictionary<string, object>();
                temp["Entidad"] = new Dictionary<string, object>()
                {
                    { "Username", username },
                    { "Password", password }
                };
                var stringData = JsonConversor.ConvertirAString(temp);

                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 1, 0);
                var mensaje = await httpClient.PostAsync(url, new StringContent(stringData));
                if (!mensaje.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                var resp = await mensaje.Content.ReadAsStringAsync();
                httpClient.Dispose(); httpClient = null;
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);

                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }

        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
            .Replace("\\r\\n", "")
            .Replace("\\", "")
            .Replace("\\\"", "\"")
            .Replace("\"", "'")
            .Replace("'[", "[")
            .Replace("]'", "]")
            .Replace("'{'", "{'")
            .Replace("\\\\", "\\")
            .Replace("'}'", "'}")
            .Replace("}'", "}")
            .Replace("\\n", "")
            .Replace("\\r", "")
            .Replace(" ", "")
            .Replace("'{", "{")
            .Replace("\"", "")
            .Replace(" ", "")
            .Replace("null", "''");
        }
    }
}