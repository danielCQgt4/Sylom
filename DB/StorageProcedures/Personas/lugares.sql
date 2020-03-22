-- =============================================
/*
SP para agregar provincias
*/
drop procedure if exists agregarProvincia;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarProvincia
    @idProvincia varchar(1),
    @nombre varchar(15)
AS
BEGIN
	SET NOCOUNT ON;
    if exists (select idProvincia from Provincia where idProvincia = @idProvincia) BEGIN
        update Provincia set nombre = @nombre where idProvincia = @idProvincia;
    end else BEGIN
        insert into Provincia values (@idProvincia,@nombre);
    end;
END
GO

-- =============================================
/*
SP para agregar cantones
*/
drop procedure if exists agregarCanton;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarCanton
    @idCanton varchar(2),
    @nombre varchar(15),
	@idProvincia varchar(1)
AS
BEGIN
	SET NOCOUNT ON;
    if exists (select idCanton from Canton where idCanton = @idCanton) BEGIN
        update Canton set nombre = @nombre where idCanton = @idCanton;
    end else BEGIN
        insert into Canton values (@idCanton,@nombre,@idProvincia);
    end;
END
GO

-- =============================================
/*
SP para agregar distritos
*/
drop procedure if exists agregarDistrito;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarDistrito
    @idDistrito varchar(3),
    @nombre varchar(15),
	@idCanton varchar(2)
AS
BEGIN
	SET NOCOUNT ON;
    if exists (select idDistrito from Distrito where idDistrito = @idDistrito) BEGIN
        update Distrito set nombre = @nombre where idDistrito = @idDistrito;
    end else BEGIN
        insert into Distrito values (@idDistrito,@nombre,@idCanton);
    end;
END
GO