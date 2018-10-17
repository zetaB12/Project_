using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        public List<Producto> ListarProductos()
        {
            var consulta ="_spListarProductos";
            Producto producto = null;
            DetalleProducto detalleProducto = null;
            Categoria categoria = null;
            List<Producto> listaProductos = new List<Producto>();
            try
            {
                var data = _gestorDaoSql.EjecutarConsulta(consulta);
                while(data.Read())
                {
                    producto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(data["Idproducto"]),
                        Nombre = data["Nombre"].ToString(),
                        Descripcion = data["Descripcion"].ToString(),
                    };

                    detalleProducto = new DetalleProducto()
                    {
                        PrecioCosto = Convert.ToDecimal(data["PrecioCosto"]),
                        PrecioVenta = Convert.ToDecimal(data["PrecioVenta"]),
                        Stock = Convert.ToInt32(data["Stock"]),
                    };
                    
                    categoria = new Categoria()
                    {
                        Nombre = data["Nombre"].ToString()
                    };

                    producto.DetalleProducto = detalleProducto;
                    producto.Categoria = categoria;

                    listaProductos.Add(producto);
                }
                data.Close();
                return listaProductos;
            }
            catch (Exception x)
            {
                throw x;
            }
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

        public Producto BuscarProductoID(int id)
        {
            SqlCommand cmd = new SqlCommand("_spBuscarProductoID");
            Producto producto = null;
            Categoria categoria = null;
            DetalleProducto detalleProducto = null;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@prmintIdProducto", id)
            };

            try
            {
                var data = _gestorDaoSql.EjecutarComandoSp(cmd, parameters);
                if (data.Read())
                {
                    producto = new Producto();
                    producto.IdProducto = Convert.ToInt32(data["IdProducto"]);
                    producto.Nombre = data["Nombre"].ToString();
                    producto.Descripcion = data["Descripcion"].ToString();

                    categoria = new Categoria();
                    categoria.IdCategoria = Convert.ToInt32(data["Idcategoria"]);
                    categoria.Nombre = data["Nombre"].ToString();

                    detalleProducto = new DetalleProducto();
                    detalleProducto.IdDetalleProducto = Convert.ToInt32(data["IdDetalleProducto"]);
                    detalleProducto.PrecioCosto = Convert.ToDecimal(data["PrecioCosto"]);
                    detalleProducto.PrecioVenta = Convert.ToDecimal(data["PrecioVenta"]);
                    detalleProducto.Stock = Convert.ToInt32(data["Stock"]);

                    producto.Categoria = categoria;
                    producto.DetalleProducto = detalleProducto;
                }
                data.Close();
                return producto;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public bool EditarProducto(Producto producto)
        {
            SqlCommand cmd = new SqlCommand("_spEditarProducto");
            var edit = false;
            try
            {
                cmd = _gestorDaoSql.ObtenerComandoSp(cmd);
                cmd.Parameters.AddWithValue("@prmIdProducto", producto.IdProducto);
                cmd.Parameters.AddWithValue("@prmstrNombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@prmstrDescripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@prmintIdCategoria", producto.Categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@prmintIdDetalleProducto", producto.DetalleProducto.IdDetalleProducto);
                cmd.Parameters.AddWithValue("@prmdcmDetalleProductoPrecioCosto", producto.DetalleProducto.PrecioCosto);
                cmd.Parameters.AddWithValue("@prmdcmDetalleProductoPrecioVenta", producto.DetalleProducto.PrecioVenta);
                cmd.Parameters.AddWithValue("@prmintDetalleProductoStok", producto.DetalleProducto.Stock);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    edit = true;
                }

                return edit;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
