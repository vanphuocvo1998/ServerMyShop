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
        UsersRepository _UsersRepository = new UsersRepository();

        [HttpPost("AddBill")]
        public Bills AddBill([FromForm]Bills bill)
        {
            // kiểm tra mail đã có chua, chua có thì tạo và luu vao db
            var user = _UsersRepository.GetByGmail(bill.Gmail);
            if (user != null)
                bill.UserId = user.Id;
            _BillsRepository.Add(bill);
            return bill;
        }
    }
}