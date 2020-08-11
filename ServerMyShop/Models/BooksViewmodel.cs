using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
namespace ServerMyShop.Models
{
    public class BooksViewmodel
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public int? Booktype { get; set; }
        public int? Provider { get; set; }
        public int? Publisher { get; set; }
        public string Content { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Sale { get; set; }
        public string Status { get; set; }
        public string Deleted { get; set; }
        public IFormFile Img { get; set; }

        public BooksViewmodel(int id, string name, string content, int price, int quantity, int sale, string status, string deleted,IFormFile img)
        {
            this.Id = id;
            this.NameBook = name;
            this.Content = content;
            this.Price = price;
            this.Quantity = quantity;
            this.Sale = sale;
            this.Status = status;
            this.Deleted = deleted;
            this.Img = img;
        }
    }
}
