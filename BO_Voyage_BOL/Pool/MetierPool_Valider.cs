using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_Voyage_DTO;
using BO_Voyage_DAL;

namespace BO_Voyage_BOL
{
    public partial class MetierPool
    {
        //------------------------------------------------------------------/Valider//-------------------------------------------------------------

        //public static IEnumerable<dtoListeVoyage> GetListesVoyages()
        //{
        //    return admin.GetListesVoyages();
        //}

        public static long VerifLogin(string identifiant, string motDePasse)
        {
            return Secure.Verifie(identifiant, motDePasse);
        }

        public static bool Valider(string identifiant, string motDePasse)
        {
            return admin.Valider(identifiant, motDePasse);
        }
        public static void UpdateClients(DtoPersonne Dtoclient)
        {
            admin.UpdateClients(Dtoclient);
        }   
        public static void RemoveVoyageur(long Id)
        {
            admin.RemoveVoyageur(Id);
        }
        public static void UpdateVoyageur(DtoPersonne DtoVoyageur)
        {
            admin.UpdateVoyageur(DtoVoyageur);
        }
        public static void UpdateDossier(DtoDossier Dtodossier)
        {
            admin.UpdateDossier(Dtodossier);
        }
   
        public static void AddClients(DtoPersonne client)
        {
            admin.AddClients(client);
        }

        public List<DtoPersonne> GetVoyageurs(long IdDossier)
        {
           return Data.GetVoyageurs( IdDossier);
        }
        public DtoPersonne GetVoyageur(long Id)
        {
            return Data.GetVoyageur(Id);
        }
        public static void AddVoyageur(DtoPersonne voy,long IdDossier)
        {
             admin.AddVoyageur(voy, IdDossier);
        }
        public static double ComputePrice(int idVoyageur  )
        {
          return  admin.ComputePrice(idVoyageur);
        }

        public DtoAcceptVoyajeurs Compute_Price(DtoAcceptVoyajeurs Acceptation, bool valid = false)
        {           
            DtoDossier Dss = GetDossierClient(Acceptation.Id);
            var voyageurs = GetVoyageurs(Acceptation.Id);
            var Voyage = MetierPool.GetVoyage(Dss.Voyage);
            double Prix = 0;
            foreach (var elm in voyageurs)
            {
                Prix += MetierPool.ComputePrice((int)elm.Id);
            }
            Dss.Etat = 2;
            Acceptation.Prix = Prix;
            Acceptation.NbVoyageurs = voyageurs.Count;
            Acceptation.DecriptionVoyage = Voyage.Description;
            DtoPersonne Client = MetierPool.GetClient(Dss.Client);
            Client.prix = Prix;

            //Efectuer le payement et soustraire le nombre de places au ores du fournisseure
            if (valid)
            {
                MetierPool.UpdateClients(Client);
                MetierPool.UpdateDossier(Dss);
            }
            return Acceptation;

        }

        public static decimal AddVoyageurs(List<DtoPersonne> listeVoyageurs, DtoPersonne client, dtoCb CB, long prix, long Pvoyage)
        {
            return admin.AddVoyageurs(listeVoyageurs, client, CB, prix, Pvoyage);
        }

        public static DtoPersonne GetClient(string identifiant, string motDePasse)
        {
            return admin.GetClient(identifiant, motDePasse);
        }

        public static DtoPersonne GetClient( long Id)
        {
            return admin.GetClient( Id);
        }

   

        public static void Test()
        {
            admin.GetClient("MUTA26", "RXPJ36");//'MUTA26','RXPJ36',60,100
        }

        public static DtoDossier GetDossier(string identifiant, string motDePasse)
        {
            return admin.GetDossier(identifiant, motDePasse);
        }

         public static dtoCb GetCb(string identifiant, string motDePasse)
        {
            return admin.GetCb(identifiant, motDePasse);
        }
        public static dtoCb GetCb(long IdCB)
        {
            return admin.GetCb(IdCB);
        }
        public static dtoVoyage GetVoyage(long IdVoyage)
        {
            return admin.GetVoyage(IdVoyage);
        }
        public static decimal GetPrice(string identifiant, string motDePasse, int age, decimal taux)
        {
            return admin.GetPrice(identifiant, motDePasse, age, taux);

        }
       
        public DtoDossier GetDossier(long IdDossier)
        {

            return Data.GetDossier(IdDossier);
        }
        public DtoDossier GetDossierClient(long IdDossier)
        {

            return Data.GetDossierClient(IdDossier);
        }
        public void RemoveDossier(long idDossier)
        {

             Data.RemoveDossier(idDossier);
        }
            
        public List<DtoDossier> GetDossiersClient(long idClient)
        {
         return Data.GetDossiersClient( idClient);

        }
    }
}
