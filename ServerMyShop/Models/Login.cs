using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerMyShop.Models
{
    public class Login
    {
        public string Gmail { get; set; }
        public string Password { get; set; }
        public Login()
        {

        }

        public Login(string gmail, string pass)
        {
            this.Gmail = gmail;
            this.Password = pass;
        }
    }
}
