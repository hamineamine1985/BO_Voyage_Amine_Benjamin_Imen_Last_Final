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
    public class ClientController : Controller
    {
        private MetierPool Metier = new MetierPool();
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Authentification()
        {
            ClientAuth Client = new ClientAuth();
            Client.Password = "";
            Client.User = "";
            return View(Client);
        }

        [HttpPost]       
        public ActionResult Authentification(ClientAuth Client)
        {
           if( MetierPool.VerifLogin(Client.User, Client.Password) != -1)
            {
            }
            return View();
        }
    }

    public class ClientAuth
    {      
        public string User { get; set; }
        public  string Password { get; set; }

    }
}