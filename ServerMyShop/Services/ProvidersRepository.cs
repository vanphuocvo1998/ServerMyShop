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
   
    public class ProvidersRepository :IProviders
    {
        BookShopContext db = new BookShopContext();

        public void Add(Providers item)
        {
            var pro = db.Providers.SingleOrDefault(n => n.Name == item.Name);
            if (pro == null)
            {
                db.Providers.Add(item);
                db.SaveChanges();
            }
        }

        public IEnumerable<Providers> GetAll()
        {
            return db.Providers.ToList();
        }
    }
}
