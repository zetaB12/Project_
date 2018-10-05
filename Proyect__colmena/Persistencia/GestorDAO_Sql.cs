using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class GestorDAO_Sql
    {
        private SqlConnection _conexion;

        public void AbrirConexion()
        {
            try
            {
                _conexion = new SqlConnection()
                {
                    ConnectionString = "Data source=.; Initial Catalog=Proyect_colmena; Integrated Security=true"
                };
                _conexion.Open();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public void CerraConexion()
        {
            try
            {
                _conexion.Close();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public SqlDataReader EjecutarComandoSp(SqlCommand command, List<SqlParameter> parametros)
        {
            try
            {
                SqlCommand comando = _conexion.CreateCommand();
               /* if (_transaccion != null)
                    comando.Transaction = _transaccion;*/
                comando.CommandText = command.CommandText;
                comando.Parameters.AddRange(parametros.ToArray());
                comando.CommandType = CommandType.StoredProcedure;
                var resultado = comando.ExecuteReader();
                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
