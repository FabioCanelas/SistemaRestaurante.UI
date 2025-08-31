using MySqlConnector;
using SistemaRestaurante.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.DAL
{
    public class LoginDAL
    {
        private readonly ConexionDB _conexion;

        public LoginDAL()
        {
            _conexion = new ConexionDB();
        }

        // Obtiene un usuario por su username (o null si no existe)
        public Usuario ObtenerPorUsername(string username)
        {
            const string query = @"
                SELECT id_usuario, nombre, username, password, rol
                FROM usuario
                WHERE username = @username
                LIMIT 1";
            using (var conn = _conexion.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return null;

                    var user = new Usuario
                    {
                        id_usuario = rdr.IsDBNull(rdr.GetOrdinal("id_usuario")) ? 0 : rdr.GetInt32("id_usuario"),
                        nombre = rdr.IsDBNull(rdr.GetOrdinal("nombre")) ? null : rdr.GetString("nombre"),
                        username = rdr.IsDBNull(rdr.GetOrdinal("username")) ? null : rdr.GetString("username"),
                        password = rdr.IsDBNull(rdr.GetOrdinal("password")) ? null : rdr.GetString("password"),
                    };

                    // Mapear rol (asumiendo que en BD está almacenado como INT)
                    if (!rdr.IsDBNull(rdr.GetOrdinal("rol")))
                    {
                        try
                        {
                            user.rol = (Rol)rdr.GetInt32("rol");
                        }
                        catch
                        {
                            user.rol = Rol.Seleccionar;
                        }
                    }
                    else
                    {
                        user.rol = Rol.Seleccionar;
                    }

                    return user;
                }
            }
        }

        // Autentica comparando username + password en texto plano (temporal e inseguro)
        public Usuario Autenticar(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password)) return null;

            var u = ObtenerPorUsername(username.Trim());
            if (u == null) return null;

            // Comparación directa (reemplazar por verificación segura en producción)
            return string.Equals(u.password ?? string.Empty, password, StringComparison.Ordinal) ? u : null;
        }
    }
}
