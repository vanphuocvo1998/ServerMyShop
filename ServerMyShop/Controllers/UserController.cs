using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Helper;
using ServerMyShop.Models;
using ServerMyShop.Services;
namespace ServerMyShop.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UsersRepository _UsersRepository = new UsersRepository();
      
        [HttpGet("LoginFacebook")]
        public IActionResult LoginFacebook()
        {
            return Content("Login sucess");
        }
        [HttpPost("Login")]
        public Users Login([FromForm]Users user)
        {
            var _user = _UsersRepository.Login(user.Gmail, user.Password);

            if (_user != null)
            {
               // if (SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "login") == null)
             //   {
                //    SessionHelper.SetObjectAsJson(HttpContext.Session, "login", _user);
             //   }
                return _user;
            }
            else
            {
                return null;
            }
            
        }
     
        [HttpPost("AddUser")]
        public Users AddUser([FromForm]Users user)
        {
            bool check = _UsersRepository.CheckExistUser(user.Gmail, user.Password);
            if(check==true)
            {
                _UsersRepository.Add(user);
                return user;
            }
            else
            {
                return user;
            }
           
        }
    }
}