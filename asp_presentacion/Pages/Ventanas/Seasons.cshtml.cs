using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace asp_presentacion.Pages.Ventanas
{
    public class SeasonsModel : PageModel
    {
        private ISeasonsPresentacion? iPresentacion = null;
        public SeasonsModel(ISeasonsPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Seasons();
                //Lista = new List<Seasons>();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        public List<Contents> ListaContents { get; set; } = new List<Contents>();
        [BindProperty] public Seasons? Actual { get; set; }
        [BindProperty] public Seasons? Filtro { get; set; }
        [BindProperty] public List<Seasons>? Lista { get; set; }
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
                var task1 = this.iPresentacion!.Contents(llave, Convert.ToInt32(UserId));
                task1.Wait();
                ListaContents = task1.Result;

                Filtro.Title = Filtro.Title ?? "";
                Filtro._Content ??= new Contents();
                Filtro._Content.Name = Filtro._Content.Name ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.PorTitle(Filtro!, llave, Convert.ToInt32(UserId));
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
                Actual = new Seasons();
                var task1 = this.iPresentacion!.Contents(llave, Convert.ToInt32(UserId));
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
                var UserId = HttpContext.Session.GetString("Id");
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
                var task2 = this.iPresentacion!.Contents(llave, Convert.ToInt32(UserId));
                task2.Wait();
                ListaContents = task2.Result;
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
                Task<Seasons>? task = null;
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