using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{
    public class DaysController : Controller
    {
        private readonly IDb db;
        public DaysController(IDb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var days = db.Days;
            return View(days);
        }
        public IActionResult Create()
        {
            var day = new Day();
            return View(day);
        }
        [HttpPost]
        public IActionResult Create(Day day)
        {
            if (ModelState.IsValid)
            {
                if (db.Days.Count > 0)
                {
                    day.Id = db.Days.Max(d => d.Id) + 1;
                }
                else
                    day.Id = 1;
                
                db.Days.Add(day);
                return RedirectToAction("Index");
            }
            return View(day);
        }
    }
}