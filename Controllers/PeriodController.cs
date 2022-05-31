using Ipcam.Data;
using Ipcam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ipcam.Controllers
{
    public class PeriodController : Controller
    {
        private readonly StoreContext _db;
        public PeriodController(StoreContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Period> objList = _db.Period;
            return View(objList);
        }
        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Period obj)
        {
            if (ModelState.IsValid)
            {
                _db.Period.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Period.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Period obj)
        {
            if (ModelState.IsValid)
            {
                _db.Period.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Period.Find(id);
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
            var obj = _db.Period.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Period.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
