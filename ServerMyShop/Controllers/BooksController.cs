using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Models;
using ServerMyShop.Services;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ServerMyShop.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BooksRepository _BooksRepository = new BooksRepository();

        public static IWebHostEnvironment _environment;
        public BooksController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class BookImage
        {
            public IFormFile Img { get; set; }
        }

        [Authorize(Roles = "1")]
        [HttpPost("UploadImg"), DisableRequestSizeLimit]
        public string UploadImg([FromForm]BookImage model)
        {
            try
            {
                if (model.Img.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Images\\");
                    }
                    using (FileStream fs = System.IO.File.Create(_environment.WebRootPath + "\\Images\\" + model.Img.FileName))
                    {
                        model.Img.CopyTo(fs);
                        fs.Flush();
                        return model.Img.FileName;
                    }
                }
                else
                    return "Upload failed";
            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }
            
        }

        [HttpGet("GetAll")]
        public IEnumerable<Books> GetAll()
        {
            return _BooksRepository.GetAll();
        }

        [HttpGet("GetByType/{idtype:int}")]
        public IEnumerable<Books> GetByType(int? idtype)
        {
            return _BooksRepository.GetByType(idtype);
        }

        [HttpGet("GetById/{id:int}")]
        public Books GetById(int? id)
        {
            return _BooksRepository.GetById(id);
        }

        [Authorize(Roles = "1")]
        [HttpPost("Add")]
        public Books Add([FromForm]Books item)
        {
            _BooksRepository.AddBook(item);
            return item;
        }

        [Authorize(Roles = "1")]
        [HttpPut("Edit/{id:int}")]
        public Books Edit(int ?id, [FromForm]BookImage img, [FromForm]Books item)
        {
            string nameImg = UploadImg(img);
            var book = new Books(item.Id, item.NameBook, item.Content, Convert.ToInt32(item.Price), Convert.ToInt32(item.Quantity), Convert.ToInt32(item.Sale), item.Status, item.Deleted, nameImg) ;
            _BooksRepository.EditBook(id, book);
            return _BooksRepository.GetById(id);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("Delete/{id:int}")]
        public void Delete(int? id)
        {
            _BooksRepository.DeleteBook(id);
        }
    }
}