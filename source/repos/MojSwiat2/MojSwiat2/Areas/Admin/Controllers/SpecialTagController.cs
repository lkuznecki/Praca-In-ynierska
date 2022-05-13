using Microsoft.AspNetCore.Mvc;
using MojSwiat2.Data;
using MojSwiat2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojSwiat2.Areas.Admin.Controllers
{

        [Area("Admin")]
        public class SpecialTagController : Controller
        {

            private ApplicationDbContext _db;

            public SpecialTagController(ApplicationDbContext db)
            {
                _db = db;
            }
            public IActionResult Index()
            {
                //var data = _db.SpecialTag.ToList()
                return View(_db.SpecialTag.ToList());
            }

            //Create Get action method
            public ActionResult Create()
            {
                return View();
            }

            //Create Post action Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(SpecialTag specialTag)
            {
                if (ModelState.IsValid)
                {
                    _db.SpecialTag.Add(specialTag);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(specialTag);
            }

            //Create Get EDIT method
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var specialTag = _db.SpecialTag.Find(id);
                if (specialTag == null)
                {
                    return NotFound();
                }
                return View(specialTag);
            }

            //Create Post EDIT action Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(SpecialTag specialTag)
            {
                if (ModelState.IsValid)
                {
                    _db.Update(specialTag);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(specialTag);
            }

            //Create Get Details action method
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var specialTags = _db.SpecialTag.Find(id);
                if (specialTags == null)
                {
                    return NotFound();
                }
                return View(specialTags);
            }

            //Create Post EDIT action Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Details(SpecialTag specialTag)
            {
                return RedirectToAction(nameof(Index));


            }

            //Create Get Delete method
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var specialTags = _db.SpecialTag.Find(id);
                if (specialTags == null)
                {
                    return NotFound();
                }
                return View(specialTags);
            }

            //Create Post Delete action Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int? id, SpecialTag specialTag)
            {
                if (id == null)
                {
                    return NotFound();
                }

                if (id!=specialTag.Id)
                {
                    return NotFound();
                }
                var specialTags = _db.SpecialTag.Find(id);
                if (specialTags == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _db.Remove(specialTags);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(specialTag);
            }
        }
}
