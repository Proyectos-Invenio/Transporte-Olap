CREATE DATABASE OLAPTRANSPORTE;

-- Tabla Clientes
CREATE TABLE Clientes (
ID_Cliente INT PRIMARY KEY IDENTITY(1,1),
Nombre_Cliente VARCHAR(100),
Telefono_Cliente VARCHAR(15),
Email_Cliente VARCHAR(100),
Direccion_Cliente VARCHAR(200)
);
-- Tabla Vehiculos
CREATE TABLE Vehiculos (
ID_Vehiculo INT PRIMARY KEY IDENTITY(1,1),
Tipo_Vehiculo VARCHAR(50),
Capacidad DECIMAL(10,2),
Placa VARCHAR(20),
Fecha_Mantenimiento DATE,
Estado VARCHAR(50)
);
-- Tabla Conductores
CREATE TABLE Conductores (
ID_Conductor INT PRIMARY KEY IDENTITY(1,1),
Nombre_Conductor VARCHAR(100),
Telefono_Conductor VARCHAR(15),
Fecha_Contratacion DATE,
Estado VARCHAR(50)
);
-- Tabla Rutas
CREATE TABLE Rutas (
ID_Ruta INT PRIMARY KEY IDENTITY(1,1),
Origen VARCHAR(100),
Destino VARCHAR(100),
Distancia DECIMAL(10,2),
Duracion_Estimada TIME
);
-- Tabla Servicios de Transporte
CREATE TABLE Servicios_Transporte (
ID_Servicio INT PRIMARY KEY IDENTITY(1,1),
ID_Cliente INT FOREIGN KEY REFERENCES Clientes(ID_Cliente),
ID_Vehiculo INT FOREIGN KEY REFERENCES Vehiculos(ID_Vehiculo),
ID_Conductor INT FOREIGN KEY REFERENCES Conductores(ID_Conductor),
ID_Ruta INT FOREIGN KEY REFERENCES Rutas(ID_Ruta),
Fecha_Salida DATETIME,
Fecha_Llegada DATETIME,
Estado VARCHAR(50),
Costo DECIMAL(10,2),
Peso_Carga DECIMAL(10,2),
Descripcion_Carga VARCHAR(200)
);