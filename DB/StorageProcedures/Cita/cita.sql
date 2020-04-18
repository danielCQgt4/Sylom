/*
SP para agregar una cita
*/
drop procedure if exists agregarSesion;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarSesion
    @asunto varchar(55),
	@fecha varchar(11),
    @hora varchar(7),
    @notas varchar(255),
    @sintomas varchar(255),
	@idExpediente int,
	@idUsuario int
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idSesion) + 1 from Sesion;
    if @id is null BEGIN
        set @id = 1;
    end;
    insert into Sesion values (@id,@asunto,@fecha,@hora,@notas,@sintomas,@idExpediente,@idUsuario,1);
END
GO

/*
SP para cancelar una cita
*/
drop procedure if exists cancelarSesion;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE cancelarSesion
    @idSesion int
AS
BEGIN
	SET NOCOUNT ON;
    update Sesion set activo = 0 
    where idSesion = @idSesion;
END
GO

/*
SP para consultar las citas
*/
drop procedure if exists consultaSesiones;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultaSesiones
AS
BEGIN
	SET NOCOUNT ON;
    select idSesion,asunto,CONVERT(varchar,fecha) as fecha,hora,notas,sintomas,idExpediente,idUsuario,
    (case when GETDATE() > fecha then '#d9534f'
    else '#2c3e50' end) as color
    from Sesion where activo = 1;
END
GO
