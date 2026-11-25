-- Execute em uma NOVA consulta no SQL Server Object Explorer ou no SSMS.
-- Servidor padrão deste projeto: (localdb)\MSSQLLocalDB
USE master;
GO

IF DB_ID(N'CadastroComputadores') IS NULL
BEGIN
    EXEC(N'CREATE DATABASE CadastroComputadores');
END;
GO

USE CadastroComputadores;
GO

IF OBJECT_ID(N'dbo.Computadores', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Computadores
    (
        Id INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_Computadores PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Marca NVARCHAR(60) NOT NULL,
        Processador NVARCHAR(100) NOT NULL,
        MemoriaRamGb INT NOT NULL,
        ArmazenamentoGb INT NOT NULL,
        CONSTRAINT CK_Computadores_MemoriaRamGb
            CHECK (MemoriaRamGb BETWEEN 1 AND 2048),
        CONSTRAINT CK_Computadores_ArmazenamentoGb
            CHECK (ArmazenamentoGb BETWEEN 1 AND 100000)
    );
END;
GO

SELECT * FROM dbo.Computadores ORDER BY Id DESC;
