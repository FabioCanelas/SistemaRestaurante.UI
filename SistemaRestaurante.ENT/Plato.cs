using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.ENT
{
    public class Plato
    {
        public int id_plato { get; set; }
        public string nombre { get; set; }  
        public string descripcion { get; set; }
        public decimal precio { get; set; }
    }
}
