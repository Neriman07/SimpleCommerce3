using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IDb vt;
        public CustomersController(IDb veritabani)
        {
            vt = veritabani;
        }
        public IActionResult Index()
        {
            var customers = vt.Customers;
            return View(customers);
        }
        public IActionResult AddBook(int customerId, int bookId)
        {
            var customer = vt.Customers.FirstOrDefault(c => c.Id == customerId);
            var book = vt.Books.FirstOrDefault(b => b.Id == bookId);
            if (customer != null && book != null) { 
                customer.RecievedBooks.Add(book);
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult ListBooks(int customerId)
        {
            var customer = vt.Customers.FirstOrDefault(c => c.Id == customerId);
            ViewBag.Books = vt.Books;
            return View(customer.RecievedBooks);
        }

        public IActionResult Create()
        {
            var customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // otomatik id için
                if (vt.Customers.Count > 0)
                {
                    customer.Id = vt.Customers.Max(m => m.Id) + 1;
                } else
                {
                    customer.Id = 1;
                }
                vt.Customers.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = vt.Customers.FirstOrDefault(b => b.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            if (ModelState.IsValid) { 
                var oldCustomer = vt.Customers.FirstOrDefault(b => b.Id == id);
                if (oldCustomer == null)
                {
                    return NotFound();
                }

                oldCustomer.FirstName = customer.FirstName;
                oldCustomer.LastName = customer.LastName;
                oldCustomer.MembershipDate = customer.MembershipDate;
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = vt.Customers.FirstOrDefault(b => b.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            vt.Customers.Remove(customer);
            return RedirectToAction("Index");
        }
    }
}