USE msdb;
GO

-- Crear un trabajo de respaldo
EXEC sp_add_job 
    @job_name = N'Respaldo_Diario';

-- Agregar un paso al trabajo
EXEC sp_add_jobstep 
    @job_name = N'Respaldo_Diario', 
    @step_name = N'Respaldo_OLAPTRANSPORTE',
    @subsystem = N'TSQL',
    @command = N'BACKUP DATABASE OLAPTRANSPORTE 
                TO DISK = N''C:\Respaldos\OLAPTRANSPORTE.bak'' 
                WITH NOFORMAT, NOINIT,  
                NAME = N''Respaldo Completo'', 
                SKIP, NOREWIND, NOUNLOAD,  STATS = 10',
    @retry_attempts = 3, 
    @retry_interval = 5; 

-- Programar el trabajo diariamente
EXEC sp_add_jobschedule 
    @job_name = N'Respaldo_Diario',
    @name = N'Schedule_Diario',
    @freq_type = 4,  -- Diario
    @freq_interval = 1, 
    @active_start_time = 020000;  -- 2:00 AM

-- Habilitar el trabajo
EXEC sp_add_jobserver 
    @job_name = N'Respaldo_Diario';
GO
