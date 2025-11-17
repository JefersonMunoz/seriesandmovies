using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class TokenAplicacion
    {
        private IConexion? IConexion = null;
        // El profe dice mejore las llaves
        private string llave = "KJGjkhdjkfgkjf54fs65d4f65sd4f";

        public TokenAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public string Llave(Users? entidad)
        {
            var usuario = this.IConexion!.Users!
                .FirstOrDefault(x => x.Username == entidad!.Username &&
                                x.Password == entidad.Password);
            if (usuario == null)
                return string.Empty;
            return llave;
        }

        public bool Validar(Dictionary<string, object> datos)
        {
            if (!datos.ContainsKey("Llave"))
                return false;
            return this.llave == datos["Llave"].ToString();
        }
    }
}