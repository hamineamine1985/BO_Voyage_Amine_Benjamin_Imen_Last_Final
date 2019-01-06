using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
//using BO_Voyage_DTO;

namespace ASP_06_BANQUE_WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        //public bool CheckCb(string  NumCb,string Crypto,string date)
        //{

        //    Random Alea = new Random();
        //    //Si == 1, la carte bancaire est invalide / interdit bancaire. 
        //    if ((Alea.Next(1, 6) == 1))
        //        return false;
        //    else
        //        return true;
        //}
        public bool CheckCb(dtoCb cb)
        {

            Random Alea = new Random();
            //Si == 1, la carte bancaire est invalide / interdit bancaire. 
            if ((Alea.Next(1, 6) == 1))
                return false;
            else
                return true;
        }
        //On récupère le prix calculé que le client doit régler.
        public bool DebiterCarte(dtoCb cb, double prix)
        {
            return true;
        }
        public bool CheckDispo(int codeVoyage, int nbPlaces)
        {
            int i = ValiderPlaces();
            if (i > 0 && i > nbPlaces)
            {
                return true;
            }

            else
                return true;
        }

        public int ValiderPlaces()
        {
            Random Alea = new Random();
            int places = Alea.Next(1, 20);
            return places;
        }

    }  



}
