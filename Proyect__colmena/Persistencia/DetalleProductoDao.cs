using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public class DetalleProductoDao
    {
        private GestorDAO_Sql _gestorDaoSql;

        public DetalleProductoDao(GestorDAO_Sql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }

        public int InsertarDetalleProducto(DetalleProducto detalleProducto)
        {
            SqlCommand cmd = new SqlCommand("_spInsertarDetalleProducto");
            try
            {
                cmd = _gestorDaoSql.ObtenerComandoSp(cmd);
                cmd.Parameters.AddWithValue("@prmdcmpreciocosto", detalleProducto.PrecioCosto);
                cmd.Parameters.AddWithValue("@prmdcmprecioventa", detalleProducto.PrecioVenta);
                cmd.Parameters.AddWithValue("@prmintstock", detalleProducto.Stock);

                cmd.Parameters.Add(new SqlParameter("@iddetalleproducto", DbType.Int32)
                    { Direction = ParameterDirection.ReturnValue });
                cmd.ExecuteNonQuery();

                int idDetalleProducto = Convert.ToInt32(cmd.Parameters["@iddetalleproducto"].Value);
                return idDetalleProducto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
