using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace asp_presentacion.Pages.Ventanas
{
    public class ContentGenresModel : PageModel
    {
        private IContentGenresPresentacion? iPresentacion = null;
        public ContentGenresModel(IContentGenresPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new ContentGenres();

                //ListaGenreTypes = new List<GenreTypes>();
                //ListaContents = new List<Contents>();
                //Lista = new List<ContentGenres>();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        public List<GenreTypes> ListaGenreTypes { get; set; }
        public List<Contents> ListaContents { get; set; }
        [BindProperty] public ContentGenres? Actual { get; set; }
        [BindProperty] public ContentGenres? Filtro { get; set; }
        [BindProperty] public List<ContentGenres>? Lista { get; set; }
        public virtual void OnGet() { OnPostBtRefrescar(); }
        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                var llave = HttpContext.Session.GetString("Llave");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }
                Filtro ??= new ContentGenres();
                Filtro._GenreType ??= new GenreTypes();
                Filtro._Content ??= new Contents();
                Filtro._GenreType.Name = Filtro._GenreType.Name ?? "";
                Filtro._Content.Name = Filtro._Content.Name ?? "";
                //var nameGenreType = Filtro!._GenreType?.Name ?? "";
                //Filtro._GenreType!.Name = nameGenreType;

                //Filtro!._GenreType?.Name = Filtro!._GenreType?.Name ?? "";
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.PorGenreType(Filtro!, llave);
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtNuevo()
        {
            try
            {
                var llave = HttpContext.Session.GetString("Llave");
                Accion = Enumerables.Ventanas.Editar;
                Actual = new ContentGenres();
                var task = this.iPresentacion!.GenreTypes(llave);
                task.Wait();
                ListaGenreTypes = task.Result;
                var task1 = this.iPresentacion!.Contents(llave);
                task1.Wait();
                ListaContents = task1.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                var llave = HttpContext.Session.GetString("Llave");
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
                var task = this.iPresentacion!.GenreTypes(llave);
                task.Wait();
                ListaGenreTypes = task.Result;
                var task1 = this.iPresentacion!.Contents(llave);
                task1.Wait();
                ListaContents = task1.Result;

            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtGuardar()
        {
            try
            {
                var llave = HttpContext.Session.GetString("Llave");
                Accion = Enumerables.Ventanas.Editar;
                Task<ContentGenres>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!,llave)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!, llave)!;
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                var llave = HttpContext.Session.GetString("Llave");
                var taskG = this.iPresentacion!.GenreTypes(llave);
                taskG.Wait();
                ListaGenreTypes = taskG.Result;

                var taskC = this.iPresentacion!.Contents(llave);
                taskC.Wait();
                ListaContents = taskC.Result;

                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtBorrar()
        {
            try
            {
                var llave = HttpContext.Session.GetString("Llave");
                var task = this.iPresentacion!.Borrar(Actual!, llave);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}