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
        //------------------------------------------------------------------/Valider//-------------------------------------------------------------


        public string GetMotDePasse(string identifiant)
        {
            var res = BoVContext.GetMotdepasse(identifiant).SingleOrDefault(); 

            return res;
        }

        public bool Valider(string identifiant, string motDePasse)
        {
            return false;
        }


        public void AddClients(DtoPersonne Dtoclient)
        {
            Client client = new Client { Id = Dtoclient.Id, identifiant = Dtoclient.identifiant, motdepasse = Dtoclient.motdepasse, Email = Dtoclient.Email, Nom = Dtoclient.Nom, Prenom = Dtoclient.Prenom, Civilite = Dtoclient.Civilite };
            BoVContext.Clients.Add(client);
            BoVContext.SaveChanges();
        }
        public  void UpdateVoyageur(DtoPersonne DtoVoyageur)
        {
            Voyageur voyageur = BoVContext.Voyageurs.Where(v => v.Id == DtoVoyageur.Id).ToList().FirstOrDefault();

            voyageur.Id = DtoVoyageur.Id;
           voyageur.Nom = DtoVoyageur.Nom;
            voyageur.Prenom = DtoVoyageur.Prenom;         
            BoVContext.SaveChanges();
        }
        public  void RemoveVoyageur(long Id)
        {
            Voyageur voyageur = BoVContext.Voyageurs.Where(v => v.Id == Id).ToList().FirstOrDefault();
            if (voyageur != null)
            {
                BoVContext.Voyageurs.Remove(voyageur);
                BoVContext.SaveChanges();
            }
               
        }
        public void UpdateClients(DtoPersonne Dtoclient)
        {
            Client client = BoVContext.Clients.Where(c => c.Id == Dtoclient.Id).ToList().FirstOrDefault();
            client.Id = Dtoclient.Id;
            client.identifiant = Dtoclient.identifiant;
            client.motdepasse = Dtoclient.motdepasse;
            client.Email = Dtoclient.Email;
            client.Nom = Dtoclient.Nom;
            client.Prenom = Dtoclient.Prenom;
            client.Civilite = Dtoclient.Civilite;
            client.Prix = (decimal)Dtoclient.prix;
            client.Ville = Dtoclient.Ville;
            BoVContext.SaveChanges();
        }


        public void AddVoyageur(DtoPersonne Voy, long P_IdDossier)
        {

            Voyageur voyageur = new Voyageur { IdDossier = P_IdDossier, Nom = Voy.Nom, Prenom = Voy.Prenom, DateNaissance = Voy.DateNaissance };
            BoVContext.Voyageurs.Add(voyageur);
            BoVContext.SaveChanges();
        }

        public List<DtoPersonne> GetVoyageurs(long IdDossier)
        {
            var ListeVoy = BoVContext.Voyageurs.Where(v => v.IdDossier == IdDossier).ToList();
            List<DtoPersonne> Voyageur = new List<DtoPersonne>();
            foreach (var Voy in ListeVoy)
            {
                Voyageur.Add(new DtoPersonne { Id = Voy.Id ,IdDossier = Voy.IdDossier, Nom = Voy.Nom, Prenom = Voy.Prenom, DateNaissance = Voy.DateNaissance });
            }
            return Voyageur;
        }
        public DtoPersonne GetVoyageur(long Id)
        {
            var Voy = BoVContext.Voyageurs.Where(v => v.Id == Id).ToList().FirstOrDefault(); ;
            DtoPersonne Voyageur;            
                 Voyageur =new DtoPersonne {  Id = Voy.Id, IdDossier = Voy.IdDossier, Nom = Voy.Nom, Prenom = Voy.Prenom, DateNaissance = Voy.DateNaissance };
          
            return Voyageur;
        }
        public double ComputePrice(int Id )
        {
            double price = 0;
            price = BoVContext.Sp_GetVoyageur_Price(Id, 13, 60).ToList().FirstOrDefault().Somme.Value;
             return   price;
        }
        public decimal AddVoyageurs(List<DtoPersonne> listeVoyageurs, DtoPersonne Dtoclient, dtoCb CB, long Prix, long Pvoyage)
        {
            Dossier dos;
            double price = 0;

            dos = new Dossier { IdVoyage = Pvoyage, IdClient = Dtoclient.Id, IdCB = CB.Id, NbVoyageur = listeVoyageurs.Count() };//   dos = new Dossier { IdVoyage = Pvoyage, IdClient = Dtoclient.Id, IdCB = CB.Id, NbVoyageur  = listeVoyageurs.Count(), Total = (int)Prix };
            BoVContext.SaveChanges();
            foreach (DtoPersonne elm in listeVoyageurs)
            {
                Voyageur voy = new Voyageur { Nom = elm.Nom, Prenom = elm.Prenom, DateNaissance = elm.DateNaissance, IdDossier = dos.Id };
                BoVContext.Voyageurs.Add(voy);
                //  BoVContext.SaveChanges();
                //  dos = new Dossier {  Voyageur = voy.Id, IdVoyage = Pvoyage,IdClient  = Dtoclient.Id, Cb = CB.Id,  Places = listeVoyageurs.Count(), Total = (int)Prix };
                //
                price += BoVContext.Sp_GetPrice(Dtoclient.identifiant, Dtoclient.motdepasse, 13, 60).ToList().FirstOrDefault().Somme.Value;
                BoVContext.Dossiers.Add(dos);
            }
            Dtoclient.prix = price;
            // Client client;// = new Client { Id = Dtoclient.Id, identifiant = Dtoclient.identifiant, motdepasse = Dtoclient.motdepasse, email = Dtoclient.Email, Nom = Dtoclient.Nom, Prenom = Dtoclient.Prenom, Civilite = Dtoclient.Civilite };
            //On a fait du link ici par manque de temps car j'etait Malade toute la journee
            /* client = Context.Clients.Where(c =>  c.Id == Dtoclient.Id).ToList().FirstOrDefault();
               client.Prix = price;  */
            // SetClient_Price(Dtoclient.Id, price);
            UpdateClients(Dtoclient);
            BoVContext.SaveChanges();

            return Convert.ToDecimal(price);
        }

        public void SetClient_Price(long Id, decimal price)
        {
            BoVContext.Sp_SetClient_Price(Id, price);
        }

        public double GetPrice(string identifiant, string motDePasse, int age, decimal taux)
        {
            var res = BoVContext.Sp_GetPrice(identifiant, motDePasse, age, taux).ToList().FirstOrDefault();
            return res.Somme.Value;
        }

        public DtoPersonne GetClient(string identifiant, string motDePasse)
        {
            //  Client client = Context.Clients.Where(c => c.identifiant.CompareTo(identifiant) == 0).FirstOrDefault();            //return  new DtoPersonne {Id= client.Id,Nom= client.Nom,Prenom= client.Prenom};
            var client = BoVContext.GetClient(identifiant, motDePasse).ToList().FirstOrDefault();
            if (client == null) return null;
            return new DtoPersonne { Id = client.Id,Civilite=client.Civilite, DateNaissance = client.DateNaissance, Ville = client.Ville, Telephone = client.Telephone, Nom = client.Nom, Prenom = client.Prenom, identifiant = client.identifiant, motdepasse = client.motdepasse, Email = client.Email };
        }
        public DtoPersonne GetClient_Email(string email, string motDePasse)
        {
            //  Client client = Context.Clients.Where(c => c.identifiant.CompareTo(identifiant) == 0).FirstOrDefault();            //return  new DtoPersonne {Id= client.Id,Nom= client.Nom,Prenom= client.Prenom};
            var client = BoVContext.GetClient_Email(email, motDePasse).ToList().FirstOrDefault();
            if (client == null) return null;
            return new DtoPersonne { Id = client.Id, Civilite = client.Civilite, DateNaissance = client.DateNaissance, Ville = client.Ville, Telephone = client.Telephone, Nom = client.Nom, Prenom = client.Prenom, identifiant = client.identifiant, motdepasse = client.motdepasse, Email = client.Email };
        }
        public  DtoPersonne GetClient(long Id)
        {
            var client = BoVContext.Clients.Where(c=>c.Id ==Id).ToList().FirstOrDefault();
            if (client == null) return null;
            return new DtoPersonne { Id = client.Id, Civilite = client.Civilite, DateNaissance =client.DateNaissance,Ville=client.Ville,Telephone=client.Telephone, Nom = client.Nom, Prenom = client.Prenom, identifiant = client.identifiant, motdepasse = client.motdepasse, Email = client.Email };

        }
        public DtoDossier GetDossierClient(long IdDossier)
        {
            //    dossier = Context.Dossiers.Where(d => d.Client==idClient).FirstOrDefault(); //   return new DtoDossier { Id = dossier.Id,Voyage= dossier.Voyage,Client = dossier.Client, Places = dossier.Places};
            var dossier = BoVContext.Sp_GetDossier(IdDossier).ToList().FirstOrDefault();

            
            if (dossier == null) return null;
            return new DtoDossier { Id = dossier.Id, Voyage = dossier.IdVoyage.Value, Email = dossier.Email, Etat = dossier.Etat.Value, Prix = dossier.Prix.Value, NbVoyageur = dossier.NbVoyageur, NbVoyageurValider = dossier.NbVoyageurValider.Value, Client = dossier.IdClient.Value, Cb = dossier.IdCB.Value };//    return new DtoDossier { Prix = dossier.Total.Value, Id = dossier.Id, Voyage = dossier.IdVoyage.Value, Client = dossier.IdClient.Value, Places = dossier.NbVoyageur,  Cb = dossier.IdCB.Value };
          

        }
        public DtoDossier GetDossier(long IdDossier)
        {
            var dossier = BoVContext.Dossiers.Where(c => c.Id == IdDossier).FirstOrDefault();
            if(dossier != null)
                return    new DtoDossier { Id = dossier.Id, Voyage = dossier.IdVoyage.Value, NbVoyageurValider = dossier.NbVoyageurValider.Value, Client = dossier.IdClient.Value, NbVoyageur = dossier.NbVoyageur, Cb = dossier.IdCB.Value, Etat = dossier.Etat.Value, Email = dossier.Email };
            return null;
        }
        public void RemoveDossier(long idDossier)
        {
            var DossTmp = BoVContext.Dossiers.Where(d => d.Id == idDossier).FirstOrDefault();
            if (DossTmp != null)
            {
                var VoyList = BoVContext.Voyageurs.Where(v => v.IdDossier == idDossier);
                BoVContext.Voyageurs.RemoveRange(VoyList);//  BoVContext.SaveChanges();
                BoVContext.Dossiers.Remove(DossTmp);
                BoVContext.SaveChanges();
            }
        }
        public void UpdateDossier(DtoDossier Dtodossier)
        {
            Dossier dossier = BoVContext.Dossiers.Where(d => d.Id == Dtodossier.Id).ToList().FirstOrDefault();

            dossier.Id = Dtodossier.Id;
            dossier.NbVoyageur = (int)Dtodossier.NbVoyageur;
            dossier.NbVoyageurValider = Dtodossier.NbVoyageurValider;
            dossier.Email = Dtodossier.Email;
            dossier.Etat = Dtodossier.Etat;
            dossier.IdVoyage = Dtodossier.Voyage;
            dossier.IdClient = Dtodossier.Client;
            dossier.IdCB = Dtodossier.Cb;


            BoVContext.SaveChanges();
        }

        public List<DtoDossier> GetDossiersClient(long idClient)
        {
            //    dossier = Context.Dossiers.Where(d => d.Client==idClient).FirstOrDefault(); //   return new DtoDossier { Id = dossier.Id,Voyage= dossier.Voyage,Client = dossier.Client, Places = dossier.Places};
            IEnumerable<Sp_GetDossier_ClientInfo_Result> dossiers;
            if (idClient == 0)
            {
                return GetDossiers();
            }
            else
            {

                dossiers = BoVContext.Sp_GetDossier_ClientInfo(idClient).ToList();
                //    else
                //  dossiers = BoVContext.Sp_GetDossier(idClient, 0).ToList();
            }
            List<DtoDossier> DtoDossiers = new List<DtoDossier>();
            foreach (var dossier in dossiers)
            {

                decimal Price = 0;
                if (dossier.Prix != null) Price = dossier.Prix.Value;
                DtoDossiers.Add(new DtoDossier { Id = dossier.Id, NbVoyageur = dossier.NbVoyageur, NbVoyageurValider = dossier.NbVoyageurValider.Value, Prix = Price, Email = dossier.Email, Etat = dossier.Etat.Value, Voyage = dossier.IdVoyage.Value, Client = dossier.IdClient.Value, Cb = dossier.IdCB.Value });
            }

            return DtoDossiers;
        }
        public List<DtoDossier> GetDossiers()
        {
            var dossiers = BoVContext.Dossiers.ToList();
            List<DtoDossier> DtoDossiers = new List<DtoDossier>();
            foreach (var dossier in dossiers)
            {

                DtoDossiers.Add(new DtoDossier { Id = dossier.Id, NbVoyageur = dossier.NbVoyageur, NbVoyageurValider = dossier.NbVoyageurValider.Value, Email = dossier.Email, Etat = dossier.Etat.Value, Voyage = dossier.IdVoyage.Value, Client = dossier.IdClient.Value, Cb = dossier.IdCB.Value });
            }

            return DtoDossiers;

        }

        public List<DtoDossier> GetDossier(string identifiant, string motDePasse)
        {
            DtoPersonne client;     //client = DataPool.GetClient(identifiant, motDePasse);            //return GetDossier(client.Id);
            List<DtoDossier> DtoDossiers = new List<DtoDossier>();
            var Dossiers = BoVContext.GetDossier(identifiant, motDePasse).ToList();
            foreach (var dossier in Dossiers)
            {
                DtoDossier dto;
                dto = new DtoDossier { Id = dossier.Id, Etat = dossier.Etat.Value, Voyage = dossier.IdVoyage.Value, Client = dossier.IdClient.Value, NbVoyageur = dossier.NbVoyageur };//    dto = new DtoDossier { Prix = dossier.Total.Value, Id = dossier.Id, Voyage = dossier.IdVoyage.Value, Client = dossier.IdClient.Value, Voyageur = dossier.Voyageur.Value, Places = dossier.NbVoyageur };

                DtoDossiers.Add(dto);


            }
            return DtoDossiers;
        }

        public dtoCb GetCb(long Idcb)
        {
            // slfdvle
            CarteBancaire cb = BoVContext.CarteBancaires.Where(b => b.Id == Idcb).FirstOrDefault();
            if (cb == null) return null;
            return new dtoCb { Id = cb.Id, Nom = cb.NomCB, Num = cb.NumCB, Crypto = cb.CryptoCB, CBDate = cb.DateExpCB };
        }

        public dtoVoyage GetVoyage(long idVoyage)
        {
            // var voy=   Context.Voyages.Where(v => v.Id == idVoyage).FirstOrDefault();
            var voy = BoVContext.Sp_GetVoyage(idVoyage).ToList().FirstOrDefault();
            return new dtoVoyage { Id = voy.Id, Dispo = voy.Dispo.Value, Description = voy.Description, Libelle = voy.Description, Prix = voy.Prix.Value, DateDepart = voy.DateDepart.Value, Region = voy.IdRegion, DateRetour = voy.DateRetour.Value };
        }
        //public dtoVoyage GetVoyageFromDossier(long idDossier)
        //{
        //    var dossier = BoVContext.Sp_GetDossier(idDossier, 1).ToList().FirstOrDefault();        //  DtoDossier dossier = GetDossier(idDossier);
        //    dtoVoyage voyage = GetVoyage((long)(dossier.IdVoyage));
        //    return voyage;
        //}
        public dtoCb GetCb(string identifiant, string motDePasse)
        {
            return GetCb(GetDossierClient(GetClient(identifiant, motDePasse).Id).Cb);
        }
    }
}
