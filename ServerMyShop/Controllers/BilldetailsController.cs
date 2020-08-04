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
    public class BilldetailsController : ControllerBase
    {
        BilldetailsRepository _BilldetailsRepository = new BilldetailsRepository();

        [HttpPost("AddBilldetail")]
        public Billdetails AddBilldetail([FromForm]Billdetails billdetail)
        {
            _BilldetailsRepository.Add(billdetail);
            return billdetail;
        }
    }
}