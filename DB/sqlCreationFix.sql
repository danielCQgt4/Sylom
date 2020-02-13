create database SylomFix;

use SylomFix;

-- Eliminacion de tablas del systema Sylom
drop table if exists Rol_Apartado;
drop table if exists Usuario_Rol;
drop table if exists Rol;
drop table if exists Bitacora;
drop table if exists Medicina_Sesion;
drop table if exists Medicina;
drop table if exists Sesion;
drop table if exists Usuario;
drop table if exists Empleado;
drop table if exists TipoEmpleado;
drop table if exists Anotacion;
drop table if exists Expediente;
drop table if exists Paciente;
drop table if exists Institucion;
drop table if exists TipoPaciente;
drop table if exists Persona;
drop table if exists Provincia;
drop table if exists Canton;
drop table if exists Distrito;

-- Creacion de tablas de regiones y generales del sistema Sylom

create table Provincia (
    idProvincia varchar(1) not null primary key,
    nombre varchar(15)
);

create table Canton (
    idCanton varchar(2) not null primary key,
    nombre varchar(15)
);

create table Distrito (
    idDistrito varchar(3) not null primary key,
    nombre varchar(15)
);

/*
Tabla Persona
*/
drop table if exists Persona;
create table Persona(
	idPersona int not null,
	cedula varchar(15) not null primary key,
	nombre varchar(40) not null,
	apellido1 varchar(30),
	apellido2 varchar(30),
	direccionPadron varchar(10),
	direccion2 varchar(255),
	provincia varchar(1),
	canton varchar(2),
	distrito varchar(3),
	genero int,
	fechaNacimiento date,
	email varchar(300),
	telefono varchar(15),
	lastUpdate date not null,
	activo bit,
    constraint provincia_Persona_fk foreign key(provincia) references Provincia(idProvincia),
    constraint canton_Persona_fk foreign key(canton) references Canton(idCanton),
    constraint distrito_Persona_fk foreign key(distrito) references Distrito(idDistrito)
);

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
Tabla Institucion
*/
drop table if exists Institucion;
create table Institucion(
	idInstitucion int not null primary key,
    nombreInstitucion varchar(75),
    direccion varchar(255),
    telefono varchar(15)
);

/*
Tabla Paciente
*/
drop table if exists Paciente;
create table Paciente(
	idPaciente int not null primary key,
	descripcion varchar(250),
	idTipoPaciente int not null,
	cedula varchar(15) not null,
    idInstitucion int not null,
	activo bit,
	constraint idTipoPaciente_Paciente_fk foreign key(idTipoPaciente) references TipoPaciente(idTipoPaciente),
	constraint cedula_Paciente_fk foreign key(cedula) references Persona(cedula),
    constraint idInstitucion foreign key(idInstitucion) references Institucion(idInstitucion)
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
    tituloAnotacion varchar(55),
	descripcion varchar(100),
	idExpediente int not null,
	constraint idExpediente_Anotacion_fk foreign key(idExpediente) references Expediente(idExpediente)
);

/*
Tabla Medicina
*/
drop table if exists Medicina;
create table Medicina(
	idMedicina int not null primary key,
	descripcion varchar(75) not null
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
	salario decimal(12,2),
	idTipoEmpleado int not null,
	cedula varchar(15) not null,
	activo bit,
	constraint idTipoEmpleado_Empleado_fk foreign key(idTipoEmpleado) references TipoEmpleado(idTipoEmpleado),
	constraint cedula_Empleado_fk foreign key(cedula) references Persona(cedula)
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
Tabla Sesion
*/
drop table if exists Sesion;
create table Sesion(
	idSesion int not null primary key,
    asunto varchar(55),
	fecha datetime not null,
    hora time,
    notas varchar(255),
    sintomas varchar(255),
	idExpediente int not null,
	idUsuario int not null,
    estado varchar(1),
	activo bit,
	constraint idExpediente_Sesion_fk foreign key(idExpediente) references Expediente(idExpediente),
	constraint idUsuario_Sesion_fk foreign key(idUsuario) references Usuario(idUsuario)
);

/*
Tabla (n-m) Actividad_Sesion
*/
drop table if exists Medicina_Sesion;
create table Medicina_Sesion(
	idMedicina int not null,
	idSesion int not null,
	constraint idMedicina_idSesion_Medicina_Sesion_pk primary key(idMedicina,idSesion),
	constraint idMedicina_Medicina_Sesion_fk foreign key(idMedicina) references Medicina(idMedicina),
	constraint idSesion_Medicina_Sesion_fk foreign key(idSesion) references Sesion(idSesion)
);

-- Creacion de tablas de seguridad del sistema Sylom

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
drop table if exists Rol_Apartado;
create table Rol_Apartado_Accion(
    idRolApartado int not null primary key,
    nombreApartado varchar(25),
    crear bit,
    leer bit,
    editar bit,
    eliminar bit,
	idRol int not null,
	constraint idRol_Rol_Apartado_Accion_fk foreign key(idRol) references Rol(idRol)
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

-- Creacion de tablas de reporter del sistema Sylom

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
	tipo char not null -- S:success, E:error, N:not authorized, O:Unknown
);