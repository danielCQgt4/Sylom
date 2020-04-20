/*
SP para el agregar empleados
*/
drop procedure if exists agregarEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarEmpleado
	@idTipoEmpleado int,
    @nombre varchar(100),

    @usuario varchar(255),
    @pass varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
    declare @idEmpleado int;
    declare @idUsuario int;
    select @idEmpleado = max(idEmpleado) + 1 from Empleado;
    if @idEmpleado is null begin 
        set @idEmpleado = 1;
    end;
    select @idUsuario = max(idUsuario) + 1 from Usuario;
    if @idUsuario is null BEGIN
        set @idUsuario = 1;
    end;

    insert into Empleado values (@idEmpleado,@idTipoEmpleado,@nombre,1);
    insert into Usuario values (@idUsuario,@usuario,@pass,@idEmpleado,1);
END
GO

/*
SP para el modificar empleados
*/
drop procedure if exists actualizarEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE actualizarEmpleado
    @idEmpleado int,
    @idTipoEmpleado int,
    @nombre varchar(100),

    @usuario varchar(255),
    @pass varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
    declare @idUsuario int;

    select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;

    update Empleado 
    set idTipoEmpleado = @idTipoEmpleado, nombre = @nombre
    where idEmpleado = @idEmpleado;

    if @usuario is not null and @pass is not null and @usuario != '' and @pass != '' BEGIN
        update Usuario 
        set usuario = @usuario, contra = @pass 
        where idUsuario = @idUsuario;
    end;
END
GO

/*
SP para el eliminar empleados
*/
drop procedure if exists eliminarEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE eliminarEmpleado
    @idEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    declare @idUsuario int;

    select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;

    update Empleado 
    set activo = 0
    where idEmpleado = @idEmpleado and idEmpleado > 1;

    update Usuario 
    set activo = 0
    where idUsuario = @idUsuario and idEmpleado > 1;
END
GO

/*
SP para el habilitar empleados
*/
drop procedure if exists habilitarEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE habilitarEmpleado
    @idEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    declare @idUsuario int;

    select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;

    update Empleado 
    set activo = 1
    where idEmpleado = @idEmpleado;

    update Usuario 
    set activo = 1
    where idUsuario = @idUsuario;
END
GO

/*
SP para el consultar empleados
*/
drop procedure if exists obtenerEmpleados;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerEmpleados
AS
BEGIN
	SET NOCOUNT ON;
    select e.idEmpleado,e.nombre,te.idTipoEmpleado,te.descripcion,u.activo
    from Usuario u, Empleado e,TipoEmpleado te
    where (u.idEmpleado = e.idEmpleado) and (te.idTipoEmpleado = e.idTipoEmpleado)
    and te.activo = 1;
END
GO


/*
SP para el verificar la pass actual de los empleados
*/
drop procedure if exists verficicarUsuarioEmpleado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE verficicarUsuarioEmpleado
    @idEmpleado int,
    @pass varchar(255),
    @output bit output
AS
BEGIN
	SET NOCOUNT ON;
    declare @idUsuario int;
    declare @temp int;
    select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;
    select @temp = count(*) from Usuario where idUsuario = @idUsuario and contra = @pass;
    set @output = case when @temp = 1 then 1 else 0 end;
END
GO