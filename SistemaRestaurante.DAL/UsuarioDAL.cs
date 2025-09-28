using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SistemaRestaurante.ENT;

namespace SistemaRestaurante.DAL
{
    public class UsuarioDAL
    {
        private readonly ConexionDB _conexion;
        
        public UsuarioDAL()
        {
            _conexion = new ConexionDB();
        }
            
        public List<Usuario> ObetenerUsuarios()
        {
            var lista = new List<Usuario>();
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "SELECT id_usuario, nombre, username, password, rol FROM usuario";

                    using (var cmd = new SQLiteCommand(query, conexion))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                nombre = Convert.ToString(reader["nombre"]),
                                username = Convert.ToString(reader["username"]),
                                password = Convert.ToString(reader["password"]),
                                rol = ParseRol(Convert.ToString(reader["rol"]))
                            });
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error en la base de datos al obtener los usuarios: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios: " + ex.Message, ex);
            }
            return lista;   
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

        public void AgregarUsuario(Usuario usuario)
        {
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "INSERT INTO usuario (nombre, username, password, rol) VALUES (@nombre, @username, @password, @rol)";
                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                        cmd.Parameters.AddWithValue("@username", usuario.username);
                        cmd.Parameters.AddWithValue("@password", usuario.password);
                        cmd.Parameters.AddWithValue("@rol", usuario.rol.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error en la base de datos al agregar el usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario: " + ex.Message, ex);
            }
        }
        
        public void ActualizarUsuario(Usuario usuario)
        {
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "UPDATE usuario SET nombre = @nombre, username = @username, password = @password, rol = @rol WHERE id_usuario = @id_usuario";
                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                        cmd.Parameters.AddWithValue("@username", usuario.username);
                        cmd.Parameters.AddWithValue("@password", usuario.password);
                        cmd.Parameters.AddWithValue("@rol", usuario.rol.ToString());
                        cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error en la base de datos al actualizar el usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario: " + ex.Message, ex);
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "DELETE FROM usuario WHERE id_usuario = @id_usuario";
                    using (var cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error en la base de datos al eliminar el usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message, ex);
            }
        }
    }
}