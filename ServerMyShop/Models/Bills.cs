using System;
using System.Collections.Generic;

namespace ServerMyShop.Models
{
    public partial class Bills
    {
        public Bills()
        {
            Billdetails = new HashSet<Billdetails>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public string Deliverytime { get; set; }
        public string Deliveryplace { get; set; }
        public string Status { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Billdetails> Billdetails { get; set; }
    }
}
