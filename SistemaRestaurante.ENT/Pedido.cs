using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.ENT
{
    public enum Estado
    {
        PENDIENTE,
        ENTREGADO,
        CANCELADO
    }

    public class Pedido
    {
        public int id_pedido { get; set; }
        public DateTime fecha_pedido { get; set; }
        public Estado estado { get; set; }
        public decimal total { get; set; }
        public int id_usuario { get; set; }

        // Número de orden (corresponde a la columna num_orden en la BD)
        public string num_orden { get; set; }
    }
}
