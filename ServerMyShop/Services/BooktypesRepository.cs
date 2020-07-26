using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Interfaces;
using ServerMyShop.Models;

namespace ServerMyShop.Services
{
    public class BooktypesRepository : IBooktypes
    {
        BookShopContext db = new BookShopContext();
        public IEnumerable<Booktypes> GetAll()
        {
            return db.Booktypes.ToList();
        }
    }
}
