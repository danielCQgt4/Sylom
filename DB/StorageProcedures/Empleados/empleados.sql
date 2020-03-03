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
	@fechaNacimiento date,
	@email varchar(300),
	@telefono varchar(15),

    @usuario varchar(255),
    @pass varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
    declare @idEmpleado int;
    declare @idUsuario int;
    select @idEmpleado = max(idEmpleado) +1 from Empleado;
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
	@email varchar(300),
	@telefono varchar(15),

    @idUsuario int,
    @usuario varchar(255),
    @pass varchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    update Persona 
    set email = @email, telefono = @telefono
    where cedula = (select cedula from Empleado where idEmpleado = @idEmpleado);

    update Empleado 
    set salario = @salario, idTipoEmpleado = @idTipoEmpleado
    where idEmpleado = @idEmpleado;

    if @usuario is not null and @idUsuario is not null and @pass is not null BEGIN
        update Usuario 
        set usuario = @usuario, contra = @pass 
        where idUsuario = @idUsuario;
    end;
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
    @idEmpleado int,
    @idUsuario int
AS
BEGIN
	SET NOCOUNT ON;

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
drop procedure if exists consultarEmpleados;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarEmpleados
AS
BEGIN
	SET NOCOUNT ON;
    select e.salario,e.idEmpleado,p.nombre,p.apellido1,p.apellido2,p.telefono,p.email,p.cedula,u.idUsuario,te.idTipoEmpleado,te.descripcion
    from Usuario u, Empleado e,TipoEmpleado te,Persona p
    where (u.idEmpleado = e.idEmpleado) and (e.cedula = p.cedula) and (te.idTipoEmpleado = e.idTipoEmpleado)
    and u.activo = 1 and e.activo = 1 and te.activo = 1;
END
GO
