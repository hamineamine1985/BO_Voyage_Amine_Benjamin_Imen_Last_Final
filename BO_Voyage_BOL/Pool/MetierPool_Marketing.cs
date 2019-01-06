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
        private DataPool Data = new DataPool();
        private static Securite Secure = new Securite();
        private static Administration admin = new Administration();

        //------------------------------------------------------------------/Marketing//-------------------------------------------------------------
        public IEnumerable<dtoListeContinent> GetListesContinent() // Méthode pour la liste des continents
        {
            return Data.GetListeContinent();
        }

        public IEnumerable<DtoAge> GetListesAge() // Méthode pour la liste des continents 
        {
            return Data.GetListesAge();
        }

        public IEnumerable<dtoListeRegion> GetListesRegions(long choix) // Méthode pour la liste des régions
        {
            return Data.GetListesRegions(choix);
        }

        public IEnumerable<DtoType> GetListesTypes(string choix) // Méthode pour la liste des types de voyages
        {
            return Data.GetListesTypes(choix);
        }

        public IEnumerable<DtoMailing> GetDtoMailings() // Méthode pour campagne de Mailing
        {
            return Data.GetDtoMailings();
        }
        public int EnregistreMailing(int IdClient)
        {
            return Data.EnregistreMailing(IdClient);
        }
        public List<DtoPersonne> Filtre(int AgeMin,int AgeMax,string TypeVoayage,dtoLieu Lieu)
        {
           return Data.Filtre(AgeMin, AgeMax, TypeVoayage, Lieu);
        }
        public IEnumerable<DtoCampaign> GetListeCampaign()
        {

            return Data.GetListeCampaign();
        }
        public  void addCampaign(DtoCampaign cmp)
        {
            Data.addCampaign(cmp);
        }
        public void UpdateCampaign(DtoCampaign cmp)
        {
            Data.UpdateCampaign(cmp);
        }
        public DtoCampaign GetCampaign(int id)
        {
           return Data.GetCampaign(id);
        }
        public void DeleteCampaign(long id)
        {
             Data.DeleteCampaign(id);
        }
               

        public IEnumerable<string> GetVoyageType()
        {
            return Data.GetVoyageType();
        }
        public int addVoyage(DtoDestination dest)
        {
         return   Data.addVoyage(dest);
        }
        public static List<DtoDossier> GetDossiers()
        {
            return Dossier.GetDossiers();
        }
    }
   
}
