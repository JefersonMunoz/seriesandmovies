using lib_dominio.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static ContentTypes? ContentTypes()
        {
            var entidad = new ContentTypes();
            entidad.Name = "Accion";
            entidad.Description = "Lo mejor en accion";
            return entidad;
        }

        public static Countries? Countries()
        {
            var entidad = new Countries();
            entidad.Name = "Colombia";
            entidad.Code = "CO";
            return entidad;
        }

        public static AudioTracks? AudioTracks()
        {
            var entidad = new AudioTracks();
            entidad.Content = 13;
            entidad.Language = 5;
            return entidad;
        }

        public static GenreTypes? GenreTypes()
        {
            var entidad = new GenreTypes();
            entidad.Name = "Fantasia";
            return entidad;
        }

        public static Languages? Languages()
        {
            var entidad = new Languages();
            entidad.Name = "Chino";
            entidad.Code = "CH";
            return entidad;
        }

        public static Persons? Persons()
        {
            var entidad = new Persons();
            entidad.Name = "Arturo";
            entidad.Lastame = "Lopez";
            entidad.Birthday = DateTime.Parse("2000-05-15");
            entidad.Description = "Director de películas";
            return entidad;
        }

        public static PersonTypeRoles? PersonTypeRoles()
        {
            var entidad = new PersonTypeRoles();
            entidad.Person = 3;
            entidad.RoleType = 4;
            return entidad;
        }

        public static Plans? Plans()
        {
            var entidad = new Plans();
            entidad.Name = "Intermedio";
            entidad.Description = "Plan 3 familiar";
            entidad.Price = 40000.00m;
            entidad.MaxPeople = 3;
            return entidad;
        }

        public static Reviews? Reviews()
        {
            var entidad = new Reviews();
            entidad.User = 2;
            entidad.Comment = "El suspenso estuvo bien, pero el final no me convenció, le faltó drama, segunda vez que la veo";
            entidad.Rating = 4;
            entidad.CreatedAt = DateTime.Parse("2025-05-15");
            entidad.Content = 2;
            return entidad;
        }
        public static RoleTypes? RoleTypes()
        {
            var entidad = new RoleTypes();
            entidad.Name = "Extra";
            return entidad;
        }

        public static Seasons? Seasons()
        {
            var entidad = new Seasons();
            entidad.NumberSeason = 1;
            entidad.Title = "El inicio de la niña huerfana";
            entidad.Content = 1;
            entidad.Description = "Primera temporada de La Niña huerfana";
            entidad.ReleasedAt = DateTime.Parse("2015-04-01");
            return entidad;
        }

        public static Studios? Studios()
        {
            var entidad = new Studios();
            entidad.Name = "Vix";
            entidad.Country = 1;
            entidad.Description = "Canal colombiano para películas expectaclares";
            return entidad;
        }

        public static Subscriptions? Subscriptions()
        {
            var entidad = new Subscriptions();
            entidad.User = 2;
            entidad.Plan = 1;
            entidad.StartedAt = DateTime.Parse("2025-09-15");
            entidad.FinishedAt = DateTime.Parse("2025-10-15");
            entidad.Price = 18000.00m;
            entidad.Months = 1;
            entidad.Status = true;
            return entidad;
        }

        public static Subtitles? Subtitles()
        {
            var entidad = new Subtitles();
            entidad.Content = 5;
            entidad.Language = 2;
            return entidad;
        }

        public static UserAccounts? UserAccounts()
        {
            var entidad = new UserAccounts();
            entidad.Name = "Sandra Maria";
            entidad.Lastname = "Cordoba Perez";
            entidad.Username = "Sandritacordoba";
            entidad.PhoneNumber = "3152265070";
            entidad.Email = "cordobasandra@hotmaill.com";
            entidad.Password = "sandraC*1000";
            entidad.Birthday = DateTime.Parse("1997-05-12");
            return entidad;
        }

        public static Watchlists? Watchlists()
        {
            var entidad = new Watchlists();
            entidad.User = 3;
            entidad.Content = 4;
            return entidad;
        }
    }

}