using System;
using System.Collections.Generic;

namespace ServerMyShop.Models
{
    public partial class Users
    {
        public Users()
        {
            Bills = new HashSet<Bills>();
        }

        public int Id { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? Usertype { get; set; }

        public virtual Usertypes UsertypeNavigation { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
    }
}
