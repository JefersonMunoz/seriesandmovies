using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class LanguagesPresentacion : ILanguagesPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Languages>> Listar(string llave, int UserId)
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

        public async Task<Languages?> Guardar(Languages? entidad, string llave, int UserId)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Languages/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Languages>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Languages?> Modificar(Languages? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Languages/Modificar");
            
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Languages>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Languages?> Borrar(Languages? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Languages/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Languages>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}