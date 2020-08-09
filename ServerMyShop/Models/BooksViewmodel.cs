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
        public IFormFile ProfileImage { get; set; }
    }
}
