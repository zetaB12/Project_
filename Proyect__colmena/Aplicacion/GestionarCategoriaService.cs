using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Persistencia;

namespace Aplicacion
{
    class GestionarCategoriaService
    {
        private GestorDAO_Sql _gestorDaoSql;
        private CategoriaDao _categoriaDao;

        public GestionarCategoriaService()
        {
            _gestorDaoSql = new GestorDAO_Sql();
            _categoriaDao = new CategoriaDao(_gestorDaoSql);
        }
        public List<Categoria> ListarCategorias()
        {
            _gestorDaoSql.AbrirConexion();
            var listarCategorias = _categoriaDao.ListarCategorias();
            _gestorDaoSql.CerraConexion();
            return listarCategorias;
        }
    }
}
