using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ServerMyShop.Models
{
    public partial class Books
    {
        public Books()
        {
            Billdetails = new HashSet<Billdetails>();
        }

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
        public string Img { get; set; }
        public Books(int id, string name, string content, int price, int quantity, int sale, string status, string deleted, string img)
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

        public Books(string img)
        {
            this.Img = img;
        }

        public virtual Booktypes BooktypeNavigation { get; set; }
        public virtual Providers ProviderNavigation { get; set; }
        public virtual Publishers PublisherNavigation { get; set; }
        public virtual ICollection<Billdetails> Billdetails { get; set; }
    }
}
