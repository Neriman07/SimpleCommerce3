using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCommerce3.Data;

namespace SimpleCommerce3.Areas.Admin
{
    public class HomeController : Controller


    {
        [Area("Admin")]
        [Authorize]

        public IActionResult Index()
        {
            return View();
        }
    }
}