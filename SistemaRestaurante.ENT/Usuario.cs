using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.ENT
{
    public enum Rol
    {
        Seleccionar = 0,
        ADMIN = 1,
        RECEPCIONISTA = 2

    }
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Rol rol { get; set; }
    }
}
