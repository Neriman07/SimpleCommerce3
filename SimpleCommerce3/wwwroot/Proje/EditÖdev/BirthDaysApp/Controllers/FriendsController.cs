using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthDaysApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthDaysApp.Controllers
{
    public class FriendsController : Controller
    {

        private readonly IDb veritabanı;
        public FriendsController(IDb veritabanı)
        {
            this.veritabanı = veritabanı;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var friends = veritabanı.Friends;
            return View(friends);
        }
        public IActionResult Create()
        {
            var arkadas = new Friend();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Friend arkadas)
        {
            //paramatreden gelen modelde sorun var mı kontrol et

            if (ModelState.IsValid)
            {
                //ıd değerini belirle
                if (veritabanı.Friends.Count>0)
                {
                    arkadas.Id = veritabanı.Friends.Max(d => d.Id) + 1;
                }
                else
                    arkadas.Id = 1;
                //arkadas nesnesini veritabanına ekle
                veritabanı.Friends.Add(arkadas);
                // listeleme sayfasına git
                return RedirectToAction("Index");
            }
            return View(arkadas);
        }
        
        public IActionResult Edit(int id)
        {
            var arkadas = veritabanı.Friends.FirstOrDefault(a=> a.Id==id);


            return View(arkadas);

        }
        [HttpPost]
        public IActionResult Edit(Friend guncelArkadas)
        {
            if (ModelState.IsValid)//friend de bir sorun var mı kontrolu
            {
            var arkadas = veritabanı.Friends.FirstOrDefault(a =>a.Id==guncelArkadas.Id);
            arkadas.Name = guncelArkadas.Name;
            arkadas.BirthDate = guncelArkadas.BirthDate;
                
                return RedirectToAction("index");
             }
            return View(guncelArkadas);
        }


        public IActionResult Delete(int id)
        {
            var arkadas = veritabanı.Friends.FirstOrDefault(a => a.Id == id);
            veritabanı.Friends.Remove(arkadas);
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var arkadas= veritabanı.Friends.FirstOrDefault(a => a.Id ==id);
            if (arkadas==null)
            {
                return NotFound();
            }
            return View(arkadas);
        }
    }
}
