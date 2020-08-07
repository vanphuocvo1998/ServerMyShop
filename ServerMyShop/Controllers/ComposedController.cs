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
    public class ComposedController : ControllerBase
    {
        ComposedRepository _ComposedRepository = new ComposedRepository();
        
        [HttpPost("Add")]
        public Composed Add([FromForm]Composed composed)
        {
            _ComposedRepository.Add(composed);
            return composed;
        }
    }
}