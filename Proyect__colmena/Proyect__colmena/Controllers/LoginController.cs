using System.Web.Mvc;
using Aplicacion;
using Dominio;


namespace Proyect__colmena.Controllers
{
    public class LoginController : Controller
    {
        private GestionarLoginService _gestionarLoginService = new GestionarLoginService();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public string VerificarAcceso([Bind(Include = "UserName, Password")] Usuario u)
        {
            var usuario = _gestionarLoginService.VerificarAcceso(u.UserName, u.Password);
            if (usuario != null)
            {
                if (usuario.UserName.Equals(u.UserName) && usuario.Password.Equals(u.Password)) return "bienvenido";
            }
            
            return "mal";
        }
    }
}