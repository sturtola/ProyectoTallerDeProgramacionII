CREATE DATABASE AurenPadelBD;
GO
USE AurenPadelBD;
GO
CREATE TABLE Usuario (
   Dni INT NOT NULL CONSTRAINT pk_Dni PRIMARY KEY,
   Nombre NVARCHAR (50) NOT NULL,
   Apellido NVARCHAR (50) NOT NULL,
   Contrasena NVARCHAR (128) NOT NULL,
   Rol NVARCHAR (20) NOT NULL CONSTRAINT chk_Rol CHECK (Rol IN ('Administrador', 'Vendedor', 'Gerente')), 
   Estado BIT NOT NULL DEFAULT 1,
)

INSERT INTO Usuario (Dni, Nombre, Apellido, Contrasena, Rol, Estado)
VALUES 
(27443675, 'Jose', 'Lopez', '12348765', 'Gerente', 1),
(34556343, 'Juan', 'Perez', '12345678', 'Vendedor', 1),
(39482712, 'Ana', 'Garcia', '87654321', 'Administrador', 1);

SELECT * FROM Usuario;
