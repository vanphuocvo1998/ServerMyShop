using System;
using System.Collections.Generic;

namespace ServerMyShop.Models
{
    public partial class Billdetails
    {
        public int Bill { get; set; }
        public int Book { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? Sumpay { get; set; }

        public virtual Bills BillNavigation { get; set; }
        public virtual Books BookNavigation { get; set; }
    }
}
