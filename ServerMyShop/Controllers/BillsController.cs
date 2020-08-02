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
    public class BillsController : ControllerBase
    {
        BillsRepository _BillsRepository = new BillsRepository();
        [HttpPost("Add")]
        public IActionResult AddBill([FromForm]Bills bill)
        {
            _BillsRepository.Add(bill);
            return Ok("success");
        }
    }
}