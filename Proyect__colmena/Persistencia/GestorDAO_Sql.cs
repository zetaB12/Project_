using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    class GestorDAO_Sql
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
    }
}
