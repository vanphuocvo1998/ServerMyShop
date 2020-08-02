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

        public Users Login(string gmail, string password)
        {
            var user = db.Users.SingleOrDefault(n => n.Gmail==gmail && n.Password == password);
            return user;
        }
    }
}
