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
    public class ProvidersController : ControllerBase
    {
        ProvidersRepository _ProvidersRepository = new ProvidersRepository();

        [HttpGet("GetAll")]
        public IEnumerable<Providers> GetAll()
        {
            return _ProvidersRepository.GetAll();
        }

        [HttpPost("Add")]
        public Providers Add([FromForm]Providers Provider)
        {
            _ProvidersRepository.Add(Provider);
            return Provider;
        }
    }
}