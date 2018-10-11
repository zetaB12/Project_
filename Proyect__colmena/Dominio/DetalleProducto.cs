using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleProducto
    {
        public int IdDetalleProducto { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }

        //public Producto Producto { get; set; }
        //public int StockMinimo { get; set; }
        //public int Cantidad { get; set; }


    }
}
