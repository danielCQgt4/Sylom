/*
SP para el agregar de tipos de paciente
*/
drop procedure if exists agregarTipoPaciente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarTipoPaciente
    @nombreTipoPaciente varchar(15) -- not null
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idTipoPaciente) + 1 from TipoPaciente;
    if  @id is null BEGIN
        set @id = 1;
    end;
    insert into TipoPaciente values (@id,@nombreTipoPaciente,1);
END
GO

/*
SP para el modificar de tipos de paciente
*/
drop procedure if exists actualizarTipoPaciente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE actualizarTipoPaciente
    @nombreTipoPaciente varchar(15), -- not null
    @idTipoPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoPaciente set descripcion = @nombreTipoPaciente 
    where idTipoPaciente = @idTipoPaciente;
END
GO

/*
SP para el eliminar de tipos de paciente
*/
drop procedure if exists eliminarTipoPaciente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE eliminarTipoPaciente
    @idTipoPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoPaciente set activo = 0
    where idTipoPaciente = @idTipoPaciente;
END
GO

/*
SP para el mostrar tipos de pacientes
*/
drop procedure if exists obtenerTipoPacientes;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerTipoPacientes
AS
BEGIN
	SET NOCOUNT ON;
    select top (select count(*) from TipoPaciente) * from TipoPaciente  where activo = 1;
END
GO

/*
SP para el mostrar tipos de paciente
*/
drop procedure if exists obtenerTipoPaciente;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerTipoPaciente
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    select top 1 * from TipoPaciente  where activo = 1 and idTipoPaciente = @id;
END
GO