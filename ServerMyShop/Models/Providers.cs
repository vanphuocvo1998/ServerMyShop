using System;
using System.Collections.Generic;

namespace ServerMyShop.Models
{
    public partial class Providers
    {
        public Providers()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
