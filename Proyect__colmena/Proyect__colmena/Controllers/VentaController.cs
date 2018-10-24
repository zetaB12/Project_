using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion;
using Dominio;
using Proyect__colmena.ViewModels;

namespace Proyect__colmena.Controllers
{
    public class VentaController : Controller
    {
        private GestionarVentaService _gestionarVentaService = new GestionarVentaService();
        GestionarClienteService _gestionarClienteService = new GestionarClienteService();

        public ActionResult Index()
        {
            var lista = _gestionarVentaService.ListarVentas();
            return View(lista); 
        }

        public ActionResult Create()
        {
           return View(new VentaViewModel());
        }

        [HttpPost]
        public ActionResult Create(VentaViewModel model, string action)
        {
            if (action.Equals("agregar_producto"))
            {
                model.AgregarItemADetalle();
            }
            return View(model);
        }

        public ActionResult ObtenerClientes()
        {
            var listaClientes = _gestionarClienteService.ListarClientes();
            return PartialView(listaClientes);
        }

        public PartialViewResult ListaClientes()
        {
            var listaClientes = _gestionarClienteService.ListarClientes();
            return PartialView(listaClientes);
        }
    }
}