using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerMyShop.Interfaces;
using ServerMyShop.Models;

namespace ServerMyShop.Services
{
    public class BooksRepository : IBooks
    {
        BookShopContext db = new BookShopContext();

        public void AddBook(Books book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void DeleteBook(int? id)
        {
            var book = db.Books.SingleOrDefault(n => n.Id == id);
            if(book!=null)
            {
                book.Deleted = "true";
                book.Status = "false";
                db.Books.Update(book);
                db.SaveChanges();
            }
            // db.Books.Remove(book);
            
        }

        public void EditBook(int? id, Books book)
        {
            var bookEdit = db.Books.SingleOrDefault(n => n.Id == id);
           
            if (bookEdit!= null)
            {
                
                bookEdit.NameBook = book.NameBook;
                bookEdit.Price = book.Price;
                bookEdit.Img = book.Img;
                bookEdit.Content = book.Content;
                bookEdit.Deleted = book.Deleted;
                bookEdit.Quantity = book.Quantity;
                bookEdit.Sale = book.Sale;
                bookEdit.Status = book.Status;
                db.Entry(bookEdit).State = EntityState.Modified;
                db.SaveChanges();
            }
           
        }

        public IEnumerable<Books> GetAll()
        {
            return db.Books.Where(n=>n.Deleted=="false").ToList();
        }

        public Books GetById(int? id)
        {
            return db.Books.SingleOrDefault(n => n.Id == id && n.Deleted == "false");
        }

        public IEnumerable<Books> GetByType(int? idtype)
        {
            return db.Books.Where(n => n.Booktype == idtype && n.Deleted == "false").ToList();
        }
    }
}
