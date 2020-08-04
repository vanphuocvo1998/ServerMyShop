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
    public class BillsRepository : IBills
    {
        BookShopContext db = new BookShopContext();
        public void Add(Bills bill)
        {
            db.Bills.Add(bill);
            db.SaveChanges();
        }

        public Bills GetById(int id)
        {
            return db.Bills.SingleOrDefault(n => n.Id == id);
        }
    }
}
