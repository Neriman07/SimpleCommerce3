﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCommerce3.Data;
using SimpleCommerce3.Models;

namespace SimpleCommerce3.Controllers
{
    public class HomeController : ControllerBase
    {
       
        public HomeController(ApplicationDbContext context):base(context)
        {
           
        }
        public IActionResult Index()
        {
            ViewBag.FeaturedProducts = _context.Products.Take(8).ToList();
            ViewBag.BrowserOurCategories = _context.Categories.Take(4).ToList();
            ViewBag.Slides = _context.Slides.Where(s=> s.IsPublished==true).OrderBy(o=>o.Position).Take(3).ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
