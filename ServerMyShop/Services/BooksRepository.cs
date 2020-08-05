using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Interfaces;
using ServerMyShop.Models;

namespace ServerMyShop.Services
{
    public class BooksRepository : IBooks
    {
        BookShopContext db = new BookShopContext();
        public IEnumerable<Books> GetAll()
        {
            return db.Books.Where(n=>n.Deleted=="false").ToList();
        }

        public Books GetById(int? id)
        {
            return db.Books.SingleOrDefault(n => n.Id == id && n.Deleted == "false");
        }

        public IEnumerable<Books> GetByType(int? idtype)
        {
            return db.Books.Where(n => n.Booktype == idtype && n.Deleted == "false").ToList();
        }
    }
}
