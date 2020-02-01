create database Sylom;

use Sylom;

-- Creacion de tablas de datos del sistema Sylom

/*
Tabla tipo paciente
*/
drop table if exists TipoPaciente;
create table TipoPaciente(
	idTipoPaciente int not null primary key,
	descripcion varchar(25) not null
);

/*
Tabla Paciente
*/
drop table if exists Paciente;
create table Paciente(
	idPaciente int not null primary key,
	cedula varchar(15) not null,
	nombre varchar(75) not null,
	edad int,
	direccion varchar(200),
	descripcionCliente varchar(250),
	fechaNacimiento date,
	fechaEntrada date not null,
	fechaSalida date null,
	idTipoPaciente int not null,
	activo bit,
	constraint idTipoPaciente_Paciente_fk foreign key(idTipoPaciente) references TipoPaciente(idTipoPaciente)
);

/*
Tabla Contacto
*/
drop table if exists Contacto;
create table Contacto(
	idContacto int not null primary key,
	cedula varchar(15) not null,
	nombre varchar(75) not null,
	telefono varchar(11) not null,
	email varchar(200),
	direccion varchar(200) not null,
	nombreTrabajo varchar(75),
	activo bit
);

/*
Tabla n-m Paciente_Contacto
*/
drop table if exists Paciente_Contacto;
create table Paciente_Contacto(
	idPaciente int not null,
	idContacto int not null,
	relacion varchar(25),
	activo bit,
	constraint idPaciente_idContacto_Paciente_Contacto_pk primary key(idPaciente,idContacto),
	constraint idPaciente_Paciente_Contacto_fk foreign key(idPaciente) references Paciente(idPaciente),
	constraint idContacto_Paciente_Contacto_fk foreign key(idContacto) references Contacto(idContacto)
);

/*
Tabla Expediente
*/
drop table if exists Expediente;
create table Expediente(
	idExpediente int not null primary key,
	descripcion varchar(75),
	idPaciente int not null,
	activo bit,
	constraint idPaciente_Expediente_fk foreign key(idPaciente) references Paciente(idPaciente)
);

/*
Tabla Anotaciones
*/
drop table if exists Anotacion;
create table Anotacion(
	idAnotacion int not null primary key,
	descripcion varchar(100),
	idExpediente int not null,
	constraint idExpediente_Anotacion_fk foreign key(idExpediente) references Expediente(idExpediente)
);

/*
Tabla TipoActividad
*/
drop table if exists TipoActividad;
create table TipoActividad(
	idTipoActividad int not null primary key,
	descripcion varchar(75)
);

/*
Tabla Actividad
*/
drop table if exists Actividad;
create table Actividad(
	idActividad int not null primary key,
	descripcion varchar(75) not null,
	notas varchar(200),
	idTipoActividad int not null,
	constraint idTipoActividad_Actividad_fk foreign key(idTipoActividad) references TipoActividad(idTipoActividad)
);

/*
Tabla TipoEmpleado
*/
drop table if exists TipoEmpleado;
create table TipoEmpleado(
	idTipoEmpleado int not null primary key,
	descripcion varchar(75) not null
);

/*
Tabla Empleado
*/
drop table if exists Empleado;
create table Empleado(
	idEmpleado int not null primary key,
	cedula varchar(15) not null,
	nombre varchar(75) not null,
	salario decimal(12,2),
	fechaEntrada date null,
	fechaSalida date null,
	direccion varchar(200),
	telefono varchar(11) not null,
	email varchar(200),
	idTipoEmpleado int not null,
	activo bit,
	constraint idTipoEmpleado_Empleado_fk foreign key(idTipoEmpleado) references TipoEmpleado(idTipoEmpleado)
);

/*
Tabla Usuario
*/
drop table if exists Usuario;
create table Usuario(
	idUsuario int not null primary key,
	usuario varchar(255) not null,
	contra varchar(255) not null,
	idEmpleado int not null,
	activo bit,
	constraint idEmpleado_Usuario_fk foreign key(idEmpleado) references Empleado(idEmpleado)
);

/*
Tabla TipoSesion
*/
drop table if exists TipoSesion;
create table TipoSesion(
	idTipoSesion int not null primary key,
	descripcion varchar(75)
);

/*
Tabla Sesion
*/
drop table if exists Sesion;
create table Sesion(
	idSesion int not null primary key,
	fechaHoraInicio datetime not null,
	fechaHoraFin datetime null,
	sala varchar(75),
	idTipoSesion int not null,
	idExpediente int not null,
	idUsuario int not null,
	activo bit,
	constraint idTipoSesion_Sesion_fk foreign key(idTipoSesion) references TipoSesion(idTipoSesion),
	constraint idExpediente_Sesion_fk foreign key(idExpediente) references Expediente(idExpediente),
	constraint idUsuario_Sesion_fk foreign key(idUsuario) references Usuario(idUsuario)
);

/*
Tabla (n-m) Actividad_Sesion
*/
drop table if exists Actividad_Sesion;
create table Actividad_Sesion(
	idActividad int not null,
	idSesion int not null,
	notas varchar(150),
	constraint idActividad_idSesion_Actividad_Sesion_pk primary key(idActividad,idSesion),
	constraint idActividad_Actividad_Sesion_fk foreign key(idActividad) references Actividad(idActividad),
	constraint idSesion_Actividad_Sesion_fk foreign key(idSesion) references Sesion(idSesion)
);

-- Creacion de tablas de seguridad del sistema Sylom

/*
Tabla Accion
*/
drop table if exists Accion;
create table Accion(
	idAccion int not null primary key,
	descripcion varchar(75) not null
);

/*
Tabla Apartado
*/
drop table if exists Apartado;
create table Apartado(
	idApartado int not null primary key,
	descripcion varchar(75)
);

/*
Tabla Rol
*/
drop table if exists Rol;
create table Rol(
	idRol int not null primary key,
	descripcion varchar(75)
);

/*
Tabla Rol_Apartado_Accion
*/
drop table if exists Rol_Apartado_Accion;
create table Rol_Apartado_Accion(
	idRol int not null,
	idApartado int not null,
	idAccion int not null,
	constraint idRol_idApartado_idAccion_Rol_Apartado_Accion_pk primary key(idRol,idApartado,idAccion),
	constraint idRol_Rol_Apartado_Accion_fk foreign key(idRol) references Rol(idRol),
	constraint idApartado_Rol_Apartado_Accion_fk foreign key(idApartado) references Apartado(idApartado),
	constraint idAccion_Rol_Apartado_Accion_fk foreign key(idAccion) references Accion(idAccion)
);

/*
Tabla Usuario_Rol
*/
drop table if exists Usuario_Rol;
create table Usuario_Rol(
	idUsuario int not null,
	idRol int not null,
	constraint idUsuario_idRol_Usuario_Rol_pk primary key(idUsuario,idRol),
	constraint idUsuario_Usuario_Rol_fk foreign key(idUsuario) references Usuario(idUsuario),
	constraint idRol_Usuario_Rol_fk foreign key(idRol) references Rol(idRol)
);

/*
Tabla Bitacora
*/
drop table if exists Bitacora;
create table Bitacora(
	idBitacora int not null primary key,
	controlador varchar(75) not null,
	metodo varchar(75) not null,
	msj varchar(200) not null,
	fecha date not null,
	tipo char not null,-- S:success, E:error, N:not authorized, [other]:Unknown
	idUsuario int not null,
	constraint idUsuario_Bitacora_fk foreign key(idUsuario) references Usuario(idUsuario) 
);