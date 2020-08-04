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
    public class BilldetailsRepository:IBilldetails
    {
        BookShopContext db = new BookShopContext();

        public void Add(Billdetails billdetail)
        {
            db.Billdetails.Add(billdetail);
            db.SaveChanges();
        }
    }
}
