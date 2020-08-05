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
    public class AuthorsController : ControllerBase
    {
        AuthorsRepository _AuthorsRepository = new AuthorsRepository();

        [HttpGet("GetAll")]
        public IEnumerable<Authors> GetAll()
        {
            return _AuthorsRepository.GetAll();
        }
    }
}