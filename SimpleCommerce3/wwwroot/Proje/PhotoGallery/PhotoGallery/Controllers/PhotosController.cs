using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Models;

namespace PhotoGallery.Controllers
{
    public class PhotosController : Controller
    {
        private IHostingEnvironment _environment;
        private IDb db;
        public PhotosController(IDb db, IHostingEnvironment hostingEnvironment)
        {
            this.db = db;
            _environment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var photos = db.Photos;
            return View(photos);
        }

        public IActionResult Create()
        {
            var photo = new Photo();
            return View(photo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Photo photo, IFormFile upload)
        {
            if (ModelState.IsValid)
            {
                if (db.Photos.Count > 0)
                {
                    photo.Id = db.Photos.Max(m => m.Id) + 1;
                } else
                {
                    photo.Id = 1;
                }
                if (upload != null && upload.Length > 0)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "Uploads", upload.FileName);
                    var directory = Path.Combine(_environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await upload.CopyToAsync(stream);
                    }
                    photo.File = upload.FileName;
                }
                db.Photos.Add(photo);
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        public IActionResult Edit(int id)
        {
            var photo = db.Photos.Where(w => w.Id == id).FirstOrDefault();
            return View(photo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Photo photo, IFormFile upload)
        {
            if (ModelState.IsValid)
            {
                var oldPhoto = db.Photos.FirstOrDefault(p => p.Id == id);
                if (upload != null && upload.Length > 0)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "Uploads", upload.FileName);
                    var directory = Path.Combine(_environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await upload.CopyToAsync(stream);
                    }
                    oldPhoto.File = upload.FileName;
                }
                oldPhoto.Name = photo.Name;
                oldPhoto.Description = photo.Description;
                return RedirectToAction("Index");
            }
            return View(photo);
        }
    }
}