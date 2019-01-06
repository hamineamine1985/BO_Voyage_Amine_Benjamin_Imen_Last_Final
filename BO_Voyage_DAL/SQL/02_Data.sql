Use [BDD_BOVoyage_IBA]
GO

/*Insert du contenu de la table Continent*/

insert into Continent (Nom) values ('Afrique')
insert into Continent (Nom) values ('Amérique')
insert into Continent (Nom) values ('Asie')
insert into Continent (Nom) values ('Europe')
insert into Continent (Nom) values ('Océanie')
Go
/*Insert du contenu de la table Pays*/

Insert into Pays (Nom,IdContinent) values ('Egypte',1)
Insert into Pays (Nom,IdContinent) values ('Kenya',1)
Insert into Pays (Nom,IdContinent) values ('Zambie',1)
Insert into Pays (Nom,IdContinent) values ('Canada',2)
Insert into Pays (Nom,IdContinent) values ('Etats-Unis',2)
Insert into Pays (Nom,IdContinent) values ('Pérou',2)
Insert into Pays (Nom,IdContinent) values ('Argentine',2)
Insert into Pays (Nom,IdContinent) values ('Japon',3)
Insert into Pays (Nom,IdContinent) values ('Thaïlande',3)
Insert into Pays (Nom,IdContinent) values ('Cambodge',3)
Insert into Pays (Nom,IdContinent) values ('Finlande',4)
Insert into Pays (Nom,IdContinent) values ('Norvège',4)
Insert into Pays (Nom,IdContinent) values ('Autriche',4)
Insert into Pays (Nom,IdContinent) values ('Irlande',4)
Insert into Pays (Nom,IdContinent) values ('Russie',4)
Insert into Pays (Nom,IdContinent) values ('Australie',5)
Insert into Pays (Nom,IdContinent) values ('Nouvelle-Zélande',5)
Insert into Pays (Nom,IdContinent) values ('Indonésie',5)
Go

/*Insert du contenu de la table Région*/

insert into Region (Nom, IdPays) values ('Vallée des Rois', 1)
insert into Region (Nom, IdPays) values ('Mont Kenya', 2)
insert into Region (Nom, IdPays) values ('Chutes Victoria',3)
insert into Region (Nom, IdPays) values ('Québec', 4)
insert into Region (Nom, IdPays) values ('Colombie-Britannique', 4)
insert into Region (Nom, IdPays) values ('Oregon', 5)
insert into Region (Nom, IdPays) values ('Louisiane', 5)
insert into Region (Nom, IdPays) values ('Machu Picchu',6)
insert into Region (Nom, IdPays) values ('Mesopotamie', 7)
insert into Region (Nom, IdPays) values ('Kyoto', 8)
insert into Region (Nom, IdPays) values ('Hokkaïdo', 8)
insert into Region (Nom, IdPays) values ('Ko Samui', 9)
insert into Region (Nom, IdPays) values ('Angkor',10)
insert into Region (Nom, IdPays) values ('Le Grand Nord',11)
insert into Region (Nom, IdPays) values ('Hardangerfjord',12)
insert into Region (Nom, IdPays) values ('Haute-Autriche', 13)
insert into Region (Nom, IdPays) values ('Comté de Kerry', 14)
insert into Region (Nom, IdPays) values ('Connemara', 14)
insert into Region (Nom, IdPays) values ('Saint-Petersbourg', 15)
insert into Region (Nom, IdPays) values ('Côte Est', 16)
insert into Region (Nom, IdPays) values ('Milford Sound', 17)
insert into Region (Nom, IdPays) values ('Ile de Bali', 18)
Go
/*Insert du contenu de la table Voyage*/

insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Circuit','La Vallée des Rois', 'A la découverte de la dernière demeure des Pharaons', CONVERT(datetime2(7),'01/03/2019',103), CONVERT(datetime2(7),'12/03/2019',103), 6, 1200, 1,'https://www.sciencesetavenir.fr/assets/img/2017/02/13/cover-r4x3w1000-58a1a1432fc53-WEB%20-%20Photo%20tombe%20Toutankhamon.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Circuit','Mount Kenya', 'Côtoyez les sommets enneigés du Kenya', CONVERT(datetime2(7),'15/02/2019',103), CONVERT(datetime2(7),'25/02/2019',103), 12, 1850.50, 2,'https://www.alibabuy.com/photos/library/1500/10295.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Circuit','Chutes Victoria', 'Allez à la découverte des plus belles chutes africaines', CONVERT(datetime2(7),'04/02/2019',103), CONVERT(datetime2(7),'22/02/2019',103), 13, 2050.50, 3,'https://c1.staticflickr.com/4/3500/3206163286_70f1f5cfac_b.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Circuit','Québec', 'Le Québec au naturel', CONVERT(datetime2(7),'02/03/2019',103), CONVERT(datetime2(7),'24/03/2019',103), 3, 2500, 4,'https://picturesmania.com/0-0/2574_quebec-can.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Circuit','Québec', 'Déambulez dans les ruelles enneigées de la ville de Québec', CONVERT(datetime2(7),'02/03/2019',103), CONVERT(datetime2(7),'24/03/2019',103), 3, 2600, 4,'https://happytowander.com/wp-content/uploads/Quebec-Happy-to-Wander-27.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Circuit','Colombie-Britannique', 'Les splendeurs légendaires de l Ouest Canadien', CONVERT(datetime2(7),'03/03/2019',103), CONVERT(datetime2(7),'23/03/2019',103), 8, 2399, 5,'https://img.ev.mu/images/attractions/8285/1605x642/810391.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Découverte','Oregon', 'Admirez les splendeurs des paysages de cet Etat sauvage', CONVERT(datetime2(7),'20/02/2019',103), CONVERT(datetime2(7),'17/03/2019',103), 5, 2850, 6,'http://res.cloudinary.com/sagacity/image/upload/c_crop,h_593,w_1000,x_0,y_0/c_scale,w_1080/v1405031172/Crater_Lake_Ami_Parikh_vhblht.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Découverte','Oregon', 'Portland, plages & terres volcaniques - Le grand tour d Oregon', CONVERT(datetime2(7),'13/02/2019',103), CONVERT(datetime2(7),'10/03/2019',103), 5, 2850, 6,'http://s1.1zoom.me/big0/812/353644-svetik.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Découverte','Louisiane', 'A la découverte des charmes de la Louisiane', CONVERT(datetime2(7),'29/01/2019',103), CONVERT(datetime2(7),'12/02/2019',103), 9, 1799, 7,'https://i.pinimg.com/originals/ce/fb/c0/cefbc0bce5f31e700688a54529c872d4.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Découverte','Machu Picchu', 'Découvrez les mystérieuses ruines du peuple Incas ', CONVERT(datetime2(7),'27/01/2019',103), CONVERT(datetime2(7),'10/02/2019',103), 7, 1999, 8,'https://www.amazingplaces.com/wp-content/uploads/2016/11/Machu-picchu-lama.jpg')



insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Familial','Mesopotamie', 'Découverte du Nord Argentin & de la Patagonie', CONVERT(datetime2(7),'15/01/2019',103), CONVERT(datetime2(7),'03/02/2019',103), 2, 2399, 9,'https://www.voyages-myterra.ch/fileadmin/_processed_/0/d/csm_argentine-fitzroy_01_855c569dd6.jpg')
insert into Voyage (TypeVoyage,Nom, [Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Découverte','Kyoto', 'Venez découvrir le Japon des traditions', CONVERT(datetime2(7),'25/03/2019',103), CONVERT(datetime2(7),'22/04/2019',103), 1, 3299.99, 10,'http://www.pointedumonde.com/wp-content/uploads/sites/7/2017/07/Kyoto-en-automne.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Découverte','Kyoto', 'Venez découvrir le Japon des traditions', CONVERT(datetime2(7),'30/03/2019',103), CONVERT(datetime2(7),'26/04/2019',103), 1, 3399.99, 10,'http://multianime.com.mx/wp-content/uploads/2016/09/wiqe.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Découverte','Hokkaido', 'Hokkaido, entre neige et volcans', CONVERT(datetime2(7),'20/01/2019',103), CONVERT(datetime2(7),'30/01/2019',103), 10, 2999, 11,'https://i.tween.pics/v1/https://www.explo.com/media/catalog/product/cache/1/thumbnail/9df78eab33525d08d6e5fb8d27136e95/v/o/voyage-japon-hokkaido-C552.png')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Farniente','Ko Samui', 'Le plaisir du farniente sur la plus belle plage du monde', CONVERT(datetime2(7),'05/02/2019',103), CONVERT(datetime2(7),'20/02/2019',103), 16, 2499, 12,'https://www.myholidayguru.co.uk/wp-content/uploads/2018/02/Tropisches-Meer-und-blauer-Himmel-in-Koh-Samui-Thailand-iStock-602322452.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Découverte','La cité d Angkor', 'Découvrez les splendeurs de cette cité mythique', CONVERT(datetime2(7),'01/02/2019',103), CONVERT(datetime2(7),'18/02/2019',103), 18, 2899, 13,'https://voyages.michelin.fr/sites/default/files/styles/poi_slideshow_big/public/images/travel_guide/NX-32943.jpg?itok=t30gACfc')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Familial','Le Grand Nord', 'Les charmes des espaces du Grand Nord', CONVERT(datetime2(7),'01/02/2019',103), CONVERT(datetime2(7),'18/02/2019',103), 18, 2899, 14,'https://img-4.linternaute.com/P6EvJHZF00iN5MtEXVqTksGekrM=/1240x/smart/9ed5bc87734c4d40accca96a1b370aa5/ccmcms-linternaute/10422438-20-merveilles-qui-vous-feront-aimer-la-finlande.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Circuit','Les Grands Fjords Norvégiens ', 'Admirez les splendeurs glaciaires de la nature', CONVERT(datetime2(7),'15/02/2019',103), CONVERT(datetime2(7),'25/01/2019',103), 12, 1499, 15,'http://www.mouvancevoyages.com/images/trips/large/a886918fc8d9b6921d8dbfc2b64024f3.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Farniente','Haute-Autriche', 'Cap sur le Tyrol et la Bavière', CONVERT(datetime2(7),'20/01/2019',103), CONVERT(datetime2(7),'28/01/2019',103), 25, 790, 16,'http://s1.1zoom.me/b5050/267/Austria_Houses_Mountains_510598_3840x2400.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Farniente','Comté de Kerry', 'Découvrez la beauté sauvage de de la côte irlandaise le long du Ring of Kerry', CONVERT(datetime2(7),'10/03/2019',103), CONVERT(datetime2(7),'18/03/2019',103), 40, 995, 17,'https://www.guide-irlande.com/wp-content/uploads/2016/07/anneau-kerry-2000x750.jpg')



insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Farniente','Connemara', 'Légende du Connemara', CONVERT(datetime2(7),'20/03/2019',103), CONVERT(datetime2(7),'31/03/2019',103), 30, 899, 18,'http://irelandsseafoodfestivals.com/wp-content/uploads/2016/11/051111CH041_1.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Farniente','Saint-Petersbourg', 'Sur les traces des tsars de Russie', CONVERT(datetime2(7),'04/03/2019',103), CONVERT(datetime2(7),'15/03/2019',103), 15, 1599.99, 19,'http://www.angelio.net/blogangelio/wp-content/uploads/2016/08/IALU-StPetersbourg.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Farniente','Saint-Petersbourg', 'Merveilles de la Russie impériale de Saint-Petersbourg à Moscou', CONVERT(datetime2(7),'10/03/2019',103), CONVERT(datetime2(7),'21/03/2019',103), 10, 1899.99, 19,'https://www.bourse-des-vols.com/commun/images/037-villes/russie/saint-petersbourg/saint-petersbourg-1920x536.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Familial','Côte Est', 'Les splendeurs de la Côte Est Australienne', CONVERT(datetime2(7),'20/01/2019',103), CONVERT(datetime2(7),'10/02/2019',103), 8, 3399, 20,'https://www.telegraph.co.uk/content/dam/Travel/Tours/australia%20beach-xlarge.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Familial','Milford Sound', 'Splendeurs de Nouvelle-Zélande', CONVERT(datetime2(7),'12/01/2019',103), CONVERT(datetime2(7),'03/02/2019',103), 2, 2899.99, 21,'http://alpineadventures.co.nz/wp-content/uploads/2017/07/milford.jpg')
insert into Voyage (TypeVoyage,Nom,[Description], DateDepart, DateRetour, Dispo, Prix, IdRegion,[Url]) values ('Farniente','Ile de Bali', 'Profitez du sable fin et chaud des belles plages indonésiennes', CONVERT(datetime2(7),'16/01/2019',103), CONVERT(datetime2(7),'02/02/2019',103), 5, 2999.99, 22,'http://s1.1zoom.me/big3/615/340888-svetik.jpg')
													 
Go
/*Insert du contenu de la table Client*/			 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mlle','Pham','Angèlique',convert(date, '06/08/1978', 103), 'phamcoucou@gmail.com', '1234123412341234', '1234567891', 'Annecy') 													 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mlle','Mandy','Angèlique',convert(date, '23/03/1986', 103), 'mandypimpon@hotmail.com', '4567456745674567', '4595875654', 'Rouen') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','Boutada','Khalil',convert(date, '06/01/1984', 103), 'boutadabouh@gmail.com','5678567856785678', '2136548957', 'Montpellier') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mme','Lalibi','Imen',convert(date, '26/02/1987', 103), 'lalibihellothere@gmail.com',  '8901890189018901','5456548565','Istanbul') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','Schawohl','Benjamin',convert(date, '09/01/1986', 103), 'schawohlbenji@gmail.com','9012901290129012', '2625487596', 'Lyon') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','Godereau','Clément',convert(date, '13/06/1986', 103), 'godreaukikou@gmail.com', '0123012301230123', '9575868123', 'Paris') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','Cosseron','Emmanuel',convert(date, '29/10/1979', 103), 'cosserontoto@gmail.com', '7890789078907890', '1254635875', 'Vienne') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','Gendouzi','Ahmed',convert(date, '14/02/1987', 103), 'gendouziguili@gmail.com','1244124412441244', '5637894268', 'Venise') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','Lagab','Hacene',convert(date, '22/11/1976', 103), 'lagabpouet@gmail.com', '1245124512451245', '6575698456', 'Lille') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','Alashkar','Ali',convert(date, '30/01/1984', 103), 'alashkarheyho@gmail.com','1247124712471247', '5987632147', 'Rouen') 
insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','Harkat','Amine',convert(date, '25/05/1985', 103), 'harkatmatcha@gmail.com','1248124812481248', '5987463214', 'Dieppe') 

insert into Client (Civilite, Nom, Prenom, DateNaissance, Email, NumCB, Telephone, Ville) values ('Mr','HARKAT','Amine',convert(date, '14/02/1985', 103), 'amine@gmail.com','1244124412441244', '5637894268', 'Paris') 
Go
/*Insert du contenu de la table CarteBancaire*/

Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Pham','1234123412341234', convert(date, '01/09/2019', 103),'236')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Pham','2345234523452345', convert(date, '01/10/2019', 103),'237')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Mandy','3456345634563456', convert(date, '01/11/2019', 103),'238')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Mandy','4567456745674567', convert(date,'01/12/2019', 103),'239')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Boutada','5678567856785678', convert(date, '01/01/2019', 103),'240')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Boutada','6789678967896789', convert(date, '01/02/2020', 103),'245')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Cosseron','7890789078907890', convert(date, '01/03/2020', 103),'250')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Lalibi','8901890189018901', convert(date, '01/04/2020', 103),'255')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Schawohl','9012901290129012', convert(date, '01/05/2020', 103),'260')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Godereau','0123012301230123', convert(date, '01/06/2020', 103),'265')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Guendouzi','1244124412441244', convert(date, '01/07/2020', 103),'270')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Lagab','1245124512451245', convert(date, '01/08/2020', 103),'275')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Lagab','1246124612461246', convert(date, '01/09/2020', 103),'280')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Alashkar','1247124712471247', convert(date, '01/10/2020', 103),'285')
Insert into CarteBancaire (NomCB, NumCB, DateExpCB, CryptoCB) values ('Harkat','1248124812481248', convert(date, '01/11/2020', 103),'290')
Go
/*Insert du contenu de la table Dossier*/

insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('phamcoucou@gmail.com', 1, '1234123412341234',     3, 15, 1,3,2)
insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('boutadabouh@gmail.com', 5, '5678567856785678',		2, 6, 3,2,2)
insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('cosserontoto@gmail.com', 7, '7890789078907890',   4, 4, 7,4,2)
insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('godreaukikou@gmail.com', 10, '0123012301230123',  5, 12, 6,5,2)
insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('lalibihellothere@gmail.com', 8, '8901890189018901',2, 5, 4,2,2)
insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('lagabpouet@gmail.com', 12, '1245124512451245',		1, 1, 9,1,2)
insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('lagabpouet@gmail.com', 13,'1246124612461246',	   2, 16, 9,2,2)
insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('mandypimpon@hotmail.com', 4, '4567456745674567',  2, 8, 2,2,2)
insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('schawob@hotmail.com', 4, '4567456745674567',		2, 3, 5,2,2)

insert into Dossier (Email, IdCB, NumCB, NbVoyageur, IdVoyage, IdClient,NbVoyageurValider,Etat) values ('amine@gmail.com', 12, '1245124512451245',		1, 1, 12,1,2)
Go
/*Insert du contenu de la table Voyageur*/

Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Pham','Angèlique',convert(date, '06/08/1978', 103),1)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Pham','Angel',convert(date, '23/07/1979', 103),1)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Pham','Marie',convert(date, '13/01/1980', 103),1)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Boutada','Khalil',convert(date, '06/01/1984', 103),2)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Boutada','Miriam', convert(date, '05/02/1988',103), 2)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Cosseron','Emmanuel',convert(date, '29/10/1979', 103),3)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Cosseron','Léa',convert(date, '13/11/1981', 103),3)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Cosseron','Théo',convert(date, '01/02/2013', 103),3)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Cosseron','Lukas',convert(date, '03/01/2016', 103),3)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Godereau','Clément',convert(date, '13/06/1986', 103),4)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Godereau','Julie',convert(date, '22/07/1987', 103),4)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Godereau','Pierre',convert(date, '06/03/1970', 103),4)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Godereau','Claris',convert(date, '05/08/1971', 103),4)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Godereau','Fanny',convert(date, '12/05/1977', 103),4)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Lalibi','Imen',convert(date, '26/02/1987', 103),5)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Lalibi','Cherif',convert(date, '05/07/1985', 103),5)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Lagab','Hacene',convert(date, '22/11/1976', 103),6)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Lagab','Hacene',convert(date, '22/11/1976', 103),7)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Boaleau','Pauline',convert(date, '13/12/1974', 103),7)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Ledieu','Kevin',convert(date, '31/01/1990', 103),8)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Ledieu','Jordan',convert(date, '25/12/1994', 103),8)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Schawohl','Benjamin',convert(date, '09/01/1986', 103),9)
Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Loison','Kevin',convert(date, '22/06/1987', 103),9)

Insert into Voyageur (Nom, Prenom, DateNaissance, IdDossier) values ('Manu','Manu',convert(date, '22/11/1970', 103),10)
Go


Insert into Campagne (Nom, [Description],[DateDeCreation],[DateDeLimite]) values ('Campagne','Super voyage aller sans retour',GetDate(),GetDate())
Insert into Campagne (Nom, [Description],[DateDeCreation],[DateDeLimite]) values ('Campagne1','Super voyage aller sans retour',GetDate(),GetDate())
Insert into Campagne (Nom, [Description],[DateDeCreation],[DateDeLimite]) values ('Campagne2','Super voyage aller sans retour',GetDate(),GetDate())
Go



Insert into CampagneClient (IdCamp, IdClient) values (1,1)
Insert into CampagneClient (IdCamp, IdClient) values (1,2)
Insert into CampagneClient (IdCamp, IdClient) values (2,3)
Insert into CampagneClient (IdCamp, IdClient) values (2,4)
Insert into CampagneClient (IdCamp, IdClient) values (3,5)
Insert into CampagneClient (IdCamp, IdClient) values (3,6)
Insert into CampagneClient (IdCamp, IdClient) values (1,7)
Insert into CampagneClient (IdCamp, IdClient) values (1,8)
Go