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
    
    public partial class Dossier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dossier()
        {
            this.Voyageurs = new HashSet<Voyageur>();
        }
    
        public long Id { get; set; }
        public string Email { get; set; }
        public Nullable<long> IdCB { get; set; }
        public string NumCB { get; set; }
        public int NbVoyageur { get; set; }
        public Nullable<long> IdVoyage { get; set; }
        public Nullable<long> IdClient { get; set; }
        public Nullable<int> Etat { get; set; }
        public Nullable<int> NbVoyageurValider { get; set; }
    
        public virtual CarteBancaire CarteBancaire { get; set; }
        public virtual Client Client { get; set; }
        public virtual Voyage Voyage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voyageur> Voyageurs { get; set; }
    }
}
