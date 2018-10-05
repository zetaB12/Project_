using System;
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
        public ActionResult VerificarAcceso([Bind(Include = "UserName, Password")] Usuario u)
        {
            try
            {
                var usuario = _gestionarLoginService.VerificarAcceso(u.UserName, u.Password);
                return RedirectToAction("Home");
            }
            catch (ApplicationException a)
            {
                ViewBag.errorLogin = a.Message;
                return View();
            }
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}