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
    public class ReserverController : Controller
    {
        private MetierPool Metier = new MetierPool();
        // GET: Reserver

        public ActionResult Index()
        {
          List<dtoListeContinent> List= Metier.GetListesContinent().ToList();
          List<SelectListItem> Continents = new List<SelectListItem>(); 
            foreach (var item in List)
            {
                Continents.Add(new SelectListItem
                {
                    Text = item.Nom,
                    Value = item.Id.ToString()
                });              
          }
            return View(Continents);
        }

        public PartialViewResult Test()
        {
           
            return PartialView();
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
        [Route("Reserver/Regions/{IdP}/{IdC}")]
        public PartialViewResult Regions(int IdP,int IdC)
        {
            List<dtoListeRegion> List = Metier.GetListeRegion(IdP , IdC).ToList();
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
        [Route("Reserver/Voyages/{IdP}/{IdC}/{IdR}")]
        public PartialViewResult Voyages(int IdP, int IdC,int IdR)
        {
            List<dtoListeVoyage> List = Metier.GetListeVoyage(IdC,IdP,  IdR).ToList();
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
        [Route("Reserver/Voyage/{IdV}")]
        public PartialViewResult Voyage(int IdV)
        {
            if(IdV != 0)
            {
           dtoListeVoyage voy = Metier.GetListeVoyage(IdV);

            return PartialView(voy);
            }
            return PartialView("");

        }
        [Route("Reserver/Payement")]
        public PartialViewResult Payement()
        {
         return PartialView();
        }

        [HttpPost]
        [Route("Reserver/Save")]
        public bool Save( InfoDossier InfoD)
        {
            // InfoDossier InfoD = Newtonsoft.Json.JsonConvert.DeserializeObject<InfoDossier>(Str);
            dtoListeDossier dossier = new dtoListeDossier { emailAdress = InfoD.emailAdress, numCarte = InfoD.numCarte, NbVoyageur = InfoD.NbVoyageur };
            string password = Metier.EnregistreDossier(InfoD.choixV, dossier);
            return true;
        }
    }
    //public class InfoDossier
    //{      
    //    public string emailAdress { get; set; }
    //    public string numCarte { get; set; }
    //    public int NbVoyageur { get; set; }
    //    public string Expiration { get; set; }
    //    public int choixV { get; set; }

    //}
}