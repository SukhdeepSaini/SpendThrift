//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpendThriftModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int ID { get; set; }
        public string CustUserName { get; set; }
        public Nullable<int> ProductID { get; set; }
        public int ProductCount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual Product Product { get; set; }
    }
}