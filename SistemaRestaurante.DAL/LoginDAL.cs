using System.Data.SQLite;
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

        private Rol ParseRol(string rolString)
        {
            if (string.IsNullOrEmpty(rolString)) return Rol.Seleccionar;

            // Intentar primero con el valor directo del enum
            if (Enum.TryParse<Rol>(rolString, true, out var rol))
                return rol;

            // Si no funciona, mapear valores comunes
            switch (rolString.ToUpper())
            {
                case "ADMINISTRADOR":
                case "ADMIN":
                    return Rol.ADMIN;
                case "RECEPCIONISTA":
                    return Rol.RECEPCIONISTA;
                default:
                    return Rol.Seleccionar;
            }
        }

        // Obtiene un usuario por su username (o null si no existe)
        public Usuario ObtenerPorUsername(string username)
        {
            const string query = @"
                SELECT id_usuario, nombre, username, password, rol
                FROM usuario
                WHERE username = @username
                LIMIT 1";
            
            try
            {
                using (var conn = _conexion.GetConnection())
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.Read()) return null;

                        var user = new Usuario
                        {
                            id_usuario = rdr["id_usuario"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id_usuario"]),
                            nombre = rdr["nombre"] == DBNull.Value ? null : Convert.ToString(rdr["nombre"]),
                            username = rdr["username"] == DBNull.Value ? null : Convert.ToString(rdr["username"]),
                            password = rdr["password"] == DBNull.Value ? null : Convert.ToString(rdr["password"]),
                            rol = ParseRol(rdr["rol"] == DBNull.Value ? "" : Convert.ToString(rdr["rol"]))
                        };

                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario: " + ex.Message, ex);
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
