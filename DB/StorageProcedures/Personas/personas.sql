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
	@direccion2 varchar(255),
	@provincia varchar(1),
	@canton varchar(2),
	@distrito varchar(3),
	@genero int = 0,
	@fechaNacimiento date = null,
	@email varchar(300),
	@telefono varchar(15),
    @activo bit
AS
BEGIN
	SET NOCOUNT ON;
    declare @fechaActual date;
    declare @id int;
	declare @edad int;
	declare @tempCedula varchar(15);
	declare @tempFecha date;
    set @fechaActual = GETDATE();
	select @tempCedula = cedula, @tempFecha = fechaNacimiento from Persona where cedula = @cedula;
	if @fechaNacimiento = '0001-01-01' begin
		set @fechaNacimiento = @tempFecha;
	end;
    if @tempCedula is not null BEGIN
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
            email = @email,
            telefono = @telefono,
            lastUpdate = @fechaActual,
            activo = @activo where cedula = @cedula;
    end
    else begin 
        select @id = max(idPersona)+1 from Persona;
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
