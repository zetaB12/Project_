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
        private SqlTransaction _transaccion;

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

        public void IniciarTransaccion()
        {
            try
            {
                AbrirConexion();
                _transaccion = _conexion.BeginTransaction();
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public void TerminarTransaccion()
        {
            try
            {
                _transaccion.Commit();
                _conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CancelarTransaccion()
        {
            try
            {
                _transaccion.Rollback();
                _conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlDataReader EjecutarComandoSp(SqlCommand command, List<SqlParameter> parametros)
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

        public SqlDataReader EjecutarConsulta(string sentenciaSql)
        {
            try
            {
                SqlCommand comando = _conexion.CreateCommand();
                if (_transaccion != null)
                    comando.Transaction = _transaccion;
                comando.CommandText = sentenciaSql;
                comando.CommandType = CommandType.Text;
                SqlDataReader resultado = comando.ExecuteReader();
                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlCommand ObtenerComandoSp(SqlCommand command)
        {
            try
            {
                SqlCommand comando = _conexion.CreateCommand();
                if (_transaccion != null)
                    comando.Transaction = _transaccion;
                comando.CommandText = command.CommandText;
                comando.CommandType = CommandType.StoredProcedure;
                return comando;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
