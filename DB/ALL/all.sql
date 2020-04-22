USE [Sylom]
GO
/****** Object:  Table [dbo].[Anotacion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anotacion](
	[idAnotacion] [int] NOT NULL,
	[tituloAnotacion] [varchar](55) NULL,
	[descripcion] [varchar](100) NULL,
	[idExpediente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idAnotacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartado](
	[idApartado] [int] NOT NULL,
	[nombreApartado] [varchar](25) NULL,
	[siteUrl] [varchar](200) NULL,
	[icon] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[idApartado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[idBitacora] [int] NOT NULL,
	[controlador] [varchar](75) NOT NULL,
	[metodo] [varchar](500) NOT NULL,
	[msj] [varchar](1000) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[usuario] [varchar](255) NOT NULL,
	[tipo] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Canton]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canton](
	[idCanton] [varchar](2) NOT NULL,
	[nombre] [varchar](15) NULL,
	[idProvincia] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCanton] ASC,
	[idProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[idDistrito] [varchar](3) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idProvincia] [varchar](1) NOT NULL,
	[idCanton] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC,
	[idCanton] ASC,
	[idDistrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[idEmpleado] [int] NOT NULL,
	[idTipoEmpleado] [int] NOT NULL,
	[nombre] [varchar](100) NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expediente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expediente](
	[idExpediente] [int] NOT NULL,
	[descripcion] [varchar](350) NOT NULL,
	[idPaciente] [int] NOT NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idExpediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institucion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institucion](
	[idInstitucion] [int] NOT NULL,
	[nombreInstitucion] [varchar](75) NULL,
	[direccion] [varchar](255) NULL,
	[telefono] [varchar](15) NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInstitucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicina]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicina](
	[idMedicina] [int] NOT NULL,
	[descripcion] [varchar](75) NOT NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMedicina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicina_Sesion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicina_Sesion](
	[idMedicina] [int] NOT NULL,
	[idSesion] [int] NOT NULL,
 CONSTRAINT [idMedicina_idSesion_Medicina_Sesion_pk] PRIMARY KEY CLUSTERED 
(
	[idMedicina] ASC,
	[idSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[idPaciente] [int] NOT NULL,
	[descripcion] [varchar](250) NULL,
	[idTipoPaciente] [int] NOT NULL,
	[cedula] [varchar](15) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](30) NOT NULL,
	[apellido2] [varchar](30) NOT NULL,
	[direccion2] [varchar](255) NOT NULL,
	[provincia] [varchar](1) NOT NULL,
	[canton] [varchar](2) NOT NULL,
	[distrito] [varchar](3) NOT NULL,
	[genero] [int] NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[idInstitucion] [int] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK__Paciente__F48A08F2A234BD8A] PRIMARY KEY CLUSTERED 
(
	[idPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] NOT NULL,
	[cedula] [varchar](15) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](30) NULL,
	[apellido2] [varchar](30) NULL,
	[direccionPadron] [varchar](10) NULL,
	[direccion2] [varchar](255) NULL,
	[provincia] [varchar](1) NULL,
	[canton] [varchar](2) NULL,
	[distrito] [varchar](3) NULL,
	[genero] [int] NULL,
	[fechaNacimiento] [date] NULL,
	[email] [varchar](300) NULL,
	[telefono] [varchar](15) NULL,
	[lastUpdate] [date] NOT NULL,
	[activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[idProvincia] [varchar](1) NOT NULL,
	[nombre] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[idRol] [int] NOT NULL,
	[descripcion] [varchar](75) NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Apartado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Apartado](
	[idRol] [int] NOT NULL,
	[idApartado] [int] NOT NULL,
	[crear] [bit] NULL,
	[leer] [bit] NULL,
	[editar] [bit] NULL,
	[eliminar] [bit] NULL,
 CONSTRAINT [idRol_idApartado_Rol_Apartado_pk] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC,
	[idApartado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesion](
	[idSesion] [int] NOT NULL,
	[asunto] [varchar](55) NULL,
	[fecha] [date] NULL,
	[hora] [varchar](7) NULL,
	[notas] [varchar](255) NULL,
	[sintomas] [varchar](255) NULL,
	[idExpediente] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEmpleado](
	[idTipoEmpleado] [int] NOT NULL,
	[descripcion] [varchar](75) NOT NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPaciente](
	[idTipoPaciente] [int] NOT NULL,
	[descripcion] [varchar](25) NOT NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] NOT NULL,
	[usuario] [varchar](255) NOT NULL,
	[contra] [varchar](255) NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Rol]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Rol](
	[idUsuario] [int] NOT NULL,
	[idRol] [int] NOT NULL,
 CONSTRAINT [idUsuario_idRol_Usuario_Rol_pk] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Anotacion]  WITH CHECK ADD  CONSTRAINT [idExpediente_Anotacion_fk] FOREIGN KEY([idExpediente])
REFERENCES [dbo].[Expediente] ([idExpediente])
GO
ALTER TABLE [dbo].[Anotacion] CHECK CONSTRAINT [idExpediente_Anotacion_fk]
GO
ALTER TABLE [dbo].[Canton]  WITH CHECK ADD  CONSTRAINT [idProvincia_Canton_fk] FOREIGN KEY([idProvincia])
REFERENCES [dbo].[Provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[Canton] CHECK CONSTRAINT [idProvincia_Canton_fk]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [idCanton_Distrito_fk] FOREIGN KEY([idCanton], [idProvincia])
REFERENCES [dbo].[Canton] ([idCanton], [idProvincia])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [idCanton_Distrito_fk]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [idTipoEmpleado_Empleado_fk] FOREIGN KEY([idTipoEmpleado])
REFERENCES [dbo].[TipoEmpleado] ([idTipoEmpleado])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [idTipoEmpleado_Empleado_fk]
GO
ALTER TABLE [dbo].[Expediente]  WITH CHECK ADD  CONSTRAINT [idPaciente_Expediente_fk] FOREIGN KEY([idPaciente])
REFERENCES [dbo].[Paciente] ([idPaciente])
GO
ALTER TABLE [dbo].[Expediente] CHECK CONSTRAINT [idPaciente_Expediente_fk]
GO
ALTER TABLE [dbo].[Medicina_Sesion]  WITH CHECK ADD  CONSTRAINT [idMedicina_Medicina_Sesion_fk] FOREIGN KEY([idMedicina])
REFERENCES [dbo].[Medicina] ([idMedicina])
GO
ALTER TABLE [dbo].[Medicina_Sesion] CHECK CONSTRAINT [idMedicina_Medicina_Sesion_fk]
GO
ALTER TABLE [dbo].[Medicina_Sesion]  WITH CHECK ADD  CONSTRAINT [idSesion_Medicina_Sesion_fk] FOREIGN KEY([idSesion])
REFERENCES [dbo].[Sesion] ([idSesion])
GO
ALTER TABLE [dbo].[Medicina_Sesion] CHECK CONSTRAINT [idSesion_Medicina_Sesion_fk]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [canton_Paciente_fk] FOREIGN KEY([canton], [provincia])
REFERENCES [dbo].[Canton] ([idCanton], [idProvincia])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [canton_Paciente_fk]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [distrito_Paciente_fk] FOREIGN KEY([provincia], [canton], [distrito])
REFERENCES [dbo].[Distrito] ([idProvincia], [idCanton], [idDistrito])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [distrito_Paciente_fk]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [idInstitucion] FOREIGN KEY([idInstitucion])
REFERENCES [dbo].[Institucion] ([idInstitucion])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [idInstitucion]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [idTipoPaciente_Paciente_fk] FOREIGN KEY([idTipoPaciente])
REFERENCES [dbo].[TipoPaciente] ([idTipoPaciente])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [idTipoPaciente_Paciente_fk]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [provincia_Paciente_fk] FOREIGN KEY([provincia])
REFERENCES [dbo].[Provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [provincia_Paciente_fk]
GO
ALTER TABLE [dbo].[Rol_Apartado]  WITH CHECK ADD  CONSTRAINT [idApartado_Rol_Apartado_fk] FOREIGN KEY([idApartado])
REFERENCES [dbo].[Apartado] ([idApartado])
GO
ALTER TABLE [dbo].[Rol_Apartado] CHECK CONSTRAINT [idApartado_Rol_Apartado_fk]
GO
ALTER TABLE [dbo].[Rol_Apartado]  WITH CHECK ADD  CONSTRAINT [idRol_Rol_Apartado_fk] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[Rol_Apartado] CHECK CONSTRAINT [idRol_Rol_Apartado_fk]
GO
ALTER TABLE [dbo].[Sesion]  WITH CHECK ADD  CONSTRAINT [idExpediente_Sesion_fk] FOREIGN KEY([idExpediente])
REFERENCES [dbo].[Expediente] ([idExpediente])
GO
ALTER TABLE [dbo].[Sesion] CHECK CONSTRAINT [idExpediente_Sesion_fk]
GO
ALTER TABLE [dbo].[Sesion]  WITH CHECK ADD  CONSTRAINT [idUsuario_Sesion_fk] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Sesion] CHECK CONSTRAINT [idUsuario_Sesion_fk]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [idEmpleado_Usuario_fk] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [idEmpleado_Usuario_fk]
GO
ALTER TABLE [dbo].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [idRol_Usuario_Rol_fk] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[Usuario_Rol] CHECK CONSTRAINT [idRol_Usuario_Rol_fk]
GO
ALTER TABLE [dbo].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [idUsuario_Usuario_Rol_fk] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuario_Rol] CHECK CONSTRAINT [idUsuario_Usuario_Rol_fk]
GO
/****** Object:  StoredProcedure [dbo].[actualizarEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[actualizarEmpleado]
    @idEmpleado int,
    @idTipoEmpleado int,
    @nombre varchar(100),

    @usuario varchar(255),
    @pass varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
    declare @idUsuario int;

    select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;

    update Empleado 
    set idTipoEmpleado = @idTipoEmpleado, nombre = @nombre
    where idEmpleado = @idEmpleado;

    if @usuario is not null and @pass is not null and @usuario != '' and @pass != '' BEGIN
        update Usuario 
        set usuario = @usuario, contra = @pass 
        where idUsuario = @idUsuario;
    end;
END
GO
/****** Object:  StoredProcedure [dbo].[actualizarInstitucion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[actualizarInstitucion]
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
/****** Object:  StoredProcedure [dbo].[actualizarMedicina]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[actualizarMedicina]
    @nombreMedicina varchar(15), -- not null
    @idMedicina int
AS
BEGIN
	SET NOCOUNT ON;
    update Medicina set descripcion = @nombreMedicina 
    where idMedicina = @idMedicina and activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[actualizarPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[actualizarPaciente]
    @idPaciente int,
    @cedula varchar(15),
    @nombre varchar(40),
	@apellido1 varchar(30),
	@apellido2 varchar(30),
	@direccion2 varchar(255),
	@provincia varchar(1),
	@canton varchar(2),
	@distrito varchar(3),
	@genero int,
	@fechaNacimiento varchar(10),

    @descripcionCliente varchar(250),
	@idTipoPaciente int,
    @idInstitucion int,
    
    @descripcionExpediente varchar(350)
AS
BEGIN
	SET NOCOUNT ON;
    update Paciente 
        set nombre = @nombre,
            apellido1 = @apellido1,
            apellido2 = @apellido2,
            direccion2 = @direccion2,
            provincia = @provincia,
            canton = @canton,
            distrito = @distrito,
            genero = @genero,
            fechaNacimiento = @fechaNacimiento,
            descripcion = @descripcionCliente,
            idTipoPaciente = @idTipoPaciente,
            idInstitucion = @idInstitucion
        where idPaciente = @idPaciente;
    update Expediente
        set descripcion = @descripcionExpediente
        where idPaciente = @idPaciente and idExpediente > 0 and activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[actualizarRol]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[actualizarRol]
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
/****** Object:  StoredProcedure [dbo].[actualizarTipoEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[actualizarTipoEmpleado]
    @nombreTipoEmpleado varchar(15), -- not null
    @idTipoEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoEmpleado set descripcion = @nombreTipoEmpleado 
    where idTipoEmpleado = @idTipoEmpleado and activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[actualizarTipoPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[actualizarTipoPaciente]
    @nombreTipoPaciente varchar(15), -- not null
    @idTipoPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoPaciente set descripcion = @nombreTipoPaciente 
    where idTipoPaciente = @idTipoPaciente and activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[agregarEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarEmpleado]
	@idTipoEmpleado int,
    @nombre varchar(100),

    @usuario varchar(255),
    @pass varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
    declare @idEmpleado int;
    declare @idUsuario int;
    select @idEmpleado = max(idEmpleado) + 1 from Empleado;
    if @idEmpleado is null begin 
        set @idEmpleado = 1;
    end;
    select @idUsuario = max(idUsuario) + 1 from Usuario;
    if @idUsuario is null BEGIN
        set @idUsuario = 1;
    end;

    insert into Empleado values (@idEmpleado,@idTipoEmpleado,@nombre,1);
    insert into Usuario values (@idUsuario,@usuario,@pass,@idEmpleado,1);
END
GO
/****** Object:  StoredProcedure [dbo].[agregarInstitucion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarInstitucion]
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
/****** Object:  StoredProcedure [dbo].[agregarMedicina]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarMedicina]
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
/****** Object:  StoredProcedure [dbo].[agregarPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarPaciente]
    @cedula varchar(15),
    @nombre varchar(40),
	@apellido1 varchar(30),
	@apellido2 varchar(30),
	@direccion2 varchar(255),
	@provincia varchar(1),
	@canton varchar(2),
	@distrito varchar(3),
	@genero int,
	@fechaNacimiento varchar(10),

    @descripcionCliente varchar(250),
	@idTipoPaciente int,
    @idInstitucion int,
    
    @descripcionExpediente varchar(350)
AS
BEGIN
	SET NOCOUNT ON;
    declare @idPaciente int;
    declare @idExpediente int;
    -- Cliente
    select @idPaciente = max(idPaciente) + 1 from Paciente;
    if @idPaciente is null BEGIN
        set @idPaciente = 1;
    end;
    insert into Paciente values (@idPaciente,@descripcionCliente,@idTipoPaciente,@cedula,@nombre,@apellido1,@apellido2,@direccion2,@provincia,@canton,@distrito,@genero,@fechaNacimiento,@idInstitucion,1);
    -- Expediente
    select @idExpediente = max(idExpediente) + 1 from Expediente;
    if @idExpediente is null BEGIN
        set @idExpediente = 1;
    end;
    insert into Expediente values (@idExpediente,@descripcionExpediente,@idPaciente,1);
END
GO
/****** Object:  StoredProcedure [dbo].[agregarRegistroBitacora]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarRegistroBitacora]
	@controlador varchar(75),
	@metodo varchar(75),
	@msj varchar(max),
    @usuario varchar(255),
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
    insert into Bitacora values (@id,@controlador,@metodo,@msj,@fecha,@usuario,@tipo);
END
GO
/****** Object:  StoredProcedure [dbo].[agregarRol]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarRol]
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
/****** Object:  StoredProcedure [dbo].[agregarRolApartado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarRolApartado]
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
/****** Object:  StoredProcedure [dbo].[agregarRolUsuario]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarRolUsuario]
    @idUsuario int,
    @idRol int
AS
BEGIN
	SET NOCOUNT ON;
    insert into Usuario_Rol values (@idUsuario,@idRol);
END
GO
/****** Object:  StoredProcedure [dbo].[agregarSesion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarSesion]
    @asunto varchar(55),
	@fecha varchar(11),
    @hora varchar(7),
    @notas varchar(255),
    @sintomas varchar(255),
	@idExpediente int,
	@idUsuario int
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idSesion) + 1 from Sesion;
    if @id is null BEGIN
        set @id = 1;
    end;
    insert into Sesion values (@id,@asunto,@fecha,@hora,@notas,@sintomas,@idExpediente,@idUsuario,1);
END
GO
/****** Object:  StoredProcedure [dbo].[agregarTipoEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarTipoEmpleado]
    @nombreTipoEmpleado varchar(15) -- not null
AS
BEGIN
	SET NOCOUNT ON;
    declare @id int;
    select @id = max(idTipoEmpleado) + 1 from TipoEmpleado;
    if  @id is null BEGIN
        set @id = 1;
    end;
    insert into TipoEmpleado values (@id,@nombreTipoEmpleado,1);
END
GO
/****** Object:  StoredProcedure [dbo].[agregarTipoPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[agregarTipoPaciente]
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
/****** Object:  StoredProcedure [dbo].[cancelarSesion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[cancelarSesion]
    @idSesion int
AS
BEGIN
	SET NOCOUNT ON;
    update Sesion set activo = 0 
    where idSesion = @idSesion;
END
GO
/****** Object:  StoredProcedure [dbo].[consultaLoginAuth]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultaLoginAuth]
    @usuario varchar(255),
    @contra varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
    declare @auth int;
    select top 1 @auth = count(*) from Usuario u where u.usuario = @usuario and u.contra = @contra;
    if @auth is not null and @auth = 1 begin
        select e.nombre,
            e.idEmpleado,e.idTipoEmpleado,te.descripcion,
            u.idUsuario
        from Empleado e,TipoEmpleado te, Usuario u
        where u.idEmpleado = e.idEmpleado and e.idTipoEmpleado = te.idTipoEmpleado  
            and u.usuario = @usuario and u.contra = @contra and u.activo = 1 and e.activo = 1;
	end
END
GO
/****** Object:  StoredProcedure [dbo].[consultaLoginPermisos]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultaLoginPermisos]
    @idUsuario int
AS
BEGIN
	SET NOCOUNT ON;
    select r.descripcion,ra.idApartado,a.nombreApartado,a.siteUrl,a.icon,ra.crear ,ra.leer, ra.editar, ra.eliminar
    from Usuario u, Usuario_Rol ur, Rol r, Apartado a, Rol_Apartado ra
    where u.idUsuario = ur.idUsuario and r.idRol = ur.idRol and r.idRol = ra.idRol and a.idApartado = ra.idApartado
        and u.idUsuario = @idUsuario
        order by r.descripcion;
END
GO
/****** Object:  StoredProcedure [dbo].[consultaPersona]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultaPersona]
    @cedula varchar(15)
AS
BEGIN
	SET NOCOUNT ON;
    select cedula,nombre,apellido1,apellido2,convert(varchar,fechaNacimiento) as fechaNaciemiento, provincia,canton,distrito,genero,direccion2,activo
    from Persona where cedula = @cedula;
END
GO
/****** Object:  StoredProcedure [dbo].[consultarApartados]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultarApartados]
AS
BEGIN
	SET NOCOUNT ON;
    select idApartado,nombreApartado
    from Apartado;
END
GO
/****** Object:  StoredProcedure [dbo].[consultarCantones]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultarCantones]
	@idProvincia varchar(1)
AS
BEGIN
	SET NOCOUNT ON;
    select * from Canton c where idProvincia = @idProvincia;
END
GO
/****** Object:  StoredProcedure [dbo].[consultarDistritos]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultarDistritos]
    @idProvincia varchar(1),
	@idCanton varchar(2)
AS
BEGIN
	SET NOCOUNT ON;
    select * from Distrito where idProvincia = @idProvincia and idCanton = @idCanton;
END
GO
/****** Object:  StoredProcedure [dbo].[consultarProvincias]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultarProvincias]
AS
BEGIN
	SET NOCOUNT ON;
    select * from Provincia;
END
GO
/****** Object:  StoredProcedure [dbo].[consultarRolApartados]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultarRolApartados]
    @idRol int
AS
BEGIN
	SET NOCOUNT ON;
    select *
    from Rol r, Rol_Apartado ra, Apartado a
    where r.idRol = @idRol and ra.idRol = r.idRol and ra.idApartado = a.idApartado;
END
GO
/****** Object:  StoredProcedure [dbo].[consultarRoles]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultarRoles]
    @idUsuario int
AS
BEGIN
	SET NOCOUNT ON;
    select r.idRol,r.descripcion 
    from Rol r, Usuario_Rol ur
    where r.idRol = ur.idRol and ur.idUsuario = @idUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[consultarRolUsuarios]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultarRolUsuarios]
    @idRol int
AS
BEGIN
	SET NOCOUNT ON;
    select u.idUsuario, e.nombre
    from Usuario u, Empleado e, Rol r, Usuario_Rol ur
    where u.idEmpleado = e.idEmpleado and ur.idUsuario = u.idUsuario and ur.idRol = r.idRol and r.idRol = @idRol;
END
GO
/****** Object:  StoredProcedure [dbo].[consultarUsuarios]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultarUsuarios]
AS
BEGIN
	SET NOCOUNT ON;
    select e.nombre, u.idUsuario
    from Usuario u, Empleado e
    where u.idEmpleado = e.idEmpleado and u.activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[consultaSesiones]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[consultaSesiones]
AS
BEGIN
	SET NOCOUNT ON;
    select idSesion,asunto,CONVERT(varchar,fecha) as fecha,hora,notas,sintomas,idExpediente,idUsuario,
    (case when GETDATE()-2 > fecha then '#d9534f'
    else '#2c3e50' end) as color
    from Sesion where activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[eliminarEmpleado]
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
/****** Object:  StoredProcedure [dbo].[eliminarInstitucion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[eliminarInstitucion]
    @idInstitucion int
AS
BEGIN
	SET NOCOUNT ON;
    update Institucion set activo = 0
    where idInstitucion = @idInstitucion;
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarMedicina]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[eliminarMedicina]
    @idMedicina int
AS
BEGIN
	SET NOCOUNT ON;
    update Medicina set activo = 0
    where idMedicina = @idMedicina;
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[eliminarPaciente]
    @idPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    update Paciente set activo = 0 where idPaciente = @idPaciente;
    update Expediente set activo = 0 where idPaciente = @idPaciente and idExpediente > 0;
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarRol]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[eliminarRol]
    @idRol int
AS
BEGIN
	SET NOCOUNT ON;
    delete from Rol_Apartado where idRol = @idRol and idApartado > 0;
    delete from Usuario_Rol where idRol = @idRol and idUsuario > 0;
    delete from Rol where idRol = @idRol;
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarTipoEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[eliminarTipoEmpleado]
    @idTipoEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoEmpleado set activo = 0
    where idTipoEmpleado = @idTipoEmpleado;
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarTipoPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[eliminarTipoPaciente]
    @idTipoPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoPaciente set activo = 0
    where idTipoPaciente = @idTipoPaciente;
END
GO
/****** Object:  StoredProcedure [dbo].[habilitarEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[habilitarEmpleado]
    @idEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    declare @idUsuario int;

    select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;

    update Empleado 
    set activo = 1
    where idEmpleado = @idEmpleado;

    update Usuario 
    set activo = 1
    where idUsuario = @idUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[habilitarInstitucion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[habilitarInstitucion]
    @idInstitucion int
AS
BEGIN
	SET NOCOUNT ON;
    update Institucion set activo = 1
    where idInstitucion = @idInstitucion;
END
GO
/****** Object:  StoredProcedure [dbo].[habilitarMedicina]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[habilitarMedicina]
    @idMedicina int
AS
BEGIN
	SET NOCOUNT ON;
    update Medicina set activo = 1
    where idMedicina = @idMedicina;
END
GO
/****** Object:  StoredProcedure [dbo].[habilitarPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[habilitarPaciente]
    @idPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    update Paciente set activo = 1 where idPaciente = @idPaciente;
    update Expediente set activo = 1 where idPaciente = @idPaciente and idExpediente > 0;
END
GO
/****** Object:  StoredProcedure [dbo].[habilitarTipoEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[habilitarTipoEmpleado]
    @idTipoEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoEmpleado set activo = 1
    where idTipoEmpleado = @idTipoEmpleado;
END
GO
/****** Object:  StoredProcedure [dbo].[habilitarTipoPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[habilitarTipoPaciente]
    @idTipoPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    update TipoPaciente set activo = 1
    where idTipoPaciente = @idTipoPaciente;
END
GO
/****** Object:  StoredProcedure [dbo].[mantenimientoPersonas]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[mantenimientoPersonas]
    @cedula varchar(15), -- not null
	@nombre varchar(40), -- not null
	@apellido1 varchar(30),
	@apellido2 varchar(30),
	@direccionPadron varchar(10),
	@direccion2 varchar(255),
	@provincia varchar(1),
	@canton varchar(2),
	@distrito varchar(3),
	@genero int = 0,
	@fechaNacimiento date = null,
	@email varchar(300),
	@telefono varchar(15),
    @activo bit
AS
BEGIN
	SET NOCOUNT ON;
    declare @fechaActual date;
    declare @id int;
	declare @edad int;
	declare @tempCedula varchar(15);
	declare @tempFecha date;
    set @fechaActual = GETDATE();
	select @tempCedula = cedula, @tempFecha = fechaNacimiento from Persona where cedula = @cedula;
	if @fechaNacimiento = '0001-01-01' begin
		set @fechaNacimiento = @tempFecha;
	end;
    if @tempCedula is not null BEGIN
      update Persona set 
            nombre = @nombre,
            apellido1 = @apellido1,
            apellido2 = @apellido2,
            direccionPadron = @direccionPadron,
            direccion2 = @direccion2,
            provincia = @provincia,
            canton = @canton,
            distrito = @distrito,
            genero = @genero,
            fechaNacimiento = @fechaNacimiento,
            email = @email,
            telefono = @telefono,
            lastUpdate = @fechaActual,
            activo = @activo where cedula = @cedula;
    end
    else begin 
        select @id = max(idPersona)+1 from Persona;
        if @id is null BEGIN
            set @id = 1;
        end;
        insert into Persona values (
            @id,
            @cedula,
            @nombre,
            @apellido1,
            @apellido2,
            @direccionPadron,
            @direccion2,
            @provincia,
            @canton,
            @distrito,
            @genero,
            @fechaNacimiento,
            @email,
            @telefono,
            @fechaActual,
            1);
    end
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerEmpleados]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerEmpleados]
AS
BEGIN
	SET NOCOUNT ON;
    select e.idEmpleado,e.nombre,te.idTipoEmpleado,te.descripcion,u.activo
    from Usuario u, Empleado e,TipoEmpleado te
    where (u.idEmpleado = e.idEmpleado) and (te.idTipoEmpleado = e.idTipoEmpleado)
    and te.activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerInstitucion]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerInstitucion]
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    select top 1 * from Institucion where activo = 1 and idInstitucion = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerInstituciones]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerInstituciones]
AS
BEGIN
	SET NOCOUNT ON;
    select * from Institucion;
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerMedicina]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerMedicina]
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    select top 1 * from Medicina where activo = 1 and idMedicina = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerMedicinas]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerMedicinas]
AS
BEGIN
	SET NOCOUNT ON;
    select * from Medicina;
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerPaciente]
    @idPaciente int
AS
BEGIN
	SET NOCOUNT ON;
    select p.idPaciente, p.direccion2, p.genero, p.cedula, p.nombre , p.apellido1, p.apellido2, p.provincia, p.canton, p.distrito,convert(varchar,p.fechaNacimiento) as fechaNacimiento, p.descripcion as descripcionPaciente, p.idTipoPaciente, p.idInstitucion, 
            e.descripcion as descripcionExpediente
    from Paciente p, Expediente e
    where (p.idPaciente = e.idPaciente) and (e.activo = 1) and (p.activo = 1) and (p.idPaciente = @idPaciente);
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerPacientes]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerPacientes]
AS
BEGIN
	SET NOCOUNT ON;
    select p.activo as activo,p.idPaciente, p.cedula, p.nombre , p.apellido1, p.apellido2, p.provincia, p.canton, p.distrito, convert(varchar,p.fechaNacimiento) as fechaNacimiento, p.descripcion as descripcionPaciente, p.idTipoPaciente, p.idInstitucion, 
            e.descripcion as descripcionExpediente, e.idExpediente
    from Paciente p, Expediente e
    where (p.idPaciente = e.idPaciente);
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerTipoEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerTipoEmpleado]
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    select top 1 * from TipoEmpleado  where activo = 1 and idTipoEmpleado = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerTipoEmpleados]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerTipoEmpleados]
    @idEmpleado int
AS
BEGIN
	SET NOCOUNT ON;
    declare @idTipoEmpleado int;
    select @idTipoEmpleado = idTipoEmpleado from Empleado where idEmpleado = @idEmpleado;
    select top (select count(*) from TipoEmpleado) idTipoEmpleado,descripcion,
    (case when @idTipoEmpleado=idTipoEmpleado then 1
	else 0 end) as asignado,activo
    from TipoEmpleado;
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerTipoPaciente]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerTipoPaciente]
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    select top 1 * from TipoPaciente  where activo = 1 and idTipoPaciente = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerTipoPacientes]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[obtenerTipoPacientes]
AS
BEGIN
	SET NOCOUNT ON;
    select top (select count(*) from TipoPaciente) * from TipoPaciente;
END
GO
/****** Object:  StoredProcedure [dbo].[tempSP]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[tempSP]
AS
BEGIN
	SET NOCOUNT ON;
    begin transaction;
	save transaction MySavePoint;
	begin try
		insert into temp values ('2020/12/31');
		insert into temp values ('2020/12/31');
		commit transaction;
	end try
	begin catch
		if @@TRANCOUNT > 0 begin 
			ROLLBACK TRANSACTION MySavePoint;
		end;
	end catch
END
GO
/****** Object:  StoredProcedure [dbo].[verficicarUsuarioEmpleado]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[verficicarUsuarioEmpleado]
    @idEmpleado int,
    @pass varchar(255),
    @output bit output
AS
BEGIN
	SET NOCOUNT ON;
    declare @idUsuario int;
    declare @temp int;
    select @idUsuario = idUsuario from Usuario where idEmpleado = @idEmpleado;
    select @temp = count(*) from Usuario where idUsuario = @idUsuario and contra = @pass;
    set @output = case when @temp = 1 then 1 else 0 end;
END
GO
/****** Object:  StoredProcedure [dbo].[verRegistroBitacora]    Script Date: 2020-04-21 6:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/05
-- =============================================
CREATE PROCEDURE [dbo].[verRegistroBitacora]
AS
BEGIN
	SET NOCOUNT ON;
    select top (select count(*) from Bitacora) * from Bitacora;
END
GO
