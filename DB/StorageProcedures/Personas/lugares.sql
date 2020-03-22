-- =============================================
/*
SP para consultar provincias
*/
drop procedure if exists consultarProvincias;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarProvincias
AS
BEGIN
	SET NOCOUNT ON;
    select * from Provincia;
END
GO

-- =============================================
/*
SP para consultar cantones
*/
drop procedure if exists consultarCantones;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarCantones
	@idProvincia varchar(1)
AS
BEGIN
	SET NOCOUNT ON;
    select * from Canton c where idProvincia = @idProvincia;
END
GO

-- =============================================
/*
SP para consultar distritos
*/
drop procedure if exists consultarDistritos;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE consultarDistritos
    @idProvincia varchar(1),
	@idCanton varchar(2)
AS
BEGIN
	SET NOCOUNT ON;
    select * from Distrito where idProvincia = @idProvincia and idCanton = @idCanton;
END
GO