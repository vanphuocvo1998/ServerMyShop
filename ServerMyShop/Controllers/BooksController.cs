using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    }
}