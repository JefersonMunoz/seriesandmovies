using asp_servicios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder, builder.Services);

builder.Services.AddScoped<IAudioTracksAplicacion, AudioTracksAplicacion>();
builder.Services.AddScoped<IContentGenresAplicacion, ContentGenresAplicacion>();
builder.Services.AddScoped<IContentsAplicacion, ContentsAplicacion>();
builder.Services.AddScoped<IContentTypesAplicacion, ContentTypesAplicacion>();
builder.Services.AddScoped<ICountriesAplicacion, CountriesAplicacion>();
builder.Services.AddScoped<ICreditsAplicacion, CreditsAplicacion>();
builder.Services.AddScoped<IEpisodesAplicacion, EpisodesAplicacion>();
builder.Services.AddScoped<IGenreTypesAplicacion, GenreTypesAplicacion>();
builder.Services.AddScoped<ILanguagesAplicacion, LanguagesAplicacion>();
builder.Services.AddScoped<IPersonsAplicacion, PersonsAplicacion>();
builder.Services.AddScoped<IPersonTypeRolesAplicacion, PersonTypeRolesAplicacion>();
builder.Services.AddScoped<IPlansAplicacion, PlansAplicacion>();
builder.Services.AddScoped<IReviewsAplicacion, ReviewsAplicacion>();
builder.Services.AddScoped<IRoleTypesAplicacion, RoleTypesAplicacion>();
builder.Services.AddScoped<ISeasonsAplicacion, SeasonsAplicacion>();
builder.Services.AddScoped<IStudiosAplicacion, StudiosAplicacion>();
builder.Services.AddScoped<ISubscriptionsAplicacion, SubscriptionsAplicacion>();
builder.Services.AddScoped<ISubtitlesAplicacion, SubtitlesAplicacion>();
builder.Services.AddScoped<IUserAccountsAplicacion, UserAccountsAplicacion>();
builder.Services.AddScoped<IWatchlistsAplicacion, WatchlistsAplicacion>();

var app = builder.Build();
startup.Configure(app, app.Environment);
app.Run();
