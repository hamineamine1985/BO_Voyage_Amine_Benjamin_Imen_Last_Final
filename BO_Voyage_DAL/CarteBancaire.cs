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
    
    public partial class CarteBancaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarteBancaire()
        {
            this.Dossiers = new HashSet<Dossier>();
        }
    
        public long Id { get; set; }
        public string NomCB { get; set; }
        public string NumCB { get; set; }
        public System.DateTime DateExpCB { get; set; }
        public string CryptoCB { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dossier> Dossiers { get; set; }
    }
}
