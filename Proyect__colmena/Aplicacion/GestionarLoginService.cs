using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Persistencia;

namespace Aplicacion
{
    public class GestionarLoginService
    {
        private GestorDAO_Sql _gestorDaoSql;
        private UsuarioDao _usuarioDao;
        private Usuario _usuario;

        public GestionarLoginService()
        {
            _gestorDaoSql = new GestorDAO_Sql();
            _usuarioDao = new UsuarioDao(_gestorDaoSql);
            _usuario = new Usuario();
        }

        public Usuario VerificarAcceso(string user, string pass)
        {
            
                _gestorDaoSql.AbrirConexion();
                var usuario = _usuarioDao.VerificarAcceso(user, pass);
                _gestorDaoSql.CerraConexion();
                var usuarioVerificado = _usuario.VerficarAcceso(usuario);
                return usuarioVerificado;
            
        }
    }
}
