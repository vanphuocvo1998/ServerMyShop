using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Models;

namespace ServerMyShop.Interfaces
{
    public interface IPublishers
    {
        IEnumerable<Publishers> GetAll();
        void Add(Publishers item);
    }
}
