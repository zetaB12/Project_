using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace Persistencia
{
    public class CategoriaDao
    {
        private GestorDAO_Sql _gestorDaoSql;

        public CategoriaDao(GestorDAO_Sql gestorDaoSql)
        {
            _gestorDaoSql = gestorDaoSql;
        }

        public List<Categoria> ListarCategorias()
        {
            var cmd = new SqlCommand("_spListarCategorias");
            var parametros = new List<SqlParameter>();
            var listaCategorias = new List<Categoria>();
            Categoria categoria = null;

            try
            {
                var data = _gestorDaoSql.EjecutarComandoSp(cmd, parametros);
                while (data.Read())
                {
                    categoria = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(data["Idcategoria"]),
                        Nombre = data["Nombre"].ToString()
                    };
                    listaCategorias.Add(categoria);
                }
                data.Close();
                return listaCategorias;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}