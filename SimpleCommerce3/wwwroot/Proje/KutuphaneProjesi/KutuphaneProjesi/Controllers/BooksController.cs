using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutuphaneProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneProjesi.Controllers
{
    public class BooksController : Controller
    {
        private readonly IDb vt;
        public BooksController(IDb vt)
        {
            this.vt = vt;
        }
        public IActionResult Index()
        {
            var books = vt.Books;
            return View(books);
        }
        public IActionResult Create()
        {
            var kitap = new Book();
            return View(kitap);
        }
        [HttpPost]
        public IActionResult Create(Book kitap)
        {
            //paramatreden gelen modelde sorun var mı kontrol et

            if (ModelState.IsValid)
            {
                //ıd değerini belirle(Id sayısını her eklemeden sonra arttır)
                if (vt.Books.Count > 0)
                {
                    kitap.Id = vt.Books.Max(d => d.Id) + 1;
                }
                else
                    kitap.Id = 1;
                //arkadas nesnesini veritabanına ekle
                vt.Books.Add(kitap);
                // listeleme sayfasına git
                return RedirectToAction("Index");
            }
            return View(kitap);
        }
        public IActionResult Edit(int id)
        {
            var book = vt.Books.FirstOrDefault(a => a.Id == id);
            if (book==null)
            {
                return NotFound();
            }

            return View(book);

        }
        [HttpPost]
        public IActionResult Edit(Book gKitap)
        {
            if (ModelState.IsValid)//friend de bir sorun var mı kontrolu
            {
                var book = vt.Books.FirstOrDefault(a => a.Id == gKitap.Id);
                book.Baslik = gKitap.Baslik;
                book.Yazar = gKitap.Yazar;
                book.BasimYili = gKitap.BasimYili;
                book.BaskiSayisi = gKitap.BaskiSayisi;
                book.Kategori = gKitap.Kategori;

                return RedirectToAction("index");
            }
            return View(gKitap);
        }
        public IActionResult Delete(int id)
        {
            var kitap = vt.Books.FirstOrDefault(a => a.Id == id);
            vt.Books.Remove(kitap);
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            var book = vt.Books.FirstOrDefault(a => a.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

    }
}