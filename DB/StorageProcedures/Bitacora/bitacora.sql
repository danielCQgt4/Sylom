/*
SP para crear un log de bitacora
*/
drop procedure if exists agregarRegistroBitacora;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarRegistroBitacora
	@controlador varchar(75),
	@metodo varchar(75),
	@msj varchar(1000),
	@tipo char(1)  
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    declare @fecha date;
    set @fecha = GETDATE();
    select @id = idBitacora + 1 from Bitacora;
    if  @id is null BEGIN
        set @id = 1;
    end;
    insert into Bitacora values (@id,@controlador,@metodo,@msj,@fecha,@tipo);
END
GO

/*
SP para ver los logs de la bitacora
*/
drop procedure if exists verRegistroBitacora;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE verRegistroBitacora
AS
BEGIN
	SET NOCOUNT ON;
    select top (select count(*) from Bitacora) * from Bitacora;
END
GO