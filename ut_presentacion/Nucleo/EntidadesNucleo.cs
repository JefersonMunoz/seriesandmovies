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
            entidad.Name = "Reality show";
            entidad.Description = "Lo mejor en farandula";
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
            entidad.Comment = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Rating = 4;
            entidad.CreatedAt = DateTime.Parse("2025-05-15");
            entidad.Content = 2;
            return entidad;
        }
        public static RoleTypes? RoleTypes()
        {
            var entidad = new RoleTypes();
            entidad.Name = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            return entidad;
        }

        public static Seasons? Seasons()
        {
            var entidad = new Seasons();
            entidad.NumberSeason = "1";
            entidad.Title = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Content = 1;
            entidad.Description = "Primera temporada de La Niña huerfana";
            entidad.ReleasedAt = DateTime.Parse("2015-04-01");
            return entidad;
        }

        public static Studios? Studios()
        {
            var entidad = new Studios();
            entidad.Name = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Country = 1;
            entidad.Description = "Canal colombiano para películas expectaculares";
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
            entidad.Name = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
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

        public static ContentGenres? ContentGenres()
        {
            var entidad = new ContentGenres();
            entidad.GenreType = 1;
            entidad.Content = 11;

            return entidad;
        }

        public static Contents? Contents()
        {
            var entidad = new Contents();
            entidad.Name = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Description = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.ContentType = 1;
            entidad.Year = DateTime.Parse("1997-05-12");
            entidad.Language = 1;
            entidad.Studio = 1;
            return entidad;
        }

        public static Credits? Credits()
        {
            var entidad = new Credits();
            entidad.Person = 1;
            entidad.Content = 1;
            entidad.RoleType = 1;

            return entidad;
        }

        public static Episodes? Episodes()
        {
            var entidad = new Episodes();
            entidad.Season = 1;
            entidad.Title = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.NumberEpisode = "7";
            entidad.DurationTime = TimeOnly.Parse("00:42:30");
            entidad.Description = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.ReleasedAt = DateTime.Parse("2025-05-12");

            return entidad;
        }
    }

}