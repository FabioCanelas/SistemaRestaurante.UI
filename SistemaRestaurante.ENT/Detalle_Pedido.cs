using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.ENT
{
    public class Detalle_Pedido
    {
        public int id_detalle { get; set; }
        public int cantidad { get; set; }
        public int num_mesa { get; set; }
        public decimal subtotal { get; set; }
        public int id_pedido { get; set; }
        public int id_plato { get; set; }
    }
}
