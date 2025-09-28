using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SistemaRestaurante.DAL
{
    public class GananciasDAL
    {
        private readonly ConexionDB _conexion;

        public GananciasDAL()
        {
            _conexion = new ConexionDB();
        }

        // Obtener ganancias del día actual
        public decimal ObtenerGananciaDelDia()
        {
            decimal total = 0;
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string sql = @"
                        SELECT COALESCE(SUM(total), 0) 
                        FROM pedido 
                        WHERE DATE(fecha_pedido) = DATE('now', 'localtime')";
                    
                    using (var cmd = new SQLiteCommand(sql, conexion))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            total = Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo ganancia del día: {ex.Message}");
            }
            return total;
        }

        // Obtener ganancias del mes actual
        public decimal ObtenerGananciaDelMes()
        {
            decimal total = 0;
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string sql = @"
                        SELECT COALESCE(SUM(total), 0) 
                        FROM pedido 
                        WHERE strftime('%Y-%m', fecha_pedido) = strftime('%Y-%m', 'now', 'localtime')";
                    
                    using (var cmd = new SQLiteCommand(sql, conexion))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            total = Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo ganancia del mes: {ex.Message}");
            }
            return total;
        }

        // Obtener total de pedidos del día
        public int ObtenerTotalPedidosDelDia()
        {
            int total = 0;
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string sql = @"
                        SELECT COUNT(*) 
                        FROM pedido 
                        WHERE DATE(fecha_pedido) = DATE('now', 'localtime')";
                    
                    using (var cmd = new SQLiteCommand(sql, conexion))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            total = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo total de pedidos del día: {ex.Message}");
            }
            return total;
        }
    }
}