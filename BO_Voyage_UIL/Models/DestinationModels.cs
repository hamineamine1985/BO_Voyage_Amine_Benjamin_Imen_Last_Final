using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BO_Voyage_BOL;
using BO_Voyage_DTO;
using System.Web.Mvc;


namespace BO_Voyage_UIL.Models
{
    public class DestinationModels
    {
        private MetierPool Metier = new MetierPool();
        public DestinationModels()
        {
            var lst = Metier.GetVoyageType();

            Datedepart = DateTime.Now;
            DateRetour = DateTime.Now;
            Type = new List<SelectListItem>();
            int i = 0;
            foreach (var elm in lst)
            {
                i++;
                Type.Add(new SelectListItem { Text = elm, Value = i.ToString() });

            }

        }
        [Required(ErrorMessage = "La date doit être donnée.")]
        public string Continent { get; set; }
        [Required()]
        public string Pays { get; set; }
        [Required()]
        [DisplayName("Région")]
        public string Régions { get; set; }

        [DisplayName("Intitulé")]
        [Required()]
        public string Intitule { get; set; }
        [Required()]
        [DisplayName("Type de voyage")]
        public List<SelectListItem> Type { get; set; }

        [Required()]
        [DataType(DataType.Currency)]
        public decimal Prix { get; set; }
        [Required()]
        [DataType(DataType.ImageUrl)]
        [DisplayName("Url de la photo")]
        public string Photo { get; set; }

        [Required()]
        [DisplayName("Déscriptif du voyage")]
        public string Descriptif { get; set; }
        [Required()]
        [DataType(DataType.Date)]
        [DisplayName("Date de départ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datedepart { get; set; }
        [Required()]
        [DataType(DataType.Date)]
        [DisplayName("Date de retour")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateRetour { get; set; }

        [Required()]
        [DisplayName("Nombre de places disponible")]
        public int Dispo { get; set; }

    }
}