-- Inserción de datos para la tabla USUARIO
INSERT INTO USUARIO (nombre, username, password, rol) VALUES
('Administrador', 'admin', '12345', 'ADMIN'),
('María García', 'mariag', '12345', 'RECEPCIONISTA'),
('Carlos Ruiz', 'carlosr', '12345', 'RECEPCIONISTA');

---
-- Inserción de datos para la tabla PLATO
INSERT INTO PLATO (nombre, descripcion, precio) VALUES
('Pizza Margarita', 'Clásica pizza con tomate, mozzarella y albahaca fresca.', 12.50),
('Hamburguesa Clásica', 'Carne de res, lechuga, tomate, queso y cebolla en pan brioche.', 9.80),
('Ensalada César', 'Lechuga romana, crutones, queso parmesano y aderezo César.', 8.00),
('Pasta Carbonara', 'Pasta fettuccine con huevo, panceta, queso parmesano y pimienta negra.', 14.00),
('Tiramisú', 'Postre italiano con capas de bizcocho, café, mascarpone y cacao.', 6.50);

---
-- Inserción de datos para la tabla PEDIDO
-- Se asume que los IDs de usuario del 1 al 5 son generados por la base de datos
INSERT INTO PEDIDO (num_orden, fecha_pedido, estado, total, id_usuario) VALUES
('ORD001', '2025-08-29', 'ENTREGADO', 30.80, 2),
('ORD002', '2025-08-29', 'PENDIENTE', 25.00, 2),
('ORD003', '2025-08-29', 'ENTREGADO', 20.50, 2),
('ORD004', '2025-08-29', 'PENDIENTE', 42.00, 3),
('ORD005', '2025-08-29', 'ENTREGADO', 19.30, 3);

---
-- Inserción de datos para la tabla DETALLE_PEDIDO
-- Se asume que los IDs de pedido y plato se generaron en las tablas anteriores
INSERT INTO DETALLE_PEDIDO (cantidad, num_mesa, subtotal, id_pedido, id_plato) VALUES
(2, 5, 25.00, 1, 1),
(1, 2, 9.80, 1, 2),
(1, 3, 12.50, 2, 1),
(2, 8, 16.00, 3, 3),
(1, 1, 14.00, 4, 4),
(1, 6, 6.50, 5, 5);
 
select * from plato; 
SELECT id_usuario FROM USUARIO;