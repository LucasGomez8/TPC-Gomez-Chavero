use master
go

create database TPC
go

use TPC
go

create table Categorias(
	IDCategoria Bigint primary key identity(1,1),
	Descripcion varchar(50) not null
)
go

create table Marcas(
	IDMarca bigint primary key identity(1,1),
	Descripcion varchar(40) not null
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
	Stock int not null,
	StockMinimo int not null,
	Precio money not null,
)
go