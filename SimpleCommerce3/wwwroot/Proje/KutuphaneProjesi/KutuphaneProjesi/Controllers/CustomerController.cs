using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutuphaneProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneProjesi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDb vt;
        public CustomerController(IDb vt)
        {
            this.vt = vt;
        }
        public IActionResult Index()
        {
            var customer = vt.Customers;
            return View(customer);
        }
        public IActionResult Create()
        {
            var musteri = new Customers();
            return View(musteri);
        }
        [HttpPost]
        public IActionResult Create(Customers musteri)
        {
            //paramatreden gelen modelde sorun var mı kontrol et

            if (ModelState.IsValid)
            {
                //ıd değerini belirle
                if (vt.Customers.Count > 0)
                {
                    musteri.Id = vt.Customers.Max(d => d.Id) + 1;
                }
                else
                    musteri.Id = 1;
                //arkadas nesnesini veritabanına ekle
                vt.Customers.Add(musteri);
                // listeleme sayfasına git
                return RedirectToAction("Index");
            }
            return View(musteri);
        }
        public IActionResult Edit(int id)
        {
            var musteri = vt.Customers.FirstOrDefault(a => a.Id == id);


            return View(musteri);

        }
        [HttpPost]
        public IActionResult Edit(Customers gmusteri)
        {
            if (ModelState.IsValid)//friend de bir sorun var mı kontrolu
            {
                var musteri = vt.Customers.FirstOrDefault(a => a.Id == gmusteri.Id);
                musteri.Ad = gmusteri.Ad;
                musteri.Soyad = gmusteri.Soyad;
                musteri.UyelikTarihi = gmusteri.UyelikTarihi;

                return RedirectToAction("index");
            }
            return View(gmusteri);
        }
        public IActionResult Delete(int id)
        {
            var musteri = vt.Customers.FirstOrDefault(a => a.Id == id);
            vt.Customers.Remove(musteri);
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var musteri = vt.Customers.FirstOrDefault(a => a.Id == id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

    }

}