using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public class UsuarioDao
    {
        private GestorDAO_Sql _gestorDaoSql;

        public UsuarioDao(GestorDAO_Sql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }

        public Usuario VerificarAcceso(string user, string pass)
        {
            var cmd = new SqlCommand("_spVerificarAcceso");

            Usuario usuario = null;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@prmstrUser", user),
                new SqlParameter("@prmstrPassword", pass)
            };

            try
            {
                var data = _gestorDaoSql.EjecutarComandoSp(cmd, parameters);
                if (data.Read())
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(data["IdUsuario"]),
                        UserName = data["UserName"].ToString(),
                        Password = data["Password"].ToString()
                    };
                }
                data.Close();
                return usuario;
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
                throw;
            }
        }
    }
}
