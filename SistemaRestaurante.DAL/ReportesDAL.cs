using System.Data.SQLite;
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
            try
            {
                using (var conn = _conexion.GetConnection())
                {
                    conn.Open();
                    string dtFecha = DateTime.Now.ToString("yyyy-MM-dd");
                    string query = "SELECT * FROM pedido WHERE fecha_pedido between @fecha1 and @fecha2";
                    using (var consult = new SQLiteCommand(query, conn))
                    {
                        consult.Parameters.AddWithValue("@fecha1", dtFecha + " 00:00:00");
                        consult.Parameters.AddWithValue("@fecha2", dtFecha + " 23:59:59");
                        using (var reader = consult.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pedido = new Detalle_PedidoAux
                                {
                                    id_pedido = Convert.ToInt32(reader["id_pedido"]),
                                    fecha_pedido = Convert.ToDateTime(reader["fecha_pedido"]),
                                    total = Convert.ToDecimal(reader["total"]),
                                };
                                lista.Add(pedido);
                            }
                        }
                    }
                }

                return lista;
            }
            catch (SQLiteException ex)
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
                    string dfFecha1 = fecha1.ToString("yyyy-MM-dd");
                    string dfFecha2 = fecha2.ToString("yyyy-MM-dd");

                    string query = "SELECT * FROM pedido WHERE fecha_pedido between @fecha1 and @fecha2";

                    using (var consult = new SQLiteCommand(query, conn))
                    {
                        consult.Parameters.AddWithValue("@fecha1", dfFecha1 + " 00:00:00");
                        consult.Parameters.AddWithValue("@fecha2", dfFecha2 + " 23:59:59");
                        using (var reader = consult.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Detalle_PedidoAux
                                {
                                    id_pedido = Convert.ToInt32(reader["id_pedido"]),
                                    fecha_pedido = Convert.ToDateTime(reader["fecha_pedido"]),
                                    total = Convert.ToDecimal(reader["total"]),
                                });
                            }
                        }
                    }
                }

                return lista;
            }
            catch (SQLiteException ex)
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
                    string query = @"SELECT dp.id_detalle, dp.id_pedido, dp.id_plato, p.nombre AS nombre_plato, dp.cantidad, dp.subtotal
                                     FROM detalle_pedido dp
                                     JOIN plato p ON dp.id_plato = p.id_plato
                                     WHERE dp.id_pedido = @idPedido";
                    using (var consult = new SQLiteCommand(query, conn))
                    {
                        consult.Parameters.AddWithValue("@idPedido", idPedido);
                        using (var reader = consult.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new DetallePedidoCompleto
                                {
                                    id_detalle = Convert.ToInt32(reader["id_detalle"]),
                                    id_pedido = Convert.ToInt32(reader["id_pedido"]),
                                    id_plato = Convert.ToInt32(reader["id_plato"]),
                                    nombre_plato = Convert.ToString(reader["nombre_plato"]),
                                    cantidad = Convert.ToInt32(reader["cantidad"]),
                                    subtotal = Convert.ToDecimal(reader["subtotal"])
                                });
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
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
