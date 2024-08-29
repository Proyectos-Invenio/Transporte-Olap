

--Creacion de la Base de Datos
CREATE DATABASE Hospital_San_Arcangel;


--Usamos la Base de Datos Creada 
USE Hospital_San_Arcangel;


-- Creamos la tabla Pacientes
CREATE TABLE Pacientes (
  nombre VARCHAR(50) NOT NULL,
  fechaDeNacimiento DATE NOT NULL,
  id VARCHAR(50) PRIMARY KEY,
  género VARCHAR(20) NOT NULL,
  informaciónDeContacto VARCHAR(100) NOT NULL
);

-- Creamos la tabla Departamentos
CREATE TABLE Departamentos (
  id VARCHAR(50) PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  ubicación VARCHAR(100) NOT NULL
);


-- Creamos la tabla Doctores
CREATE TABLE Doctores (
  id VARCHAR(50) PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  especialidad VARCHAR(50) NOT NULL,
  idDepartamento VARCHAR(50) FOREIGN KEY REFERENCES Departamentos(id),
  informaciónDeContacto VARCHAR(100) NOT NULL
);


-- Creamos la tabla Citas
CREATE TABLE Citas (
  id VARCHAR(50) PRIMARY KEY,
  idPaciente VARCHAR(50) FOREIGN KEY REFERENCES Pacientes(id), 
  idDoctor VARCHAR(50) FOREIGN KEY REFERENCES Doctores(id),
  fechaDeCita DATETIME NOT NULL,
  estado VARCHAR(20) NOT NULL
);


-- Creamos la tabla Tratamientos
CREATE TABLE Tratamientos (
  id VARCHAR(50) PRIMARY KEY,
  idCita VARCHAR(50) FOREIGN KEY REFERENCES Citas(id),
  tipoDeTratamiento VARCHAR(50) NOT NULL,
  descripción VARCHAR(200) NOT NULL,
  costo DECIMAL(10,2) NOT NULL
);

--Insertar Datos en Departamentos
INSERT INTO Departamentos (id, nombre, ubicación) VALUES
('D001', 'Pediatría', 'Primer Piso'),
('D002', 'Cardiología', 'Segundo Piso'),
('D003', 'Neurología', 'Tercer Piso');

--Insertar Datos en Pacientes
INSERT INTO Pacientes (id, nombre, fechaDeNacimiento, género, informaciónDeContacto) VALUES
('P001', 'Juan Pérez', '1985-06-15', 'Masculino', 'juan.perez@example.com'),
('P002', 'María López', '1990-03-22', 'Femenino', 'maria.lopez@example.com'),
('P003', 'Carlos García', '1978-11-30', 'Masculino', 'carlos.garcia@example.com');

--Insertar Datos en Doctores
INSERT INTO Doctores (id, nombre, especialidad, idDepartamento, informaciónDeContacto) VALUES
('D001', 'Dr. Ana Torres', 'Pediatría', 'D001', 'ana.torres@example.com'),
('D002', 'Dr. Luis Martínez', 'Cardiología', 'D002', 'luis.martinez@example.com'),
('D003', 'Dr. Elena Ruiz', 'Neurología', 'D003', 'elena.ruiz@example.com');

--Insertar Datos en Citas
INSERT INTO Citas (id, idPaciente, idDoctor, fechaDeCita, estado) VALUES
('C001', 'P001', 'D001', '2024-09-10 10:00:00', 'Confirmada'),
('C002', 'P002', 'D002', '2024-09-11 11:00:00', 'Pendiente'),
('C003', 'P003', 'D003', '2024-09-12 09:30:00', 'Cancelada');

--Insertar Datos en Tratamientos
INSERT INTO Tratamientos (id, idCita, tipoDeTratamiento, descripción, costo) VALUES
('T001', 'C001', 'Consulta', 'Consulta pediátrica general', 50.00),
('T002', 'C002', 'Examen', 'Examen cardiológico', 100.00),
('T003', 'C003', 'Consulta', 'Consulta neurológica', 75.00);


--Consulta 1: Obtener todos los pacientes
SELECT * FROM Pacientes;

--Consulta 2: Obtener todas las citas con detalles de pacientes y doctores
SELECT C.id AS CitaID, P.nombre AS Paciente, D.nombre AS Doctor, C.fechaDeCita, C.estado
FROM Citas C
JOIN Pacientes P ON C.idPaciente = P.id
JOIN Doctores D ON C.idDoctor = D.id;

--Consulta 3: Obtener tratamientos realizados con sus costos
SELECT T.id AS TratamientoID, C.fechaDeCita, T.tipoDeTratamiento, T.costo
FROM Tratamientos T
JOIN Citas C ON T.idCita = C.id;

--Consulta 4: Obtener todos los doctores en un departamento específico
SELECT D.nombre AS Doctor, D.especialidad
FROM Doctores D
WHERE D.idDepartamento = 'D001';  -- Cambia el ID del departamento según sea necesario

--Consulta 5: Obtener pacientes con citas confirmadas
SELECT P.nombre AS Paciente, C.fechaDeCita
FROM Pacientes P
JOIN Citas C ON P.id = C.idPaciente
WHERE C.estado = 'Confirmada';