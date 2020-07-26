using System;
using System.Collections.Generic;

namespace ServerMyShop.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RolesUsertype = new HashSet<RolesUsertype>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public virtual ICollection<RolesUsertype> RolesUsertype { get; set; }
    }
}
