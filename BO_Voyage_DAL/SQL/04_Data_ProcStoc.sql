Use [BDD_BOVoyage_IBA]
GO
-- Procédure stockée Dossier à/p de l'IClient

create PROC Sp_GetDossier(@Id bigint)
AS

begin
SELECT d.*,c.Prix
FROM Dossier d inner join 
Client c on c.Id =  d.IdClient
WHERE d.Id=@Id
End
GO
exec Sp_GetDossier 1
GO

create PROC Sp_GetDossier_ClientInfo(@Id bigint)
AS
begin
SELECT d.*,c.Prix
FROM Dossier d inner join 
Client c on c.Id =  d.IdClient
WHERE d.IdClient=@Id
End
GO

exec Sp_GetDossier_ClientInfo 5
GO



create PROC Sp_GenereId
AS
begin
select dbo.GenereId()
End
GO

exec Sp_GenereId
go




--Procédure stockée retourne le voyage à/p de l'Id

CREATE PROC Sp_GetVoyage (@Id bigint)
AS
SELECT *
FROM Voyage
WHERE Id=@Id
Go


exec Sp_GetVoyage 1
go


--Procédure stockée retourne le voyage à/p de l'IdClient
create PROC Sp_GetVoyageClient (@IdClient bigint)
AS
SELECT v.*
FROM Voyage v inner join
Dossier D ON d.IdVoyage = v.Id inner join
Client c on c.Id = d.IdClient
WHERE c.Id=@IdClient
Go

exec Sp_GetVoyageClient 1
go

--Procédure stockée retourne le voyage à/p de l'IdClient
create PROC Sp_GetCb(@IdCb bigint)
AS
SELECT *  
FROM
[dbo].[CarteBancaire]
WHERE Id=@IdCb 
Go

exec Sp_GetCb 1
go


create PROC Sp_GetVoyageur_Price(@IdVoyageur int  ,@Age int, @Taux decimal)
AS
select * from dbo.GetVoyageur_Price(@IdVoyageur,@Age,@Taux)
GO

EXEC Sp_GetVoyageur_Price 1,56,60
go

create PROC Sp_GetPrice(@Identifiant nvarchar(Max),@Password nvarchar(Max)  ,@Age int, @Taux decimal)
AS

select * from dbo.GetPrice(@Identifiant,@Password,@Age,@Taux)

Go
-------------------------------------------------------------------------
exec Sp_GetPrice 'SNSR85','WFDS62',60,110
go



CREATE PROC Sp_SetClient_Price(@Id bigint, @Price decimal)
AS

UPDATE [dbo].[Client]     SET Prix = @Price
 WHERE Client.Id=@Id
GO

--create PROC Filtre(@TypeVoy nvarchar(Max), @idC bigint,@idP bigint,@idR bigint,@AgeMin int ,@AgeMax int)
--AS

--select c.*
--from [dbo].[Voyageur] voy inner join
--[dbo].[Dossier] d on d.id = voy.IdDossier inner join
-- [dbo].[Voyage] v on v.Id =d.IdVoyage inner join
--[dbo].[Region] r on r.id = v.IdRegion inner join
-- [dbo].[Pays] p on p.Id= r.IdPays inner join
--[dbo].[Continent] c on  c. Id=p.IdContinent
--  where v.TypeVoyage =@TypeVoy  and c.Id = @idC and p.Id = @idP and r.Id = @idR
--  and ( ( year(GetDate()) - year(voy.DateNaissance)) <= @AgeMax)
--   and ( ( year(GetDate()) - year(voy.DateNaissance)) >= @AgeMin)

--GO

--exec Sp_SetClient_Price 1 , 2000
create PROC Filtre(@TypeVoy nvarchar(Max), @idC bigint,@idP bigint,@idR bigint,@AgeMin int ,@AgeMax int)
AS

select cli.*
from [dbo].[Voyageur] voy inner join
[dbo].[Dossier] d on d.id = voy.IdDossier inner join
 [dbo].[Voyage] v on v.Id =d.IdVoyage inner join
[dbo].[Region] r on r.id = v.IdRegion inner join
 [dbo].[Pays] p on p.Id= r.IdPays inner join
[dbo].[Continent] c on  c. Id=p.IdContinent inner join 
[dbo].Client cli on cli.Id = d.IdClient
  where v.TypeVoyage =@TypeVoy  and c.Id = @idC and p.Id = @idP and r.Id = @idR
  and ( ( year(GetDate()) - year(cli.DateNaissance)) <= @AgeMax)
   and ( ( year(GetDate()) - year(cli.DateNaissance)) >= @AgeMin)
GO
exec Filtre 'Circuit',1,1,1,10,90
Go
exec Filtre 'Circuit',1,1,1,31,40
Go
CREATE PROCEDURE  Sp_Get_Voyage_Type
AS 
select distinct [dbo].[Voyage].TypeVoyage from [dbo].[Voyage]
GO

exec Sp_Get_Voyage_Type

go
--CREATE PROC GetMotdepasse(@id char(6))
--AS
--SELECT DISTINCT motdepasse from Client where identifiant=@Id
--GO

CREATE PROC GetMotdepasse(@id char(500))
AS
SELECT DISTINCT motdepasse from Client where Email=@Id
GO

exec GetMotdepasse 'schawohlbenji@gmail.com'
go
