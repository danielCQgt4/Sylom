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
    @salario decimal(12,2),
	@idTipoEmpleado int,
	@cedula varchar(15),
	@fechaNacimiento varchar(10),
	@email varchar(300),
	@telefono varchar(15),

    @usuario varchar(255),
    @pass varchar(255),
    @output varchar(35) output
AS
BEGIN
	SET NOCOUNT ON;
    declare @idEmpleado int;
    declare @idUsuario int;
    if ISDATE(@fechaNacimiento) = 1 BEGIN
        select @idEmpleado = max(idEmpleado) + 1 from Empleado;
        if @idEmpleado is null begin 
            set @idEmpleado = 1;
        end;
        select @idUsuario = max(idUsuario) + 1 from Usuario;
        if @idUsuario is null BEGIN
            set @idUsuario = 1;
        end;

        update Persona 
        set fechaNacimiento = @fechaNacimiento, email = @email, telefono = @telefono
        where cedula = @cedula;

        insert into Empleado values (@idEmpleado,@salario,@idTipoEmpleado,@cedula,1);
        insert into Usuario values (@idUsuario,@usuario,@pass,@idEmpleado,1);
        set @output = '';
    end else begin
        set @output = 'Fecha no valida';
    end;
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
    @salario decimal(12,2),
	@idTipoEmpleado int,
    @fechaNacimiento varchar(10),
	@email varchar(300),
	@telefono varchar(15),

    @usuario varchar(255),
    @contra varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
    declare @cedula varchar(15);
    declare @idUsuario int;

    begin transaction;
	save transaction MySavePoint;

	begin try
        select @cedula = cedula from Empleado where idEmpleado = @idEmpleado;
        select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;

        update Persona 
        set email = @email, telefono = @telefono, fechaNacimiento = @fechaNacimiento
        where cedula = @cedula;

        update Empleado 
        set salario = @salario, idTipoEmpleado = @idTipoEmpleado
        where idEmpleado = @idEmpleado;

        if @usuario is not null and @usuario is not null and @usuario != '' and @contra != '' BEGIN
            update Usuario 
            set usuario = @usuario, contra = @contra 
            where idUsuario = @idUsuario;
        end;
        commit transaction;
    end TRY
    begin CATCH
        if @@TRANCOUNT > 0 begin 
			ROLLBACK TRANSACTION MySavePoint;
		end;
    end CATCH
END
GO

/*
SP para el modificar empleados
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
    where idEmpleado = @idEmpleado;

    update Usuario 
    set activo = 0
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
    select e.salario,e.idEmpleado,p.nombre,p.apellido1,p.apellido2,CONVERT(varchar,p.fechaNacimiento) as fechaNacimiento,p.telefono,p.email,p.cedula,te.idTipoEmpleado,te.descripcion
    from Usuario u, Empleado e,TipoEmpleado te,Persona p
    where (u.idEmpleado = e.idEmpleado) and (e.cedula = p.cedula) and (te.idTipoEmpleado = e.idTipoEmpleado)
    and u.activo = 1 and e.activo = 1 and te.activo = 1;
END
GO


/*
SP para el verificar la contra actual de los empleados
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
    @contra varchar(255),
    @output bit output
AS
BEGIN
	SET NOCOUNT ON;
    declare @idUsuario int;
    declare @temp int;
    select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;
    select @temp = count(*) from Usuario where idUsuario = @idUsuario and contra = @contra;
    set @output = case when @temp = 1 then 1 else 0 end;
END
GO