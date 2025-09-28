-- ========================================
-- SCRIPTS DDL - Supabase (PostgreSQL)
-- Sistema de Gestión de Restaurante
-- ========================================

-- Tabla usuarios para Supabase
CREATE TABLE usuarios (
    id SERIAL PRIMARY KEY,
    id_local INTEGER,
    nombre TEXT NOT NULL,
    username TEXT NOT NULL,
    password TEXT NOT NULL,
    rol TEXT NOT NULL,
    created_at TIMESTAMPTZ DEFAULT NOW(),
    updated_at TIMESTAMPTZ DEFAULT NOW()
);

-- Tabla platos para Supabase
CREATE TABLE platos (
    id SERIAL PRIMARY KEY,
    id_local INTEGER,
    nombre TEXT NOT NULL,
    descripcion TEXT,
    precio DECIMAL(10,2) NOT NULL,
    created_at TIMESTAMPTZ DEFAULT NOW(),
    updated_at TIMESTAMPTZ DEFAULT NOW()
);

-- Tabla pedidos para Supabase
CREATE TABLE pedidos (
    id SERIAL PRIMARY KEY,
    id_local INTEGER,
    fecha_pedido TIMESTAMPTZ NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    created_at TIMESTAMPTZ DEFAULT NOW(),
    updated_at TIMESTAMPTZ DEFAULT NOW()
);

-- Tabla detalle_pedidos para Supabase
CREATE TABLE detalle_pedidos (
    id SERIAL PRIMARY KEY,
    id_local INTEGER,
    cantidad INTEGER NOT NULL,
    num_mesa INTEGER,
    subtotal DECIMAL(10,2) NOT NULL,
    id_pedido INTEGER,
    id_plato INTEGER,
    created_at TIMESTAMPTZ DEFAULT NOW(),
    updated_at TIMESTAMPTZ DEFAULT NOW()
);

-- Índices para mejorar el rendimiento
CREATE INDEX idx_usuarios_username ON usuarios(username);
CREATE INDEX idx_usuarios_id_local ON usuarios(id_local);
CREATE INDEX idx_platos_id_local ON platos(id_local);
CREATE INDEX idx_pedidos_fecha ON pedidos(fecha_pedido);
CREATE INDEX idx_pedidos_id_local ON pedidos(id_local);
CREATE INDEX idx_detalle_pedidos_pedido ON detalle_pedidos(id_pedido);
CREATE INDEX idx_detalle_pedidos_plato ON detalle_pedidos(id_plato);
CREATE INDEX idx_detalle_pedidos_id_local ON detalle_pedidos(id_local);

-- Habilitar Row Level Security (RLS) - Opcional
ALTER TABLE usuarios ENABLE ROW LEVEL SECURITY;
ALTER TABLE platos ENABLE ROW LEVEL SECURITY;
ALTER TABLE pedidos ENABLE ROW LEVEL SECURITY;
ALTER TABLE detalle_pedidos ENABLE ROW LEVEL SECURITY;

-- Políticas de seguridad básicas (ajustar según necesidades)
CREATE POLICY "Permitir lectura pública" ON usuarios FOR SELECT USING (true);
CREATE POLICY "Permitir lectura pública" ON platos FOR SELECT USING (true);
CREATE POLICY "Permitir lectura pública" ON pedidos FOR SELECT USING (true);
CREATE POLICY "Permitir lectura pública" ON detalle_pedidos FOR SELECT USING (true);

CREATE POLICY "Permitir inserción pública" ON usuarios FOR INSERT WITH CHECK (true);
CREATE POLICY "Permitir inserción pública" ON platos FOR INSERT WITH CHECK (true);
CREATE POLICY "Permitir inserción pública" ON pedidos FOR INSERT WITH CHECK (true);
CREATE POLICY "Permitir inserción pública" ON detalle_pedidos FOR INSERT WITH CHECK (true);