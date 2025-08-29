using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Org.BouncyCastle.Bcpg;
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
                    string query = "SELECT id_usuario,nombre,username,password,rol FROM usuario";

                    using (var cmd = new MySqlCommand(query, conexion))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                id_usuario = reader.GetInt32("id_usuario"),
                                nombre = reader.GetString("nombre"),
                                username = reader.GetString("username"),
                                password = reader.GetString("password"),
                                rol = (Rol)Enum.Parse(typeof(Rol), reader.GetString("rol"))
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new Exception("Error en la base de datos al obtener los productos: "+ ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: ", ex);
            }
            return lista;   
        }

        public void AgregarUsuario(Usuario usuario)
        {
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "INSERT INTO usuario (nombre, username, password, rol) VALUES (@nombre, @username, @password, @rol)";
                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                        cmd.Parameters.AddWithValue("@username", usuario.username);
                        cmd.Parameters.AddWithValue("@password", usuario.password);
                        cmd.Parameters.AddWithValue("@rol", usuario.rol.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error en la base de datos al agregar el usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario: ", ex);
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
                    using (var cmd = new MySqlCommand(query, conexion))
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
            catch (MySqlException ex)
            {
                throw new Exception("Error en la base de datos al actualizar el usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario: ", ex);
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
                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error en la base de datos al eliminar el usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: ", ex);
            }
        }
    }
}
