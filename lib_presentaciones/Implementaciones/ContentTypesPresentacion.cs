using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ContentTypesPresentacion : IContentTypesPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<ContentTypes>> Listar(string llave, int UserId)
        {
            var lista = new List<ContentTypes>();
            var datos = new Dictionary<string, object>();
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentTypes/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ContentTypes>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<ContentTypes>> PorName(ContentTypes? entidad, string llave, int UserId)
        {
            var lista = new List<ContentTypes>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentTypes/PorName");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ContentTypes>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<ContentTypes?> Guardar(ContentTypes? entidad, string llave, int UserId)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentTypes/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ContentTypes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ContentTypes?> Modificar(ContentTypes? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentTypes/Modificar");
            
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ContentTypes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ContentTypes?> Borrar(ContentTypes? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentTypes/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ContentTypes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}