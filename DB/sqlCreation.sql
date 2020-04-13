--create database Sylom;

--use Sylom;

drop table if exists Persona;
drop table if exists Provincia;
drop table if exists Canton;
drop table if exists Distrito;
-- Eliminacion de tablas del systema Sylom
drop table if exists Rol_Apartado;
drop table if exists Apartado;
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

-- Creacion de tablas de regiones y generales del sistema Sylom

create table Provincia (
    idProvincia varchar(1) not null primary key,
    nombre varchar(50)
);

create UNIQUE index nombre_Provincia_index
on Provincia (nombre);

create table Canton (
    idCanton varchar(2) not null,
    nombre varchar(50),
	idProvincia varchar(1) not null,
	primary key(idCanton,idProvincia),
	constraint idProvincia_Canton foreign key(idProvincia) REFERENCES Provincia(idProvincia)
);

create table Distrito (
    idDistrito varchar(3) not null,
    nombre varchar(50) not null,
	idProvincia varchar(1) not null,
	idCanton varchar(2) not null,
	primary key (idProvincia,idCanton,idDistrito),
	constraint idCanton_Distrito_fk foreign key(idCanton,idProvincia) references Canton(idCanton,idProvincia)
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
	activo bit
);

-- Creacion de tablas de datos del sistema Sylom

/*
Tabla tipo paciente
*/
drop table if exists TipoPaciente;
create table TipoPaciente(
	idTipoPaciente int not null primary key,
	descripcion varchar(25) not null,
	activo bit not null
);

create UNIQUE index descripcion_TipoPaciente_index
on TipoPaciente (descripcion);

/*
Tabla Institucion
*/
drop table if exists Institucion;
create table Institucion(
	idInstitucion int not null primary key,
    nombreInstitucion varchar(75),
    direccion varchar(255),
    telefono varchar(15),
	activo bit not null
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
	nombre varchar(40) not null,
	apellido1 varchar(30) not null,
	apellido2 varchar(30) not null,
	direccion2 varchar(255) not null,
	provincia varchar(1) not null,
	canton varchar(2) not null,
	distrito varchar(3) not null,
	genero int not null,
	fechaNacimiento date not null,
    idInstitucion int not null,
	activo bit not null,
	constraint idTipoPaciente_Paciente_fk foreign key(idTipoPaciente) references TipoPaciente(idTipoPaciente),
    constraint idInstitucion foreign key(idInstitucion) references Institucion(idInstitucion),
    constraint provincia_Paciente_fk foreign key(provincia) references Provincia(idProvincia),
    constraint canton_Paciente_fk foreign key(canton,provincia) references Canton(idCanton,idProvincia),
    constraint distrito_Paciente_fk foreign key(provincia,canton,distrito) references Distrito(idProvincia,idCanton,idDistrito)
);

create UNIQUE index cedula_Paciente_index
on Paciente (cedula);

/*
Tabla Expediente
*/
drop table if exists Expediente;
create table Expediente(
	idExpediente int not null primary key,
	descripcion varchar(350) not null,
	idPaciente int not null,
	activo bit not null,
	constraint idPaciente_Expediente_fk foreign key(idPaciente) references Paciente(idPaciente)
);

create UNIQUE index idExpediente_Expediente_index
on Expediente (idPaciente);

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
	descripcion varchar(75) not null,
	activo bit not null
);


create UNIQUE index descripcion_Medicina_index
on Medicina (descripcion);

/*
Tabla TipoEmpleado
*/
drop table if exists TipoEmpleado;
create table TipoEmpleado(
	idTipoEmpleado int not null primary key,
	descripcion varchar(75) not null,
	activo bit not null
);

create UNIQUE index descripcion_TipoEmpleado_index
on TipoEmpleado (descripcion);

/*
Tabla Empleado
*/
drop table if exists Empleado;
create table Empleado(
	idEmpleado int not null primary key,
	idTipoEmpleado int not null,
	nombre varchar(100) not null,
	activo bit not null,
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

create UNIQUE index usuario__Usuario_index
on Usuario (usuario);

create UNIQUE index idEmpleado_Empleado_Usuario_index
on Usuario (idEmpleado);

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
Tabla Rol_Apartado
*/
drop table if exists Apartado;
create table Apartado(
    idApartado int not null primary key,
    nombreApartado varchar(25),
	siteUrl varchar(200),
	icon varchar(200)
);

/*
Tabla Rol_Apartado
*/
drop table if exists Rol_Apartado;
create table Rol_Apartado(
	idRol int not null,
	idApartado int not null,
    crear bit,
    leer bit,
    editar bit,
    eliminar bit,
	constraint idRol_idApartado_Rol_Apartado_pk primary key(idRol,idApartado),
	constraint idRol_Rol_Apartado_fk foreign key(idRol) references Rol(idRol),
	constraint idApartado_Rol_Apartado_fk foreign key(idApartado) references Apartado(idApartado)
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
	metodo varchar(500) not null,
	msj varchar(1000) not null,
	fecha datetime not null,
	usuario varchar(255) not null,
	tipo char not null -- S:success, E:error, N:not authorized, O:Unknown
);