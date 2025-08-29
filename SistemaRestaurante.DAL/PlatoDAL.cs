using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using SistemaRestaurante.ENT;


namespace SistemaRestaurante.DAL
{
    public class PlatoDAL
    {
        private readonly ConexionDB _conexion;
        public PlatoDAL()
        {
            _conexion = new ConexionDB();
        }

        public List<Plato>ObtenerPlatos()
        {
            var lista = new List<Plato>();
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "SELECT id_plato,nombre,descripcion,precio FROM plato";
                    using (var cmd = new MySqlCommand(query, conexion))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Plato
                            {
                                id_plato = reader.GetInt32("id_plato"),
                                nombre = reader.GetString("nombre"),
                                descripcion = reader.GetString("descripcion"),
                                precio = reader.GetDecimal("precio")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error en la base de datos al obtener los Platos: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Platos: ", ex);
            }
            return lista;
        }

        public void agregarPlato(Plato plato)
        {
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "INSERT INTO plato (nombre, descripcion, precio) VALUES (@nombre, @descripcion, @precio)";
                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", plato.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", plato.descripcion);
                        cmd.Parameters.AddWithValue("@precio", plato.precio);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error en la base de datos al agregar el Plato: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el Plato: ", ex);
            }
        }
        
        public void EliminarPlato(int id_plato)
        {
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "DELETE FROM plato WHERE id_plato = @id_plato";
                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_plato", id_plato);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error en la base de datos al eliminar el Plato: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Plato: ", ex);
            }
        }

        public void ActualizarPlato(Plato plato)
        {
            try
            {
                using (var conexion = _conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "UPDATE plato SET nombre = @nombre, descripcion = @descripcion, precio = @precio WHERE id_plato = @id_plato";
                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", plato.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", plato.descripcion);
                        cmd.Parameters.AddWithValue("@precio", plato.precio);
                        cmd.Parameters.AddWithValue("@id_plato", plato.id_plato);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error en la base de datos al actualizar el Plato: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Plato: ", ex);
            }
        }
    }
}
