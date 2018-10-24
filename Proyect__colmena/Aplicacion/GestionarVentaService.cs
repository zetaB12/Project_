using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Persistencia;

namespace Aplicacion
{
    public class GestionarVentaService
    {
        private GestorDAO_Sql _gestorDaoSql;
        private VentaDao _ventaDao;

        public GestionarVentaService()
        {
            _gestorDaoSql = new GestorDAO_Sql();
            _ventaDao = new VentaDao(_gestorDaoSql);
        }

        public List<Venta> ListarVentas()
        {
            _gestorDaoSql.AbrirConexion();
            var listarVentas = _ventaDao.ListarVentas();
            _gestorDaoSql.CerraConexion();
            return listarVentas;
        }
    }
}
