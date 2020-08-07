using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Models;
namespace ServerMyShop.Interfaces
{
    public interface IBooktypes
    {
        IEnumerable<Booktypes> GetAll();
        void AddType(Booktypes item);
    }
}
