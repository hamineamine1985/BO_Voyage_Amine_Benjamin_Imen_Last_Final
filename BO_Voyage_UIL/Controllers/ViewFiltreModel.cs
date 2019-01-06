using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BO_Voyage_BOL;
using BO_Voyage_DTO;
using BO_Voyage_UIL.Models;
namespace BO_Voyage_UIL.Controllers
{
    public class ViewFiltreModel
    {
        private MetierPool Metier = new MetierPool();
        private List<dtoListeContinent> ListC { get; set; }
        private List<dtoListePays> ListP { get; set; }
        private List<dtoListeRegion> ListR { get; set; }
        public int id { get; set; }
        public List<SelectListItem> Continents { get; set; }
        public List<SelectListItem> Pays { get; set; }
        public List<SelectListItem> Regions { get; set; }

        [Required()]
        [DisplayName("Type du voyage")]
        public List<SelectListItem> Type { get; set; }
        public List<SelectListItem> TrancheAge { get; set; }


        public void GetContinent()
        {            //______________________________________________________________________________________________
            ListC = Metier.GetListesContinent().ToList();
            Continents = new List<SelectListItem>();
            foreach (var item in ListC)
            {
                Continents.Add(new SelectListItem
                {
                    Text = item.Nom,
                    Value = item.Id.ToString()
                });

            }
            //______________________________________________________________________________________________
        }
        public void GetPays(int IdC)
        {
            //______________________________________________________________________________________________
            ListP = Metier.GetListePays(IdC).ToList();
            Pays = new List<SelectListItem>();
            foreach (var item in ListP)
            {
                Pays.Add(new SelectListItem
                {
                    Text = item.Nom,
                    Value = item.Id.ToString()
                });
            }
            //______________________________________________________________________________________________
        }
        public void GetRegions(int IdC, int IdP)
        {
            //______________________________________________________________________________________________
            ListR = Metier.GetListeRegion(IdP, IdC).ToList();
            Regions = new List<SelectListItem>();
            foreach (var item in ListR)
            {
                Regions.Add(new SelectListItem
                {
                    Text = item.Nom,
                    Value = item.Id.ToString()
                });
            }
            //______________________________________________________________________________________________
        }

        public string GetVoyageType(string TypeV)
        {
            string Voyage = "";
            int index = int.Parse(TypeV);
            var lst = Metier.GetVoyageType().ToList();
            if (index >= 1 && index < lst.Count)
            {
                string str = lst[index - 1];
                Voyage = str;
            }
            return Voyage;
        }


        public void SetVoyageType()
        {
            var lst = Metier.GetVoyageType();
            Type = new List<SelectListItem>();
            int i = 0;
            foreach (var elm in lst)
            {
                i++;
                Type.Add(new SelectListItem { Text = elm, Value = i.ToString() });

            }
        }

        public TrancheAge GetAge(int id)
        {
            TrancheAge tranche = new TrancheAge();
            int AgeMin = 0;
            int AgeMax = 0;
            switch (id)
            {
                case 1: tranche.AgeMin = 0; tranche.AgeMax = 12; break;
                case 2: tranche.AgeMin = 13; tranche.AgeMax = 30; break;
                case 3: tranche.AgeMin = 31; tranche.AgeMax = 45; break;
                case 4: tranche.AgeMin = 46; tranche.AgeMax = 65; break;
                default: tranche.AgeMin = 65; tranche.AgeMax = 500; break;
            }
            return tranche;
        }


        public void GetTrancheAge()
        {

            TrancheAge = new List<SelectListItem>();
            int i = 1;
            TrancheAge.Add(new SelectListItem { Text = "0-12", Value = i.ToString() }); i++;
            TrancheAge.Add(new SelectListItem { Text = "13-30", Value = i.ToString() }); i++;
            TrancheAge.Add(new SelectListItem { Text = "31-45", Value = i.ToString() }); i++;
            TrancheAge.Add(new SelectListItem { Text = "46-65", Value = i.ToString() }); i++;
            TrancheAge.Add(new SelectListItem { Text = "65 et +", Value = i.ToString() });
        }

        public void GetAll()
        {
            //______________________________________________________________________________________________
            int IdP = 0, IdC = 0;
            GetContinent();
            IdC = (int)ListC.FirstOrDefault().Id;
            GetPays(IdC);
            IdP = (int)ListP.FirstOrDefault().Id;
            GetRegions(IdC, IdP);
            SetVoyageType();
            GetTrancheAge();
            //______________________________________________________________________________________________
        }
        public ViewFiltreModel()
        {
            GetAll();
        }

    }
    public class TrancheAge
    {
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }

    }
    public class ViewClientModel
    {
        public int id { get; set; }
        public List<ClientModels> clientModels { get; set; }
        

    }
    public class CibleCampagn
    {
        public int id { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int ContinentId { get; set; }
        public int PaysId { get; set; }
        public int RegionId { get; set; }
        public string VoyageType { get; set; }
    }
}