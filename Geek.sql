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

CREATE TABLE EstadoProducto
(
	idEstado 		CHAR(5)		 PRIMARY KEY,
	nombreEstado	VARCHAR(50)	 NOT NULL
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
	idEstado 			CHAR(5)	
    CONSTRAINT FK_Producto_Marca FOREIGN KEY (idMarca) REFERENCES Marca(idMarca),
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria),
	CONSTRAINT FK_Producto_Estado FOREIGN KEY (idEstado) REFERENCES EstadoProducto(idEstado)
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

CREATE TABLE Carrito (
    idCarrito		CHAR(5)		PRIMARY KEY,
	idProducto		CHAR(5),
	idUsuario		CHAR(5),
	cantidad		INT			DEFAULT 1,
	CONSTRAINT FK_Carrito_Producto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),
	CONSTRAINT FK_Carrito_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario)
)
go

CREATE TABLE EstadoOrden
(
	idEstadoOrden 		CHAR(5)		 PRIMARY KEY,
	nombreEstadoOrden	VARCHAR(50)	 NOT NULL
)
go

CREATE TABLE Orden 
(
    idOrden				CHAR(5)    PRIMARY KEY,
    idCarrito			CHAR(5),
    idUsuario			CHAR(5),
	idEstadoOrden 		CHAR(5),
    cantidad			INT			DEFAULT	1,
	fechaCreacion	    DATETIME	NOT NULL		DEFAULT		GETDATE(),
    CONSTRAINT FK_Orden_Carrito FOREIGN KEY (idCarrito) REFERENCES Carrito(idCarrito),
    CONSTRAINT FK_Orden_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
	CONSTRAINT FK_Orden_EstadoOrden FOREIGN KEY (idEstadoOrden) REFERENCES EstadoOrden(idEstadoOrden)
)
go






