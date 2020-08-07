using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerMyShop.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class MailSendController : ControllerBase
    {
        [HttpGet("SendEmail/{Name}/{Email}/{Message}")]
        public string SendEmail(string Name, string Email, string Message)
        {

            try
            {
                // Credentials
                var credentials = new System.Net.NetworkCredential("16110426@student.hcmute.edu.vn", "vovanphuoc1998");

                // Mail message
                var mail = new System.Net.Mail.MailMessage()
                {
                    From = new MailAddress("16110426@student.hcmute.edu.vn"),
                    Subject = "PhuocVo Book Shop",
                    Body = Message
                };

                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(Email));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
               // client.UseDefaultCredentials = true;
                client.Send(mail);
             
                return "Email Sent Successfully!";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }
    }
}