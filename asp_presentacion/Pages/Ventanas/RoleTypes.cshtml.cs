using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace asp_presentacion.Pages.Ventanas
{
    public class RoleTypesModel : PageModel
    {
        private IRoleTypesPresentacion? iPresentacion = null;
        public RoleTypesModel(IRoleTypesPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public RoleTypes? Actual { get; set; }
        [BindProperty] public List<RoleTypes>? Lista { get; set; }
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
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Listar(llave, Convert.ToInt32(UserId));
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
                Actual = new RoleTypes();
                Lista = new List<RoleTypes>();
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
                Task<RoleTypes>? task = null;
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