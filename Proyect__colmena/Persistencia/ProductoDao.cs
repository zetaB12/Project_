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
    public class ProductoDao
    {
        private GestorDAO_Sql _gestorDaoSql;

        public ProductoDao(GestorDAO_Sql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }

        public int InsertarProducto(Producto producto, int idDetalleProducto)
        {
            SqlCommand cmd = new SqlCommand("_spInsertarProducto");
            try
            {
                cmd = _gestorDaoSql.ObtenerComandoSp(cmd);
                cmd.Parameters.AddWithValue("@prmstrNombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@prmstrDescripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@prmintIdCategoria", producto.Categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@prmintIdDetalleProducto", idDetalleProducto);
                cmd.Parameters.Add(new SqlParameter("@IdProducto", DbType.Int32)
                    {Direction = ParameterDirection.ReturnValue});
                cmd.ExecuteNonQuery();

                var IdProducto = Convert.ToInt32(cmd.Parameters["@IdProducto"].Value);
                return IdProducto;

            }
            catch (Exception x)
            {
                throw x;
            }

        }
    }
}
