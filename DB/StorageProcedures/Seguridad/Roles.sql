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
    if not exists(select * from Rol where descripcion = @nombre) BEGIN
        insert into Rol values (@id,@nombre);
    end;
    select idRol from Rol where idRol = @idRol;
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

/*
SP para consultar apartado por acceso y rol
*/
drop procedure if exists consultarRolApartadoByUsuario;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarRolApartadoByUsuario
    @idUsuario int
AS
BEGIN
	SET NOCOUNT ON;
    select 
	a.idApartado as idApartado,
	a.nombreApartado as nombreApartado,
	sum(cast(crear as int)) as crear,
	sum(cast(leer as int)) as leer,
	sum(cast(editar as int)) as editar,
	sum(cast(eliminar as int)) as eliminar
    from Rol r, Apartado a, Rol_Apartado ra, Usuario_Rol ur
    where ur.idUsuario = @idUsuario
        and r.idRol = ra.idRol and ra.idApartado = a.idApartado and ur.idRol = r.idRol
    group by a.nombreApartado,a.idApartado;
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
    select r.idRol,descripcion 
    from Rol r, Usuario_Rol ur
    where r.idRol = ur.idRol and ur.idUsuario = @idUsuario;
END
GO

/*
SP para eliminar eliminarRolApartado
*/
drop procedure if exists eliminarRolApartado;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE eliminarRolApartado
    @idRol int,
    @idApartado int
AS
BEGIN
	SET NOCOUNT ON;
    delete from Rol_Apartado where idRol = @idRol and idApartado = @idApartado;
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