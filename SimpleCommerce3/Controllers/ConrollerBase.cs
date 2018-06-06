using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SimpleCommerce3.Data;
using SimpleCommerce3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Controllers
{
    public class ControllerBase:Controller
    {
        // veritabanına bağlanmak için
        protected readonly ApplicationDbContext _context;
        public ControllerBase(ApplicationDbContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            controller.ViewBag.Categories = _context.Categories.ToList();

            //oturum açmış kullanıcının adını alıyor
            string owner = User.Identity.Name;
           
            if (string.IsNullOrEmpty(owner))
            {
                //oturum açmayan kullanıcıyı sitede takip eder
                owner = HttpContext.Session.Id;
            }
            controller.ViewBag.CartItemCount =GetCart(owner).CartItems.Sum(c=>c.Quantity);
            base.OnActionExecuting(context);
        }
       protected Cart GetCart(string owner)
       {  
            Cart cart = _context.Carts.Include(i => i.CartItems).ThenInclude(t=>t.Product).Where(c => c.Owner == owner).FirstOrDefault();
            if (cart == null)
            {
                cart = new Cart();
                cart.Owner = owner;
                _context.Carts.Add(cart);
                _context.SaveChanges();
                
            }
            HttpContext.Session.SetString("CartId", cart.Id.ToString());
            return cart;
       }
    }
}
