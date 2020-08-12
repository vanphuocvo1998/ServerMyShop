using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Models;
using ServerMyShop.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ServerMyShop.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UsersRepository _UsersRepository = new UsersRepository();
        public IConfiguration _config;
         BookShopContext db = new BookShopContext();
        public UserController(IConfiguration config)
        {
            _config = config;
           
        }

        [HttpGet("SignIn")]
        public IActionResult SignIn(string gmail, string password)
        {
            Users login = new Users();
            login.Gmail = gmail;
            login.Password = password;
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);
            if(user!=null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                return Ok(new { token = tokenStr });
            }
            return response;
        }
        private Users AuthenticateUser(Users login)
        {
            //Users user = null;
            //if(login.Gmail=="vanphuocvo1998@gmail.com" && login.Password=="123")
            //{
            //    user = new Users { Gmail = "vanphuocvo1998@gmail.com", Password = "123" };
            //}

            Users user = _UsersRepository.GetLoginUser(login);
            return user;
        }

        private string GenerateJSONWebToken(Users userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userinfo.Gmail),
                new Claim(JwtRegisteredClaimNames.Email, userinfo.Gmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userinfo.Usertype.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience:_config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
             );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;

        }

        [Authorize(Roles ="1")]
        [HttpPost("Post")]
        public string GetInfo()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var username = claim[0].Value;
            return "Welcome to: " + username;
        }

        [Authorize(Roles = "1")]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value 1", "value 2", "value 3" };
        }
       

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