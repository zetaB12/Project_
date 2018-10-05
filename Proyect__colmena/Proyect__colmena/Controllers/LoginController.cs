using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace Proyect__colmena.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String VerificarAcceso(Usuario usuario)
        {
            return "hola " + usuario.UserName + " " +usuario.Password;
        }
    }
}