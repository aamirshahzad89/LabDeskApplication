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
    public class SetupResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SetupResults
        public ActionResult Index()
        {
            return View(db.SetupResults.ToList());
        }

        // GET: SetupResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupResult setupResult = db.SetupResults.Find(id);
            if (setupResult == null)
            {
                return HttpNotFound();
            }
            return View(setupResult);
        }

        // GET: SetupResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResultID,ResultName")] SetupResult setupResult)
        {
            if (ModelState.IsValid)
            {
                db.SetupResults.Add(setupResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setupResult);
        }

        // GET: SetupResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupResult setupResult = db.SetupResults.Find(id);
            if (setupResult == null)
            {
                return HttpNotFound();
            }
            return View(setupResult);
        }

        // POST: SetupResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResultID,ResultName")] SetupResult setupResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setupResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setupResult);
        }

        // GET: SetupResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupResult setupResult = db.SetupResults.Find(id);
            if (setupResult == null)
            {
                return HttpNotFound();
            }
            return View(setupResult);
        }

        // POST: SetupResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetupResult setupResult = db.SetupResults.Find(id);
            db.SetupResults.Remove(setupResult);
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
