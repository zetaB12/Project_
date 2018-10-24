using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public object Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Dni { get; set; }
    }
}
