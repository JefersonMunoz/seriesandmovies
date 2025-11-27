using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace asp_presentacion.Pages.Ventanas
{
    public class SubscriptionsModel : PageModel
    {
        private ISubscriptionsPresentacion? iPresentacion = null;
        public SubscriptionsModel(ISubscriptionsPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Subscriptions();
                Lista = new List<Subscriptions>();
                ListaUsers = new List<Users>();
                ListaPlans = new List<Plans>();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        public List<SelectListItem> Estado { get; set; }/* = new List<SelectListItem>();*/
        public List<Users> ListaUsers { get; set; }
        public List<Plans> ListaPlans { get; set; }
        [BindProperty] public Subscriptions? Actual { get; set; }
        [BindProperty] public Subscriptions? Filtro { get; set; }
        [BindProperty] public List<Subscriptions>? Lista { get; set; }
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
                //Filtro.Description = Filtro.Description ?? "";
                Filtro ??= new Subscriptions();
                Filtro._User ??= new Users();
                Filtro._User.Name = Filtro._User.Name ?? "";
                Filtro._Plan ??= new Plans();
                Filtro._Plan.Name = Filtro._Plan.Name ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.PorPlan(Filtro!, llave, Convert.ToInt32(UserId));
                task.Wait();
                Lista = task.Result;
                Actual = null;

                Estado = new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Activo" },
                    new SelectListItem { Value = "0", Text = "Inactivo" }
                };
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
                Actual = new Subscriptions();
                Lista = new List<Subscriptions>();
                var task = this.iPresentacion!.Users(llave, Convert.ToInt32(UserId));
                task.Wait();
                ListaUsers = task.Result;
                var task1 = this.iPresentacion!.Plans(llave, Convert.ToInt32(UserId));
                task1.Wait();
                ListaPlans = task1.Result;
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
                var task = this.iPresentacion!.Users(llave, Convert.ToInt32(UserId));
                task.Wait();
                ListaUsers = task.Result;
                var task1 = this.iPresentacion!.Plans(llave, Convert.ToInt32(UserId));
                task1.Wait();
                ListaPlans = task1.Result;
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
                Task<Subscriptions>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!, llave, Convert.ToInt32(UserId))!;
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