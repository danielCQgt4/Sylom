/*
SP para agregar pacientes
*/
drop procedure if exists agregarCliente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarCliente
    @cedula varchar(15),
	@fechaNacimiento varchar(10),

    @descripcion varchar(250),
	@idTipoPaciente int,
    @idInstitucion int
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idPaciente) + 1 from Paciente;
    if @id is null BEGIN
        set @id = 1;
    end;
    insert into Paciente values (@id,@descripcion,@idTipoPaciente,@cedula,@idInstitucion,1);
END
GO

/*
SP para agregar expediente de paciente
*/
drop procedure if exists agregarExpediente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarExpediente
    @idPaciente int,
    @descripcion varchar(75)
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idExpediente) + 1 from Expediente;
    if @id is null BEGIN
        set @id = 1;
    end;
    insert into Expediente values (@id,@descripcion,@idPaciente,1);
END
GO

/*
SP para agregar anotacion del expediente de paciente
*/
drop procedure if exists agregarExpedienteAnotacion;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarExpedienteAnotacion
    @idExpediente int,
    @titulo varchar(55),
    @descripcion varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idAnotacion) + 1 from Anotacion;
    if @id is null BEGIN
        set @id = 1;
    end;
    insert into Anotacion values (@idAnotacion,@titulo,@descripcion,@idExpediente);
END
GO