//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BO_Voyage_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Voyageur
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public System.DateTime DateNaissance { get; set; }
        public long IdDossier { get; set; }
    
        public virtual Dossier Dossier { get; set; }
    }
}
