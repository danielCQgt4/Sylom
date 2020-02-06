/*
SP para el mantenimiento de personas
*/
drop procedure if exists mantenimientoPersonas;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE mantenimientoPersonas
    @cedula varchar(15), -- not null
	@nombre varchar(40), -- not null
	@apellido1 varchar(30),
	@apellido2 varchar(30),
	@direccionPadron varchar(10),
	@direccion2 varchar(255) = '',
	@provincia varchar(1),
	@canton varchar(2),
	@distrito varchar(3),
	@genero int = 0,
	@fechaNacimiento date = null,
	@edad int = 0,
	@email varchar(300) = '',
	@telefono varchar(15) = '0000-0000',
    @activo bit
AS
BEGIN
	SET NOCOUNT ON;
    declare @fechaActual date;
    declare @id int;
    set @fechaActual = GETDATE();
    if exists (select * from Persona where cedula = @cedula) BEGIN
      update Persona set 
            nombre = @nombre,
            apellido1 = @apellido1,
            apellido2 = @apellido2,
            direccionPadron = @direccionPadron,
            direccion2 = @direccion2,
            provincia = @provincia,
            canton = @canton,
            distrito = @distrito,
            genero = @genero,
            fechaNacimiento = @fechaNacimiento,
            edad = @edad,
            email = @email,
            telefono = @telefono,
            lastUpdate = @fechaActual,
            activo = @activo where cedula = @cedula;
    end
    else begin 
        select @id = max(idPersona) from Persona;
        if @id is null BEGIN
            set @id = 1;
        end;
        insert into Persona values (
            @id,
            @cedula,
            @nombre,
            @apellido1,
            @apellido2,
            @direccionPadron,
            @direccion2,
            @provincia,
            @canton,
            @distrito,
            @genero,
            @fechaNacimiento,
            @edad,
            @email,
            @telefono,
            @fechaActual,
            1);
    end
END
GO

-- =============================================
/*
SP para la vista de personas
*/
drop procedure if exists consultaPersona;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultaPersona
    @cedula varchar(15)
AS
BEGIN
	SET NOCOUNT ON;
    select * from Persona where cedula = @cedula;
END
GO

-- =============================================
/*
SP para manejo de activos
*/
drop procedure if exists manejoActivos;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE manejoActivos
    @cedula varchar(15)
AS
BEGIN
	SET NOCOUNT ON;
    declare @fechaActual date;
    set @fechaActual = GETDATE();
    update Persona set activo = 0 where lastUpdate != @fechaActual;
END
GO

/*
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
	@edad = 20,
	@email = 'danielcotoquiros@hotmail.com',
	@telefono = '6196-3428',
    @activo = 1;

	select * from Persona;

	delete from Persona where cedula != '';