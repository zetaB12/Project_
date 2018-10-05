using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Usuario VerficarAcceso(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ApplicationException("Usuario o Password no válidos!");
                return usuario;

            }
            catch (Exception x)
            {                
                throw x;
            }
        }
    }
}
