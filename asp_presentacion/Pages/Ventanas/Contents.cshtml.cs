using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace asp_presentacion.Pages.Ventanas
{
    public class ContentsModel : PageModel
    {
        private IContentsPresentacion? iPresentacion = null;
        public ContentsModel(IContentsPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Contents();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        public List<ContentTypes> ListaContentTypes { get; set; } = new List<ContentTypes>();
        public List<Studios> ListaStudios { get; set; }
        public List<Languages> ListaLanguages { get; set; }
        [BindProperty] public Contents? Actual { get; set; }
        [BindProperty] public Contents? Filtro { get; set; }
        [BindProperty] public List<Contents>? Lista { get; set; }
        public virtual void OnGet() { OnPostBtRefrescar(); }
        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                var llave = HttpContext.Session.GetString("Llave");
                var UserId = HttpContext.Session.GetString("Id");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                var task1 = this.iPresentacion!.ContentTypes(llave, Convert.ToInt32(UserId));
                task1.Wait();
                ListaContentTypes = task1.Result;

                Filtro!.Description = Filtro!.Description ?? "";
                Filtro!.ContentType = Filtro!.ContentType ?? 0;
                //Filtro!.ContentType = Filtro!.ContentType == 0 ? 1 : Filtro!.ContentType;
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Filtro(Filtro!, llave, Convert.ToInt32(UserId));
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
                var UserId = HttpContext.Session.GetString("Id");
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Contents();
                var task = this.iPresentacion!.ContentTypes(llave, Convert.ToInt32(UserId));
                task.Wait();
                ListaContentTypes = task.Result;
                var task1 = this.iPresentacion!.Studios(llave, Convert.ToInt32(UserId));
                task1.Wait();
                ListaStudios = task1.Result;
                var task2 = this.iPresentacion!.Languages(llave, Convert.ToInt32(UserId));
                task2.Wait();
                ListaLanguages = task2.Result;
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
                var UserId = HttpContext.Session.GetString("Id");
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
                var task = this.iPresentacion!.ContentTypes(llave, Convert.ToInt32(UserId));
                task.Wait();
                ListaContentTypes = task.Result;
                var task1 = this.iPresentacion!.Studios(llave, Convert.ToInt32(UserId));
                task1.Wait();
                ListaStudios = task1.Result;
                var task2 = this.iPresentacion!.Languages(llave, Convert.ToInt32(UserId));
                task2.Wait();
                ListaLanguages = task2.Result;

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
                var UserId = HttpContext.Session.GetString("Id");
                Accion = Enumerables.Ventanas.Editar;
                Task<Contents>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!,llave, Convert.ToInt32(UserId))!;
                else
                    task = this.iPresentacion!.Modificar(Actual!, llave, Convert.ToInt32(UserId))!;
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
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
                var UserId = HttpContext.Session.GetString("Id");
                var task = this.iPresentacion!.Borrar(Actual!, llave, Convert.ToInt32(UserId));
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
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}