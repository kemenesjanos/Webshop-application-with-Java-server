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
    
    public partial class Sales
    {
        public decimal ID { get; set; }
        public Nullable<decimal> Seller_ID { get; set; }
        public Nullable<decimal> Buyer_ID { get; set; }
        public Nullable<System.DateTime> Transaction_Date { get; set; }
        public string Product_Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> Shipping_Cost { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}