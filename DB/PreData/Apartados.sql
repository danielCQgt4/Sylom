/*Datos de prueba*/
-- Empleado
insert into TipoEmpleado values (1,'Dev',1);
insert into Empleado values (1,10000,1,'305230724','Daniel','Coto','Quiros',null,3,01,002,1,'2000/03/20',1);
-- Usuario
insert into Usuario values (1,'danielcqgt4','1234',1,1);
-- Roles
insert into Rol values (1,'Rol prueba');
-- Rol Apartado
insert into Rol_Apartado values (1,1,1,1,1,1);
insert into Rol_Apartado values (1,2,1,1,1,1);
insert into Rol_Apartado values (1,3,1,1,1,1);
insert into Rol_Apartado values (1,4,1,1,1,1);
insert into Rol_Apartado values (1,5,1,1,1,1);
insert into Rol_Apartado values (1,6,1,1,1,1);
-- Rol Usuario
insert into Usuario_Rol values (1,1);

-- ---------------------------------------------------------------------------------------------------------

/*Asi se quedan con la excepcion del la ruta:1 y el icono:2*/
insert into Apartado values (1,'Mantenimientos','/mantenimientos','/Public/IMG/General/mantenimiento.png');
insert into Apartado values (2,'Seguridad','/seguridad','/Public/IMG/General/seguridad.png');
insert into Apartado values (3,'Paciente','/paciente','/Public/IMG/General/paciente.png');
insert into Apartado values (4,'Empleados','/empleado','/Public/IMG/General/empleado.png');
insert into Apartado values (5,'Reportes','','/Public/IMG/General/reporte.png');
insert into Apartado values (6,'Mi cuenta','','/Public/IMG/General/miCuenta.png');