using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRestaurante.ENT;

namespace SistemaRestaurante.DAL
{
    public class RegistroPedidoDAL
    {
        private readonly ConexionDB _conexion;

        public RegistroPedidoDAL()
        {
            _conexion = new ConexionDB();
        }

        public void RegistrarPedido(Pedido pedido, List<Detalle_Pedido> detalles)
        {
            using (var conexion = _conexion.GetConnection())
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // Insertar pedido
                        string queryPedido = "INSERT INTO pedido (fecha_pedido, estado, total, id_usuario, nombre_cliente) VALUES (@fecha_pedido, @estado, @total, @id_usuario, @nombre_cliente); SELECT LAST_INSERT_ID();";
                        int idPedido;
                        using (var cmd = new MySqlCommand(queryPedido, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@fecha_pedido", pedido.fecha_pedido);
                            cmd.Parameters.AddWithValue("@estado", pedido.estado.ToString());
                            cmd.Parameters.AddWithValue("@total", pedido.total);
                            cmd.Parameters.AddWithValue("@id_usuario", pedido.id_usuario);
                            cmd.Parameters.AddWithValue("@nombre_cliente", pedido.nombre_cliente);
                            idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insertar detalles
                        string queryDetalle = "INSERT INTO detalle_pedido (cantidad, num_mesa, subtotal, id_pedido, id_plato) VALUES (@cantidad, @num_mesa, @subtotal, @id_pedido, @id_plato)";
                        foreach (var detalle in detalles)
                        {
                            using (var cmd = new MySqlCommand(queryDetalle, conexion, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                                cmd.Parameters.AddWithValue("@num_mesa", detalle.num_mesa);
                                cmd.Parameters.AddWithValue("@subtotal", detalle.subtotal);
                                cmd.Parameters.AddWithValue("@id_pedido", idPedido);
                                cmd.Parameters.AddWithValue("@id_plato", detalle.id_plato);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al registrar el pedido: " + ex.Message, ex);
                    }
                }
            }
        }

        //// Obtener el detalle de un pedido por id_pedido
        //public List<Detalle_Pedido> ObtenerDetallePorPedido(int idPedido)
        //{
        //    var lista = new List<Detalle_Pedido>();
        //    using (var conexion = _conexion.GetConnection())
        //    {
        //        conexion.Open();
        //        string query = "SELECT * FROM detalle_pedido WHERE id_pedido = @id_pedido";
        //        using (var cmd = new MySqlCommand(query, conexion))
        //        {
        //            cmd.Parameters.AddWithValue("@id_pedido", idPedido);
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    lista.Add(new Detalle_Pedido
        //                    {
        //                        id_detalle = reader.GetInt32("id_detalle"),
        //                        cantidad = reader.GetInt32("cantidad"),
        //                        num_mesa = reader.GetInt32("num_mesa"),
        //                        subtotal = reader.GetDecimal("subtotal"),
        //                        id_pedido = reader.GetInt32("id_pedido"),
        //                        id_plato = reader.GetInt32("id_plato")
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    return lista;
        //}

        // Método para registrar un pedido y sus detalles

    }
}
