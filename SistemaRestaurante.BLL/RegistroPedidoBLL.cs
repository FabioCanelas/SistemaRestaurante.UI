using SistemaRestaurante.DAL;
using SistemaRestaurante.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.BLL
{
    public class RegistroPedidoBLL
    {
        private readonly RegistroPedidoDAL _registroDal = new RegistroPedidoDAL();

        // Calcula el total a partir de los subtotales de los detalles
        public decimal CalcularTotal(IEnumerable<Detalle_Pedido> detalles)
        {
            if (detalles == null) return 0m;
            return Math.Round(detalles.Sum(d => d.subtotal), 2);
        }

        // Validaciones de negocio
        private void ValidarPedido(Pedido pedido, List<Detalle_Pedido> detalles)
        {
            if (pedido == null)
                throw new Exception("Pedido inválido.");

            if (detalles == null || detalles.Count == 0)
                throw new Exception("El pedido debe contener al menos un plato.");

            if (pedido.total <= 0)
                throw new Exception("El total del pedido debe ser mayor que cero.");

            decimal sumaSubtotales = CalcularTotal(detalles);
            if (Math.Round(sumaSubtotales, 2) != Math.Round(pedido.total, 2))
                throw new Exception($"El total ({pedido.total:0.00}) no coincide con la suma de subtotales ({sumaSubtotales:0.00}).");

            for (int i = 0; i < detalles.Count; i++)
            {
                var d = detalles[i];
                if (d.cantidad <= 0)
                    throw new Exception($"Cantidad inválida en el detalle #{i + 1} (id_plato={d.id_plato}).");
                if (d.num_mesa <= 0)
                    throw new Exception($"Número de mesa inválido en el detalle #{i + 1} (id_plato={d.id_plato}).");
                if (d.subtotal <= 0)
                    throw new Exception($"Subtotal inválido en el detalle #{i + 1} (id_plato={d.id_plato}).");
            }
        }

        // Registrar pedido: valida, asigna total y delega al DAL. Devuelve num_orden (ORD###)
        public string RegistrarPedido(Pedido pedido, List<Detalle_Pedido> detalles)
        {
            if (pedido == null) throw new ArgumentNullException(nameof(pedido));
            if (detalles == null) throw new ArgumentNullException(nameof(detalles));

            // Asegurar total correcto
            pedido.total = CalcularTotal(detalles);

            // Validar negocio
            ValidarPedido(pedido, detalles);

            // Persistir y obtener num_orden
            var numeroOrden = _registroDal.RegistrarPedido(pedido, detalles);
            return numeroOrden;
        }
    }
}

