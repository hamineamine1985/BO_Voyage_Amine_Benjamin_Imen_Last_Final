using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BO_Voyage_UIL.Models
{

    public class CampaignModels
    {

        public long Id { get; set; }

        [Required()]
        [Display(Name = "Nom de la campagne")]
        public string Nom { get; set; }

        [Required()]
        public string Description { get; set; }
        [Required()]
        [Display(Name = "Date de début")]
        public DateTime DateCreation { get; set; }

        [Required()]
        [Display(Name = "Date de fin")]
        public DateTime DateLimite { get; set; }
    }
}