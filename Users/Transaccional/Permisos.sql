-- Permisos para Administrador (acceso completo)
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO db_admin;
GRANT EXECUTE ON SCHEMA::dbo TO db_admin;

-- Permisos para Gerente (s�lo consulta y descarga de informes)
GRANT SELECT ON SCHEMA::dbo TO db_manager;
GRANT EXECUTE ON PROCEDURE::GenerateReport TO db_manager;

-- Permisos para Analista (creaci�n de an�lisis y generaci�n de informes)
GRANT SELECT ON SCHEMA::dbo TO db_analyst;
GRANT INSERT, UPDATE ON TABLE dbo.AnalysisData TO db_analyst;
GRANT EXECUTE ON PROCEDURE::GenerateAnalysis TO db_analyst;
