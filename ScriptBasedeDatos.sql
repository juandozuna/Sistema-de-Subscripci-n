/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [MVCSuscriptionDatabse]    Script Date: 10/4/17 6:01:33 PM ******/
CREATE DATABASE [MVCSuscriptionDatabse]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MVCSuscriptionDatabse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\MVCSuscriptionDatabse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MVCSuscriptionDatabse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\MVCSuscriptionDatabse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MVCSuscriptionDatabse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET ARITHABORT OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET  MULTI_USER 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET QUERY_STORE = OFF
GO
USE [MVCSuscriptionDatabse]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MVCSuscriptionDatabse]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 10/4/17 6:01:33 PM ******/
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
 CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteSuscripcion]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Table [dbo].[Images]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Table [dbo].[Perfiles]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Table [dbo].[PerfilRoles]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Table [dbo].[Plan]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Table [dbo].[Servicio]    Script Date: 10/4/17 6:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[ServicioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Precio] [float] NOT NULL,
	[ImagenID] [int] NULL,
 CONSTRAINT [PK_dbo.Servicio] PRIMARY KEY CLUSTERED 
(
	[ServicioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicioEnPlan]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Table [dbo].[Subscripcions]    Script Date: 10/4/17 6:01:33 PM ******/
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
/****** Object:  Index [IX_ImagenID]    Script Date: 10/4/17 6:01:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImagenID] ON [dbo].[Clientes]
(
	[ImagenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImagenID]    Script Date: 10/4/17 6:01:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImagenID] ON [dbo].[Plan]
(
	[ImagenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImagenID]    Script Date: 10/4/17 6:01:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImagenID] ON [dbo].[Servicio]
(
	[ImagenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlanID]    Script Date: 10/4/17 6:01:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlanID] ON [dbo].[ServicioEnPlan]
(
	[PlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ServicioID]    Script Date: 10/4/17 6:01:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_ServicioID] ON [dbo].[ServicioEnPlan]
(
	[ServicioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageID]    Script Date: 10/4/17 6:01:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImageID] ON [dbo].[Subscripcions]
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlanID]    Script Date: 10/4/17 6:01:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlanID] ON [dbo].[Subscripcions]
(
	[PlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
USE [master]
GO
ALTER DATABASE [MVCSuscriptionDatabse] SET  READ_WRITE 
GO
