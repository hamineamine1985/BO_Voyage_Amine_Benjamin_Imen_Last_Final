using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BO_Voyage_UIL.Models
{

    public class ClientModels
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Civilite { get; set; }
        public string Telephone { get; set; }
        public double prix { get; set; }
        public long Client { get; set; }
        public DateTime DateNaissance { get; set; }
        public string motdepasse { get; set; }
        public string identifiant { get; set; }
        public bool cibler { get; set; }
    }
    public class VoyageurModels
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [Required()]
        [DataType(DataType.Date)]
        [DisplayName("Date de Naissance")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

    }
}