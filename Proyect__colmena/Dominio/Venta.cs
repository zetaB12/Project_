using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public decimal Cambio { get; set; }
        public Cliente Cliente { get; set; }
        public List<LineaVenta> LineaVentas { get; set; }

        public Venta()
        {
            LineaVentas = new List<LineaVenta>();
        }
    }
}
