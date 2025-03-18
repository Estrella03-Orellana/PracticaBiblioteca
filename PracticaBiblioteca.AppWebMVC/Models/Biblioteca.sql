
CREATE DATABASE Biblioteca;
GO

USE Biblioteca;
GO

CREATE TABLE Autores (
  Id INT PRIMARY KEY IDENTITY(1,1),
  Nombre VARCHAR(255) NOT NULL,
);

CREATE TABLE Editoriales (
  Id INT PRIMARY KEY IDENTITY(1,1),
  Nombre VARCHAR(255) NOT NULL
);



CREATE TABLE Libros (
  Id INT PRIMARY KEY IDENTITY(1,1),
  Titulo VARCHAR(255) NOT NULL,
  AutorID INT,
  EditorialId INT,
 FOREIGN KEY (AutorId) REFERENCES Autores(Id),
 FOREIGN KEY (EditorialId) REFERENCES Editoriales(Id)
);




CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Password CHAR(32) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    UltimoInicioSesion DATETIME,
    Estatus TINYINT DEFAULT 1 -- Usamos TINYINT para Estatus y un valor predeterminado de 1
);

