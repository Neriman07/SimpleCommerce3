using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public IActionResult RemoveFromCart(int cartItemId)//Sepete eklenen ürünlerden istediğimizi kaldırmamızı sağlıyor
        {

            string owner = User.Identity.Name;//oturum açmış kullanıcının adını alıyor
            if (string.IsNullOrEmpty(owner))
            {
                //oturum açmayan kullanıcıyı sitede takip eder
                owner = HttpContext.Session.Id;
            }
            Cart cart = GetCart(owner);
            var cartItemToRemove = cart.CartItems.Where(ci => ci.Id == cartItemId).FirstOrDefault();

            if (cartItemToRemove!=null)
            {
                cart.CartItems.Remove(cartItemToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart");
        }
        public IActionResult AddToCart(int productId)
        {
            string owner = User.Identity.Name;//oturum açmış kullanıcının adını alıyor
            if (string.IsNullOrEmpty(owner))
            {
                //oturum açmayan kullanıcıyı sitede takip eder
                owner = HttpContext.Session.Id;
            }
            Cart cart = GetCart(owner);
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
            HttpContext.Session.SetString("CartId", cart.Id.ToString());
            return Json(cart.CartItems.Sum(ci=>ci.Quantity));
        }

       
       public IActionResult Cart()
        {
            string owner = User.Identity.Name;//oturum açmış kullanıcının adını alıyor
            if (string.IsNullOrEmpty(owner))
            {
                //oturum açmayan kullanıcıyı sitede takip eder
                owner = HttpContext.Session.Id;
            }
            Cart cart = GetCart(owner);
            return View(cart);
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}