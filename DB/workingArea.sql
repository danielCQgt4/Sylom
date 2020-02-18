
select * from Persona;


exec consultaPersona @cedula = '305230724';

exec mantenimientoPersonas @cedula = '305230724', -- not null
	@nombre = 'Daniel Alberto', -- not null
	@apellido1 = 'Coto',
	@apellido2 = 'Quiros',
	@direccionPadron = '',
	@direccion2 = '',
	@provincia = '',
	@canton = '',
	@distrito = '',
	@genero = 1,
	@fechaNacimiento = '2000-03-20',
	@email = 'danielcotoquiros@hotmail.com',
	@telefono = '6196-3428',
    @activo = 1;

exec mantenimientoPersonas @cedula = '900870725', -- not null
	@nombre = 'Iris Isabel', -- not null
	@apellido1 = 'Quiros',
	@apellido2 = 'Coto',
	@direccionPadron = '',
	@direccion2 = '',
	@provincia = '',
	@canton = '',
	@distrito = '',
	@genero = 1,
	@fechaNacimiento = '1967-05-22',
	@email = 'irisqc@compubetel.com',
	@telefono = '6043-1485',
    @activo = 1;

	select count(*) from Persona;

	delete from Persona where cedula != '';

	update Persona set lastUpdate = '2020/02/05' where cedula = '901290599';

	select DATEDIFF(day,'2000/03/20','2020/03/20')/365;