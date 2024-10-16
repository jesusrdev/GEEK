use master
go

if DB_ID('DB_GEEK') is not null
begin
	use master
	drop database DB_GEEK
end
go

CREATE DATABASE DB_GEEK
go 

USE DB_GEEK
go

CREATE TABLE Rol
(
	idRol			CHAR(5)		PRIMARY KEY,
	descripcionRol	VARCHAR(50) NOT NULL
)
go

CREATE TABLE Usuario
(
	idUsuario			CHAR(5)			PRIMARY KEY,
	nombreUsuario		VARCHAR(50)		NOT NULL,
	apellidoUsuario		VARCHAR(50)		NOT NULL,
	email				VARCHAR(100)	NOT NULL	UNIQUE,	
	contrasenia			VARCHAR(50)		NOT NULL,
	fechaRegistro		DATETIME		NOT NULL	DEFAULT		GETDATE(),
	direccion           VARCHAR(200)	NOT NULL,
	departamento		VARCHAR(50)		NOT NULL,
	pais				VARCHAR(50)		NOT NULL,
	idRol				CHAR(5)         /*DEFAULT 'user'*/,
	CONSTRAINT FK_Usuario_Rol FOREIGN KEY(idRol) REFERENCES Rol(idRol)
)
go

CREATE TABLE Marca
(
	idMarca			CHAR(5)		 PRIMARY KEY,
	nombreMarca		VARCHAR(50)	 NOT NULL,
	rutaImagen		VARCHAR(255)	NOT NULL
)
go

CREATE TABLE Categoria
(
	idCategoria				CHAR(5)		PRIMARY KEY,
	descripcionCategoria	VARCHAR(50)	 NOT NULL,
)
go


CREATE TABLE Producto 
(
    idProducto			CHAR(5)			PRIMARY KEY,
    nombreProducto		VARCHAR(100)	NOT NULL,
    descripcion			VARCHAR(200), 
	descripcioGeneral	VARCHAR(MAX),
    precio				DECIMAL(10, 2),
	stockProducto		INT,
	descuento			DECIMAL(10, 2),
    idMarca				CHAR(5),
    idCategoria			CHAR(5),
	estadoProducto		VARCHAR(50)	
    CONSTRAINT FK_Producto_Marca FOREIGN KEY (idMarca) REFERENCES Marca(idMarca),
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria),
)
go

CREATE TABLE Imagen
(
	idImagen 		CHAR(5)			PRIMARY KEY,
	rutaImagen		VARCHAR(255)	NOT NULL,
)
go

CREATE TABLE ProductoImagen (
    idProducto		    CHAR(5),
    idImagen			CHAR(5),
    PRIMARY KEY (idProducto, idImagen),
    CONSTRAINT FK_ProductoImagen_Producto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),
    CONSTRAINT FK_ProductoImagen_ImagenProducto FOREIGN KEY (idImagen) REFERENCES Imagen(idImagen)
)
go

CREATE TABLE Orden 
(
    idOrden				CHAR(5)    PRIMARY KEY,
    idUsuario			CHAR(5),
	estadoOrden 		CHAR(5),
	fechaCreacion	    DATETIME	NOT NULL		DEFAULT		GETDATE(),
    CONSTRAINT FK_Orden_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
)
go

CREATE TABLE DetalleOrden (
    idOrden			CHAR(5),
	idProducto		CHAR(5),
	idUsuario		CHAR(5),
	cantidad		INT			DEFAULT 1,
	precio			FLOAT,
	PRIMARY KEY(idOrden,idProducto),
	CONSTRAINT FK_DetalleOrden_Producto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),
	CONSTRAINT FK_DetalleOrden_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
	CONSTRAINT FK_DetalleOrden_Orden FOREIGN KEY (idOrden) REFERENCES Orden(idOrden)
)
go





