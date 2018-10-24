using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect__colmena.ViewModels
{
    public class VentaViewModel
    {
        #region cabecera

        public string Cliente { get; set; }
        public int CabeceraProductoId { get; set; }
        public string CabeceraProductoNombre { get; set; }
        public int CabeceraProductoCantidad { get; set; }
        public decimal CabeceraProductoPrecio { get; set; }
        #endregion

        #region Contenido
        public List<LineaVentaViewModel> lineaVenta { get; set; }
        #endregion

        public VentaViewModel()
        {
            lineaVenta = new List<LineaVentaViewModel>();
            Refrescar();
        }

        public void AgregarItemADetalle()
        {
            lineaVenta.Add(new LineaVentaViewModel()
            {
                ProductoId = CabeceraProductoId,
                ProductoNombre = CabeceraProductoNombre,
                PrecioUnitario = CabeceraProductoPrecio,
                Cantidad = CabeceraProductoCantidad,
            });
            Refrescar();
        }

        public decimal Total()
        {
            return lineaVenta.Sum(x => x.Monto());
        }

        public void Refrescar()
        {
            CabeceraProductoId = 0;
            CabeceraProductoNombre = null;
            CabeceraProductoCantidad = 1;
            CabeceraProductoPrecio = 0;
        }
    }
}