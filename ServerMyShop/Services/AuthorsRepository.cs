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

        public IEnumerable<Authors> GetAll()
        {
            return db.Authors.ToList();
        }
    }
}
