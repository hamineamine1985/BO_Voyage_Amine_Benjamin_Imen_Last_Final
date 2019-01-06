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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici
     
            [OperationContract]
      //  bool CheckCb(string NumCb, string Crypto, string date);
        bool CheckCb(dtoCb cb);

        [OperationContract]
         bool DebiterCarte(dtoCb cb, double prix);

        [OperationContract]
        bool CheckDispo(int codeVoyage, int nbPlaces);


    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
           
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
           
        }
    }

    [DataContract]
    public class dtoCb
    {
        [DataMember]
        internal long Id { get; set; }
        [DataMember]
        internal int Client { get; set; }
        [DataMember]
        internal string Nom { get; set; }
        [DataMember]
        internal string Num { get; set; }
        [DataMember]
        internal DateTime CBDate { get; set; }
        [DataMember]
        internal string Crypto { get; set; }

    }

}
