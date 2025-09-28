# ??? Sistema de Gestión de Restaurante

Sistema completo de gestión para restaurantes desarrollado en **C# .NET Framework 4.7.2** con arquitectura en capas, base de datos SQLite local y sincronización con Supabase.

## ?? Características Principales

- **Dashboard Administrativo** con métricas en tiempo real
- **Gestión de Usuarios** con roles (Administrador/Recepcionista)
- **Administración de Platos** (CRUD completo)
- **Sistema de Pedidos** con numeración automática
- **Reportes de Ventas** y análisis de ganancias
- **Base de Datos Híbrida** (SQLite + Supabase)
- **Interfaz de Usuario** intuitiva en Windows Forms
- **Sincronización automática** con la nube

## ??? Arquitectura del Sistema

El proyecto sigue una arquitectura en capas bien definida:

```
SistemaRestaurante.UI/          # Interfaz de Usuario (Windows Forms)
??? Formularios/                # Formularios de la aplicación
??? Recursos/                   # Imágenes y recursos
??? appsettings.json           # Configuración de conexiones

SistemaRestaurante.BLL/         # Lógica de Negocio
??? UsuarioBLL.cs              # Lógica de usuarios
??? PlatoBLL.cs                # Lógica de platos
??? RegistroPedidoBLL.cs       # Lógica de pedidos
??? GananciasBLL.cs            # Lógica de reportes

SistemaRestaurante.DAL/         # Acceso a Datos
??? ConexionDB.cs              # Conexión SQLite
??? UsuarioDAL.cs              # CRUD usuarios
??? PlatoDAL.cs                # CRUD platos
??? RegistroPedidoDAL.cs       # CRUD pedidos
??? GananciasDAL.cs            # Consultas de reportes
??? SupabaseSyncService.cs     # Sincronización con Supabase

SistemaRestaurante.ENT/         # Entidades
??? Usuario.cs                 # Modelo de usuario
??? Plato.cs                   # Modelo de plato
??? Pedido.cs                  # Modelo de pedido
??? DetallePedido.cs          # Modelo detalle pedido
```

## ??? Base de Datos

El sistema utiliza una arquitectura híbrida con **SQLite** para almacenamiento local y **Supabase** para sincronización en la nube.

### SQLite (Base de Datos Local)

#### Scripts DDL (Creación de Tablas)

```sql
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

-- Tabla para secuencia de órdenes
CREATE TABLE IF NOT EXISTS orden_secuencia (
    fecha DATE PRIMARY KEY,
    last_number INTEGER NOT NULL
);
```

#### Scripts DML (Datos Iniciales)

```sql
-- Usuarios iniciales
INSERT OR REPLACE INTO usuario (id_usuario, nombre, username, password, rol) 
VALUES (1, 'Administrador', 'admin', 'admin123', 'ADMIN');

INSERT OR REPLACE INTO usuario (id_usuario, nombre, username, password, rol) 
VALUES (2, 'Recepcionista', 'recep', 'recep123', 'RECEPCIONISTA');

-- Platos de ejemplo
INSERT INTO plato (nombre, descripcion, precio) 
VALUES ('Pollo a la plancha', 'Pechuga de pollo con guarnición', 35.00);

INSERT INTO plato (nombre, descripcion, precio) 
VALUES ('Pasta Bolognesa', 'Pasta con salsa de carne', 28.00);

INSERT INTO plato (nombre, descripcion, precio) 
VALUES ('Ensalada César', 'Ensalada fresca con pollo', 22.00);
```

### Supabase (Base de Datos en la Nube)

#### Scripts DDL para Supabase

```sql
-- Tabla usuarios (Supabase)
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

-- Tabla platos (Supabase)
CREATE TABLE platos (
    id SERIAL PRIMARY KEY,
    id_local INTEGER,
    nombre TEXT NOT NULL,
    descripcion TEXT,
    precio DECIMAL(10,2) NOT NULL,
    created_at TIMESTAMPTZ DEFAULT NOW(),
    updated_at TIMESTAMPTZ DEFAULT NOW()
);

-- Tabla pedidos (Supabase)
CREATE TABLE pedidos (
    id SERIAL PRIMARY KEY,
    id_local INTEGER,
    fecha_pedido TIMESTAMPTZ NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    created_at TIMESTAMPTZ DEFAULT NOW(),
    updated_at TIMESTAMPTZ DEFAULT NOW()
);

-- Tabla detalle_pedidos (Supabase)
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

-- Índices para mejorar rendimiento
CREATE INDEX idx_usuarios_username ON usuarios(username);
CREATE INDEX idx_pedidos_fecha ON pedidos(fecha_pedido);
CREATE INDEX idx_detalle_pedidos_pedido ON detalle_pedidos(id_pedido);
```

## ?? Configuración

### Requisitos Previos

- **.NET Framework 4.7.2** o superior
- **Visual Studio 2019/2022**
- **SQLite** (incluido en el proyecto)
- **Cuenta de Supabase** (opcional para sincronización)

### Configuración de Base de Datos

1. **SQLite Local**: Se crea automáticamente al ejecutar la aplicación
2. **Supabase**: Configurar en `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=restaurante.db;Version=3;"
  },
  "Supabase": {
    "Url": "https://tu-proyecto.supabase.co",
    "Key": "tu-api-key-aqui",
    "Enabled": true
  }
}
```

### Instalación y Ejecución

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/FabioCanelas/SistemaRestaurante.UI.git
   cd SistemaRestaurante.UI
   ```

2. **Abrir en Visual Studio**
   - Abrir `SistemaRestaurante.UI.sln`
   - Restaurar paquetes NuGet
   - Compilar la solución

3. **Ejecutar la aplicación**
   - Establecer `SistemaRestaurante.UI` como proyecto de inicio
   - Presionar F5 o ejecutar

### Credenciales por Defecto

- **Administrador**: `admin` / `admin123`
- **Recepcionista**: `recep` / `recep123`

## ?? Funcionalidades

### Dashboard Administrativo
- Métricas en tiempo real (ganancias, pedidos)
- Actualización automática cada 30 segundos
- Tarjetas informativas con colores distintivos

### Gestión de Usuarios
- Crear, editar y eliminar usuarios
- Roles: Administrador y Recepcionista
- Validaciones de seguridad

### Administración de Platos
- CRUD completo de platos
- Gestión de precios y descripciones
- Integración con sistema de pedidos

### Sistema de Pedidos
- Numeración automática (ORD001, ORD002...)
- Gestión de mesas
- Cálculo automático de totales
- Estado de pedidos

### Reportes y Analytics
- Ganancias por día/mes
- Total de pedidos
- Promedio diario
- Filtros por fechas

## ?? Sincronización con Supabase

El sistema incluye sincronización automática con Supabase:

- **Detección automática** de conexión a internet
- **Sincronización incremental** de datos
- **Mapeo de campos** entre SQLite y PostgreSQL
- **Manejo de errores** robusto

### Configurar Supabase

1. Crear proyecto en [Supabase](https://supabase.com/)
2. Ejecutar scripts DDL de Supabase
3. Obtener URL y API Key
4. Configurar en `appsettings.json`
5. Habilitar sincronización: `"Enabled": true`

## ?? Dependencias

### Paquetes NuGet
```xml
<PackageReference Include="System.Data.SQLite" Version="1.0.118" />
<PackageReference Include="Microsoft.Extensions.Configuration" Version="6.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="6.0.0" />
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
```

## ??? Desarrollo

### Estructura del Código
- **Patrón Repository** para acceso a datos
- **Inyección de dependencias** manual
- **Separación de responsabilidades** por capas
- **Manejo de excepciones** centralizado

### Buenas Prácticas Implementadas
- Uso de `using` statements para recursos
- Transacciones para operaciones críticas
- Validación en capa de negocio
- Logs de debugging

## ?? Licencia

Este proyecto está bajo la Licencia MIT. Ver [LICENSE](LICENSE) para más detalles.

## ?? Contribuciones

Las contribuciones son bienvenidas. Por favor:

1. Hacer fork del proyecto
2. Crear una rama para la funcionalidad (`git checkout -b feature/AmazingFeature`)
3. Commit de cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## ?? Soporte

Para reportar bugs o solicitar funcionalidades, por favor crear un [issue](https://github.com/FabioCanelas/SistemaRestaurante.UI/issues).

---

**Desarrollado con ?? para la gestión eficiente de restaurantes**