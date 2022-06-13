use TPC

insert into TipoUsuario (descripcion)
values('Administrador'),('Vendedor')

insert into Usuarios(nombre,apellido,dni, IDTipoUsuario, contraseña, nick, fechaNac)
values ('Admin','Admin','1111','1','Admin','Admin',GETDATE()), ('Empleado1','Empleado1','00001','2','MyUser','Empleado1',GETDATE())