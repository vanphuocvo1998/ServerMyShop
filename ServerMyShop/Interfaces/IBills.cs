using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Models;
namespace ServerMyShop.Interfaces
{
    public interface IBills
    {
        void Add(Bills bill);
        Bills GetById(int id);
    }
}
