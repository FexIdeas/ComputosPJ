USE [master]
GO
/****** Object:  Database [ComputosPJ]    Script Date: 27/09/2018 8:25:51 ******/
CREATE DATABASE [ComputosPJ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComputosPJ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ComputosPJ.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComputosPJ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ComputosPJ_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComputosPJ] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComputosPJ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComputosPJ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComputosPJ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComputosPJ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComputosPJ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComputosPJ] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComputosPJ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComputosPJ] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ComputosPJ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComputosPJ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComputosPJ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComputosPJ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComputosPJ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComputosPJ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComputosPJ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComputosPJ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComputosPJ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComputosPJ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComputosPJ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComputosPJ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComputosPJ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComputosPJ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComputosPJ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComputosPJ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComputosPJ] SET RECOVERY FULL 
GO
ALTER DATABASE [ComputosPJ] SET  MULTI_USER 
GO
ALTER DATABASE [ComputosPJ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComputosPJ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComputosPJ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComputosPJ] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ComputosPJ]
GO
/****** Object:  StoredProcedure [dbo].[GetPermisosPorNombreDeUsuario]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		MC
-- Create date: 2017-06-21
-- Description:	GetPermisosPorUsuario
-- =============================================
CREATE PROCEDURE [dbo].[GetPermisosPorNombreDeUsuario]
(@UserName NVARCHAR(256))
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	a.ID, a.PadreID, a.Nombre, a.Orden, a.Icono, a.Accion, 
			a.Controlador, a.Activo, a.FechaAlta, a.mnuId
	FROM	[dbo].[Menu] a
			INNER JOIN
			[dbo].[MenuAspNetRoles] b ON a.ID=b.MenuId
			INNER JOIN
			[dbo].[AspNetUserRoles] c ON b.AspNetRolesId=c.RoleId
			INNER JOIN
			[dbo].[AspNetUsers] d ON c.UserId=d.Id
	WHERE	d.UserName=@UserName--'pgarcia'

END

GO
/****** Object:  Table [dbo].[Accion]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Icono] [nvarchar](50) NULL,
 CONSTRAINT [PK_Accion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetMenuAccion]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetMenuAccion](
	[IdMenu] [int] NOT NULL,
	[IdAccion] [int] NOT NULL,
 CONSTRAINT [PK_AspNetMenuAccion] PRIMARY KEY CLUSTERED 
(
	[IdMenu] ASC,
	[IdAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PadreID] [int] NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Orden] [tinyint] NULL,
	[Icono] [nvarchar](50) NULL,
	[Accion] [nvarchar](150) NOT NULL,
	[Controlador] [nvarchar](150) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[mnuId] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuAspNetRoles]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuAspNetRoles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[AspNetRolesId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_MenuAspNetRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuAspNetRolesAccion]    Script Date: 27/09/2018 8:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuAspNetRolesAccion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccionId] [int] NOT NULL,
	[MenuAspNetRolesId] [int] NOT NULL,
 CONSTRAINT [PK_MenuAspNetRolesAccion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'93939632-34b5-415a-a53d-21b6d006cbe5', N'Administrador')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1217f309-32bf-4384-b342-ed82a60f2ff9', N'93939632-34b5-415a-a53d-21b6d006cbe5')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName]) VALUES (N'1217f309-32bf-4384-b342-ed82a60f2ff9', NULL, 0, N'ALh5yQcGXUBTLZvL8YFsYaD5FY1tCTbvSb+m76Zleh0iidk+CcJJQVREN8AlhfSIow==', N'76b32470-e66d-4708-8b41-5c3661737ff0', NULL, 0, 0, NULL, 1, 0, N'admin', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

GO
INSERT [dbo].[Menu] ([ID], [PadreID], [Nombre], [Orden], [Icono], [Accion], [Controlador], [Activo], [FechaAlta], [mnuId]) VALUES (1, NULL, N'Seguridad', 90, NULL, N'Index', N'Users,Roles', 1, CAST(0x0000A96100000000 AS DateTime), NULL)
GO
INSERT [dbo].[Menu] ([ID], [PadreID], [Nombre], [Orden], [Icono], [Accion], [Controlador], [Activo], [FechaAlta], [mnuId]) VALUES (2, 1, N'Usuarios', 91, NULL, N'Index', N'Users', 1, CAST(0x0000A96100000000 AS DateTime), NULL)
GO
INSERT [dbo].[Menu] ([ID], [PadreID], [Nombre], [Orden], [Icono], [Accion], [Controlador], [Activo], [FechaAlta], [mnuId]) VALUES (3, 1, N'Roles', 92, NULL, N'Index', N'Roles', 1, CAST(0x0000A96100000000 AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuAspNetRoles] ON 

GO
INSERT [dbo].[MenuAspNetRoles] ([ID], [MenuId], [AspNetRolesId]) VALUES (1017, 2, N'93939632-34b5-415a-a53d-21b6d006cbe5')
GO
INSERT [dbo].[MenuAspNetRoles] ([ID], [MenuId], [AspNetRolesId]) VALUES (1018, 3, N'93939632-34b5-415a-a53d-21b6d006cbe5')
GO
INSERT [dbo].[MenuAspNetRoles] ([ID], [MenuId], [AspNetRolesId]) VALUES (1019, 1, N'93939632-34b5-415a-a53d-21b6d006cbe5')
GO
SET IDENTITY_INSERT [dbo].[MenuAspNetRoles] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 27/09/2018 8:25:51 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 27/09/2018 8:25:51 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 27/09/2018 8:25:51 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 27/09/2018 8:25:51 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 27/09/2018 8:25:51 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 27/09/2018 8:25:51 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_mnuActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_mnuFechaAlta]  DEFAULT (getdate()) FOR [FechaAlta]
GO
ALTER TABLE [dbo].[AspNetMenuAccion]  WITH CHECK ADD  CONSTRAINT [FK_AspNetMenuAccion_Accion] FOREIGN KEY([IdAccion])
REFERENCES [dbo].[Accion] ([ID])
GO
ALTER TABLE [dbo].[AspNetMenuAccion] CHECK CONSTRAINT [FK_AspNetMenuAccion_Accion]
GO
ALTER TABLE [dbo].[AspNetMenuAccion]  WITH CHECK ADD  CONSTRAINT [FK_AspNetMenuAccion_Menu] FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[AspNetMenuAccion] CHECK CONSTRAINT [FK_AspNetMenuAccion_Menu]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Menu] FOREIGN KEY([PadreID])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Menu]
GO
ALTER TABLE [dbo].[MenuAspNetRoles]  WITH CHECK ADD  CONSTRAINT [FK_MenuAspNetRoles_AspNetRoles] FOREIGN KEY([AspNetRolesId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[MenuAspNetRoles] CHECK CONSTRAINT [FK_MenuAspNetRoles_AspNetRoles]
GO
ALTER TABLE [dbo].[MenuAspNetRoles]  WITH CHECK ADD  CONSTRAINT [FK_MenuAspNetRoles_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[MenuAspNetRoles] CHECK CONSTRAINT [FK_MenuAspNetRoles_Menu]
GO
ALTER TABLE [dbo].[MenuAspNetRolesAccion]  WITH CHECK ADD  CONSTRAINT [FK_MenuAspNetRolesAccion_Accion] FOREIGN KEY([AccionId])
REFERENCES [dbo].[Accion] ([ID])
GO
ALTER TABLE [dbo].[MenuAspNetRolesAccion] CHECK CONSTRAINT [FK_MenuAspNetRolesAccion_Accion]
GO
ALTER TABLE [dbo].[MenuAspNetRolesAccion]  WITH CHECK ADD  CONSTRAINT [FK_MenuAspNetRolesAccion_MenuAspNetRoles] FOREIGN KEY([MenuAspNetRolesId])
REFERENCES [dbo].[MenuAspNetRoles] ([ID])
GO
ALTER TABLE [dbo].[MenuAspNetRolesAccion] CHECK CONSTRAINT [FK_MenuAspNetRolesAccion_MenuAspNetRoles]
GO
USE [master]
GO
ALTER DATABASE [ComputosPJ] SET  READ_WRITE 
GO
