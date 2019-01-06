using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO_Voyage_BOL;
using BO_Voyage_DTO;
using BO_Voyage_UIL.Models;
namespace BO_Voyage_UIL.Controllers
{
    [Authorize]
    public class MarketingController : Controller
    {
        private MetierPool Metier = new MetierPool();
        // GET: Marketing
        public ActionResult Index()
        {
            return View();
        }
        //____________________________________Destination____________________________________________________//

        public ActionResult NouvellesDestinations()
        {
            DestinationModels dest = new DestinationModels();


            return View(dest);

        }
        [HttpPost]
        public ActionResult NouvellesDestinations(DestinationModels dest)
        {
            var Type = Request.Form["Type"];
            int resultat = -1;
            DtoDestination Dest;
            if (Type != "")
            {
                Dest = new DtoDestination
                {
                    Continent = dest.Continent,
                    Pays = dest.Pays,
                    Intitule = dest.Intitule,
                    Prix = dest.Prix,
                    Photo = dest.Photo,
                    Descriptif = dest.Descriptif,
                    Datedepart = dest.Datedepart,
                    DateRetour = dest.DateRetour,
                    Régions = dest.Régions,
                    Dispo = dest.Dispo
                };             
                int index = int.Parse(Type);
                var lst = Metier.GetVoyageType().ToList();
                if (index >= 1 && index < lst.Count)
                {
                    string str = lst[index - 1];
                    Dest.Type = str;
                }
                resultat= Metier.addVoyage(Dest);
            }
            if(resultat == 1)
            {
                return RedirectToAction("VoyageAjouter");
            }
            else if(resultat == 0)
            {
                return RedirectToAction("Erreur_Continent");
            }

            return RedirectToAction("Index");
        }

        public ActionResult VoyageAjouter()
        {
            
            return View();
        }
        public ActionResult Erreur_Continent()
        {
          
            return View();
        }

        //____________________________________Dossier____________________________________________________//

        public ActionResult Listereservations()
        {
            List<DtoDossier> liste = MetierPool.GetDossiers();
            return View(liste);
        }
        [HttpPost]
        public ActionResult Listereservations(List<DtoDossier> dossiers)
        {
            return RedirectToAction("Index");

        }
        //_________________________________________________________________________________________________//
        //____________________________________Campagne____________________________________________________//

        public ActionResult CampagneMarketing()
        {
            List<DtoCampaign> Liste = Metier.GetListeCampaign().ToList();
            List<CampaignModels> ListCamp = new List<CampaignModels>();
            foreach (var elm in Liste)
            {
                ListCamp.Add(new CampaignModels { Id = elm.Id, Description = elm.Description, Nom = elm.Nom, DateCreation = elm.DateDebut, DateLimite = elm.DateFin });
            }
            //  ViewBag.Message = "Your Test";

            return View(ListCamp);
        }

        public ActionResult Create_CampagneMarketing()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create_CampagneMarketing(CampaignModels Camp)
        {  
      

            DtoCampaign Cmp = new DtoCampaign { Nom = Camp.Nom, DateDebut = DateTime.Now, Description = "Manifique", DateFin = Camp.DateLimite };

            Metier.addCampaign(Cmp);
            return View();
        }

        public ActionResult Edit_CampagneMarketing(int id)
        {
            if (id== 0)
                return RedirectToAction("Index");

            DtoCampaign Cmp = Metier.GetCampaign(id);
            CampaignModels CmpModel = new CampaignModels { Id = Cmp.Id, Nom = Cmp.Nom, Description = Cmp.Description, DateCreation = Cmp.DateDebut, DateLimite = Cmp.DateFin };
            return View(CmpModel);
        }

       [HttpPost]
        public ActionResult Edit_CampagneMarketing(CampaignModels Camp)
        {
            DtoCampaign Cmp = new DtoCampaign { Id = Camp.Id, Nom = Camp.Nom, DateDebut = Camp.DateCreation, Description = Camp.Description, DateFin = Camp.DateLimite };
            Metier.UpdateCampaign(Cmp);
            return RedirectToAction("CampagneMarketing");// return View();
        }

        public ActionResult Delete_CampagneMarketing(int id)
        {
            if (id== 0)
                return RedirectToAction("Index");
            DtoCampaign Cmp = Metier.GetCampaign(id);
            CampaignModels CmpModel = new CampaignModels { Id = Cmp.Id, Nom = Cmp.Nom, Description = Cmp.Description, DateCreation = Cmp.DateDebut, DateLimite = Cmp.DateFin };
            return View(CmpModel);
        }

        [HttpPost]
        public ActionResult Delete_CampagneMarketing(CampaignModels Camp)
        {
            if (!(Camp != null && Camp.Id != 0 ))
                return RedirectToAction("Index");
            Metier.DeleteCampaign(Camp.Id);
            return RedirectToAction("CampagneMarketing");
        }

        public ActionResult Detail_CampagneMarketing(int id=0)
        {
          
            if (id == 0)         
                return RedirectToAction("Index");
           
            ViewFiltreModel model = new ViewFiltreModel();//    model.GetAll();
            model.id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Detail_CampagneMarketing(ViewFiltreModel Filre)
        {
            var Continent = Request.Form["Continents"];
            var Pay =    Request.Form["Pays"];
            var Region = Request.Form["Regions"];
            var Type=   Request.Form["Type"];
            var TrancheAge =    Request.Form["TrancheAge"];      
            dtoLieu Lieu = new dtoLieu();
            ViewFiltreModel model = new ViewFiltreModel();
          TrancheAge tranche=  model.GetAge(int.Parse(TrancheAge));
            Lieu.ContinentId = int.Parse(Continent);
            Lieu.PaysId = int.Parse(Pay);
            Lieu.RegionId = int.Parse(Region);
            string VoyageType=     model.GetVoyageType(Type).Trim();
            //   return View(personnes);
            CibleCampagn camp = new CibleCampagn { VoyageType= VoyageType, AgeMax = tranche.AgeMax, AgeMin = tranche.AgeMin, ContinentId=  Lieu.ContinentId, PaysId= Lieu.PaysId, RegionId= Lieu.RegionId };
            camp.id = Filre.id;
            return RedirectToAction("Cible", camp);

        }
       
        public ActionResult Cible(CibleCampagn camp)
        {
            if(camp.ContinentId == 0)
                return RedirectToAction("Index");
            dtoLieu Lieu = new dtoLieu {ContinentId= camp.ContinentId,PaysId= camp.PaysId,RegionId= camp.RegionId };
            List<DtoPersonne> personnes = Metier.Filtre(camp.AgeMin, camp.AgeMax, camp. VoyageType, Lieu);
            ViewClientModel VclientModels = new ViewClientModel();
            VclientModels. clientModels =new List<ClientModels> ();
          foreach( var elm in personnes)
            {
                VclientModels.clientModels.Add(new ClientModels {Nom=elm.Nom,Prenom=elm.Prenom,Id=elm.Id,Email=elm.Email });
            }

            //ViewClientModel  avec un id
            VclientModels.id = camp.id;
            return View(VclientModels);
        }


 

        [HttpPost]
        public ActionResult Cible(List<ElementClientViewModel>  Ids)//      public ActionResult Cible(List<ClientModels> Clients)
        {

            int i = 0;
            //foreach (var elm in Clients)
            //{
            //   
            //}
            //var cibler=    Request.Form.GetValues("cibler");
            //   bool fait = bool.Parse(Request.Form.GetValues("cibler")[0]);
    

            foreach (var elm in Request.Form)
            {
                i++;
            }

            return RedirectToAction("Index", "Marketing");
        }




        public PartialViewResult Pays(int id)
        {
         

            List<dtoListePays> List = Metier.GetListePays(id).ToList();
            List<SelectListItem> Pays = new List<SelectListItem>();
            foreach (var item in List)
            {
                Pays.Add(new SelectListItem
                {
                    Text = item.Nom,
                    Value = item.Id.ToString()
                });
            }
            return PartialView(Pays);
        }
        [Route("Marketing/Regions/{IdP}/{IdC}")]
        public PartialViewResult Regions(int IdP, int IdC)
        {
            List<dtoListeRegion> List = Metier.GetListeRegion(IdP, IdC).ToList();
            List<SelectListItem> Regions = new List<SelectListItem>();
            foreach (var item in List)
            {
                Regions.Add(new SelectListItem
                {
                    Text = item.Nom,
                    Value = item.Id.ToString()
                });
            }
            return PartialView(Regions);
        }
        [Route("Marketing/Voyages/{IdP}/{IdC}/{IdR}")]
        public PartialViewResult Voyages(int IdP, int IdC, int IdR)
        {
            List<dtoListeVoyage> List = Metier.GetListeVoyage(IdC, IdP, IdR).ToList();
            List<SelectListItem> Voyages = new List<SelectListItem>();
            foreach (var item in List)
            {
                Voyages.Add(new SelectListItem
                {
                    Text = item.Nom,
                    Value = item.Id.ToString()
                });
            }
            return PartialView(Voyages);
        }
    }

  public class ElementClientViewModel
    {
      //  public bool cibler { get; set; }
         public int Id { get; set; }
    }
}