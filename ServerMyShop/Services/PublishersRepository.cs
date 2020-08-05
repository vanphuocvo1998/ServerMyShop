﻿using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Interfaces;
using ServerMyShop.Models;

namespace ServerMyShop.Services
{
    public class PublishersRepository : IPublishers
    {
        BookShopContext db = new BookShopContext();

        public IEnumerable<Publishers> GetAll()
        {
            return db.Publishers.ToList();
        }
    }
}
