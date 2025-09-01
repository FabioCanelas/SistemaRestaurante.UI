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
    public class DetallePedidoResult
    {
        public List<Detalle_Pedido> Pedidos { get; set; }
        public decimal TotalGeneral { get; set; }
    }
    public class Detalle_PedidoAux
    {
        public int id_pedido { get; set; }
        public DateTime fecha_pedido { get; set; }
        // public string estado { get; set; } opsional a mostrarse o no
        public decimal total { get; set; }
        // public int id_usuario { get; set; } opsional a mostrarse o no

    }
}
