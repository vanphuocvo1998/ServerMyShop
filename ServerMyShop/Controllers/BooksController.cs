using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Models;
using ServerMyShop.Services;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;

namespace ServerMyShop.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BooksRepository _BooksRepository = new BooksRepository();
        IWebHostEnvironment IWebHostEnvironment;
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

        [HttpPost("Add")]
        public Books Add([FromForm]Books item)
        {
            _BooksRepository.AddBook(item);
            return item;
        }

        [HttpPut("Edit/{id:int}")]
        public Books Edit(int ?id, [FromForm]BooksViewmodel item)
        {
            //string imgname = UploadedFile(item);
            _BooksRepository.EditBook(id, item);
            return _BooksRepository.GetById(id);
        }

        [HttpDelete("Delete/{id:int}")]
        public void Delete(int? id)
        {
            _BooksRepository.DeleteBook(id);
        }

        //public string uploadedfile(booksviewmodel model)
        //{
        //    string uniquefilename = null;

        //    if (model.profileimage != null)
        //    {
        //        string uploadsfolder = path.combine("c:\\users\\vanph\\desktop\\bookshop\\clientmyshop\\public\\images", "c:\\users\\vanph\\desktop\\bookshop\\adminmyshop\\public\\images");
        //        uniquefilename = guid.newguid().tostring() + "_" + model.profileimage.filename;
        //        string filepath = path.combine(uploadsfolder, uniquefilename);
        //        using (var filestream = new filestream(filepath, filemode.create))
        //        {
        //            model.profileimage.copyto(filestream);
        //        }
        //    }
        //    return uniquefilename;
        //}
        //[HttpPost]
        //public IActionResult Index(IFormFile files)
        //{
        //    if (files != null)
        //    {
        //        if (files.Length > 0)
        //        {
        //            //Getting FileName
        //            var fileName = Path.GetFileName(files.FileName);

        //            //Assigning Unique Filename (Guid)
        //            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

        //            //Getting file Extension
        //            var fileExtension = Path.GetExtension(fileName);

        //            // concatenating  FileName + FileExtension
        //            var newFileName = String.Concat(myUniqueFileName, fileExtension);

        //            // Combines two strings into a path.
        //            var filepath =
        //    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"\{newFileName}";

        //            using (FileStream fs = System.IO.File.Create(filepath))
        //            {
        //                files.CopyTo(fs);
        //                fs.Flush();
        //            }
        //        }
        //    }
        //    return Ok("Success");
        //}
    }
}