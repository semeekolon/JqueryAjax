//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BillingSystem2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class eOrderDet
    {
        public long Id { get; set; }
        public long OrderMasterId { get; set; }
        public long ProductId { get; set; }
        public int Qty { get; set; }
        public int Total { get; set; }
    
        public virtual eOrderMaster eOrderMaster { get; set; }
        public virtual eProduct eProduct { get; set; }
    }
}
