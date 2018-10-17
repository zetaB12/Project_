using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Persistencia;
using Exception = System.Exception;

namespace Aplicacion
{
    public class GestionarProductoService
    {
        private GestorDAO_Sql _gestorDaoSql;
        private ProductoDao _productoDao;
        private DetalleProductoDao _detalleProductoDao;

        public GestionarProductoService()
        {
            _gestorDaoSql = new GestorDAO_Sql();
            _productoDao = new ProductoDao(_gestorDaoSql);
            _detalleProductoDao = new DetalleProductoDao(_gestorDaoSql);
        }

        public List<Producto> ListarProductos()
        {
            _gestorDaoSql.IniciarTransaccion();
            var lista = _productoDao.ListarProductos();
            _gestorDaoSql.TerminarTransaccion();
            return lista;
        }

        public bool RegistrarProducto(Producto producto)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();//primera llamada a iniciar transaccion
                int idDetalleProducto = InsertarDetalleProducto(producto.DetalleProducto);
                if (idDetalleProducto <= 0)
                {
                    _gestorDaoSql.CancelarTransaccion();
                    return false;
                }
                _gestorDaoSql.IniciarTransaccion();//segunda llamada a iniciar transaccion
                int insert = InsertarProducto(producto, idDetalleProducto);
                if (insert <= 0)
                {
                    _gestorDaoSql.CancelarTransaccion();
                    return false;
                }
                _gestorDaoSql.TerminarTransaccion();
                return true;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public int InsertarProducto(Producto producto, int idDetalleProducto)
        {
            try
            {
                //_gestorDaoSql.IniciarTransaccion();//aqui llame al iniciar trasaccion linea 38
                int insert = _productoDao.InsertarProducto(producto, idDetalleProducto);
                if (insert <= 0)
                    _gestorDaoSql.CancelarTransaccion();
                return 1;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public int InsertarDetalleProducto(DetalleProducto detalleProducto)
        {
            try
            {
                //_gestorDaoSql.IniciarTransaccion();//segunda llamada_ aqui ya abrio linea 30
                int inserto = _detalleProductoDao.InsertarDetalleProducto(detalleProducto);
                if (inserto > 0)
                    _gestorDaoSql.TerminarTransaccion();
                else
                    _gestorDaoSql.CancelarTransaccion();
                return inserto;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public Producto BuscarProductoID(int id)
        {
            try
            {
                _gestorDaoSql.AbrirConexion();
                var producto = _productoDao.BuscarProductoID(id);
                _gestorDaoSql.CerraConexion();
                return producto;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public bool EditarProducto(Producto producto)
        {
            try
            {
                _gestorDaoSql.IniciarTransaccion();
                var insert = _productoDao.EditarProducto(producto);
                _gestorDaoSql.TerminarTransaccion();
                return insert;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
