using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }
        
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones
            services.AddScoped<IContentsPresentacion, ContentsPresentacion>();
            services.AddScoped<IAudioTracksPresentacion, AudioTracksPresentacion>();
            services.AddScoped<IContentGenresPresentacion, ContentGenresPresentacion>();
            services.AddScoped<IContentTypesPresentacion, ContentTypesPresentacion>();
            services.AddScoped<ICountriesPresentacion, CountriesPresentacion>();
            services.AddScoped<ICreditsPresentacion, CreditsPresentacion>();
            services.AddScoped<IEpisodesPresentacion, EpisodesPresentacion>();
            services.AddScoped<IGenreTypesPresentacion, GenreTypesPresentacion>();
            services.AddScoped<ILanguagesPresentacion, LanguagesPresentacion>();
            services.AddScoped<IPersonsPresentacion, PersonsPresentacion>();
            services.AddScoped<IPersonTypeRolesPresentacion, PersonTypeRolesPresentacion>();
            //services.AddScoped<IPlansPresentacion, PlansPresentacion>();
            //services.AddScoped<IReviewsPresentacion, ReviewsPresentacion>();
            //services.AddScoped<IRoleTypesPresentacion, RoleTypesPresentacion>();
            //services.AddScoped<ISeasonsPresentacion, SeasonsPresentacion>();
            //services.AddScoped<IStudiosPresentacion, StudiosPresentacion>();
            //services.AddScoped<ISubscriptionsPresentacion, SubscriptionsPresentacion>();
            //services.AddScoped<ISubtitlesPresentacion, SubtitlesPresentacion>();
            //services.AddScoped<IUsersPresentacion, UsersPresentacion>();
            //services.AddScoped<IWatchlistsPresentacion, WatchlistsPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}