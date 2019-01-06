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
    public class ValiderController : Controller
    {
        private MetierPool Metier = new MetierPool();
        // GET: Valider
        public ActionResult Index(int id=0)
        {
            List<DtoDossier> liste = null;
            List<DossierModels> ListD = new List<DossierModels>(); 
            if (id == 0)
            {
                return View(ListD);
            }
             liste = Metier.GetDossiersClient(id);// Data.GetDossiersClient(idClient);           
            foreach (var el in liste)
            {
                ListD.Add(new DossierModels {Id= el.Id,Email=el.Email,Prix=el.Prix,Client = el.Client,Voyage=el.Voyage, NbVoyageur = el.NbVoyageur, NbVoyageurValider = el.NbVoyageurValider} );
            }
            return View(ListD);
        }
        //____________________________________Dossier____________________________________________________//

        public ActionResult Edit_Dossier(int id)
        {
            if(id==0)
                return RedirectToAction("Index");
            DtoDossier Dss = Metier.GetDossierClient(id);
            DossierModels dossier = new DossierModels { Id = Dss.Id, Email = Dss.Email, Prix = Dss.Prix, Client = Dss.Client, Voyage = Dss.Voyage, NbVoyageur = Dss.NbVoyageur, NbVoyageurValider = Dss.NbVoyageurValider };
            return View(dossier);
        }
        [HttpPost]
        public ActionResult Edit_Dossier(DossierModels dossiers)
        {
            return RedirectToAction("Index");

        }
        public ActionResult Delete_Dossier(DossierClientModels dossierR)
        {
            if( !( dossierR != null && dossierR.id!=0 && dossierR.idCli!=0))
                return RedirectToAction("Index");


            DtoDossier Dss = Metier.GetDossierClient(dossierR.idCli);
            DossierModels dossier = new DossierModels { Id = Dss.Id, Email = Dss.Email, Prix = Dss.Prix, Client = Dss.Client, Voyage = Dss.Voyage, NbVoyageur = Dss.NbVoyageur, NbVoyageurValider = Dss.NbVoyageurValider };
            return View(dossier);
        }
        [HttpPost]
        public ActionResult Delete_Dossier(DossierModels dossier)
        {
            Metier.RemoveDossier(dossier.Id);
            return RedirectToAction("Index");

        }
        //___________________________________________Validation_______________________________________________________//


        public ActionResult Valider_Dossier(DossierClientModels dossierR)
        {
            if (!(dossierR != null && dossierR.id != 0 && dossierR.idCli != 0))
                return RedirectToAction("Index");

            DtoDossier Dss = Metier.GetDossierClient(dossierR.id);
            if (Dss.NbVoyageur >= 1   && Dss.NbVoyageurValider<= Dss.NbVoyageur)
            {
                
             return   RedirectToAction("Index", "Voyageur", dossierR);
            }
            else
            {

            }
            
            DossierModels dossier = new DossierModels { Id = Dss.Id, Email = Dss.Email, Prix = Dss.Prix,  Client = Dss.Client, Voyage = Dss.Voyage, NbVoyageur = Dss.NbVoyageur, NbVoyageurValider = Dss.NbVoyageurValider };
            return View(dossier);
        }
        [HttpPost]
        public ActionResult Valider_Dossier(DossierModels dossier)
        {
            return RedirectToAction("Index");
        }
     
    }

}