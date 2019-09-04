using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabDeskApplication.Models;

namespace LabDeskApplication.Controllers
{
    [Authorize]
    public class SetupColoursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SetupColours
        public ActionResult Index()
        {
            return View(db.SetupColours.ToList());
        }

        // GET: SetupColours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupColour setupColour = db.SetupColours.Find(id);
            if (setupColour == null)
            {
                return HttpNotFound();
            }
            return View(setupColour);
        }

        // GET: SetupColours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupColours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColourID,ColourName")] SetupColour setupColour)
        {
            if (ModelState.IsValid)
            {
                db.SetupColours.Add(setupColour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setupColour);
        }

        // GET: SetupColours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupColour setupColour = db.SetupColours.Find(id);
            if (setupColour == null)
            {
                return HttpNotFound();
            }
            return View(setupColour);
        }

        // POST: SetupColours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColourID,ColourName")] SetupColour setupColour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setupColour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setupColour);
        }

        // GET: SetupColours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupColour setupColour = db.SetupColours.Find(id);
            if (setupColour == null)
            {
                return HttpNotFound();
            }
            return View(setupColour);
        }

        // POST: SetupColours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetupColour setupColour = db.SetupColours.Find(id);
            db.SetupColours.Remove(setupColour);
            db.SaveChanges();
            return RedirectToAction("Index");
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
