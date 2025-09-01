using SistemaRestaurante.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRestaurante.DAL;

namespace SistemaRestaurante.BLL
{
    public class ReportesBLL
    {
        private readonly ReportesDAL _detallePedidoDAL = new ReportesDAL();
        public List<Detalle_PedidoAux> ObtenerDetallesPedido()
        {
            return _detallePedidoDAL.ObtenerDetallesPedido();
        }
        public List<Detalle_PedidoAux> DatePedido(DateTime DateSearchPedido1, DateTime DateSearchPedido2)
        {
            return _detallePedidoDAL.obtenerFechaPedido(DateSearchPedido1, DateSearchPedido2);
        }
        private readonly ReportesDAL _detalleporid = new ReportesDAL();
        public List<DetallePedidoCompleto> ObtenerDetalleCompletoPorId(int idpedido)
        {
            return _detalleporid.ObtenerDetalleCompletoPorId(idpedido);
        }
    }
}
