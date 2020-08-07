using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Models;

namespace ServerMyShop.Interfaces
{
    public interface IAuthors
    {
        IEnumerable<Authors> GetAll();
        void Add(Authors item);
    }
}
