using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LineaVenta
    {
        public int IdLineaVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Venta Venta { get; set; }        
        public List<DetalleProducto> DetalleProductos { get; set; }
    }

}
