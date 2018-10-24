using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Persistencia;

namespace Aplicacion
{
    public class GestionarClienteService
    {
        private GestorDAO_Sql _gestorDaoSql;
        private ClienteDao _clienteDao;

        public GestionarClienteService()
        {
            _gestorDaoSql = new GestorDAO_Sql();
            _clienteDao = new ClienteDao(_gestorDaoSql);
        }

        public List<Cliente> ListarClientes()
        {
            _gestorDaoSql.AbrirConexion();
            var lista = _clienteDao.ListarClientes();
            _gestorDaoSql.CerraConexion();
            return lista;
        }
    }
}
