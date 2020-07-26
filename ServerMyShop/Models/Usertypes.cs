using System;
using System.Collections.Generic;

namespace ServerMyShop.Models
{
    public partial class Usertypes
    {
        public Usertypes()
        {
            RolesUsertype = new HashSet<RolesUsertype>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RolesUsertype> RolesUsertype { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
