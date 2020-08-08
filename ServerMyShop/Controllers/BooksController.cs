using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Models;
using ServerMyShop.Services;
namespace ServerMyShop.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BooksRepository _BooksRepository = new BooksRepository();

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
        public Books Edit(int ?id, [FromForm]Books item)
        {
         
            _BooksRepository.EditBook(id, item);
            return item;
        }

        [HttpDelete("Delete/{id:int}")]
        public void Delete(int? id)
        {
            _BooksRepository.DeleteBook(id);
        }
    }
}