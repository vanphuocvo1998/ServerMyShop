using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Interfaces;
using ServerMyShop.Models;
namespace ServerMyShop.Services
{
    public class UsersRepository : IUser
    {
        BookShopContext db = new BookShopContext();

        public void Add(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool CheckExistUser(string gmail, string phone)
        {
            if (db.Users.SingleOrDefault(n => n.Gmail == gmail && n.Phone == phone)==null)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }

        public Users GetByGmail(string gmail)
        {
            return db.Users.FirstOrDefault(n=>n.Gmail==gmail);
        }

        public Users GetByPhone(string phone)
        {
            return db.Users.SingleOrDefault(n => n.Phone == phone);
        }

        public Users Login(string gmail, string password)
        {
            var user = db.Users.SingleOrDefault(n => n.Gmail==gmail && n.Password == password);
            return user;
        }
    }
}
