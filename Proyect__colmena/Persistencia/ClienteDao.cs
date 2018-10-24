using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public class ClienteDao
    {
        private GestorDAO_Sql _gestorDaoSql;

        public ClienteDao(GestorDAO_Sql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }

        public List<Cliente> ListarClientes()
        {
            var cmd = new SqlCommand("_spListarClientes");
            var parametros = new List<SqlParameter>();
            var listaClientes = new List<Cliente>();
            Cliente cliente = null;

            try
            {
                var data = _gestorDaoSql.EjecutarComandoSp(cmd, parametros);
                while (data.Read())
                {
                    cliente = new Cliente()
                    {
                        IdCliente= Convert.ToInt32(data["IdCliente"]),
                        Nombre = data["Nombre"].ToString(),
                        Apellidos = data["Apellidos"].ToString(),
                        Dni =   Convert.ToInt32(data["Dni"])
                    };
                    listaClientes.Add(cliente);
                }
                data.Close();
                return listaClientes;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
