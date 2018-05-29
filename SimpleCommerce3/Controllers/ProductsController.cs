using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int categoryId)
        {

            return View();
        }

    }
   
}
