using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SimpleCommerce3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Controllers
{
    public class ProductsController : ControllerBase
    {

        public ProductsController(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IActionResult> Index(int CategoryId , string order = "date-asc",int page=1, string sortExpression="CreateData")
        {
            ViewBag.LatestProducts = _context.Products.Where(ı => ı.IsPublished == true).OrderByDescending(o=>o.CreateData).Take(3).ToList();
            ViewBag.ProductCategories = _context.Categories.Include(c=>c.Products).ToList();
            ViewBag.SelectedCategory = _context.Categories.Where(c => c.Id == CategoryId).FirstOrDefault();
            var products = _context.Products.Where(p => (CategoryId != 0 ? p.CategoryId == CategoryId : true) && p.IsPublished == true);

            switch (order)
            {
                case "date-asc":
                    products = products.OrderBy(o => o.CreateData);
                    break;
                case "date-desc":
                    products = products.OrderByDescending(o => o.CreateData);
                    break;
                case "price-asc":
                    products = products.OrderBy(o => o.Price);
                    break;
                case "price-desc":
                    products = products.OrderByDescending(o => o.Price);
                    break;           

            }

            var model = await PagingList.CreateAsync(products, 10, page,sortExpression, "CreateData");
            model.RouteValue = new RouteValueDictionary { { "categoryId", CategoryId },{ "order", order } };
            return View(model);


        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(i => i.Category).Where(p => p.IsPublished == true && p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Summary(int id)
        {
            var product = _context.Products.Include(i => i.Category).Where(p => p.IsPublished == true && p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

    }
   
}
