using System;
using System.Collections.Generic;

namespace ServerMyShop.Models
{
    public partial class RolesUsertype
    {
        public int Role { get; set; }
        public int Usertype { get; set; }

        public virtual Roles RoleNavigation { get; set; }
        public virtual Usertypes UsertypeNavigation { get; set; }
    }
}
