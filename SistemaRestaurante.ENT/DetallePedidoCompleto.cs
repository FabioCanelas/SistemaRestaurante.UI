using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.ENT
{
    // DTO para detalles con información de plato
    public class DetallePedidoCompleto
    {
        public int id_detalle { get; set; }
        public int id_pedido { get; set; }
        public int id_plato { get; set; }
        public string nombre_plato { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
    }
}
