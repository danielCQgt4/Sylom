/*Datos de prueba*/
-- Empleado
insert into TipoEmpleado values (1,'Prueba');
insert into Empleado values (1,10000,1,'305230724',1);
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
insert into Apartado values (1,'Mantenimientos','','');
insert into Apartado values (2,'Seguridad','','');
insert into Apartado values (3,'Paciente','','');
insert into Apartado values (4,'Empleados','','');
insert into Apartado values (5,'Reportes','','');
insert into Apartado values (6,'Mi cuenta','','');