/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [MVCSuscriptionDatabse]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/12/17 7:11:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Primer Nombre] [varchar](50) NOT NULL,
	[Segundo Nombre] [varchar](50) NULL,
	[Primer_Apellido] [varchar](50) NOT NULL,
	[Fecha_de_nacimiento] [date] NOT NULL,
	[Numero Telefonico] [varchar](50) NULL,
	[e-mail] [varchar](100) NOT NULL,
	[Metodo de Pago] [varchar](50) NOT NULL,
	[NumeroTarjeta] [int] NULL,
	[CVC_o_CVV] [int] NULL,
	[Fecha_de_expiracion] [date] NULL,
	[ImagenID] [int] NULL,
	[IDPedro] [int] NULL,
	[IDErick] [int] NULL,
 CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteSuscripcion]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteSuscripcion](
	[ClienteSuscripcionId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[SubscripcionId] [int] NOT NULL,
	[Cliente_ClientID] [int] NULL,
 CONSTRAINT [PK_dbo.ClienteSuscripcion] PRIMARY KEY CLUSTERED 
(
	[ClienteSuscripcionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[imagesID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[ImageData] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_dbo.Images] PRIMARY KEY CLUSTERED 
(
	[imagesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[PerfilID] [int] IDENTITY(1,1) NOT NULL,
	[nombrePerfil] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[PerfilID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilRoles]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilRoles](
	[perfiRolesID] [int] IDENTITY(1,1) NOT NULL,
	[perfilId] [int] NOT NULL,
	[roleName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_PerfilRoles] PRIMARY KEY CLUSTERED 
(
	[perfiRolesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilUsuario](
	[perfilUserId] [int] IDENTITY(1,1) NOT NULL,
	[perfilId] [int] NOT NULL,
	[userId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_PerfilUsuario] PRIMARY KEY CLUSTERED 
(
	[perfilUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plan]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plan](
	[PlanID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Precio] [float] NOT NULL,
	[ImagenID] [int] NULL,
 CONSTRAINT [PK_dbo.Plan] PRIMARY KEY CLUSTERED 
(
	[PlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[ServicioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Precio] [float] NOT NULL,
	[ImagenID] [int] NULL,
	[IDPedro] [int] NULL,
	[IDErick] [int] NULL,
 CONSTRAINT [PK_dbo.Servicio] PRIMARY KEY CLUSTERED 
(
	[ServicioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicioEnPlan]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicioEnPlan](
	[ServicioEnPlanID] [int] IDENTITY(1,1) NOT NULL,
	[ServicioID] [int] NOT NULL,
	[PlanID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ServicioEnPlan] PRIMARY KEY CLUSTERED 
(
	[ServicioEnPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscripcions]    Script Date: 10/12/17 7:11:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscripcions](
	[SubscripcionID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NOT NULL,
	[Fecha_creacion] [date] NOT NULL,
	[Active] [bit] NOT NULL,
	[ImageID] [int] NULL,
 CONSTRAINT [PK_dbo.Subscripcions] PRIMARY KEY CLUSTERED 
(
	[SubscripcionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Clientes_dbo.Images_ImagenID] FOREIGN KEY([ImagenID])
REFERENCES [dbo].[Images] ([imagesID])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_dbo.Clientes_dbo.Images_ImagenID]
GO
ALTER TABLE [dbo].[ClienteSuscripcion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClienteSuscripcion_dbo.Clientes_Cliente_ClientID] FOREIGN KEY([Cliente_ClientID])
REFERENCES [dbo].[Clientes] ([ClientID])
GO
ALTER TABLE [dbo].[ClienteSuscripcion] CHECK CONSTRAINT [FK_dbo.ClienteSuscripcion_dbo.Clientes_Cliente_ClientID]
GO
ALTER TABLE [dbo].[ClienteSuscripcion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClienteSuscripcion_dbo.Subscripcions_SubscripcionId] FOREIGN KEY([SubscripcionId])
REFERENCES [dbo].[Subscripcions] ([SubscripcionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClienteSuscripcion] CHECK CONSTRAINT [FK_dbo.ClienteSuscripcion_dbo.Subscripcions_SubscripcionId]
GO
ALTER TABLE [dbo].[PerfilRoles]  WITH CHECK ADD  CONSTRAINT [FK_PerfilRoles_Perfiles] FOREIGN KEY([perfilId])
REFERENCES [dbo].[Perfiles] ([PerfilID])
GO
ALTER TABLE [dbo].[PerfilRoles] CHECK CONSTRAINT [FK_PerfilRoles_Perfiles]
GO
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Perfil] FOREIGN KEY([perfilId])
REFERENCES [dbo].[Perfiles] ([PerfilID])
GO
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Perfil]
GO
ALTER TABLE [dbo].[Plan]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Plan_dbo.Images_ImagenID] FOREIGN KEY([ImagenID])
REFERENCES [dbo].[Images] ([imagesID])
GO
ALTER TABLE [dbo].[Plan] CHECK CONSTRAINT [FK_dbo.Plan_dbo.Images_ImagenID]
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Servicio_dbo.Images_ImagenID] FOREIGN KEY([ImagenID])
REFERENCES [dbo].[Images] ([imagesID])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [FK_dbo.Servicio_dbo.Images_ImagenID]
GO
ALTER TABLE [dbo].[ServicioEnPlan]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ServicioEnPlan_dbo.Plan_PlanID] FOREIGN KEY([PlanID])
REFERENCES [dbo].[Plan] ([PlanID])
GO
ALTER TABLE [dbo].[ServicioEnPlan] CHECK CONSTRAINT [FK_dbo.ServicioEnPlan_dbo.Plan_PlanID]
GO
ALTER TABLE [dbo].[ServicioEnPlan]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ServicioEnPlan_dbo.Servicio_ServicioID] FOREIGN KEY([ServicioID])
REFERENCES [dbo].[Servicio] ([ServicioID])
GO
ALTER TABLE [dbo].[ServicioEnPlan] CHECK CONSTRAINT [FK_dbo.ServicioEnPlan_dbo.Servicio_ServicioID]
GO
ALTER TABLE [dbo].[Subscripcions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Subscripcions_dbo.Images_ImageID] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Images] ([imagesID])
GO
ALTER TABLE [dbo].[Subscripcions] CHECK CONSTRAINT [FK_dbo.Subscripcions_dbo.Images_ImageID]
GO
ALTER TABLE [dbo].[Subscripcions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Subscripcions_dbo.Plan_PlanID] FOREIGN KEY([PlanID])
REFERENCES [dbo].[Plan] ([PlanID])
GO
ALTER TABLE [dbo].[Subscripcions] CHECK CONSTRAINT [FK_dbo.Subscripcions_dbo.Plan_PlanID]
GO
