Use [BDD_BOVoyage_IBA]
GO




create FUNCTION GetClient_Email
(	
	-- Add the parameters for the function here
	@Identifiant nvarchar(Max),@Password nvarchar(Max)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select * 
	from [dbo].[Client] c
	where c.Email=@Identifiant and c.motdepasse=@Password
)
GO


CREATE FUNCTION GetClient
(	
	-- Add the parameters for the function here
	@Identifiant nvarchar(Max),@Password nvarchar(Max)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select * 
	from [dbo].[Client] c
	where c.identifiant=@Identifiant and c.motdepasse=@Password
)
GO


select * from dbo.GetClient('SNSR85','WFDS62')
go

create FUNCTION GetDossier
(	
	-- Add the parameters for the function here
	@Identifiant nvarchar(Max),@Password nvarchar(Max)
)
RETURNS TABLE 
AS
RETURN 
(
	select d.*
	from [dbo].[Dossier] d inner join
		[dbo].[Client] c on c.Id =d.IdClient
	where c.identifiant=@Identifiant and c.motdepasse=@Password
)
GO
select * from dbo.GetDossier('SNSR85','WFDS62')
go
------------------------------------------------------------------------------------------------------------------------
create FUNCTION GetVoyageur_Price
(	
	-- Add the parameters for the function here
	@IdVoyageur int  ,@Age int, @Taux decimal
)
RETURNS TABLE 
AS
RETURN 
(
select   sum( (v.Prix *
			IIF( (year(GetDate()) - year(vg.DateNaissance)) < @Age, @Taux, 100.0) 	)/100	
				)   Somme  ,count (v.Id)  Nbr
	from [dbo].[Dossier] d inner join
			[dbo].[Client] c on c.Id =d.IdClient inner join
			[dbo].[Voyageur] vg on vg.IdDossier = d.Id  inner join
			dbo.Voyage v on v.Id = d.IdVoyage
	WHERE @IdVoyageur = vg.Id   -- c.identifiant=@Identifiant and c.motdepasse=@Password
	--group by d.Client
)
GO

select * from dbo.GetVoyageur_Price(1,41,10)
GO
-------------------------------------------------------------------------------

create FUNCTION GetPrice
(	
	-- Add the parameters for the function here
	@Identifiant nvarchar(Max),@Password nvarchar(Max)  ,@Age int, @Taux decimal
)
RETURNS TABLE 
AS
RETURN 
(
select   sum( (v.Prix *
			IIF( (year(GetDate()) - year(vg.DateNaissance)) < @Age, @Taux, 1.0) 	)/100	
				)   Somme  ,count (v.Id)  Nbr
	from [dbo].[Dossier] d inner join
			[dbo].[Client] c on c.Id =d.IdClient inner join
			[dbo].[Voyageur] vg on vg.IdDossier = d.Id  inner join
			dbo.Voyage v on v.Id = d.IdVoyage
	where c.identifiant=@Identifiant and c.motdepasse=@Password
	--group by d.Client
)
GO

select * from dbo.GetPrice('SNSR85','WFDS62',60,100)
go

--alter FUNCTION GetPrix
--(	
--	-- Add the parameters for the function here
--	@Identifiant nvarchar(Max),@Password nvarchar(Max)
--)
--RETURNS TABLE 
--AS
--RETURN 
--(
--	select   sum(v.Prix *  (year(GetDate()) - year(vg.DateNaissance)) )   Somme  ,count (v.Id)  Nbr
--	from [dbo].[Dossier] d inner join
--			[dbo].[Client] c on c.Id =d.Client inner join
--			[dbo].[Voyageur] vg on vg.Id = d.Voyageur  inner join
--			dbo.Voyage v on v.Id = d.Voyage
--	where c.identifiant=@Identifiant and c.motdepasse=@Password
--	--group by d.Client
--)
--GO

--select * from dbo.GetPrix('DWTK86','LAMS76')
--go
