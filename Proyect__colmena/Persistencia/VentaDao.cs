using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public class VentaDao
    {
        private GestorDAO_Sql _gestorDaoSql;

        public VentaDao(GestorDAO_Sql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }

        public List<Venta> ListarVentas()
        {
            var cmd = new SqlCommand("_spListarVentas");
            var parameter = new List<SqlParameter>();
            var listaventas = new List<Venta>();
            Venta venta;
            Cliente cliente;

            try
            {
                var data = _gestorDaoSql.EjecutarComandoSp(cmd, parameter);
                while (data.Read())
                {
                    venta = new Venta
                    {
                        IdVenta = Convert.ToInt32(data["IdVenta"]),
                        Fecha = Convert.ToDateTime(data["Fecha"]),
                        Importe = Convert.ToDecimal(data["Importe"])
                    };

                    cliente = new Cliente
                    {
                        IdCliente = Convert.ToInt32(data["IdCliente"]),
                        Nombre = data["Nombre"].ToString(),
                        Apellidos = data["Apellidos"].ToString(),
                        Dni = Convert.ToInt32(data["Dni"])
                    };
                    venta.Cliente = cliente;

                    listaventas.Add(venta);
                }
                data.Close();
                return listaventas;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
