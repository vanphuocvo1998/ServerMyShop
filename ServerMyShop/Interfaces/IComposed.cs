using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Models;

namespace ServerMyShop.Interfaces
{
    public interface IComposed
    {
        void Add(Composed item);
    }
}
