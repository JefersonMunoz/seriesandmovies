
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ContentGenresPresentacion : IContentGenresPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<ContentGenres>> Listar(string llave, int UserId)
        {
            var lista = new List<ContentGenres>();
            var datos = new Dictionary<string, object>();
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentGenres/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ContentGenres>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<GenreTypes>> GenreTypes(string llave, int UserId)
        {
            var lista = new List<GenreTypes>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "GenreTypes/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<GenreTypes>>(
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

        public async Task<List<ContentGenres>> PorGenreType(ContentGenres? entidad, string llave, int UserId)
        { 
            var lista = new List<ContentGenres>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentGenres/PorGenreType");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ContentGenres>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<ContentGenres?> Guardar(ContentGenres? entidad, string llave, int UserId)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentGenres/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ContentGenres>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ContentGenres?> Modificar(ContentGenres? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentGenres/Modificar");
            
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ContentGenres>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ContentGenres?> Borrar(ContentGenres? entidad, string llave, int UserId)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = new { Id = entidad!.Id };
            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ContentGenres/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, llave, UserId);
            
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ContentGenres>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}