using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.DAL;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class SarkiController : Controller
    {
        private SarkiContext db = new SarkiContext();

        // GET: Sarki
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Sure" ? "date_desc" : "Sure";
            var sarkilar = from s in db.Sarkilar
                           select s;
          

            if (!String.IsNullOrEmpty(searchString)) { sarkilar = sarkilar.Where(s => s.sarki_adi.ToUpper().Contains(searchString.ToUpper())); }

            switch (sortOrder)
            {
                case "name_desc":
                    sarkilar = sarkilar.OrderByDescending(s => s.sarki_adi);
                    break;
                case "Sure":
                    sarkilar = sarkilar.OrderBy(s => s.sarki_suresi);
                    break;
                case "date_desc":
                    sarkilar = sarkilar.OrderByDescending(s => s.sarki_suresi);
                    break;
                default:
                    sarkilar = sarkilar.OrderBy(s => s.sarki_adi);
                    break;
            }
            return View(sarkilar.ToList());
            
        }

        // GET: Sarki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sarki sarki = db.Sarkilar.Find(id);
            if (sarki == null)
            {
                return HttpNotFound();
            }
            return View(sarki);
        }

        // GET: Sarki/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sarki/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SarkiID,sarki_adi,sarki_suresi,Secret")] Sarki sarki)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Sarkilar.Add(sarki);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(sarki);
        }

        // GET: Sarki/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sarki sarki = db.Sarkilar.Find(id);
            if (sarki == null)
            {
                return HttpNotFound();
            }
            return View(sarki);
        }

        // POST: Sarki/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SarkiID,sarki_adi,sarki_suresi,Secret")] Sarki sarki)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(sarki).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(sarki);
        }

        // GET: Sarki/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Sarki sarki = db.Sarkilar.Find(id);
            if (sarki == null)
            {
                return HttpNotFound();
            }
            return View(sarki);
        }

        // POST: Sarki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Sarki sarki = db.Sarkilar.Find(id);
                db.Sarkilar.Remove(sarki);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Album()
        {
            var albumler = from s in db.Albumler
                           select s;
            return View(albumler.ToList());
        }

        public ActionResult Dinle()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
