using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerMyShop.Models;
namespace ServerMyShop.Interfaces
{
    public interface IBooks
    {
        IEnumerable<Books> GetAll();
        IEnumerable<Books> GetByType(int? idtype);

        Books GetById(int? id);
        void AddBook(Books book);
        void EditBook(int? id,Books book);
        void DeleteBook(int? id);
    }
}
