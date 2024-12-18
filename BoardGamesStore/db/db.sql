USE [master]
GO
/****** Object:  Database [BoardGamesStore]    Script Date: 16.12.2024 20:10:58 ******/
CREATE DATABASE [BoardGamesStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BoardGamesStore', FILENAME = N'C:\Users\berte\BoardGamesStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BoardGamesStore_log', FILENAME = N'C:\Users\berte\BoardGamesStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BoardGamesStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BoardGamesStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BoardGamesStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BoardGamesStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BoardGamesStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BoardGamesStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BoardGamesStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BoardGamesStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BoardGamesStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BoardGamesStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BoardGamesStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BoardGamesStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BoardGamesStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BoardGamesStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BoardGamesStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BoardGamesStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BoardGamesStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BoardGamesStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BoardGamesStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BoardGamesStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BoardGamesStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BoardGamesStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BoardGamesStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BoardGamesStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BoardGamesStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BoardGamesStore] SET  MULTI_USER 
GO
ALTER DATABASE [BoardGamesStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BoardGamesStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BoardGamesStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BoardGamesStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BoardGamesStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BoardGamesStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BoardGamesStore] SET QUERY_STORE = OFF
GO
USE [BoardGamesStore]
GO
/****** Object:  Table [dbo].[ArtistGame]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistGame](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Artist] [int] NOT NULL,
	[Game] [int] NOT NULL,
 CONSTRAINT [PK_ArtistGame] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DesignerGame]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesignerGame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designer] [int] NOT NULL,
	[Game] [int] NOT NULL,
 CONSTRAINT [PK_DesignerGame] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designers]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Designer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[AgeRestriction] [int] NOT NULL,
	[MinPlayers] [int] NOT NULL,
	[MaxPlayers] [int] NOT NULL,
	[PlayTime] [int] NOT NULL,
	[Image] [nvarchar](100) NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenreGame]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenreGame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Genre] [int] NOT NULL,
	[Game] [int] NOT NULL,
 CONSTRAINT [PK_GenreGame] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublisherGame]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublisherGame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Publisher] [int] NOT NULL,
	[Game] [int] NOT NULL,
 CONSTRAINT [PK_PublisherGame] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.12.2024 20:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ArtistGame] ON 
GO
INSERT [dbo].[ArtistGame] ([id], [Artist], [Game]) VALUES (1, 1, 1)
GO
INSERT [dbo].[ArtistGame] ([id], [Artist], [Game]) VALUES (2, 2, 2)
GO
INSERT [dbo].[ArtistGame] ([id], [Artist], [Game]) VALUES (3, 3, 3)
GO
INSERT [dbo].[ArtistGame] ([id], [Artist], [Game]) VALUES (4, 4, 4)
GO
INSERT [dbo].[ArtistGame] ([id], [Artist], [Game]) VALUES (5, 5, 5)
GO
INSERT [dbo].[ArtistGame] ([id], [Artist], [Game]) VALUES (1014, 1, 4015)
GO
SET IDENTITY_INSERT [dbo].[ArtistGame] OFF
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 
GO
INSERT [dbo].[Artists] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (1, N'John', N'Doe', N'A.')
GO
INSERT [dbo].[Artists] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (2, N'Jane', N'Smith', NULL)
GO
INSERT [dbo].[Artists] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (3, N'Alex', N'Johnson', N'B.')
GO
INSERT [dbo].[Artists] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (4, N'Emily', N'Davis', NULL)
GO
INSERT [dbo].[Artists] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (5, N'Michael', N'Brown', N'C.')
GO
SET IDENTITY_INSERT [dbo].[Artists] OFF
GO
SET IDENTITY_INSERT [dbo].[DesignerGame] ON 
GO
INSERT [dbo].[DesignerGame] ([Id], [Designer], [Game]) VALUES (1, 4, 1)
GO
INSERT [dbo].[DesignerGame] ([Id], [Designer], [Game]) VALUES (2, 2, 2)
GO
INSERT [dbo].[DesignerGame] ([Id], [Designer], [Game]) VALUES (3, 3, 3)
GO
INSERT [dbo].[DesignerGame] ([Id], [Designer], [Game]) VALUES (4, 1, 4)
GO
INSERT [dbo].[DesignerGame] ([Id], [Designer], [Game]) VALUES (5, 5, 5)
GO
INSERT [dbo].[DesignerGame] ([Id], [Designer], [Game]) VALUES (1014, 1, 4015)
GO
SET IDENTITY_INSERT [dbo].[DesignerGame] OFF
GO
SET IDENTITY_INSERT [dbo].[Designers] ON 
GO
INSERT [dbo].[Designers] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (1, N'Reiner', N'Knizia', NULL)
GO
INSERT [dbo].[Designers] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (2, N'Alan', N'Moon', NULL)
GO
INSERT [dbo].[Designers] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (3, N'Uwe', N'Rosenberg', NULL)
GO
INSERT [dbo].[Designers] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (4, N'Klaus', N'Teuber', NULL)
GO
INSERT [dbo].[Designers] ([Id], [FirstName], [LastName], [Patronymic]) VALUES (5, N'Elizabeth', N'Hargrave', NULL)
GO
SET IDENTITY_INSERT [dbo].[Designers] OFF
GO
SET IDENTITY_INSERT [dbo].[Games] ON 
GO
INSERT [dbo].[Games] ([Id], [Title], [AgeRestriction], [MinPlayers], [MaxPlayers], [PlayTime], [Image], [Price]) VALUES (1, N'Catan', 12, 3, 4, 90, N'placeholder.jpg', CAST(39.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Games] ([Id], [Title], [AgeRestriction], [MinPlayers], [MaxPlayers], [PlayTime], [Image], [Price]) VALUES (2, N'Pandemic', 7, 2, 4, 45, N'placeholder.jpg', CAST(49.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Games] ([Id], [Title], [AgeRestriction], [MinPlayers], [MaxPlayers], [PlayTime], [Image], [Price]) VALUES (3, N'Ticket to Ride', 7, 2, 5, 60, N'placeholder.jpg', CAST(44.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Games] ([Id], [Title], [AgeRestriction], [MinPlayers], [MaxPlayers], [PlayTime], [Image], [Price]) VALUES (4, N'Codenames', 16, 2, 8, 15, N'placeholder.jpg', CAST(19.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Games] ([Id], [Title], [AgeRestriction], [MinPlayers], [MaxPlayers], [PlayTime], [Image], [Price]) VALUES (5, N'Gloomhaven', 16, 1, 4, 120, N'placeholder.jpg', CAST(89.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Games] ([Id], [Title], [AgeRestriction], [MinPlayers], [MaxPlayers], [PlayTime], [Image], [Price]) VALUES (4015, N'dfs', 7, 1, 10, 15, N'6386980763453888821048324939343724624.png', CAST(100.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[GenreGame] ON 
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (1, 1, 1)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (2, 7, 1)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (3, 1, 2)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (4, 3, 2)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (5, 2, 3)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (6, 7, 3)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (7, 2, 4)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (8, 4, 4)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (9, 1, 5)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (10, 5, 5)
GO
INSERT [dbo].[GenreGame] ([Id], [Genre], [Game]) VALUES (1019, 2, 4015)
GO
SET IDENTITY_INSERT [dbo].[GenreGame] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Strategy')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Family')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Cooperative')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Party')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Adventure')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (6, N'Card Game')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (7, N'Eurogame')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (8, N'Thematic')
GO
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[PublisherGame] ON 
GO
INSERT [dbo].[PublisherGame] ([Id], [Publisher], [Game]) VALUES (1, 7, 1)
GO
INSERT [dbo].[PublisherGame] ([Id], [Publisher], [Game]) VALUES (2, 2, 2)
GO
INSERT [dbo].[PublisherGame] ([Id], [Publisher], [Game]) VALUES (3, 3, 3)
GO
INSERT [dbo].[PublisherGame] ([Id], [Publisher], [Game]) VALUES (4, 3, 4)
GO
INSERT [dbo].[PublisherGame] ([Id], [Publisher], [Game]) VALUES (5, 3, 5)
GO
INSERT [dbo].[PublisherGame] ([Id], [Publisher], [Game]) VALUES (10, 1, 4015)
GO
SET IDENTITY_INSERT [dbo].[PublisherGame] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (1, N'Hasbro')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (2, N'Fantasy Flight Games')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (3, N'Asmodee')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (4, N'Wizards of the Coast')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (5, N'Rio Grande Games')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (6, N'IELLO')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (7, N'Catan Studio')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (8, N'Blue Orange Games')
GO
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Пользователь')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Администратор')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Менеджер')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Login], [Password], [Role], [FirstName], [LastName], [Patronymic]) VALUES (2, N'', N'', 2, N'Meow', N'MeowMeow', N'MeowMeowMeowMeow')
GO
INSERT [dbo].[Users] ([Id], [Login], [Password], [Role], [FirstName], [LastName], [Patronymic]) VALUES (3, N'1232', N'123', 3, N'1231', N'123', N'123')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[ArtistGame]  WITH CHECK ADD  CONSTRAINT [FK_ArtistGame_Artists] FOREIGN KEY([Artist])
REFERENCES [dbo].[Artists] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ArtistGame] CHECK CONSTRAINT [FK_ArtistGame_Artists]
GO
ALTER TABLE [dbo].[ArtistGame]  WITH CHECK ADD  CONSTRAINT [FK_ArtistGame_Games] FOREIGN KEY([Game])
REFERENCES [dbo].[Games] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ArtistGame] CHECK CONSTRAINT [FK_ArtistGame_Games]
GO
ALTER TABLE [dbo].[DesignerGame]  WITH CHECK ADD  CONSTRAINT [FK_DesignerGame_Designer] FOREIGN KEY([Designer])
REFERENCES [dbo].[Designers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DesignerGame] CHECK CONSTRAINT [FK_DesignerGame_Designer]
GO
ALTER TABLE [dbo].[DesignerGame]  WITH CHECK ADD  CONSTRAINT [FK_DesignerGame_Games] FOREIGN KEY([Game])
REFERENCES [dbo].[Games] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DesignerGame] CHECK CONSTRAINT [FK_DesignerGame_Games]
GO
ALTER TABLE [dbo].[GenreGame]  WITH CHECK ADD  CONSTRAINT [FK_GenreGame_Games] FOREIGN KEY([Game])
REFERENCES [dbo].[Games] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GenreGame] CHECK CONSTRAINT [FK_GenreGame_Games]
GO
ALTER TABLE [dbo].[GenreGame]  WITH CHECK ADD  CONSTRAINT [FK_GenreGame_Genres] FOREIGN KEY([Genre])
REFERENCES [dbo].[Genres] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GenreGame] CHECK CONSTRAINT [FK_GenreGame_Genres]
GO
ALTER TABLE [dbo].[PublisherGame]  WITH CHECK ADD  CONSTRAINT [FK_PublisherGame_Games] FOREIGN KEY([Game])
REFERENCES [dbo].[Games] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PublisherGame] CHECK CONSTRAINT [FK_PublisherGame_Games]
GO
ALTER TABLE [dbo].[PublisherGame]  WITH CHECK ADD  CONSTRAINT [FK_PublisherGame_Publishers] FOREIGN KEY([Publisher])
REFERENCES [dbo].[Publishers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PublisherGame] CHECK CONSTRAINT [FK_PublisherGame_Publishers]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [BoardGamesStore] SET  READ_WRITE 
GO
