use master
go

create database TPC
go

use TPC
go

create table Categorias(
	IDCategoria bigint primary key identity(1,1),
	Descripcion varchar(50) not null unique
)
go

create table TipoProducto(
	IDTipoProducto bigint primary key identity(1,1),
	Descripcion varchar(50) not null unique 
)
go

create table Marcas(
	IDMarca bigint primary key identity(1,1),
	Descripcion varchar(40) not null unique
)
go

create table Proveedores(
	IDProveedor bigint primary key not null identity(1,1),
	Nombre varchar(40) not null
)
go

create table Productos(
	IDProducto bigint primary key identity(1,1),
	Nombre varchar(40) not null,
	Descripcion varchar(250) not null,
	IDCategoria bigint foreign key references Categorias(IDCategoria),
	IDMarca bigint foreign key references Marcas(IDMarca),
	IDTipoProducto bigint foreign key references TipoProducto(IDTipoProducto),
	Stock int not null,
	StockMinimo int not null,
	porcentajeVenta smallint not null,
)
go

create table TipoUsuario(
	idTipoUsuario bigint primary key identity (1,1),
	descripcion varchar(150),
)
go

create table Usuarios(
	idUsuario bigint primary key identity (1,1),
	nombre varchar(100) not null,
	apellido varchar(100) not null,
	dni varchar(10) not null unique,
	IDTipoUsuario bigint foreign key references TipoUsuario(IDTipoUsuario),
	contraseña varchar(20) not null,
	nick varchar(25) not null unique,
	fechaNac date not null,
)
go

create table Clientes(
	idCliente bigint primary key identity (1,1),
	nombre varchar(100) not null,
	cuitOrDni varchar(15) null unique,
	fechaNac date not null,
	telefono varchar(20) unique null,
	email varchar(100) unique null,
)
go

create table TipoDeFactura(
	idTipoFactura bigint primary key identity(1,1),
	descripcion varchar(100) not null,
)
go

create table Ventas(
	IDRegistro bigint primary key identity(1,1),
	NumeroFactura bigint unique,
	TipoFactura bigint foreign key references TipoDeFactura(idTipoFactura),
	idVendedor bigint foreign key references Usuarios(idUsuario),
	idCliente bigint foreign key references Clientes(IDCliente),
	Fecha date not null,
	MontoTotal money not null,
	detalle varchar(max)
)
go

create table Compras(
	IDRegistro bigint primary key identity(1,1),
	NumeroFactura bigint unique,
	TipoFactura bigint foreign key references TipoDeFactura(idTipoFactura),
	IDProveedor bigint foreign key references Proveedores(IDProveedor),
	IDAdministrador bigint foreign key references Usuarios(IDUsuario),
	Fecha date not null,
	MontoTotal money not null,
	detalle varchar(max)
)
go

create table ProductoXCompra(
	IDRegistro bigint foreign key references Compras(IDRegistro) not null,
	IDProducto bigint foreign key references Productos(IDProducto) not null,
	Cantidad bigint not null,
	precioCompra money not null,
)
go

create table ProductoXVenta(
	IDRegistro bigint foreign key references Ventas(IDRegistro) not null,
	IDProducto bigint foreign key references Productos(IDProducto) not null,
	Cantidad bigint not null,
	precioVenta money not null,
)
go


insert into TipoUsuario (descripcion)
values('Administrador'),('Vendedor')
go

insert into Usuarios(nombre,apellido,dni, IDTipoUsuario, contraseña, nick, fechaNac)
values ('Admin','Admin','1111','1','Admin','Admin',GETDATE())
go

insert into TipoDeFactura(Descripcion)
values('Nota de Credito'), ('Factura Original'), ('Factura Duplicada')
go

Create Procedure sp_VistaVentas AS
Select ventas.IDRegistro, ventas.NumeroFactura, TipoDeFactura.descripcion, Usuarios.nick, Clientes.nombre, Productos.Nombre AS NombreProducto, pxv.Cantidad, pxv.precioVenta ,ventas.Fecha, ventas.MontoTotal, Ventas.detalle from ventas
inner join TipoDeFactura on TipoDeFactura.idTipoFactura = Ventas.TipoFactura
inner join Usuarios on Usuarios.idUsuario = Ventas.idVendedor
inner join Clientes on Clientes.idCliente = Ventas.idCliente
inner join ProductoxVenta pxv on pxv.IDRegistro = Ventas.IDRegistro
inner join Productos on Productos.IDProducto = pxv.IDProducto

exec sp_VistaVentas
