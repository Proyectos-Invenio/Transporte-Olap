# Usuarios:

## 1.	Administrador de Base de Datos (DBA)

###	Descripción
Este perfil tiene el control total sobre la base de datos. Es responsable de la administración, mantenimiento, seguridad, y respaldo de la base de datos.

###	Permisos

-   CREATE DATABASE, ALTER DATABASE, DROP DATABASE
-  	CREATE TABLE, ALTER TABLE, DROP TABLE
-  	CREATE PROCEDURE, ALTER PROCEDURE, DROP PROCEDURE
-  	CREATE VIEW, ALTER VIEW, DROP VIEW
-  	BACKUP DATABASE, RESTORE DATABASE
-  	GRANT, REVOKE, DENY permisos a otros usuarios
-  	db_owner en las bases de datos relevantes

## 2.	 Usuario de Aplicación

### Descripción
Este perfil está diseñado para el usuario o el servicio de la aplicación que interactúa con la base de datos para realizar operaciones de lectura y escritura, como inserciones, actualizaciones y consultas. Generalmente, no tiene permisos para modificar la estructura de la base de datos.

### Permisos:

-	SELECT, INSERT, UPDATE, DELETE en las tablas necesarias
-	EXECUTE en procedimientos almacenados y funciones relevantes
-	VIEW DEFINITION para ver la estructura de las tablas y otros objetos
-	db_datareader y db_datawriter en las bases de datos relevantes

## 3.    Analista de Datos

### Descripción: 
Este perfil se asigna a usuarios encargados de realizar análisis de datos. Tienen acceso de solo lectura a las tablas y vistas, y pueden ejecutar procedimientos almacenados diseñados para la extracción de datos. No pueden realizar modificaciones en los datos ni en la estructura de la base de datos.

### Permisos:

-	SELECT en todas las tablas y vistas relevantes
-	EXECUTE en procedimientos almacenados y funciones de lectura de datos
-	db_datareader en las bases de datos relevantes
-	Acceso a herramientas de análisis y reporting si están integradas con SQL Server (como SQL Server Reporting Services, SSRS)

