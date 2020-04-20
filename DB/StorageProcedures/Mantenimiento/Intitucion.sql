/*
SP para el agregar de Institucion
*/
drop procedure if exists agregarInstitucion;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarInstitucion
    @nombreInstitucion varchar(75),
    @direccion varchar(255),
    @telefono varchar(15)
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idInstitucion) + 1 from Institucion;
    if  @id is null BEGIN
        set @id = 1;
    end;
    insert into Institucion values (@id,@nombreInstitucion,@direccion,@telefono,1);
END
GO

/*
SP para el modificar de Institucion
*/
drop procedure if exists actualizarInstitucion;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE actualizarInstitucion
    @nombreInstitucion varchar(75),
    @direccion varchar(255),
    @telefono varchar(15),
    @idInstitucion int
AS
BEGIN
	SET NOCOUNT ON;
    update Institucion
    set nombreInstitucion = @nombreInstitucion,
    direccion = @direccion,
    telefono = @telefono
    where idInstitucion = @idInstitucion and activo = 1;
END
GO

/*
SP para el eliminar de Institucion
*/
drop procedure if exists eliminarInstitucion;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE eliminarInstitucion
    @idInstitucion int
AS
BEGIN
	SET NOCOUNT ON;
    update Institucion set activo = 0
    where idInstitucion = @idInstitucion;
END
GO

/*
SP para el mostrar Instituciones
*/
drop procedure if exists obtenerInstituciones;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerInstituciones
AS
BEGIN
	SET NOCOUNT ON;
    select * from Institucion;
END
GO

/*
SP para el mostrar Institucions
*/
drop procedure if exists obtenerInstitucion;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerInstitucion
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    select top 1 * from Institucion where activo = 1 and idInstitucion = @id;
END
GO