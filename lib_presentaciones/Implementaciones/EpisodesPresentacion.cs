using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class EpisodesPresentacion : IEpisodesPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Episodes>> Listar(string llave, int UserId)
        {
            var lista = new List<Episodes>();
            var datos = new Dictionary<string, object>();
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Episodes/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Episodes>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Episodes>> PorEpisodes(Episodes? entidad, string llave, int UserId)
        {
            var lista = new List<Episodes>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Episodes/PorEpisodes");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Episodes>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Episodes?> Guardar(Episodes? entidad, string llave, int UserId)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Episodes/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Episodes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Episodes?> Modificar(Episodes? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Episodes/Modificar");
            
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Episodes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Episodes?> Borrar(Episodes? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = new { Id = entidad!.Id };
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Episodes/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Episodes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}