-- =============================================
/*
SP para agregar rol
*/
drop procedure if exists agregarRol;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarRol
    @nombre varchar(75)
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idRol) + 1 from Rol;
    if  @id is null BEGIN
        set @id = 1;
    end;
    insert into Rol values (@id,@nombre);
    select idRol from Rol where idRol = @id;
END
GO

-- =============================================
/*
SP para agregar rol_apartado
*/
drop procedure if exists agregarRolApartado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarRolApartado
    @idRol int,
    @idApartado int,
    @crear bit,
    @leer bit,
    @editar bit,
    @eliminar bit
AS
BEGIN
	SET NOCOUNT ON;
    insert into Rol_Apartado values (@idRol,@idApartado,@crear,@leer,@editar,@eliminar);
END
GO

-- =============================================
/*
SP para agregar rol_usuario
*/
drop procedure if exists agregarRolUsuario;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarRolUsuario
    @idUsuario int,
    @idRol int
AS
BEGIN
	SET NOCOUNT ON;
    insert into Usuario_Rol values (@idUsuario,@idRol);
END
GO

/*
SP para consultar roles
*/
drop procedure if exists consultarRoles;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarRoles
    @idUsuario int
AS
BEGIN
	SET NOCOUNT ON;
    select r.idRol,r.descripcion 
    from Rol r, Usuario_Rol ur
    where r.idRol = ur.idRol and ur.idUsuario = @idUsuario;
END
GO

/*
SP para consultar apartados
*/
drop procedure if exists consultarApartados;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarApartados
AS
BEGIN
	SET NOCOUNT ON;
    select idApartado,nombreApartado
    from Apartado;
END
GO

/*
SP para consultar usuarios
*/
drop procedure if exists consultarUsuarios;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarUsuarios
AS
BEGIN
	SET NOCOUNT ON;
    select e.nombre, u.idUsuario
    from Usuario u, Empleado e
    where u.idEmpleado = e.idEmpleado and u.activo = 1;
END
GO


/*
SP para consultar usuarios
*/
drop procedure if exists consultarRolApartados;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarRolApartados
    @idRol int
AS
BEGIN
	SET NOCOUNT ON;
    select *
    from Rol r, Rol_Apartado ra, Apartado a
    where r.idRol = @idRol and ra.idRol = r.idRol and ra.idApartado = a.idApartado;
END
GO


/*
SP para consultar usuarios
*/
drop procedure if exists consultarRolUsuarios;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarRolUsuarios
    @idRol int
AS
BEGIN
	SET NOCOUNT ON;
    select u.idUsuario, e.nombre
    from Usuario u, Empleado e, Rol r, Usuario_Rol ur
    where u.idEmpleado = e.idEmpleado and ur.idUsuario = u.idUsuario and ur.idRol = r.idRol and r.idRol = @idRol;
END
GO


/*
SP para eliminar eliminarRol
*/
drop procedure if exists eliminarRol;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE eliminarRol
    @idRol int
AS
BEGIN
	SET NOCOUNT ON;
    delete from Rol_Apartado where idRol = @idRol and idApartado > 0;
    delete from Usuario_Rol where idRol = @idRol and idUsuario > 0;
    delete from Rol where idRol = @idRol;
END
GO

drop procedure if exists actualizarRol;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE actualizarRol
    @idRol int,
    @descripcion varchar(75)
AS
BEGIN
	SET NOCOUNT ON;
    update Rol set descripcion = @descripcion where idRol = @idRol;
    delete from Rol_Apartado where idRol = @idRol and idApartado > 0;
    delete from Usuario_Rol where idRol = @idRol and idUsuario > 0;
END
GO