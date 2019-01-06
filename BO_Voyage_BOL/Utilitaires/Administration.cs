using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_Voyage_DTO;
using BO_Voyage_DAL;
namespace BO_Voyage_BOL
{
  public  class Administration
    {

        private DataPool Data = new DataPool();
        public  dtoCb GetCb(string identifiant, string motDePasse)
        {
            DtoPersonne client = Data.GetClient(identifiant, motDePasse);
            DtoDossier dossier = Data.GetDossierClient(client.Id);
            dtoCb CB = Data.GetCb(dossier.Cb);
            return CB;
        }
        public  dtoCb GetCb(long IdCB)
        {
           return Data.GetCb(IdCB);  
        }
        public  dtoVoyage GetVoyage(long IdVoyage)
        {
            return Data.GetVoyage(IdVoyage);
        }
        public  DtoDossier GetDossier(string identifiant, string motDePasse)
        {
            DtoPersonne client = Data.GetClient(identifiant, motDePasse);
            DtoDossier dossier = null;
            if (client != null)
            {
                dossier = Data.GetDossierClient(client.Id);
            }

            return dossier;
        }

        public  DtoPersonne GetClient(string identifiant, string motDePasse)
        {
            return Data.GetClient(identifiant, motDePasse);
        }
        public  DtoPersonne GetClient(long Id)
        {
            return Data.GetClient(Id);
        }
        public  void UpdateClients(DtoPersonne Dtoclient)
        {
            Data.UpdateClients(Dtoclient);
        }
        public  void RemoveVoyageur(long Id)
        {
            Data.RemoveVoyageur(Id);
        }
        public  void UpdateVoyageur(DtoPersonne DtoVoyageur)
        {
            Data.UpdateVoyageur(DtoVoyageur);
        }
        public  void UpdateDossier(DtoDossier Dtodossier)
        {
            Data.UpdateDossier(Dtodossier);
        }
        public  void AddClients(DtoPersonne client)
        {
            Data.AddClients(client);
        }

        public  decimal AddVoyageurs(List<DtoPersonne> listeVoyageurs, DtoPersonne client, dtoCb CB, long prix, long Pvoyage)
        {
            return Data.AddVoyageurs(listeVoyageurs, client, CB, prix, Pvoyage);
        }
        public  void AddVoyageur(DtoPersonne voy, long IdDossier)
        {
             Data.AddVoyageur(voy, IdDossier);
        }
        public  double ComputePrice(int id  )
        {
          return  Data.ComputePrice(id);
        }

        public  bool Valider(string identifiant, string motDePasse)
        {
            //Appel aux services Fournisseur et Bancaire pour les vérifications. 
            ServiceFournisseur fournisseur = new ServiceFournisseur();
            ServiceBancaire banque = new ServiceBancaire();
            dtoCb cb = Data.GetCb(identifiant, motDePasse);// GetCb(identifiant, motDePasse);
            List<DtoDossier> dossiers = Data.GetDossier(identifiant, motDePasse);
            DtoDossier dossier = dossiers.FirstOrDefault();
            dtoVoyage voyage = Data.GetVoyage(dossier.Id);


            if (banque.CheckCB(cb))
            {
                if (fournisseur.CheckDispo((int)voyage.Id,(int) dossier.NbVoyageur))
                {
                    return true;
                }
                else
                    return false;

            }
            return false;//true

            return Data.Valider(identifiant, motDePasse);
        }
        public  decimal GetPrice(string identifiant, string motDePasse, int age, decimal taux)
        {
            return Convert.ToDecimal(Data.GetPrice(identifiant, motDePasse, age, taux));

        }
     
    }
    public class Securite
    {
        private DataPool Data = new DataPool();
        public long Verifie(string Email, string motDePasse)
        {
            long Id = -1;
            if (motDePasse == Data.GetMotDePasse(Email).Trim())
            {
                Id = Data.GetClient_Email(Email, motDePasse).Id;
            }
           return Id;

           // return motDePasse == Data.GetMotDePasse(identifiant);
        }
    }
}
