using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerMyShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }

        public Cart(int masp, int soluong)
        {
            using (BookShopContext db = new BookShopContext())
            {
                this.Id = masp;
                this.Count = soluong;
                Books sp = db.Books.SingleOrDefault(n => n.Id == masp);
                this.Name = sp.NameBook;
                this.Image = sp.Img;
                this.Price = sp.Price.Value;
                this.Total = this.Count * this.Price;
            }
        }

        public Cart(int masp)
        {
            using (BookShopContext db = new BookShopContext())
            {
                this.Id = masp;

                Books sp = db.Books.SingleOrDefault(n => n.Id == masp);
                this.Name = sp.NameBook;
                this.Count = 1;
                this.Image = sp.Img;
                this.Price = sp.Price.Value;
                this.Total = this.Count * this.Price;
            }
        }


        public Cart()
        {

        }
    }
}
