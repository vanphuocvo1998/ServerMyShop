using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Models;
namespace ServerMyShop.Interfaces
{
    public interface IProviders
    {
        IEnumerable<Providers> GetAll();
        void Add(Providers item);
    }
}
