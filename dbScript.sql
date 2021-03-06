USE [master]
GO
/****** Object:  Database [ContactManagerDb]    Script Date: 06.07.2021 15:51:20 ******/
CREATE DATABASE [ContactManagerDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactManagerDb', FILENAME = N'C:\Users\fytru\ContactManagerDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContactManagerDb_log', FILENAME = N'C:\Users\fytru\ContactManagerDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ContactManagerDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactManagerDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactManagerDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactManagerDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactManagerDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactManagerDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactManagerDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactManagerDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ContactManagerDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactManagerDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactManagerDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactManagerDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactManagerDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactManagerDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactManagerDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactManagerDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactManagerDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ContactManagerDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactManagerDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactManagerDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactManagerDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactManagerDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactManagerDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ContactManagerDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContactManagerDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ContactManagerDb] SET  MULTI_USER 
GO
ALTER DATABASE [ContactManagerDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactManagerDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContactManagerDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContactManagerDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContactManagerDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ContactManagerDb] SET QUERY_STORE = OFF
GO
USE [ContactManagerDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ContactManagerDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06.07.2021 15:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 06.07.2021 15:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Married] [bit] NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210705175042_ContactMigration', N'5.0.6')
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (1, N'George', CAST(N'2000-02-29T00:00:00.0000000' AS DateTime2), 0, N'0730746521', CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (2, N'Victoria', CAST(N'2001-04-01T00:00:00.0000000' AS DateTime2), 0, N'0730746322', CAST(2000.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (3, N'AAPL', CAST(N'2000-01-03T00:00:00.0000000' AS DateTime2), 0, N'0730746526', CAST(322.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (4, N'AAPL', CAST(N'2000-01-03T00:00:00.0000000' AS DateTime2), 0, N'0730746526', CAST(322.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (5, N'AAPL', CAST(N'2000-01-03T00:00:00.0000000' AS DateTime2), 1, N'0730746526', CAST(322.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (6, N'AAPL', CAST(N'2000-01-03T00:00:00.0000000' AS DateTime2), 1, N'0730746526', CAST(322.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (11, N'Natali', CAST(N'2000-01-03T00:00:00.0000000' AS DateTime2), 1, N'0730746526', CAST(322.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (12, N'Volodymyr', CAST(N'2000-04-14T00:00:00.0000000' AS DateTime2), 0, N'0730746528', CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (13, N'AAPL', CAST(N'2000-01-03T00:00:00.0000000' AS DateTime2), 1, N'0730746526', CAST(322.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (14, N'Natali', CAST(N'2000-01-03T00:00:00.0000000' AS DateTime2), 1, N'0730746526', CAST(322.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (15, N'Volodymyr', CAST(N'2000-04-14T00:00:00.0000000' AS DateTime2), 0, N'0730746528', CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Contacts] ([Id], [Name], [DateOfBirth], [Married], [Phone], [Salary]) VALUES (16, N'AAPL', CAST(N'2000-01-03T00:00:00.0000000' AS DateTime2), 1, N'0730746526', CAST(322.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
USE [master]
GO
ALTER DATABASE [ContactManagerDb] SET  READ_WRITE 
GO
