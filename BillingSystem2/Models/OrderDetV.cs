using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem2.Models
{
    public class OrderDetV : eOrderDet
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int GrantTotal { get; set; }
    }
}