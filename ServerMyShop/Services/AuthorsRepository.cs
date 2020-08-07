using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ServerMyShop.Interfaces;
using ServerMyShop.Models;

namespace ServerMyShop.Services
{
    public class AuthorsRepository : IAuthors
    {
        BookShopContext db = new BookShopContext();

        public void Add(Authors item)
        {
            var author = db.Authors.SingleOrDefault(n => n.Name == item.Name);
            if(author==null)
            {
                db.Authors.Add(item);
                db.SaveChanges();
            }
        }

        public IEnumerable<Authors> GetAll()
        {
            return db.Authors.ToList();
        }
    }
}
