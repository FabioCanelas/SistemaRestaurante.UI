-- ========================================
-- SCRIPTS DML - Supabase (PostgreSQL)
-- Datos de ejemplo para pruebas
-- ========================================

-- Insertar usuarios de ejemplo en Supabase
INSERT INTO usuarios (id_local, nombre, username, password, rol) 
VALUES (1, 'Administrador', 'admin', 'admin123', 'ADMIN');

INSERT INTO usuarios (id_local, nombre, username, password, rol) 
VALUES (2, 'Recepcionista', 'recep', 'recep123', 'RECEPCIONISTA');

-- Insertar platos de ejemplo en Supabase
INSERT INTO platos (id_local, nombre, descripcion, precio) 
VALUES (1, 'Pollo a la plancha', 'Pechuga de pollo con guarnición', 35.00);

INSERT INTO platos (id_local, nombre, descripcion, precio) 
VALUES (2, 'Pasta Bolognesa', 'Pasta con salsa de carne', 28.00);

INSERT INTO platos (id_local, nombre, descripcion, precio) 
VALUES (3, 'Ensalada César', 'Ensalada fresca con pollo', 22.00);

INSERT INTO platos (id_local, nombre, descripcion, precio) 
VALUES (4, 'Pizza Margherita', 'Pizza clásica con tomate y mozzarella', 32.00);

INSERT INTO platos (id_local, nombre, descripcion, precio) 
VALUES (5, 'Hamburguesa Clásica', 'Hamburguesa con carne, lechuga y tomate', 25.00);

-- Ejemplo de pedidos para pruebas (opcional)
INSERT INTO pedidos (id_local, fecha_pedido, total) 
VALUES (1, NOW(), 60.00);

INSERT INTO pedidos (id_local, fecha_pedido, total) 
VALUES (2, NOW() - INTERVAL '1 day', 45.00);

-- Ejemplo de detalles de pedido (opcional)
INSERT INTO detalle_pedidos (id_local, cantidad, num_mesa, subtotal, id_pedido, id_plato) 
VALUES (1, 2, 5, 35.00, 1, 1);

INSERT INTO detalle_pedidos (id_local, cantidad, num_mesa, subtotal, id_pedido, id_plato) 
VALUES (2, 1, 5, 25.00, 1, 5);

-- Consultas útiles para verificar los datos
-- SELECT * FROM usuarios;
-- SELECT * FROM platos;
-- SELECT * FROM pedidos;
-- SELECT * FROM detalle_pedidos;