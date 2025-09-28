using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace SistemaRestaurante.DAL    
{
    public class ConexionDB
    {
        private readonly string _connectionString;
        private static bool _inicializado = false;
        private static readonly object _lock = new object();
        
        public ConexionDB()
        {
            var configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
            
            // Solo inicializar una vez
            if (!_inicializado)
            {
                lock (_lock)
                {
                    if (!_inicializado)
                    {
                        InicializarBaseDatos();
                        _inicializado = true;
                    }
                }
            }
        }

        private void InicializarBaseDatos()
        {
            try
            {
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();
                    
                    // Verificar si existe la tabla usuario
                    string checkTable = "SELECT name FROM sqlite_master WHERE type='table' AND name='usuario';";
                    using (var cmd = new SQLiteCommand(checkTable, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            System.Diagnostics.Debug.WriteLine("Creando tablas en base de datos SQLite...");
                            // Crear todas las tablas
                            CrearTablas(conn);
                            // Insertar datos iniciales
                            InsertarDatosIniciales(conn);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Tablas ya existen en base de datos SQLite.");
                            // Verificar si existen usuarios, si no, insertarlos
                            string checkUsuarios = "SELECT COUNT(*) FROM usuario;";
                            using (var cmdUsuarios = new SQLiteCommand(checkUsuarios, conn))
                            {
                                var count = Convert.ToInt32(cmdUsuarios.ExecuteScalar());
                                if (count == 0)
                                {
                                    System.Diagnostics.Debug.WriteLine("Insertando usuarios iniciales...");
                                    InsertarDatosIniciales(conn);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error inicializando BD: " + ex.Message);
                // No lanzar excepción para no interrumpir la aplicación
            }
        }

        private void CrearTablas(SQLiteConnection conn)
        {
            string[] scripts = {
                @"CREATE TABLE IF NOT EXISTS usuario (
                    id_usuario INTEGER PRIMARY KEY AUTOINCREMENT,
                    nombre TEXT NOT NULL,
                    username TEXT UNIQUE NOT NULL,
                    password TEXT NOT NULL,
                    rol TEXT NOT NULL
                );",
                
                @"CREATE TABLE IF NOT EXISTS plato (
                    id_plato INTEGER PRIMARY KEY AUTOINCREMENT,
                    nombre TEXT NOT NULL,
                    descripcion TEXT,
                    precio DECIMAL(10,2) NOT NULL
                );",
                
                @"CREATE TABLE IF NOT EXISTS pedido (
                    id_pedido INTEGER PRIMARY KEY AUTOINCREMENT,
                    fecha_pedido DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    estado TEXT NOT NULL,
                    total DECIMAL(10,2) NOT NULL,
                    id_usuario INTEGER,
                    num_orden TEXT,
                    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
                );",
                
                @"CREATE TABLE IF NOT EXISTS detalle_pedido (
                    id_detalle INTEGER PRIMARY KEY AUTOINCREMENT,
                    cantidad INTEGER NOT NULL,
                    num_mesa INTEGER,
                    subtotal DECIMAL(10,2) NOT NULL,
                    id_pedido INTEGER,
                    id_plato INTEGER,
                    FOREIGN KEY (id_pedido) REFERENCES pedido(id_pedido),
                    FOREIGN KEY (id_plato) REFERENCES plato(id_plato)
                );",
                
                @"CREATE TABLE IF NOT EXISTS orden_secuencia (
                    fecha DATE PRIMARY KEY,
                    last_number INTEGER NOT NULL
                );"
            };

            foreach (string script in scripts)
            {
                using (var cmd = new SQLiteCommand(script, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertarDatosIniciales(SQLiteConnection conn)
        {
            // Insertar usuario admin (usar INSERT OR REPLACE para asegurar que existe)
            string insertAdmin = @"INSERT OR REPLACE INTO usuario (id_usuario, nombre, username, password, rol) 
                                   VALUES (1, 'Administrador', 'admin', 'admin123', 'ADMIN');";
            using (var cmd = new SQLiteCommand(insertAdmin, conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Insertar usuario recepcionista
            string insertRecep = @"INSERT OR REPLACE INTO usuario (id_usuario, nombre, username, password, rol) 
                                   VALUES (2, 'Recepcionista', 'recep', 'recep123', 'RECEPCIONISTA');";
            using (var cmd = new SQLiteCommand(insertRecep, conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Insertar platos de ejemplo solo si no existen
            string checkPlatos = "SELECT COUNT(*) FROM plato;";
            using (var cmdCheck = new SQLiteCommand(checkPlatos, conn))
            {
                var count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (count == 0)
                {
                    string[] platos = {
                        "INSERT INTO plato (nombre, descripcion, precio) VALUES ('Pollo a la plancha', 'Pechuga de pollo con guarnición', 35.00);",
                        "INSERT INTO plato (nombre, descripcion, precio) VALUES ('Pasta Bolognesa', 'Pasta con salsa de carne', 28.00);",
                        "INSERT INTO plato (nombre, descripcion, precio) VALUES ('Ensalada César', 'Ensalada fresca con pollo', 22.00);"
                    };

                    foreach (string plato in platos)
                    {
                        using (var cmd = new SQLiteCommand(plato, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}