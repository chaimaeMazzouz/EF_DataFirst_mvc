//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AtelierPratique_16.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicule()
        {
            this.voyage = new HashSet<voyage>();
        }
    
        public string Immatricule { get; set; }
        public string Marque { get; set; }
        public string Type_Vehicule { get; set; }
        public Nullable<System.DateTime> Dt_Mise_Service { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voyage> voyage { get; set; }
    }
}
