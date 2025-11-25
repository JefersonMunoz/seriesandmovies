using lib_dominio.Nucleo;
using lib_presentaciones; // Added
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks; // Added for async Task

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Username { get; set; }
        [BindProperty] public string? Password { get; set; }
        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }
        public void OnPostBtClean()
        {
            try
            {
                Username = string.Empty;
                Password = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        // MODIFIED: Method is now async Task and implements the key retrieval logic
        public async Task OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password)) // Changed to OR logic for mandatory fields
                {
                    OnPostBtClean();
                    return;
                }

                // Removed the hardcoded login check: if ("admin.123" != Username + "." + Password)

                var comunicaciones = new Comunicaciones();

                // 1. Call the API to get the Llave (key)
                var respuestaLlave = await comunicaciones.ObtenerLlave(Username!, Password!);

                // 2. Check if the key and user ID were received
                if (respuestaLlave != null &&
                    respuestaLlave.ContainsKey("Llave") &&
                    respuestaLlave.ContainsKey("UserId"))
                {
                    var llave = respuestaLlave["Llave"]?.ToString();
                    var userId = respuestaLlave["UserId"]?.ToString();

                    if (!string.IsNullOrEmpty(llave) && !string.IsNullOrEmpty(userId))
                    {
                        // 3. Set session variables upon successful authentication
                        ViewData["Logged"] = true;
                        HttpContext.Session.SetString("Usuario", Username!);
                        HttpContext.Session.SetString("Id", userId);
                        HttpContext.Session.SetString("Llave", llave); // Store the key

                        EstaLogueado = true;
                        OnPostBtClean();
                        return;
                    }
                }

                // If the flow reaches here, authentication failed or keys were missing
                ViewData["LoginError"] = "Credenciales inválidas o error de comunicación.";
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}