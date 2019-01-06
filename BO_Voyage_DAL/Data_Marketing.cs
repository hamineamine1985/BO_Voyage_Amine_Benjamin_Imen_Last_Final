using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_Voyage_DTO;
namespace BO_Voyage_DAL
{
    public partial class DataPool
    {
        public context_Bo_express BoVContext = new context_Bo_express();        // new BOVoyageContext();  //context_Bo_express
   //------------------------------------------------------------------/Marketing//-------------------------------------------------------------
                                                               
        public string EnregistreDossier(long choixV, dtoListeDossier dossier)
        {
            Client cli = null;
            using (var BoVContext = new context_Bo_express())
            {
            dossier.numCarte = dossier.numCarte.Replace(" ", "");
            dossier.emailAdress = dossier.emailAdress.Trim();
            CarteBancaire CB = new CarteBancaire { NumCB = dossier.numCarte, NomCB = dossier.NomCarte, CryptoCB = dossier.Crypto, DateExpCB = dossier.Expiration };
            BoVContext.CarteBancaires.Add(CB);

            var res = BoVContext.Clients.Where(c => c.Email.CompareTo(dossier.emailAdress) == 0).ToList();
               
                if(res != null)
                     cli= res.FirstOrDefault();
            //decimal? resultat = 0;
            long IdCli = 0;

            var pass=    GeneratePassword(2,2,1,1);
            var L_motdepasse =    BoVContext.Sp_GenereId().ToList().FirstOrDefault().Trim();
             var  L_identifiant = BoVContext.Sp_GenereId().ToList().FirstOrDefault().Trim();
            if (cli== null){
                cli = BoVContext.Clients.Add(new Client {   Nom = "", Prenom="",Email=dossier.emailAdress,NumCB=dossier.numCarte,Civilite="",DateNaissance=DateTime.Now ,Telephone="06xxxxxxxx",Ville="" ,motdepasse= L_motdepasse, identifiant= L_identifiant, Prix=0, AssuranceRpatri= dossier.AssuranceRpatri, AssuranceAnnul= dossier .AssuranceAnnul});               
            }

             BoVContext.SaveChanges();
             IdCli = cli.Id;
          var  resultat = BoVContext.EnregistreDossier(choixV, dossier.emailAdress, dossier.numCarte, dossier.NbVoyageur, IdCli, CB.Id);
          //  BoVContext.SaveChanges();
            }

      
            
            return cli.motdepasse;
        }
        public IEnumerable<DtoAge> GetListesAge() // Procédure Stockée pour la liste des clients/voyageurs majeurs
        {
            var res = BoVContext.Voyageurs.Select(v => new DtoAge
            {
                Id=v.Id,
                Prenom=v.Prenom,Nom=v.Nom,
              Age=  DateTime.Now.Year - v.DateNaissance.Year
            }).OrderBy(v=>v.Age).ToList();
            return res;
        }

        public IEnumerable<dtoListeRegion> GetListesRegions(long choix) // Procédure Stockée pour la liste de clients/voyageurs par région
        {
            var res = BoVContext.Regions.Where(r =>r.Id == choix) .Select(r=> new dtoListeRegion {Id=r.Id,Nom=r.Nom, IdPays  =r.IdPays}) .ToList();
            return res;
        }

        public IEnumerable<DtoType> GetListesTypes(string choix) // Procédure Stockée pour la liste de clients/voyageurs par type de voyage
        {
            return null;
        }
        public IEnumerable<DtoMailing> GetDtoMailings() // Procédure Stockée pour l'opération Mailing (client ayant déjà effectué ce type de voyage)
        {
            return null;
        }
        public int EnregistreMailing(int IdClient)
        {

            return 0;
        }
        public void addCampaign(DtoCampaign cmp)
        {
         BoVContext.Campagnes.Add(new Campagne {Nom= cmp.Nom,Description= cmp.Description,DateDeCreation= cmp.DateDebut,DateDeLimite= cmp.DateFin });
            BoVContext.SaveChanges();
        }
        public void UpdateCampaign(DtoCampaign cmp)
        {
        Campagne Campg=    BoVContext.Campagnes.Where(c => c.Id == cmp.Id).ToList().FirstOrDefault();
            Campg.Nom = cmp.Nom; Campg.Description = cmp.Description; Campg.DateDeCreation = cmp.DateDebut; Campg.DateDeLimite = cmp.DateFin;
            BoVContext.SaveChanges();
        }

        public DtoCampaign GetCampaign(int Id)
        {
            var m = BoVContext.Campagnes.Where(c => c.Id == Id).ToList().FirstOrDefault();
            var camp= new DtoCampaign { Id = m.Id, Nom = m.Nom, Description = m.Description, DateDebut = m.DateDeCreation.Value, DateFin = m.DateDeLimite.Value };
            return camp;
        }
        public void DeleteCampaign(long Id)
        {
            var m = BoVContext.Campagnes.Where(c => c.Id == Id).ToList().FirstOrDefault();
            if(m!= null)
            {
                var Liste = BoVContext.CampagneClients.Where(c => c.IdCamp == Id);
                  BoVContext.CampagneClients.RemoveRange(Liste);
                BoVContext.Campagnes.Remove(m);
                BoVContext.SaveChanges();
            }
           
        }
        public IEnumerable<DtoCampaign> GetListeCampaign()
        {
            var ListCamp = BoVContext.Campagnes.Select(m=>new DtoCampaign { Id=m.Id,Nom=m.Nom,Description=m.Description,DateDebut=m.DateDeCreation.Value,DateFin=m.DateDeLimite.Value }).ToList();
            return ListCamp;
        }
        public List<DtoPersonne> Filtre(int AgeMin, int AgeMax, string typeVoayage, dtoLieu lieu)
        {
            //   var Liste=     GetListesAge().Where(a => a.Age <= AgeMax && a.Age >= AgeMin);
            List<DtoPersonne> Clients = new List<DtoPersonne>();
                  var Liste = BoVContext.Filtre(typeVoayage, lieu.ContinentId, lieu.PaysId, lieu.RegionId, AgeMin, AgeMax).ToList();
            foreach (var client in Liste)
            {
                Clients.Add( new DtoPersonne { Id = client.Id, Civilite = client.Civilite, DateNaissance = client.DateNaissance, Ville = client.Ville, Telephone = client.Telephone, Nom = client.Nom, Prenom = client.Prenom, identifiant = client.identifiant, motdepasse = client.motdepasse, Email = client.Email });
            }
            return Clients;


        }
        public IEnumerable<string> GetVoyageType()
        {
            //   var Liste=     GetListesAge().Where(a => a.Age <= AgeMax && a.Age >= AgeMin);
            var Liste = BoVContext.Sp_Get_Voyage_Type().ToList();// Filtre(typeVoayage, lieu.Continent.Id, lieu.Pays.Id, lieu.Region.Id, AgeMin, AgeMax).ToList();
            return Liste;
        }
        public int addVoyage(DtoDestination dest)
        {
            long IdPay=0, IdCont=0, IdReg = 0;

            var ContTmp = BoVContext.Continents.Where(c=>c.Nom.ToLower().CompareTo( dest.Continent.ToLower())==0).FirstOrDefault();
            if (ContTmp != null)
                IdCont = ContTmp.Id;
            var PayTmp = BoVContext.Pays.Where(c => c.Nom.ToLower().CompareTo(dest.Pays.ToLower()) == 0).FirstOrDefault();

            if (PayTmp != null)
                IdPay = PayTmp.Id;

            var RegTmp = BoVContext.Regions.Where(c => c.Nom.ToLower().CompareTo(dest.Régions.ToLower()) == 0).FirstOrDefault();
            if (RegTmp != null)
                IdReg = RegTmp.Id;
            if (IdCont != 0)
            {
                if (IdPay == 0) {
                    Pay PayNew = new Pay { Nom = dest.Pays, IdContinent = IdCont };
                    BoVContext.Pays.Add(PayNew);
                    BoVContext.SaveChanges();
                    IdPay = PayNew.Id;
                
                }
                if (IdReg == 0)
                {
                 Region Reg=   new Region { Nom = dest.Régions, IdPays = IdPay };
                    BoVContext.Regions.Add(Reg);
                    BoVContext.SaveChanges();
                    IdReg = Reg.Id;
                }
                double Price = Decimal.ToDouble(dest.Prix);


            Voyage voy = new Voyage {Dispo= dest.Dispo, Url=dest.Photo, Nom= dest.Intitule, IdRegion= IdReg, TypeVoyage = dest.Type,Description= dest.Descriptif,DateDepart= dest.Datedepart,DateRetour= dest.DateRetour,Prix= Price };
            BoVContext.Voyages.Add(voy);
            BoVContext.SaveChanges();
                return 1;
          }
            return 0;
        }
    }
}

