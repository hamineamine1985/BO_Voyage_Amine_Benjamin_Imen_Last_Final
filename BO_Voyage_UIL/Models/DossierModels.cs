using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BO_Voyage_UIL.Models
{
    public class DossierModels
    {

        public long Id { get; set; }
    //[Display(AutoGenerateField = false)]
        public long Client { get; set; }
        public long Voyage { get; set; }
    //    [HiddenInput(DisplayValue = false)]
        public long Cb { get; set; }
     //   public int Places { get; set; }
        public int NbVoyageurValider { get; set; }
        public long NbVoyageur { get; set; }
        public int Etat { get; set; }
        //     [Display(Name = "Adress email")]
        public string Email { get; set; }
     //   [HiddenInput(DisplayValue = false)]
        public long Voyageur { get; set; }
        public decimal Prix { get; set; }
       

    }
}