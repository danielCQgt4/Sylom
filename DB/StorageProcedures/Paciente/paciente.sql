/*
SP para agregar pacientes
*/
drop procedure if exists agregarPaciente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarPaciente
    @cedula varchar(15),
    @nombre varchar(40),
	@apellido1 varchar(30),
	@apellido2 varchar(30),
	@direccion2 varchar(255),
	@provincia varchar(1),
	@canton varchar(2),
	@distrito varchar(3),
	@genero int,
	@fechaNacimiento varchar(10),

    @descripcionCliente varchar(250),
	@idTipoPaciente int,
    @idInstitucion int,
    
    @descripcionExpediente varchar(350)
AS
BEGIN
	SET NOCOUNT ON;
    declare @idPaciente int;
    declare @idExpediente int;
    -- Cliente
    select @idPaciente = max(idPaciente) + 1 from Paciente;
    if @idPaciente is null BEGIN
        set @idPaciente = 1;
    end;
    insert into Paciente values (@idPaciente,@descripcionCliente,@idTipoPaciente,@cedula,@nombre,@apellido1,@apellido2,@direccion2,@provincia,@canton,@distrito,@genero,@fechaNacimiento,@idInstitucion,1);
    -- Expediente
    select @idExpediente = max(idExpediente) + 1 from Expediente;
    if @idExpediente is null BEGIN
        set @idExpediente = 1;
    end;
    insert into Expediente values (@idExpediente,@descripcionExpediente,@idPaciente,1);
END
GO


/*
SP para eliminar paciente
*/
drop procedure if exists eliminarPaciente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE eliminarPaciente
    @idPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    update Paciente set activo = 0 where idPaciente = @idPaciente;
    update Expediente set activo = 0 where idPaciente = @idPaciente and idExpediente > 0;
END
GO

/*
SP para modificar pacientes
*/
drop procedure if exists actualizarPaciente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE actualizarPaciente
    @idPaciente int,
    @cedula varchar(15),
    @nombre varchar(40),
	@apellido1 varchar(30),
	@apellido2 varchar(30),
	@direccion2 varchar(255),
	@provincia varchar(1),
	@canton varchar(2),
	@distrito varchar(3),
	@genero int,
	@fechaNacimiento varchar(10),

    @descripcionCliente varchar(250),
	@idTipoPaciente int,
    @idInstitucion int,
    
    @descripcionExpediente varchar(350)
AS
BEGIN
	SET NOCOUNT ON;
    update Paciente 
        set nombre = @nombre,
            apellido1 = @apellido1,
            apellido2 = @apellido2,
            direccion2 = @direccion2,
            provincia = @provincia,
            canton = @canton,
            distrito = @distrito,
            genero = @genero,
            fechaNacimiento = @fechaNacimiento,
            descripcion = @descripcionCliente,
            idTipoPaciente = @idTipoPaciente,
            idInstitucion = @idInstitucion
        where idPaciente = @idPaciente;
    update Expediente
        set descripcion = @descripcionExpediente
        where idPaciente = @idPaciente and idExpediente > 0;
END
GO

/*
SP para obtener pacientes
*/
drop procedure if exists obtenerPacientes;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerPacientes
AS
BEGIN
	SET NOCOUNT ON;
    select p.idPaciente, p.cedula, p.nombre , p.apellido1, p.apellido2, p.provincia, p.canton, p.distrito, convert(varchar,p.fechaNacimiento) as fechaNacimiento, p.descripcion as descripcionPaciente, p.idTipoPaciente, p.idInstitucion, 
            e.descripcion as descripcionExpediente, e.idExpediente
    from Paciente p, Expediente e
    where (p.idPaciente = e.idPaciente) and (e.activo = 1) and (p.activo = 1);
END
GO

/*
SP para obtener un paciente
*/
drop procedure if exists obtenerPaciente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerPaciente
    @idPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    select p.idPaciente, p.direccion2, p.genero, p.cedula, p.nombre , p.apellido1, p.apellido2, p.provincia, p.canton, p.distrito,convert(varchar,p.fechaNacimiento) as fechaNacimiento, p.descripcion as descripcionPaciente, p.idTipoPaciente, p.idInstitucion, 
            e.descripcion as descripcionExpediente
    from Paciente p, Expediente e
    where (p.idPaciente = e.idPaciente) and (e.activo = 1) and (p.activo = 1) and (p.idPaciente = @idPaciente);
END
GO
