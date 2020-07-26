using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerMyShop.Models;
using ServerMyShop.Helper;
namespace ServerMyShop.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        BookShopContext db = new BookShopContext();

        [HttpGet("GetCart")]
        public IEnumerable<Cart> GetCart()
        {
            //var LocalStorage = new LocalStorage(;
            //if (LocalStorage.Get("cart") == null)
            //{
            //    return null;
            //}
            //var carts = LocalStorage.Get<List<Cart>>("cart");
            //return carts;
       
            // lấy giỏ hàng từ session cart
            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                return null;
            }
            var cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
           
            return cart;
        }

        //thêm giỏ hàng
        [HttpGet("AddCart/{Id:int}")]
        public IActionResult AddCart(int Id)
        {
            // kiểm tra sp đã tồn tại chưa
            Books product = db.Books.SingleOrDefault(n => n.Id == Id);
            if (product == null)
            {
                return Content("SP không tồn tại");
            }
            // nều session giỏ hàng chua có => tạo session giỏ hàng mới, tên là cart
            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                List<Cart> cart = new List<Cart>();
                Cart itemcart = new Cart(); // đối tượng cart để lưu thông tin sp cho vào giỏ
                itemcart.Id = Id;
                itemcart.Name = product.NameBook;
                itemcart.Count = 1;
                itemcart.Price = product.Price.Value;
                itemcart.Image = product.Img;
                itemcart.Total = product.Price.Value * itemcart.Count;
                cart.Add(itemcart); // thêm 1 sp vào giỏ
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart); // lưu đối tượng cart vào session tên là cart
                return Ok("Success");
            }
            else // nếu cđã tồn tại
            {
                //lấy ra list san phẩm trong giỏ hàng
                List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                Cart cartcheck = cart.SingleOrDefault(n => n.Id == Id); // kiểm tra đã có trong giỏ hàng chưa
                                                                        // int index = isExist(Id); // vị trí sp đã tồn tại trong list giỏ hàng
                if (cartcheck != null)// đã tồn tại trong giỏ hàng
                {
                  
                    cartcheck.Count++; // số lượng tăng lên
                    cartcheck.Total = cartcheck.Price * cartcheck.Count; // sửa giá
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartcheck);
                }
                else
                {
                    // tạo ra cart khác để mua sp khác
                    Cart newitemcart = new Cart(); // đối tượng cart để lưu thông tin sp cho vào giỏ
                    newitemcart.Id = Id;
                    newitemcart.Name = product.NameBook;
                    newitemcart.Count = 1;
                    newitemcart.Price = product.Price.Value;
                    newitemcart.Image = product.Img;
                    newitemcart.Total = product.Price.Value * newitemcart.Count;
                    cart.Add(newitemcart); // thêm 1 sp vào giỏ
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                // cập nhật lại giá trị trong session cart
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return Ok("Success");
            }

       
        }

        // xóa giỏ hàng
        [HttpDelete("DeleteItemCart/{Id:int}")]
        public IActionResult DeleteItemCart(int? Id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                Cart cartcheck = cart.SingleOrDefault(n => n.Id == Id); // lấy ra sp cần xóa
                if (cartcheck != null)
                {
                    cart.Remove(cartcheck); // xóa sp
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart); // cập nhật lại giỏ hàng trong session
                    return Ok("Xóa thành công"); // thành công
                }
                else
                    return Content("Xóa thất bại");
            }
            else
                return Content("Chưa mua hàng");
        }

        public int GetTotal()
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart == null)
                return 0;
            return cart.Sum(n => n.Total);
        }

        public int GetCount()
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart == null)
                return 0;
            return cart.Sum(n => n.Count);
        }


        [HttpGet("GetUpdateCart/{Id:int}")]
        public Cart GetUpdateCart(int? Id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            Cart cartcheck = cart.SingleOrDefault(n => n.Id == Id); // lấy ra sp cần xóa
            return cartcheck;
        }
        [HttpPut("SetUpdateCart")]
        public IActionResult SetUpdateCart([FromForm]Cart item)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                Cart cartupdate = cart.Find(n => n.Id == item.Id); // lấy ra sp cần xóa
                if(cartupdate !=null)
                {
                    cartupdate.Count = item.Count;
                    cartupdate.Total = cartupdate.Count * cartupdate.Total;
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart); // cập nhật lại giỏ hàng trong session
                    return Ok("Update thành công");
                }
                return Content("Không tồn tại sản phẩm");
               
            }
            else
                return Content("Thất bại");
            
        }

    }
}