using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO_Voyage_BOL;
using BO_Voyage_DTO;
using BO_Voyage_UIL.Models;
using System.ComponentModel.DataAnnotations;

//___________________________________
using System.Globalization;

using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
//___________________________________

namespace BO_Voyage_UIL.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        //private ServiceReferenceBanqueFournisseur.Service1Client srv = new ServiceReferenceBanqueFournisseur.Service1Client();

        public HomeController()
        {
            //  _signInManager= HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
         //  _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); 
        }

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //________________________________________________________________________________________________
        //________________________________________________________________________________________________

        private MetierPool Metier = new MetierPool();
        // GET: Reserver

        public ActionResult Index()
        {
            List<dtoListeContinent> List = Metier.GetListesContinent().ToList();
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
        [Route("Home/Regions/{IdP}/{IdC}")]
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
        [Route("Home/Voyages/{IdP}/{IdC}/{IdR}")]
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
        [Route("Home/Voyage/{IdV}")]
        public PartialViewResult Voyage(int IdV)
        {
            if (IdV != 0)
            {
                dtoListeVoyage voy = Metier.GetListeVoyage(IdV);

                ListeVoyageModel voyage = new ListeVoyageModel { Id= voy.Id,Nom= voy.Nom,Prix= voy.Prix,DateDepart= voy.DateDepart.ToString("dd-MM-yyyy"),DateRetour= voy.DateRetour.ToString("dd-MM-yyyy"), Description= voy.Description,Url= voy.Url };

                return PartialView(voyage);
            }
            return PartialView("");

        }
        [Route("Home/Payement")]
        public PartialViewResult Payement()
        {
            return PartialView();
        }

        [HttpPost]
        [Route("Home/Save")]
         public ActionResult Save(InfoDossier InfoD)//public bool Save(InfoDossier InfoD)// public bool Save(InfoDossier InfoD)//public bool Save(InfoDossier InfoD)
        {
            // InfoDossier InfoD = Newtonsoft.Json.JsonConvert.DeserializeObject<InfoDossier>(Str);
            string pass = "Aminose_9";
            dtoListeDossier dossier = new dtoListeDossier { emailAdress = InfoD.emailAdress,AssuranceAnnul=InfoD.AssuranceAnnul,AssuranceRpatri=InfoD.AssuranceRpatri, numCarte = InfoD.numCarte, NbVoyageur = InfoD.NbVoyageur , NomCarte= InfoD.NomCarte, IdVoyage = InfoD.choixV , Crypto =InfoD. Crypto , Expiration = DateTime.Parse(InfoD.Expiration)};
            pass = Metier.EnregistreDossier(InfoD.choixV, dossier);        
         //   RegisterViewModel model = new RegisterViewModel {Email= dossier.emailAdress,Password= pass,ConfirmPassword= pass };
            //     return   RedirectToAction("RegisterClient", "Account", model);
            //     EnregistreDossierMvc(dossier.emailAdress, password);
            LoginModels model = new LoginModels { Login = dossier.emailAdress, Password = pass };           
            return RedirectToAction("ConfirmationDossier", "Home", model);
         //  return true;
        }

        [Route("Home/ConfirmationDossier")]
        public ActionResult ConfirmationDossier(LoginModels Credentials)
        {
            return View(Credentials);
           
        }
        // public ActionResult RegisterClient(RegisterViewModel model)
        //{

        //    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //    var result = UserManager.Create(user, model.Password);//         var result =  UserManager.CreateAsync(user, model.Password);
        //    SignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);//            SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //                                                                       // Pour plus d'informations sur l'activation de la confirmation de compte et de la réinitialisation de mot de passe, visitez https://go.microsoft.com/fwlink/?LinkID=320771
        //                                                                            // Envoyer un message électronique avec ce lien
        //                                                                            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //                                                                            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //                                                                            // await UserManager.SendEmailAsync(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=\"" + callbackUrl + "\">ici</a>");
        //    return RedirectToAction("Index", "Home");

        //    // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
        //    return View(model);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Qui sommes-nous ?";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Contactez-nous ! ";

            return View();
        }
        public ActionResult Auth()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult Auth(LoginModels Credentials)
        {
          long Id=  MetierPool.VerifLogin(Credentials.Login, Credentials.Password);

            return RedirectToAction("Index","Valider",new {id= Id});
        }



    }
    public class InfoDossier
    {
        public string emailAdress { get; set; }
        public string numCarte { get; set; }
        public int NbVoyageur { get; set; }
        public string Expiration { get; set; }
        public int choixV { get; set; }
        public string NomCarte { get; set; }
        public string Crypto { get; set; }
        public bool AssuranceRpatri { get; set; }
        public bool AssuranceAnnul { get; set; }
 }
    public class LoginModels
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }         
    }
    public class ListeVoyageModel
    {
        public long Id { get; set; }
        public string Nom { get; set; }// public string Libelle;  //   public int Dispo;  //     public long Region;
        public string Description { get; set; }
        public string Url { get; set; }
        public double Prix { get; set; }
        public string DateDepart { get; set; }
        public string DateRetour { get; set; }
    }


}