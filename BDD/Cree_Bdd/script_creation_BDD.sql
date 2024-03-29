USE [master]
GO
/****** Object:  Database [asl]    Script Date: 24/05/2021 15:53:14 ******/
CREATE DATABASE [asl]

ALTER DATABASE [asl] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [asl].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [asl] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [asl] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [asl] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [asl] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [asl] SET ARITHABORT OFF 
GO
ALTER DATABASE [asl] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [asl] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [asl] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [asl] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [asl] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [asl] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [asl] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [asl] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [asl] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [asl] SET  DISABLE_BROKER 
GO
ALTER DATABASE [asl] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [asl] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [asl] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [asl] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [asl] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [asl] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [asl] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [asl] SET RECOVERY FULL 
GO
ALTER DATABASE [asl] SET  MULTI_USER 
GO
ALTER DATABASE [asl] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [asl] SET DB_CHAINING OFF 
GO
ALTER DATABASE [asl] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [asl] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [asl] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'asl', N'ON'
GO
ALTER DATABASE [asl] SET QUERY_STORE = OFF
GO
USE [asl]
GO
/****** Object:  Table [dbo].[atelier]    Script Date: 24/05/2021 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[atelier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[capacite] [int] NOT NULL,
	[id_participants] [int] NOT NULL,
 CONSTRAINT [atelier_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Date]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Date](
	[id] [int] NOT NULL,
	[date_debut] [datetime] NOT NULL,
	[date_fin] [datetime] NOT NULL,
 CONSTRAINT [Date_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipements]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[connexionReseauFilaire] [bit] NULL,
	[bar] [bit] NULL,
	[salonReception] [bit] NULL,
	[cabineEssayage] [bit] NULL,
	[nbrSiege] [varchar](5) NULL,
	[tablesFournis] [bit] NULL,
 CONSTRAINT [equipements_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[intervenir]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[intervenir](
	[email] [varchar](50) NOT NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [intervenir_PK] PRIMARY KEY CLUSTERED 
(
	[email] ASC,
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Intervention]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intervention](
	[email] [varchar](50) NOT NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [Intervention_PK] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[partenaires]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partenaires](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[typePartenaire] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participants]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participants](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenom] [varchar](50) NOT NULL,
	[adresse] [varchar](50) NOT NULL,
	[portable] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[nombre_Participation] [int] NOT NULL,
 CONSTRAINT [participants_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participer]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participer](
	[id] [int] NOT NULL,
	[id_atelier] [int] NOT NULL,
 CONSTRAINT [participer_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[id_atelier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posseder]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posseder](
	[id] [int] NOT NULL,
	[id_stands] [int] NOT NULL,
 CONSTRAINT [posseder_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[id_stands] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stands]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idAllee] [varchar](5) NULL,
	[idOrdre] [varchar](5) NULL,
	[equipement] [int] NOT NULL,
	[montantFacture] [varchar](5) NULL,
	[nom] [varchar](50) NOT NULL,
	[id_partenaires] [int] NULL,
	[surface] [int] NOT NULL,
 CONSTRAINT [stands_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[themes]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[themes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](350) NOT NULL,
	[id_atelier] [int] NOT NULL,
 CONSTRAINT [themes_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[typePartenaire]    Script Date: 24/05/2021 15:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[typePartenaire](
	[id] [int] NOT NULL,
	[nom] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[atelier]  WITH CHECK ADD  CONSTRAINT [atelier_participants_FK] FOREIGN KEY([id_participants])
REFERENCES [dbo].[participants] ([id])
GO
ALTER TABLE [dbo].[atelier] CHECK CONSTRAINT [atelier_participants_FK]
GO
ALTER TABLE [dbo].[Date]  WITH CHECK ADD  CONSTRAINT [Date_atelier_FK] FOREIGN KEY([id])
REFERENCES [dbo].[atelier] ([id])
GO
ALTER TABLE [dbo].[Date] CHECK CONSTRAINT [Date_atelier_FK]
GO
ALTER TABLE [dbo].[intervenir]  WITH CHECK ADD  CONSTRAINT [intervenir_Intervention_FK] FOREIGN KEY([email])
REFERENCES [dbo].[Intervention] ([email])
GO
ALTER TABLE [dbo].[intervenir] CHECK CONSTRAINT [intervenir_Intervention_FK]
GO
ALTER TABLE [dbo].[intervenir]  WITH CHECK ADD  CONSTRAINT [intervenir_participants0_FK] FOREIGN KEY([id])
REFERENCES [dbo].[participants] ([id])
GO
ALTER TABLE [dbo].[intervenir] CHECK CONSTRAINT [intervenir_participants0_FK]
GO
ALTER TABLE [dbo].[Intervention]  WITH CHECK ADD  CONSTRAINT [Intervention_Date_FK] FOREIGN KEY([id])
REFERENCES [dbo].[Date] ([id])
GO
ALTER TABLE [dbo].[Intervention] CHECK CONSTRAINT [Intervention_Date_FK]
GO
ALTER TABLE [dbo].[partenaires]  WITH CHECK ADD FOREIGN KEY([typePartenaire])
REFERENCES [dbo].[typePartenaire] ([id])
GO
ALTER TABLE [dbo].[participer]  WITH CHECK ADD  CONSTRAINT [participer_atelier0_FK] FOREIGN KEY([id_atelier])
REFERENCES [dbo].[atelier] ([id])
GO
ALTER TABLE [dbo].[participer] CHECK CONSTRAINT [participer_atelier0_FK]
GO
ALTER TABLE [dbo].[participer]  WITH CHECK ADD  CONSTRAINT [participer_participants_FK] FOREIGN KEY([id])
REFERENCES [dbo].[participants] ([id])
GO
ALTER TABLE [dbo].[participer] CHECK CONSTRAINT [participer_participants_FK]
GO
ALTER TABLE [dbo].[posseder]  WITH CHECK ADD  CONSTRAINT [posseder_equipements_FK] FOREIGN KEY([id])
REFERENCES [dbo].[equipements] ([id])
GO
ALTER TABLE [dbo].[posseder] CHECK CONSTRAINT [posseder_equipements_FK]
GO
ALTER TABLE [dbo].[posseder]  WITH CHECK ADD  CONSTRAINT [posseder_stands0_FK] FOREIGN KEY([id_stands])
REFERENCES [dbo].[stands] ([id])
GO
ALTER TABLE [dbo].[posseder] CHECK CONSTRAINT [posseder_stands0_FK]
GO
ALTER TABLE [dbo].[themes]  WITH CHECK ADD  CONSTRAINT [themes_atelier_FK] FOREIGN KEY([id_atelier])
REFERENCES [dbo].[atelier] ([id])
GO
ALTER TABLE [dbo].[themes] CHECK CONSTRAINT [themes_atelier_FK]
GO
USE [master]
GO
ALTER DATABASE [asl] SET  READ_WRITE 
GO
