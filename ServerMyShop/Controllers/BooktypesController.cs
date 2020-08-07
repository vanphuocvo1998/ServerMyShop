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
    public class BooktypesController : ControllerBase
    {
        BooktypesRepository _BooktypesRepository = new BooktypesRepository();

        [HttpGet("GetAll")]
        public IEnumerable<Booktypes> GetAll()
        {
            return _BooktypesRepository.GetAll();
        }

        [HttpPost("Add")]
        public Booktypes Add([FromForm]Booktypes type)
        {
            _BooktypesRepository.AddType(type);
            return type;
        }
    }
}