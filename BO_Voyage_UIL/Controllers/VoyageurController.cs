using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO_Voyage_BOL;
using BO_Voyage_DTO;
using BO_Voyage_UIL.Models;

namespace BO_Voyage_UIL.Controllers
{
    public class VoyageurController : Controller
    {
        private MetierPool Metier = new MetierPool();
        // GET: Voyageur
        public ActionResult Index(DossierClientModels dossierR)
        {
            if (dossierR == null || dossierR.id == 0 || dossierR.idCli == 0)
                return RedirectToAction("Index","valider");

            List<DtoPersonne> ListPersonne = Metier.GetVoyageurs(dossierR.id);
            List<VoyageurModels> Voyageurs = new List<VoyageurModels>();
            foreach (var el in ListPersonne)
            {
                Voyageurs.Add(new VoyageurModels { Id = el.Id, Nom = el.Nom, Prenom = el.Prenom, DateNaissance = el.DateNaissance });
            }
            ViewVoyajeursModel Voys = new ViewVoyajeursModel();
            Voys.Voyageurs = Voyageurs;
            Voys.Ids = dossierR;
            DtoDossier Dss = Metier.GetDossierClient(dossierR.id);
            Voys.Etat = Dss.Etat;
            return View(Voys);
        }

        public ActionResult Create(DossierClientModels dossierR)
        {
            if (dossierR == null || dossierR.id == 0 || dossierR.idCli == 0)
                return View("");

            ViewVoyajeurModel voy = new ViewVoyajeurModel();
            voy.Voyageur = new VoyageurModels { DateNaissance = DateTime.Now };
            voy.Ids = dossierR;
            return View(voy);
        }

        [HttpPost]
        public ActionResult Create(ViewVoyajeurModel voy)//VoyageurModels voy)
        {
            if (voy.Ids == null || voy.Ids.id == 0 || voy.Ids.idCli == 0)
                return View("");
            var Ids = voy.Ids;
            // voy.Ids =(DossierClientModels) Ids;
            long IdDossier = voy.Ids.id;
            long IdClient = 0;
            AcceptVoyajeursModel Acceptation = new AcceptVoyajeursModel();

            DtoDossier Dss = Metier.GetDossierClient(IdDossier);
            if (Dss.NbVoyageurValider == Dss.NbVoyageur)
            {
                Dss.Etat = 1;
                Acceptation.Id = (int)IdDossier;
                Acceptation.IdCli = (int)Ids.idCli;
                Acceptation.NbVoyageurs = Dss.NbVoyageurValider;
                Acceptation.DecriptionVoyage = MetierPool.GetVoyage(Dss.Voyage).Description;
                return RedirectToAction("Accepte", Acceptation);
            }
            else if (Dss.NbVoyageurValider < Dss.NbVoyageur)
            {
                //  voy.Id = 0;
                DtoPersonne voyageur = new DtoPersonne { Nom = voy.Voyageur.Nom, Prenom = voy.Voyageur.Prenom, DateNaissance = voy.Voyageur.DateNaissance };
                MetierPool.AddVoyageur(voyageur, IdDossier);
                Dss.NbVoyageurValider = Dss.NbVoyageurValider + 1;

                if (Dss.NbVoyageurValider < Dss.NbVoyageur)
                {
                    MetierPool.UpdateDossier(Dss);
                    return RedirectToAction("Create", Ids);
                }
                else if (Dss.NbVoyageurValider == Dss.NbVoyageur)
                {
                    Dss.Etat = 1;
                }
                MetierPool.UpdateDossier(Dss);
            }

            return RedirectToAction("Index", Ids);//// ajouter Id Client et Id Dossier
        }

        //public AcceptVoyajeursModel Compute_Price(AcceptVoyajeursModel Acceptation,bool valid =false)
        //{
        //    DtoDossier Dss = Metier.GetDossierClient(Acceptation.Id);
        //    var voyageurs = Metier.GetVoyageurs(Acceptation.Id);
        //    var Voyage = MetierPool.GetVoyage(Dss.Voyage);
        //    double Prix = 0;
        //    foreach (var elm in voyageurs)
        //    {
        //        Prix += MetierPool.ComputePrice((int)elm.Id);
        //    }
        //    Dss.Etat = 2;
        //    Acceptation.Prix = Prix;
        //    Acceptation.NbVoyageurs = voyageurs.Count;
        //    Acceptation.DecriptionVoyage = Voyage.Description;
        //    DtoPersonne Client = MetierPool.GetClient(Dss.Client);
        //    Client.prix = Prix;

        //    //Efectuer le payement et soustraire le nombre de places au ores du fournisseure
        //    if (valid) { 
        //    MetierPool.UpdateClients(Client);
        //    MetierPool.UpdateDossier(Dss);
        //    }
        //    return Acceptation;

        //}

        public ActionResult Accepte(DossierClientModels dossierR)
        {         
            DtoAcceptVoyajeurs AcceptVoyajeurs = new DtoAcceptVoyajeurs { Id = dossierR.id, IdCli = dossierR.idCli };
            AcceptVoyajeurs= Metier. Compute_Price(AcceptVoyajeurs);
            AcceptVoyajeursModel Acceptation = new AcceptVoyajeursModel {  Id = AcceptVoyajeurs.Id, IdCli = AcceptVoyajeurs.IdCli ,NbVoyageurs= AcceptVoyajeurs .NbVoyageurs,Prix= AcceptVoyajeurs .Prix};
          //  Acceptation = Compute_Price(Acceptation);           
            //Page Validation de l'ajout
            return View(Acceptation);
        }
        [HttpPost]
        public ActionResult Accepte(AcceptVoyajeursModel Acceptation)
        {
           DtoDossier Dss = Metier.GetDossierClient(Acceptation.Id);         
            dtoCb CB=  MetierPool.GetCb(Dss.Cb);       
            ServiceReferenceBanqueFournisseur.Service1Client srv = new ServiceReferenceBanqueFournisseur.Service1Client();
            ServiceReferenceBanqueFournisseur.dtoCb cb = new ServiceReferenceBanqueFournisseur.dtoCb { Id = 1, Nom = CB.Nom, Crypto = CB.Crypto,  CBDate = CB.CBDate, Num = CB.Num  };
            bool res = srv.CheckCb(cb);

            if (res)
            {
            DtoAcceptVoyajeurs AcceptVoyajeurs = new DtoAcceptVoyajeurs { Id = Acceptation.Id, IdCli = Acceptation.IdCli, NbVoyageurs = Acceptation.NbVoyageurs, Prix = Acceptation.Prix };
            AcceptVoyajeurs = Metier.Compute_Price(AcceptVoyajeurs,true);
            Acceptation = new AcceptVoyajeursModel { Id = AcceptVoyajeurs.Id, IdCli = AcceptVoyajeurs.IdCli };
            return RedirectToAction("felicitation", Acceptation); // View(Acceptation)
            }
            else
            {
                return RedirectToAction("PayementRefuser", Acceptation); // View(Acceptation)
            }

          //  Acceptation = Compute_Price(Acceptation,true);
  ;
        }

        public ActionResult felicitation(AcceptVoyajeursModel Acceptation)
        {
      
            return  View(Acceptation);
        }
        public ActionResult PayementRefuser(AcceptVoyajeursModel Acceptation)
        {          
            return View();
        }

        public ActionResult Edit(DossierClientModels dossierR)
        {
            ViewVoyajeurModel VMvoy = new ViewVoyajeurModel();
            DtoPersonne voy= Metier.GetVoyageur(dossierR.idVoyageur);
            VoyageurModels Voyageur = new VoyageurModels { DateNaissance = voy.DateNaissance, Prenom = voy.Prenom,Nom=voy.Nom,Id= voy.Id };
            VMvoy.Voyageur = Voyageur;
            VMvoy.Ids = dossierR;
            return View(VMvoy);
        }
        [HttpPost]
        public ActionResult Edit(ViewVoyajeurModel Voy)
        {
            long IdDossier = Voy.Ids.id;
       //     DtoPersonne voy = Metier.GetVoyageur(dossierR.idVoyageur);
            DtoPersonne Voyageur = new DtoPersonne { Id = Voy.Voyageur.Id, Nom=  Voy.Voyageur.Nom,    Prenom=Voy.Voyageur.Prenom,DateNaissance=Voy.Voyageur.DateNaissance };
            MetierPool.UpdateVoyageur(Voyageur);
            return RedirectToAction("Index", Voy.Ids);// return View(Voy);
        }
        public ActionResult Delete(DossierClientModels dossierR)
        {
           ViewVoyajeurModel VMvoy = new ViewVoyajeurModel();
            DtoPersonne voy = Metier.GetVoyageur(dossierR.idVoyageur);
            VoyageurModels Voyageur = new VoyageurModels { DateNaissance = voy.DateNaissance, Prenom = voy.Prenom, Nom = voy.Nom, Id = voy.Id };
            VMvoy.Voyageur = Voyageur;
            VMvoy.Ids = dossierR;
            return View(VMvoy);
        }
        [HttpPost]
        public ActionResult Delete(ViewVoyajeurModel Voy)
        {
            long IdDossier = Voy.Ids.id;
            DtoDossier Dss = Metier.GetDossierClient(IdDossier);
            if(Dss.NbVoyageurValider > 0)
            {
             Dss.NbVoyageurValider = Dss.NbVoyageurValider - 1;
            }        
            Dss.Etat = 0;        
            MetierPool.RemoveVoyageur(Voy.Ids.idVoyageur);
            MetierPool.UpdateDossier(Dss);
           
            return RedirectToAction("Index", Voy. Ids);
        }
    }


    public class AcceptVoyajeursModel
    {
        public int Id { get; set; }
        public int IdCli { get; set; }
        public Double Prix { get; set; }
        public long NbVoyageurs { get; set; }
        public string DecriptionVoyage { get; set; }
    }

    public class ViewVoyajeurModel
    {
        public VoyageurModels Voyageur { get; set; }
        public DossierClientModels Ids { get; set; }

    }
    public class ViewVoyajeursModel
    {
        public List<VoyageurModels> Voyageurs { get; set; }
        //  public long Id { get; set; }
        public DossierClientModels Ids { get; set; }
        public int Etat { get; set; }
    }
}