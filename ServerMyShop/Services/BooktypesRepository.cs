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

        public void AddType(Booktypes item)
        {
            var type = db.Booktypes.SingleOrDefault(n => n.Name == item.Name);
            if(type==null)
            {
                db.Booktypes.Add(item);
                db.SaveChanges();
            }
        }

        public IEnumerable<Booktypes> GetAll()
        {
            return db.Booktypes.ToList();
        }
    }
}
