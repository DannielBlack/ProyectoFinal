CREATE TABLE tblPersona
(
	[IdPersona] INT NOT NULL PRIMARY KEY identity, 
    [Nombres] VARCHAR(50) NOT NULL, 
    [Apellidos] VARCHAR(50) NOT NULL, 
    [Genero] CHAR(1) NOT NULL, 
    [Cedula] INT NOT NULL, 
    [Ciudad] VARCHAR(50) NOT NULL, 
    [Direccion] VARCHAR(50) NULL, 
    [FechaNacimiento] DATETIME NULL, 
    [GrupoSanguineo] CHAR(2) NULL, 
    [EstadoCivil] VARCHAR(50) NULL, 
    [Profesion] VARCHAR(50) NULL
)
