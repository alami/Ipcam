using Ipcam.Data;
using Ipcam.Models;
using Ipcam.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ipcam.Controllers
{
    public class TariffController : Controller
    {
        private readonly StoreContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TariffController(StoreContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;            
        }
        public IActionResult Index()
        {
            IEnumerable<Tariff> objList = _db.Tariff;

            foreach (var obj in objList)
            {
                obj.Resolution = _db.Resolution.FirstOrDefault(u => u.Id == obj.ResolutionId);
            };

            return View(objList);            
        }

        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {            
            TariffVM tariffVM = new TariffVM()
            {
                Tariff = new Tariff(),
                ResolutionSelectList = _db.Resolution.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                PeriodSelectList = _db.Period.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(tariffVM);
            }
            else
            {
                tariffVM.Tariff = _db.Tariff.Find(id);
                if (tariffVM.Tariff == null)
                {
                    return NotFound();
                }
                return View(tariffVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TariffVM tariffVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (tariffVM.Tariff.Id == 0)
                {
                    //Creating
                    string upload = webRootPath + WC.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    tariffVM.Tariff.Image = fileName + extension;

                    _db.Tariff.Add(tariffVM.Tariff);
                }
                else
                {
                    //UPDATING
                    var objFromDb = _db.Tariff.AsNoTracking().FirstOrDefault(u => u.Id == tariffVM.Tariff.Id);

                    if (files.Count > 0)
                    {
                        string upload = webRootPath + WC.ImagePath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        var oldFile = Path.Combine(upload, objFromDb.Image);

                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        tariffVM.Tariff.Image = fileName + extension;
                    }
                    else
                    {
                        tariffVM.Tariff.Image = objFromDb.Image;
                    }
                    _db.Tariff.Update(tariffVM.Tariff);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Resolution.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Resolution.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Resolution.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
