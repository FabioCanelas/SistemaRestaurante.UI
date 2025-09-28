using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SQLite;

namespace SistemaRestaurante.DAL
{
    public class SupabaseSyncService
    {
        private readonly string _supabaseUrl;
        private readonly string _supabaseKey;
        private readonly bool _enabled;
        private readonly HttpClient _httpClient;
        private readonly ConexionDB _conexionDB;

        public SupabaseSyncService()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _supabaseUrl = configuration["Supabase:Url"];
            _supabaseKey = configuration["Supabase:Key"];
            _enabled = bool.Parse(configuration["Supabase:Enabled"] ?? "false");
            
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("apikey", _supabaseKey);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_supabaseKey}");
            
            _conexionDB = new ConexionDB();
        }

        // Verificar conexión a internet
        public async Task<bool> TieneConexionInternet()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    var response = await client.GetAsync("https://www.google.com");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        // Sincronizar todos los datos
        public async Task<bool> SincronizarDatos()
        {
            if (!_enabled)
            {
                System.Diagnostics.Debug.WriteLine("Supabase sync deshabilitado");
                return false;
            }

            if (!await TieneConexionInternet())
            {
                System.Diagnostics.Debug.WriteLine("Sin conexión a internet");
                return false;
            }

            try
            {
                System.Diagnostics.Debug.WriteLine("Iniciando sincronización con Supabase...");
                
                await SincronizarUsuarios();
                await SincronizarPlatos();
                await SincronizarPedidos();
                await SincronizarDetallePedidos();
                
                System.Diagnostics.Debug.WriteLine("Sincronización completada exitosamente");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en sincronización: {ex.Message}");
                return false;
            }
        }

        private async Task SincronizarUsuarios()
        {
            var usuarios = ObtenerUsuariosLocales();
            if (usuarios.Count > 0)
            {
                await EnviarDatosSupabase("usuarios", usuarios); // CORREGIDO: era "usuario"
            }
        }

        private async Task SincronizarPlatos()
        {
            var platos = ObtenerPlatosLocales();
            if (platos.Count > 0)
            {
                await EnviarDatosSupabase("platos", platos); // CORREGIDO: era "plato"
            }
        }

        private async Task SincronizarPedidos()
        {
            var pedidos = ObtenerPedidosLocales();
            if (pedidos.Count > 0)
            {
                await EnviarDatosSupabase("pedidos", pedidos); // CORREGIDO: era "pedido"
            }
        }

        private async Task SincronizarDetallePedidos()
        {
            var detalles = ObtenerDetallePedidosLocales();
            if (detalles.Count > 0)
            {
                await EnviarDatosSupabase("detalle_pedidos", detalles); // CORREGIDO: era "detalle_pedido"
            }
        }

        private async Task EnviarDatosSupabase(string tabla, List<object> datos)
        {
            try
            {
                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);
                System.Diagnostics.Debug.WriteLine($"?? Enviando a {tabla}: {json}"); // Log del JSON
                
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType.MediaType = "application/json";
                
                string url = $"{_supabaseUrl}/rest/v1/{tabla}";
                System.Diagnostics.Debug.WriteLine($"?? URL: {url}"); // Log de URL
                
                var response = await _httpClient.PostAsync(url, content);
                
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"? {datos.Count} registros enviados exitosamente a {tabla}");
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"? Error enviando a {tabla}: {response.StatusCode} - {responseBody}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"? Excepción enviando a {tabla}: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"? Stack trace: {ex.StackTrace}");
            }
        }

        // Obtener datos locales - CORREGIDO
        private List<object> ObtenerUsuariosLocales()
        {
            var usuarios = new List<object>();
            try
            {
                using (var conn = _conexionDB.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id_usuario, nombre, username, password, rol FROM usuario";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuarios.Add(new
                                {
                                    id_local = reader.GetInt32(0),    // Mapear id_usuario -> id_local
                                    nombre = reader.GetString(1),
                                    username = reader.GetString(2),
                                    password = reader.GetString(3),
                                    rol = reader.GetString(4)
                                });
                            }
                        }
                    }
                }
                System.Diagnostics.Debug.WriteLine($"?? Obtenidos {usuarios.Count} usuarios de SQLite");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo usuarios: {ex.Message}");
            }
            return usuarios;
        }

        private List<object> ObtenerPlatosLocales()
        {
            var platos = new List<object>();
            try
            {
                using (var conn = _conexionDB.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id_plato, nombre, descripcion, precio FROM plato";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                platos.Add(new
                                {
                                    id_local = reader.GetInt32(0),   // Mapear id_plato -> id_local
                                    nombre = reader.GetString(1),
                                    descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    precio = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
                System.Diagnostics.Debug.WriteLine($"?? Obtenidos {platos.Count} platos de SQLite");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo platos: {ex.Message}");
            }
            return platos;
        }

        private List<object> ObtenerPedidosLocales()
        {
            var pedidos = new List<object>();
            try
            {
                using (var conn = _conexionDB.GetConnection())
                {
                    conn.Open();
                    // Solo campos que existen en Supabase
                    string sql = "SELECT id_pedido, fecha_pedido, total FROM pedido";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pedidos.Add(new
                                {
                                    id_local = reader.GetInt32(0),   // Mapear id_pedido -> id_local
                                    fecha_pedido = reader.GetDateTime(1).ToString("yyyy-MM-ddTHH:mm:ss"), // Formato ISO
                                    total = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
                System.Diagnostics.Debug.WriteLine($"?? Obtenidos {pedidos.Count} pedidos de SQLite");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo pedidos: {ex.Message}");
            }
            return pedidos;
        }

        private List<object> ObtenerDetallePedidosLocales()
        {
            var detalles = new List<object>();
            try
            {
                using (var conn = _conexionDB.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id_detalle, cantidad, num_mesa, subtotal, id_pedido, id_plato FROM detalle_pedido";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                detalles.Add(new
                                {
                                    id_local = reader.GetInt32(0),   // Mapear id_detalle -> id_local
                                    cantidad = reader.GetInt32(1),
                                    num_mesa = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                    subtotal = reader.GetDecimal(3),
                                    id_pedido = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                    id_plato = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5)
                                });
                            }
                        }
                    }
                }
                System.Diagnostics.Debug.WriteLine($"?? Obtenidos {detalles.Count} detalles de pedido de SQLite");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo detalles pedidos: {ex.Message}");
            }
            return detalles;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}