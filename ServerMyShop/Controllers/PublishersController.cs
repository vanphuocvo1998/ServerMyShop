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
    public class PublishersController : ControllerBase
    {
        PublishersRepository _PublishersRepository = new PublishersRepository();

        [HttpGet("GetAll")]
        public IEnumerable<Publishers> GetAll()
        {
            return _PublishersRepository.GetAll();
        }

        [HttpPost("Add")]
        public Publishers Add([FromForm]Publishers Publisher)
        {
            _PublishersRepository.Add(Publisher);
            return Publisher;
        }
    }
}