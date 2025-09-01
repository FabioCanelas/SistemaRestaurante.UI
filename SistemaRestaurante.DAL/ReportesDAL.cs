using MySqlConnector;
using SistemaRestaurante.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.DAL
{
    public class ReportesDAL
    {
        private readonly ConexionDB _conexion;

        public ReportesDAL()
        {

            _conexion = new ConexionDB();
        }

        public List<Detalle_PedidoAux> ObtenerDetallesPedido()
        {
            var lista = new List<Detalle_PedidoAux>();
            var resultado = new List<DetallePedidoResult>();
            decimal totalGeneral = 0;
            try
            {
                using (var conn = _conexion.GetConnection())
                {
                    conn.Open();
                    string dtFecha = DateTime.Now.ToString("yyyy/MM/dd");
                    string query = "SELECT * FROM pedido WHERE fecha_pedido between '" + dtFecha + " 00:00:00' and '" + dtFecha + " 23:59:59'";
                    using (var consult = new MySqlCommand(query, conn))
                    using (var reader = consult.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pedido = new Detalle_PedidoAux
                            {
                                id_pedido = reader.GetInt32("id_pedido"),
                                fecha_pedido = reader.GetDateTime("fecha_pedido"),
                                total = reader.GetDecimal("total"),
                            };
                            lista.Add(pedido);
                            totalGeneral += pedido.total;
                        }
                    }

                }


                return (lista);

            }
            catch (MySqlException ex)
            {

                throw new Exception("Error en la base de datos al obtener los productos: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: ", ex);
            }


        }
        public List<Detalle_PedidoAux> obtenerFechaPedido(DateTime fecha1, DateTime fecha2)
        {
            var lista = new List<Detalle_PedidoAux>();
            try
            {
                using (var conn = _conexion.GetConnection())
                {
                    conn.Open();
                    string dfFecha1 = fecha1.ToString("yyyy/MM/dd");
                    string dfFecha2 = fecha2.ToString("yyyy/MM/dd");


                    string query = "SELECT * FROM pedido WHERE fecha_pedido between '" + dfFecha1 + " 00:00:00' and '" + dfFecha2 + " 23:59:59'";

                    using (var consult = new MySqlCommand(query, conn))
                    using (var reader = consult.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Detalle_PedidoAux
                            {
                                id_pedido = reader.GetInt32("id_pedido"),
                                fecha_pedido = reader.GetDateTime("fecha_pedido"),
                                total = reader.GetDecimal("total"),
                            });
                        }
                    }
                }


                return lista;
            }
            catch (MySqlException ex)
            {

                throw new Exception("Error en la base de datos al obtener los productos: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: " + ex.Message);
            }
        }


        public List<DetallePedidoCompleto> ObtenerDetalleCompletoPorId(int idPedido)
        {
            var lista = new List<DetallePedidoCompleto>();
            try
            {
                using (var conn = _conexion.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT dp.id_detalle, dp.id_pedido, dp.id_plato, p.nombre AS nombre_plato, dp.cantidad, dp.subtotal, (dp.cantidad * dp.subtotal) AS subtotal
                                     FROM detalle_pedido dp
                                     JOIN plato p ON dp.id_plato = p.id_plato
                                     WHERE dp.id_pedido = @idPedido";
                    using (var consult = new MySqlCommand(query, conn))
                    {
                        consult.Parameters.AddWithValue("@idPedido", idPedido);
                        using (var reader = consult.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new DetallePedidoCompleto
                                {
                                    id_detalle = reader.GetInt32("id_detalle"),
                                    id_pedido = reader.GetInt32("id_pedido"),
                                    id_plato = reader.GetInt32("id_plato"),
                                    nombre_plato = reader.GetString("nombre_plato"),
                                    cantidad = reader.GetInt32("cantidad"),
                                    subtotal = reader.GetDecimal("subtotal")
                                });
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error en la base de datos al obtener los detalles del pedido: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles del pedido: " + ex.Message, ex);
            }
            return lista;


        }
    }
}
