using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCommerce3.Data;
using SimpleCommerce3.Models;

namespace SimpleCommerce3.Controllers
{
    public class ShopController : ControllerBase
    {
        public ShopController(ApplicationDbContext context): base(context)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCart(int productId)
        {
            string owner = User.Identity.Name;//oturum açmış kullanıcının adını alıyor
            if (string.IsNullOrEmpty(owner))
            {
                //oturum açmayan kullanıcıyı sitede takip eder
                owner = HttpContext.Session.Id;
            }
            var cart = GetCart(owner);
            CartItem cartItem = cart.CartItems.Where(c => c.ProductId == productId).FirstOrDefault();
            if (cartItem==null)
            {
                cartItem = new CartItem();
                cartItem.ProductId = productId;
                cartItem.Quantity = 1;
                cart.CartItems.Add(cartItem);

            }
            else
            {
                cartItem.Quantity += 1;
            }
            _context.SaveChanges();
            return Json(true);
        }

       
       
    }
}