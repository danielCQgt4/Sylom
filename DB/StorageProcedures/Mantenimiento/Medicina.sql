/*
SP para el agregar de medicina
*/
drop procedure if exists agregarMedicina;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE agregarMedicina
    @nombreMedicina varchar(15) -- not null
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idMedicina) + 1 from Medicina;
    if  @id is null BEGIN
        set @id = 1;
    end;
    insert into Medicina values (@id,@nombreMedicina,1);
END
GO

/*
SP para el modificar de medicina
*/
drop procedure if exists actualizarMedicina;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE actualizarMedicina
    @nombreMedicina varchar(15), -- not null
    @idMedicina int
AS
BEGIN
	SET NOCOUNT ON;
    update Medicina set descripcion = @nombreMedicina 
    where idMedicina = @idMedicina;
END
GO

/*
SP para el eliminar de medicina
*/
drop procedure if exists eliminarMedicina;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE eliminarMedicina
    @idMedicina int
AS
BEGIN
	SET NOCOUNT ON;
    update Medicina set activo = 0
    where idMedicina = @idMedicina;
END
GO

/*
SP para el mostrar medicinas
*/
drop procedure if exists obtenerMedicinas;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerMedicinas
AS
BEGIN
	SET NOCOUNT ON;
    select top (select count(*) from Medicina) * from Medicina where activo = 1;
END
GO

/*
SP para el mostrar medicina
*/
drop procedure if exists obtenerMedicina;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE obtenerMedicina
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    select top 1 * from Medicina where activo = 1 and idMedicina = @id;
END
GO