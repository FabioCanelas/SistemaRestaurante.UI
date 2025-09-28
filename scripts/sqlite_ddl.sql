-- ========================================
-- SCRIPTS DDL - SQLite
-- Sistema de Gestión de Restaurante
-- ========================================

-- Tabla de usuarios
CREATE TABLE IF NOT EXISTS usuario (
    id_usuario INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL,
    username TEXT UNIQUE NOT NULL,
    password TEXT NOT NULL,
    rol TEXT NOT NULL
);

-- Tabla de platos
CREATE TABLE IF NOT EXISTS plato (
    id_plato INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL,
    descripcion TEXT,
    precio DECIMAL(10,2) NOT NULL
);

-- Tabla de pedidos
CREATE TABLE IF NOT EXISTS pedido (
    id_pedido INTEGER PRIMARY KEY AUTOINCREMENT,
    fecha_pedido DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    estado TEXT NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    id_usuario INTEGER,
    num_orden TEXT,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
);

-- Tabla de detalle de pedidos
CREATE TABLE IF NOT EXISTS detalle_pedido (
    id_detalle INTEGER PRIMARY KEY AUTOINCREMENT,
    cantidad INTEGER NOT NULL,
    num_mesa INTEGER,
    subtotal DECIMAL(10,2) NOT NULL,
    id_pedido INTEGER,
    id_plato INTEGER,
    FOREIGN KEY (id_pedido) REFERENCES pedido(id_pedido),
    FOREIGN KEY (id_plato) REFERENCES plato(id_plato)
);

-- Tabla para secuencia de órdenes diarias
CREATE TABLE IF NOT EXISTS orden_secuencia (
    fecha DATE PRIMARY KEY,
    last_number INTEGER NOT NULL
);

-- Índices para mejorar el rendimiento
CREATE INDEX IF NOT EXISTS idx_usuario_username ON usuario(username);
CREATE INDEX IF NOT EXISTS idx_pedido_fecha ON pedido(fecha_pedido);
CREATE INDEX IF NOT EXISTS idx_detalle_pedido_id ON detalle_pedido(id_pedido);
CREATE INDEX IF NOT EXISTS idx_detalle_plato_id ON detalle_pedido(id_plato);