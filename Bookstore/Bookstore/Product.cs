//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bookstore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int BasisPrice { get; set; }
        public string Catagories { get; set; }
        public int Amount { get; set; }
        public string Deliver { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
