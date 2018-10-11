using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion;
using Dominio;

namespace Proyect__colmena.Controllers
{
    public class ProductoController : Controller
    {
        private readonly GestionarCategoriaService _gestionarCategoriaService = new GestionarCategoriaService();
        private readonly GestionarProductoService _gestionarProductoService = new GestionarProductoService();
        // GET: Producto
        public ActionResult Index()
        {
            List<Categoria> listaCategorias = _gestionarCategoriaService.ListarCategorias();
            ViewBag.lista = new SelectList(listaCategorias, "IdCategoria", "Nombre");
            ViewBag.listaCategoria = listaCategorias;
            return View();
        }

        public ActionResult Create()
        {
            var listaCategorias = _gestionarCategoriaService.ListarCategorias();
            ViewBag.IdCategoria = new SelectList(listaCategorias, "IdCategoria", "Nombre");
            return View();
        }

        [HttpPost]
        public String Create(Producto producto)
        {
            bool insert = _gestionarProductoService.RegistrarProducto(producto);

            return insert ? "bien hecho" : "mal";

            //return producto.IdProducto + " " + producto.Nombre + " " + producto.Descripcion + " " + producto.Categoria.IdCategoria;
        }
    }
}