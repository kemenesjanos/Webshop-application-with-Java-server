//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webshop.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loc()
        {
            this.Users = new HashSet<Users>();
        }
    
        public decimal ID { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public Nullable<decimal> House_Number { get; set; }
        public Nullable<decimal> Zip_Code { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
