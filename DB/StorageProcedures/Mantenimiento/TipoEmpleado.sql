/*
SP para el agregar de tipos de empleado
*/
drop procedure if exists agregarTipoEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarTipoEmpleado
    @nombreTipoEmpleado varchar(15) -- not null
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idTipoEmpleado) + 1 from TipoEmpleado;
    if  @id is null BEGIN
        set @id = 1;
    end;
    insert into TipoEmpleado values (@id,@nombreTipoEmpleado,1);
END
GO

/*
SP para el modificar de tipos de empleado
*/
drop procedure if exists actualizarTipoEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE actualizarTipoEmpleado
    @nombreTipoEmpleado varchar(15), -- not null
    @idTipoEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoEmpleado set descripcion = @nombreTipoEmpleado 
    where idTipoEmpleado = @idTipoEmpleado;
END
GO

/*
SP para el eliminar de tipos de empleado
*/
drop procedure if exists eliminarTipoEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE eliminarTipoEmpleado
    @idTipoEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoEmpleado set activo = 0
    where idTipoEmpleado = @idTipoEmpleado;
END
GO

/*
SP para el mostrar tipos de empleados
*/
drop procedure if exists obtenerTipoEmpleados;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerTipoEmpleados
    @idEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    declare @idTipoEmpleado int;
    select @idTipoEmpleado = idTipoEmpleado from Empleado where idEmpleado = @idEmpleado;
    select top (select count(*) from TipoEmpleado) idTipoEmpleado,descripcion,
    (case when @idTipoEmpleado=idTipoEmpleado then 1
	else 0 end) as asignado
    from TipoEmpleado  where activo = 1;
END
GO

/*
SP para el mostrar tipos de empleado
*/
drop procedure if exists obtenerTipoEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerTipoEmpleado
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    select top 1 * from TipoEmpleado  where activo = 1 and idTipoEmpleado = @id;
END
GO