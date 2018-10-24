using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Producto> listarProductos = _gestionarProductoService.ListarProductos();
            return View(listarProductos);
        }

        public ActionResult Create()
        {
            var listaCategorias = _gestionarCategoriaService.ListarCategorias();
            ViewBag.IdCategoria = new SelectList(listaCategorias, "IdCategoria", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto producto, string action, string xd)
        {
            bool insert = _gestionarProductoService.RegistrarProducto(producto);
            if (insert == true)
            {
               return RedirectToAction("Index");
            }

            return View();

            //return producto.IdProducto + " " + producto.Nombre + " " + producto.Descripcion + " " + producto.Categoria.IdCategoria;
        }

        public ActionResult Edit(int id)
        {
            var producto = _gestionarProductoService.BuscarProductoID(id);
            var listaCategorias = _gestionarCategoriaService.ListarCategorias();
            ViewBag.IdCategoria = new SelectList(listaCategorias, "IdCategoria", "Nombre", producto.Categoria.IdCategoria);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            bool insert = _gestionarProductoService.EditarProducto(producto);
            return RedirectToAction("Index");
            //return producto.IdProducto + " " + producto.Nombre + " " + producto.Descripcion + " " + producto.Categoria.IdCategoria;
        }

        public ActionResult ProductoModal()
        {
            return PartialView();
        }
    }
}

