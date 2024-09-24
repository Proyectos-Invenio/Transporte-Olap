-- Crear usuario Administrador
CREATE LOGIN admin_login WITH PASSWORD = 'loselose57';
CREATE USER admin_user FOR LOGIN admin_login;
EXEC sp_addrolemember 'db_admin', 'admin_user';

-- Crear usuario Gerente
CREATE LOGIN manager_login WITH PASSWORD = 'lsoelose57';
CREATE USER manager_user FOR LOGIN manager_login;
EXEC sp_addrolemember 'db_manager', 'manager_user';

-- Crear usuario Analista
CREATE LOGIN analyst_login WITH PASSWORD = 'loselose57';
CREATE USER analyst_user FOR LOGIN analyst_login;
EXEC sp_addrolemember 'db_analyst', 'analyst_user';
