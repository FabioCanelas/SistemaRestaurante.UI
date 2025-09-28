using System.Data.SQLite;
using System;
using System.Collections.Generic;
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

        // Ahora devuelve el num_orden asignado (ej. ORD001)
        public string RegistrarPedido(Pedido pedido, List<Detalle_Pedido> detalles)
        {
            string numeroOrden = null;

            using (var conexion = _conexion.GetConnection())
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // Crear la tabla de secuencia si no existe (solo la primera vez; seguro dentro de la transacción)
                        string createSeqTable = @"
                            CREATE TABLE IF NOT EXISTS orden_secuencia (
                                fecha DATE PRIMARY KEY,
                                last_number INTEGER NOT NULL
                            );
                        ";
                        using (var cmdCreate = new SQLiteCommand(createSeqTable, conexion, transaccion))
                        {
                            cmdCreate.ExecuteNonQuery();
                        }

                        // Reservar siguiente número para hoy
                        int nextNumber;
                        string selectSeq = "SELECT last_number FROM orden_secuencia WHERE fecha = date('now')";
                        using (var cmdSel = new SQLiteCommand(selectSeq, conexion, transaccion))
                        {
                            var result = cmdSel.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                nextNumber = Convert.ToInt32(result) + 1;
                                string updateSeq = "UPDATE orden_secuencia SET last_number = @last WHERE fecha = date('now')";
                                using (var cmdUpd = new SQLiteCommand(updateSeq, conexion, transaccion))
                                {
                                    cmdUpd.Parameters.AddWithValue("@last", nextNumber);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                nextNumber = 1;
                                string insertSeq = "INSERT INTO orden_secuencia (fecha, last_number) VALUES (date('now'), @last)";
                                using (var cmdIns = new SQLiteCommand(insertSeq, conexion, transaccion))
                                {
                                    cmdIns.Parameters.AddWithValue("@last", nextNumber);
                                    cmdIns.ExecuteNonQuery();
                                }
                            }
                        }

                        // Formato de num_orden: ORD + ### (ej. ORD001) — reinicia cada día
                        numeroOrden = "ORD" + nextNumber.ToString("D3");
                        pedido.num_orden = numeroOrden;

                        // Insertar pedido con num_orden
                        string queryPedido = "INSERT INTO pedido (fecha_pedido, estado, total, id_usuario, num_orden) VALUES (@fecha_pedido, @estado, @total, @id_usuario, @num_orden); SELECT last_insert_rowid();";
                        int idPedido;
                        using (var cmd = new SQLiteCommand(queryPedido, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@fecha_pedido", pedido.fecha_pedido);
                            cmd.Parameters.AddWithValue("@estado", pedido.estado.ToString());
                            cmd.Parameters.AddWithValue("@total", pedido.total);
                            cmd.Parameters.AddWithValue("@id_usuario", pedido.id_usuario);
                            cmd.Parameters.AddWithValue("@num_orden", (object)pedido.num_orden ?? DBNull.Value);

                            idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insertar detalles
                        string queryDetalle = "INSERT INTO detalle_pedido (cantidad, num_mesa, subtotal, id_pedido, id_plato) VALUES (@cantidad, @num_mesa, @subtotal, @id_pedido, @id_plato)";
                        foreach (var detalle in detalles)
                        {
                            using (var cmd = new SQLiteCommand(queryDetalle, conexion, transaccion))
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
                        try { transaccion.Rollback(); } catch { }
                        throw new Exception("Error al registrar el pedido: " + ex.Message, ex);
                    }
                }
            }

            return numeroOrden;
        }
    }
}
