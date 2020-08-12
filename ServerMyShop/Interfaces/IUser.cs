using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Models;
namespace ServerMyShop.Interfaces
{
    public interface IUser
    {
        Users Login(string gmail, string password);
        void Add(Users user);

        Users GetByGmail(string gmail);

        Users GetByPhone(string phone);

        Users GetLoginUser(Users login);
        bool CheckExistUser(string gmail, string phone);
        
    }
}
