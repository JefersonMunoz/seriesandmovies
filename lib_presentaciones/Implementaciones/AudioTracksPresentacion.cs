using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using System.Collections.Generic;

namespace lib_presentaciones.Implementaciones
{
    public class AudioTracksPresentacion : IAudioTracksPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<AudioTracks>> Listar(string llave, int UserId)
        {
            var lista = new List<AudioTracks>();
            var datos = new Dictionary<string, object>();
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "AudioTracks/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<AudioTracks>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<AudioTracks>> AudioTracks(string llave, int UserId)
        {
            var lista = new List<AudioTracks>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "AudioTracks/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<AudioTracks>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Contents>> Contents(string llave, int UserId)
        {
            var lista = new List<Contents>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Contents/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Contents>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Languages>> Languages(string llave, int UserId)
        {
            var lista = new List<Languages>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Languages/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Languages>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<AudioTracks>> PorLanguage(AudioTracks? entidad, string llave, int UserId)
        {
            var lista = new List<AudioTracks>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "AudioTracks/PorLanguage");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<AudioTracks>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<AudioTracks?> Guardar(AudioTracks? entidad, string llave, int UserId)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "AudioTracks/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<AudioTracks>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<AudioTracks?> Modificar(AudioTracks? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "AudioTracks/Modificar");
            
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<AudioTracks>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<AudioTracks?> Borrar(AudioTracks? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = new { Id = entidad!.Id };
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "AudioTracks/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<AudioTracks>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}



