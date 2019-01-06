using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_Voyage_DTO;
using BO_Voyage_DAL;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BO_Voyage_BOL
{

    public static class Continent
    {
        private static DataPool Data = new DataPool();
        internal  static  IEnumerable<dtoListeContinent> GetListeContinent()
        {
            return Data.GetListeContinent();
        }
    }

    public static class Pays
    {
        private static  DataPool Data = new DataPool();
        public static IEnumerable<dtoListePays> GetListePays(int choixC)
        {
            return Data.GetListePays(choixC);
        }
    }

    public static class Region
    {
        private static DataPool Data = new DataPool();
        public static IEnumerable<dtoListeRegion> GetListeRegion(int choixP, int choixC)
        {
            return Data.GetListeRegion(choixP, choixC);
        }
    }

    public static class Voyage
    {
        private static DataPool Data = new DataPool();
        public static IEnumerable<dtoListeVoyage> GetListeVoyage(int choixC, int choixP, int choixR)
        {
            return Data.GetListeVoyage(choixC, choixP, choixR);
        }
        public static dtoListeVoyage GetVoyage(int IdVoy)
        {
            return Data.GetVoyage(IdVoy);
        }


    }

    public static class Dossier
    {
        private static DataPool Data = new DataPool();
        public static string EnregistreDossier(long choixV, dtoListeDossier dossier)
        {
            return Data.EnregistreDossier(choixV, dossier);
        }

        public static List<DtoDossier> GetDossiers()
        {
            return Data.GetDossiers();
        }

    }

    public  class RegexUtilities
    {
      private static DataPool Data = new DataPool();
      static  bool  invalid = false;

        public   bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;


            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;


            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private  string DomainMapper(Match match)
        {

            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}
