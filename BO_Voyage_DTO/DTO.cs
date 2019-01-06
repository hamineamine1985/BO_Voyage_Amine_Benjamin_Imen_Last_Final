using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_Voyage_DTO
{

    public class DtoAcceptVoyajeurs
    {
        public int Id { get; set; }
        public int IdCli { get; set; }
        public Double Prix { get; set; }
        public long NbVoyageurs { get; set; }
        public string DecriptionVoyage { get; set; }
    }

    public class DtoDestination
    {
        public string Continent { get; set; }
        public int Dispo { get; set; }
        public string Pays { get; set; }
        public string Régions { get; set; }
        public string Intitule { get; set; }
        public string Type { get; set; }//  public List<SelectListItem> Type { get; set; }
        public decimal Prix { get; set; }
        public string Photo { get; set; }
        public string Descriptif { get; set; }
        public DateTime Datedepart { get; set; }
        public DateTime DateRetour { get; set; }

    }
    public class DtoPersonne
    {
        public DtoPersonne()
        {
            IdDossier = -1;
            cibler = true;
        }
        public int MyProperty { get; set; }
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public long IdDossier { get; set; }
        

        public string Email { get; set; }
        public string Civilite { get; set; }
        public string Telephone { get; set; }
        public string Ville { get; set; }
        public string NumPasseport { get; set; }
        public double prix { get; set; }
        public long Client { get; set; }
        public DateTime DateNaissance { get; set; }

        public string motdepasse { get; set; }
        public string identifiant { get; set; }
        public bool cibler { get; set; }
    }

    public class dtoCb
    {
        public long Id { get; set; }
        public int Client { get; set; }
        public string Nom { get; set; }
        public string Num { get; set; }
        public DateTime CBDate { get; set; }
        public string Crypto { get; set; }

    }
    public class dtoListeVoyage
    {
        public long Id { get; set; }
        public string Nom { get; set; }// public string Libelle;  //   public int Dispo;  //     public long Region;
        public string Description { get; set; }
        public string Url { get; set; }
        public double Prix { get; set; }
        public DateTime DateDepart { get; set; }
        public DateTime DateRetour { get; set; }
    }

    public class dtoVoyage
    {
        public long Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }                 //On ne met pas décimal dans le cas où on aurait un prix trop élevé. 
        public long Region { get; set; }
        public long Dispo { get; set; }
        public DateTime DateDepart { get; set; }
        public DateTime DateRetour { get; set; }
    }

    public class DtoDossier//DtoOffreVoyage
    {
        public long Id { get; set; }
        public long Client { get; set; }
        public long Voyage { get; set; }
        public long Cb { get; set; }
    //    public int Places { get; set; }
        public string Email { get; set; }
        public decimal Prix{ get; set; }
        public int NbVoyageurValider { get; set; }
        public long NbVoyageur { get; set; }
        public int Etat { get; set; }
    }

    public class dtoListeContinent
    {

        public long Id { get; set; }
        public string Nom { get; set; }
    }
    public class dtoListeDossier
    {
        public string emailAdress { get; set; }
        public string numCarte { get; set; }
        public int NbVoyageur { get; set; }
        public string NomCarte { get; set; }
        public long IdVoyage { get; set; }
        public string Crypto { get; set; }   
        public DateTime Expiration { get; set; }
        public bool AssuranceRpatri { get; set; }
        public bool AssuranceAnnul { get; set; }

    }
    public class dtoListePays
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public long IdContinent { get; set; }
    }
    public class dtoListeRegion
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public long IdPays { get; set; }
    }
    public class dtoLieu
    {
        public int ContinentId { get; set; }
        public int PaysId { get; set; }
        public int RegionId { get; set; }
    }
    public class DtoAge
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }
    }
    public class DtoType
    {
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Mail { get; set; }
        public string Libelle { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }


    public class DtoCampaign
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

    }
    public class DtoMailing
    {
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Mail { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

    }

}
