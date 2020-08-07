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
    public class ComposedRepository : IComposed
    {
        BookShopContext db = new BookShopContext();

        bool checkExist(int idbook, int idauthor)
        {
            try
            {
                var book = db.Books.Single(n => n.Id == idbook);
                var author = db.Authors.Single(n => n.Id == idauthor);
                if (book != null && author != null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
           
        }
        bool checkComposed(Composed item)
        {
            var c = db.Composed.SingleOrDefault(n => n.Book == item.Book && n.Author == item.Author);
            if (c == null)
                return true;
            else
                return false;
        }
        public void Add(Composed item)
        {
            if(checkExist(item.Book, item.Author)==true && checkComposed(item)==true)
            {
                db.Composed.Add(item);
                db.SaveChanges();
            }

        }
    }
}
