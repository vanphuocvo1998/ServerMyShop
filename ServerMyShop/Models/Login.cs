using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerMyShop.Models
{
    public class Login
    {
        BookShopContext db = new BookShopContext();
        public string Gmail { get; set; }
        public string Password { get; set; }

        public Users GetLoginUser(Users login)
        {
            var userinfo = new Users();
            //var query = from Users in db.Users
            //            join Usertypes in db.Usertypes on Users.Usertype equals Usertypes.Id
            //            join RolesUsertype in db.RolesUsertype on Usertypes.Id equals RolesUsertype.Usertype
            //            join Roles in db.Roles on RolesUsertype.Role equals Roles.Id

            //            select new {Id= Users.Id, Gmail= Users.Gmail,Password= Users.Password, Address= Users.Address, Phone= Users.Phone, Usertype= Users.Usertype };

            var obj = db.Users
                  .Join(db.Usertypes,
                      f => new { f1 = f.Usertype.Value },
                      s => new { f1 = s.Id },
                      (f, s) =>
                      new
                      {
                          Id = f.Id,
                          Gmail = f.Gmail,
                          Password = f.Password,
                          Address = f.Address,
                          Phone = f.Phone,
                          Usertype = s.Id
                      }
                  )
                  .Join(db.RolesUsertype,
                     m => m.Usertype, n => n.Usertype,
                     (m, n) => new
                     {
                         Id = m.Id,
                         Gmail = m.Gmail,
                         Password = m.Password,
                         Address = m.Address,
                         Phone = m.Phone,
                         Usertype = m.Usertype,
                         Role = n.Role
                     }
                     )
                  .Join(db.Roles,
                     p => p.Role, q => q.Id,
                     (p, q) => new
                     {
                         Id = p.Id,
                         Gmail = p.Gmail,
                         Password = p.Password,
                         Address = p.Address,
                         Phone = p.Phone,
                         Usertype = p.Usertype,
                         Role = q.Id,
                         Name = q.Name
                     }
                     )
                  .FirstOrDefault(a => a.Gmail == login.Gmail && a.Password == login.Password);

            userinfo.Id = obj.Id;
            userinfo.Gmail = obj.Gmail;
            userinfo.Password = obj.Password;
            userinfo.Address = obj.Address;
            userinfo.Phone = obj.Phone;
            userinfo.Usertype = obj.Usertype;

            return userinfo;
            
        }

        public Login(string gmail, string pass)
        {
            this.Gmail = gmail;
            this.Password = pass;
        }
    }
}
