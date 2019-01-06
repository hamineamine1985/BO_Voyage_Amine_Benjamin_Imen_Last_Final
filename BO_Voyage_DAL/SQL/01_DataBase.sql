USE [master]
GO
/*	.\sqlexpress	*/
/****** Object:  Database [BDD_BOVoyage_IBA]    Script Date: 10/11/2018 12:50:02 ******/
--CREATE DATABASE [BDD_BOVoyage_IBA]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'BDD_BOVoyage_IBA', FILENAME = N'E:\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BDD_BOVoyage_IBA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'BDD_BOVoyage_IBA_log', FILENAME = N'E:\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BDD_BOVoyage_IBA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO

--CREATE DATABASE [BDD_BOVoyage_IBA]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'BDD_BOVoyage_IBA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BDD_BOVoyage_IBA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'BDD_BOVoyage_IBA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BDD_BOVoyage_IBA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO

/****** Object:  Database [BDD_BOVoyage_IBA]    Script Date: 10/11/2018 12:50:02 ******/
CREATE DATABASE [BDD_BOVoyage_IBA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDD_BOVoyage_IBA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BDD_BOVoyage_IBA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDD_BOVoyage_IBA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BDD_BOVoyage_IBA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO



/****** Object:  Table [dbo].[Continent]    Script Date: 10/11/2018 12:50:34 ******/
USE [BDD_BOVoyage_IBA]
GO

CREATE TABLE [dbo].[Continent](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Pays]    Script Date: 10/11/2018 12:50:50 ******/

CREATE TABLE [dbo].[Pays](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](20) NULL,
	[IdContinent] [bigint] NOT NULL,
 CONSTRAINT [PK_Pays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pays]  WITH CHECK ADD  CONSTRAINT [FK_Pays_Continent] FOREIGN KEY([IdContinent])
REFERENCES [dbo].[Continent] ([Id])
GO

ALTER TABLE [dbo].[Pays] CHECK CONSTRAINT [FK_Pays_Continent]
GO

/****** Object:  Table [dbo].[Region]    Script Date: 10/11/2018 12:51:09 ******/

CREATE TABLE [dbo].[Region](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](20) NULL,
	[IdPays] [bigint] NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Region]  WITH CHECK ADD  CONSTRAINT [FK_Region_Pays] FOREIGN KEY([IdPays])
REFERENCES [dbo].[Pays] ([Id])
GO

ALTER TABLE [dbo].[Region] CHECK CONSTRAINT [FK_Region_Pays]
GO


/****** Object:  Table [dbo].[Voyage]    Script Date: 02/12/2018 11:23:03 ******/

CREATE TABLE [dbo].[Voyage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateDepart] [datetime2](7) NULL,
	[DateRetour] [datetime2](7) NULL,
	[Dispo] [bigint] NULL,
	[Prix] [float] NULL,
	[IdRegion] [bigint] NOT NULL,
	[Url] [nvarchar](max) NULL,
	[TypeVoyage] [nchar](10) NULL,
 CONSTRAINT [PK_Voyage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Voyage]  WITH CHECK ADD  CONSTRAINT [FK_Voyage_Region] FOREIGN KEY([IdRegion])
REFERENCES [dbo].[Region] ([Id])
GO

ALTER TABLE [dbo].[Voyage] CHECK CONSTRAINT [FK_Voyage_Region]
GO

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
CREATE VIEW RandChar
AS
SELECT RAND() AS Value
go

CREATE FUNCTION GenereId()
RETURNS char(6)
AS
BEGIN
	declare @alphabet varchar(26) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
	declare @nombre varchar(10) = '0123456789'
	declare @c1 char(1)
	declare @c2 char(1)
	declare @c3 char(1)
	declare @c4 char(1)
	declare @c5 char(1)
	declare @c6 char(1)
	select @c1= substring(@alphabet, convert(int, Value*25+1), 1) from RandChar
	select @c2= substring(@alphabet, convert(int, Value*25+1), 1) from RandChar
	select @c3= substring(@alphabet, convert(int, Value*25+1), 1) from RandChar
	select @c4= substring(@alphabet, convert(int, Value*25+1), 1) from RandChar
	select @c5 = substring(@nombre, convert(int, Value*9+1), 1) from RandChar
	select @c6 = substring(@nombre, convert(int, Value*9+1), 1) from RandChar
	RETURN  @c1+@c2+@c3+@c4+@c5+@c6
END
go

select dbo.GenereId()
go


---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------

/****** Object:  Table [dbo].[Client]    Script Date: 10/11/2018 12:52:10 ******/

CREATE TABLE [dbo].[Client](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Civilite] [nvarchar](5) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[DateNaissance] [date] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[NumCB] [char](16) NOT NULL,
	[Telephone] [char](10) NOT NULL,
	[motdepasse] [nchar](6) NULL,
	[identifiant] [nchar](16) NULL,
	[Prix] [money] NULL CONSTRAINT [DF_Client_Prix]  DEFAULT ((0)),
	[Ville] [nvarchar](50) NOT NULL,
	[AssuranceAnnul] [bit] NULL CONSTRAINT [DF_Client_AssuranceAnnul]  DEFAULT ((0)),
	[AssuranceRpatri] [bit] NULL CONSTRAINT [DF_Client_AssuranceRpatri_1]  DEFAULT ((0)),
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [DF_Client_motdepasse_1]  DEFAULT ([dbo].[GenereId]()) FOR [motdepasse]
GO

ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [DF_Client_identifiant_1]  DEFAULT ([dbo].[GenereId]()) FOR [identifiant]
GO
--ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [DF_Client_identifiant_1]  DEFAULT ([dbo].[GenereId]()) FOR [identifiant]
--GO


/****** Object:  Table [dbo].[CarteBancaire]    Script Date: 10/11/2018 12:52:37 ******/

CREATE TABLE [dbo].[CarteBancaire](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NomCB] [nvarchar](20) NOT NULL,
	[NumCB] [char](16) NOT NULL,
	[DateExpCB] [date] NOT NULL,
	[CryptoCB] [char](3) NOT NULL,	
 CONSTRAINT [PK_CarteBancaire] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [BDD_BOVoyage_IBA]
GO

/****** Object:  Table [dbo].[Dossier]    Script Date: 10/11/2018 12:52:52 ******/

CREATE TABLE [dbo].[Dossier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IdCB] [bigint] NULL,
	[NumCB] [char](16) NOT NULL,
	[NbVoyageur] [int] NOT NULL,
	[IdVoyage] [bigint] NULL,
	[IdClient] [bigint] NULL,
	[Etat] [int] NULL CONSTRAINT [DF_Dossier_Etat]  DEFAULT ((0)),
	[NbVoyageurValider] [int] NULL CONSTRAINT [DF_Dossier_NbVoyageurValider]  DEFAULT ((0)),
 CONSTRAINT [PK_Dossier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Dossier]  WITH CHECK ADD  CONSTRAINT [FK_Dossier_CarteBancaire] FOREIGN KEY([IdCB])
REFERENCES [dbo].[CarteBancaire] ([Id])
GO

ALTER TABLE [dbo].[Dossier] CHECK CONSTRAINT [FK_Dossier_CarteBancaire]
GO

ALTER TABLE [dbo].[Dossier]  WITH CHECK ADD  CONSTRAINT [FK_Dossier_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([Id])
GO

ALTER TABLE [dbo].[Dossier] CHECK CONSTRAINT [FK_Dossier_Client]
GO

ALTER TABLE [dbo].[Dossier]  WITH CHECK ADD  CONSTRAINT [FK_Dossier_Voyage] FOREIGN KEY([IdVoyage])
REFERENCES [dbo].[Voyage] ([Id])
GO

ALTER TABLE [dbo].[Dossier] CHECK CONSTRAINT [FK_Dossier_Voyage]
GO

USE [BDD_BOVoyage_IBA]
GO

/****** Object:  Table [dbo].[Voyageur]    Script Date: 10/11/2018 12:53:25 ******/

CREATE TABLE [dbo].[Voyageur](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](20) NOT NULL,
	[Prenom] [nvarchar](20) NOT NULL,
	[DateNaissance] [date] NOT NULL,
	[IdDossier] [bigint] NOT NULL,
 CONSTRAINT [PK_Voyageur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Voyageur]  WITH CHECK ADD  CONSTRAINT [FK_Voyageur_Dossier] FOREIGN KEY([IdDossier])
REFERENCES [dbo].[Dossier] ([Id])
GO

ALTER TABLE [dbo].[Voyageur] CHECK CONSTRAINT [FK_Voyageur_Dossier]
GO


/****** Object:  Table [dbo].[Campagne]    Script Date: 21/12/2018 16:39:15 ******/
CREATE TABLE [dbo].[Campagne](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](max) NOT NULL,
	[Description] [varchar](max) NOT NULL,
		[DateDeCreation] [datetime2](7) NULL,
	[DateDeLimite] [datetime2](7) NULL,
 CONSTRAINT [PK_Campagne] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[CampagneClient]    Script Date: 21/12/2018 16:40:29 ******/

CREATE TABLE [dbo].[CampagneClient](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCamp] [bigint] NOT NULL,
	[IdClient] [bigint] NOT NULL,
 CONSTRAINT [PK_Cible] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CampagneClient]  WITH CHECK ADD  CONSTRAINT [FK_Cible_Campagne] FOREIGN KEY([IdCamp])
REFERENCES [dbo].[Campagne] ([Id])
GO

ALTER TABLE [dbo].[CampagneClient] CHECK CONSTRAINT [FK_Cible_Campagne]
GO

ALTER TABLE [dbo].[CampagneClient]  WITH CHECK ADD  CONSTRAINT [FK_Cible_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([Id])
GO

ALTER TABLE [dbo].[CampagneClient] CHECK CONSTRAINT [FK_Cible_Client]
GO

--*********************

CREATE PROC GetListeContinent
AS
-- Liste des continents
SELECT
	c.*--c.Id, c.Nom
from 
	Continent c 
Go

--******************************

CREATE PROC GetListePays(@choixC int)
AS 
-- Liste des Pays en fonction du choix de continent
SELECT
	p.*--p.Id, p.Nom
FROM
	Pays p
	inner join Continent c on p.IdContinent = c.Id
WHERE 
	@choixC = c.Id
GO

--********************

CREATE PROC GetListeRegion(@choixP int, @choixC int)
AS 
-- Liste des régions en fonction du pays choisi
SELECT
	r.*-- r.Id, r.Nom
FROM
	Region r
	inner join Pays p on p.Id = r.IdPays
	inner join Continent c on c.Id = p.IdContinent
WHERE 
	(c.Id = @choixC) AND (p.Id = @choixP OR @choixP = 0)
GO


--*****************************

CREATE PROC GetListeVoyage(@choixC int, @choixP int, @choixR int)
AS 
-- Liste des voyages en fonction de la région choisie.
if @choixP = 0 set @choixR=0
SELECT
			v.*--	v.Id, v.Nom, v.Description
FROM
	Voyage v
	inner join Region r on r.Id = v.IdRegion
	inner join Pays p on p.Id = r.IdPays
	inner join Continent c on c.Id = p.IdContinent
WHERE	
	(@choixR = r.Id OR @choixR = 0) AND (@choixP = p.Id OR @choixP = 0) AND (@choixC = c.Id)

GO

--********************

--CREATE PROC [dbo].[EnregistreDossier](@IdVoyage bigint, @EmailClient nvarchar(50), @NumCBClient char(16), @NbVoyageur int)
--AS
---- Enregistrement d'un nouveau dossier
--BEGIN TRY
--	INSERT INTO 
--		Dossier(IdVoyage, Email, NumCB, NbVoyageur) values
--					(@IdVoyage, @EmailClient, @NumCBClient, @NbVoyageur)
--	SELECT @@IDENTITY AS 'Identity'
--END TRY

--BEGIN CATCH
--	SELECT 
--		0
--END CATCH
--GO

create PROC EnregistreDossier(@IdVoyage bigint, @EmailClient nvarchar(50), @NumCBClient char(16), @NbVoyageur int, @IdClient bigint, @IdCB bigint)
AS
-- Enregistrement d'un nouveau dossier
BEGIN TRY
	INSERT INTO 
		Dossier(IdVoyage, Email, NumCB, NbVoyageur,IdClient,IdCB) values
					(@IdVoyage, @EmailClient, @NumCBClient, @NbVoyageur, @IdClient , @IdCB )
	SELECT @@IDENTITY AS 'Identity'
END TRY

BEGIN CATCH
	SELECT 
		0
END CATCH
GO