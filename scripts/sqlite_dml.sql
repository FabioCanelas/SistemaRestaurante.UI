-- ========================================
-- SCRIPTS DML - SQLite
-- Datos Iniciales del Sistema
-- ========================================

-- Insertar usuarios iniciales
INSERT OR REPLACE INTO usuario (id_usuario, nombre, username, password, rol) 
VALUES (1, 'Administrador', 'admin', 'admin123', 'ADMIN');

INSERT OR REPLACE INTO usuario (id_usuario, nombre, username, password, rol) 
VALUES (2, 'Recepcionista', 'recep', 'recep123', 'RECEPCIONISTA');

-- Insertar platos de ejemplo
INSERT OR IGNORE INTO plato (nombre, descripcion, precio) 
VALUES ('Pollo a la plancha', 'Pechuga de pollo con guarnici�n', 35.00);

INSERT OR IGNORE INTO plato (nombre, descripcion, precio) 
VALUES ('Pasta Bolognesa', 'Pasta con salsa de carne', 28.00);

INSERT OR IGNORE INTO plato (nombre, descripcion, precio) 
VALUES ('Ensalada C�sar', 'Ensalada fresca con pollo', 22.00);

INSERT OR IGNORE INTO plato (nombre, descripcion, precio) 
VALUES ('Pizza Margherita', 'Pizza cl�sica con tomate y mozzarella', 32.00);

INSERT OR IGNORE INTO plato (nombre, descripcion, precio) 
VALUES ('Hamburguesa Cl�sica', 'Hamburguesa con carne, lechuga y tomate', 25.00);

INSERT OR IGNORE INTO plato (nombre, descripcion, precio) 
VALUES ('Sopa del d�a', 'Sopa casera con ingredientes frescos', 15.00);

INSERT OR IGNORE INTO plato (nombre, descripcion, precio) 
VALUES ('Pescado a la plancha', 'Filete de pescado con vegetales', 40.00);

INSERT OR IGNORE INTO plato (nombre, descripcion, precio) 
VALUES ('Lasa�a', 'Lasa�a tradicional con carne y queso', 30.00);

-- Ejemplo de pedido inicial (opcional)
-- INSERT INTO pedido (fecha_pedido, estado, total, id_usuario, num_orden) 
-- VALUES (datetime('now'), 'Completado', 60.00, 1, 'ORD001');