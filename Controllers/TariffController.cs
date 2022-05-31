using Ipcam.Data;
using Ipcam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Ipcam.Controllers
{
    public class TariffController : Controller
    {
        private readonly StoreContext _db;
        public TariffController(StoreContext db)
        {
            _db = db;
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
            IEnumerable<SelectListItem> ResolutionDropDown = _db.Resolution.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.ResolutionDropDown = ResolutionDropDown;

            IEnumerable<SelectListItem> PeriodDropDown = _db.Period.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.PeriodDropDown = PeriodDropDown;

            Tariff tariff = new Tariff();
            if (id == null)
            {
                //this is for create
                return View(tariff);
            }
            else
            {
                tariff = _db.Tariff.Find(id);
                if (tariff == null)
                {
                    return NotFound();
                }
                return View(tariff);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Tariff obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tariff.Add(obj);
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
