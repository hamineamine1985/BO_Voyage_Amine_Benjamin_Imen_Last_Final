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
        //------------------------------------------------------------------/Reserver//-------------------------------------------------------------

        public  IEnumerable<dtoListeContinent> GetListeContinent()
        {
            return Continent.GetListeContinent();
        }

        public  IEnumerable<dtoListePays> GetListePays(int choixC)
        {
            return Pays.GetListePays(choixC);
        }

        public  IEnumerable<dtoListeRegion> GetListeRegion(int choixP, int choixC)
        {
            return Region.GetListeRegion(choixP, choixC);
        }

        public  IEnumerable<dtoListeVoyage> GetListeVoyage(int choixC, int choixP, int choixR)
        {
            return Voyage.GetListeVoyage(choixC, choixP, choixR);
        }
        public  dtoListeVoyage GetListeVoyage(int IdVoy)
        {
            return Voyage.GetVoyage(IdVoy);
        }   

        public  string EnregistreDossier(long choixV, dtoListeDossier dossier)
        {
            return Dossier.EnregistreDossier(choixV, dossier);
        }

        public bool VerificationEmail(string emailAddress)
        {
            RegexUtilities util = new RegexUtilities();
            return util.IsValidEmail(emailAddress);
        }

    }
}
