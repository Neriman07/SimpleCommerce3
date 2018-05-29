using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly IDb vt;
        public BooksController(IDb veritabani)
        {
            vt = veritabani;
        }
        public IActionResult Index()
        {
            var books = vt.Books;
            return View(books);
        }
        public IActionResult Create()
        {
            var book = new Book();
            return View(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                // otomatik id için
                if (vt.Books.Count > 0)
                {
                    book.Id = vt.Books.Max(m => m.Id) + 1;
                } else
                {
                    book.Id = 1;
                }
                vt.Books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = vt.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            if (ModelState.IsValid) { 
                var oldBook = vt.Books.FirstOrDefault(b => b.Id == id);
                if (oldBook == null)
                {
                    return NotFound();
                }

                oldBook.Name = book.Name;
                oldBook.Author = book.Author;
                oldBook.PublishYear = book.PublishYear;
                oldBook.Category = book.Category;
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = vt.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            vt.Books.Remove(book);
            return RedirectToAction("Index");
        }
    }
}