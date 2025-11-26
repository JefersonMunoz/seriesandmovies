using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace asp_presentacion.Pages.Ventanas
{
    public class CreditsModel : PageModel
    {
        private ICreditsPresentacion? iPresentacion = null;
        public CreditsModel(ICreditsPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Credits();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        public List<Persons> ListaPersons { get; set; }
        public List<Contents> ListaContents { get; set; }
        public List<RoleTypes> ListaRoleTypes { get; set; }
        [BindProperty] public Credits? Actual { get; set; }
        [BindProperty] public Credits? Filtro { get; set; }
        [BindProperty] public List<Credits>? Lista { get; set; }
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
                Filtro ??= new Credits();
                Filtro._Person ??= new Persons();
                Filtro._Content ??= new Contents();
                Filtro._RoleType ??= new RoleTypes();
                Filtro._Person.Name = Filtro._Person.Name ?? "";
                Filtro._Content.Name = Filtro._Content.Name ?? "";
                Filtro._RoleType.Name = Filtro._RoleType.Name ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.PorPersons(Filtro!, llave, Convert.ToInt32(UserId));
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
                Actual = new Credits();
                var task = this.iPresentacion!.Persons(llave, Convert.ToInt32(UserId));
                task.Wait();
                ListaPersons = task.Result;
                var task1 = this.iPresentacion!.Contents(llave, Convert.ToInt32(UserId));
                task1.Wait();
                ListaContents = task1.Result;
                var task2 = this.iPresentacion!.RoleTypes(llave, Convert.ToInt32(UserId));
                task2.Wait();
                ListaRoleTypes = task2.Result;
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
                var task = this.iPresentacion!.Persons(llave, Convert.ToInt32(UserId));
                task.Wait();
                ListaPersons = task.Result;
                var task1 = this.iPresentacion!.Contents(llave, Convert.ToInt32(UserId));
                task1.Wait();
                ListaContents = task1.Result;
                var task2 = this.iPresentacion!.RoleTypes(llave, Convert.ToInt32(UserId));
                task2.Wait();
                ListaRoleTypes = task2.Result;

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
                Task<Credits>? task = null;
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