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
    public class SetupVendorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SetupVendors
        public ActionResult Index()
        {
            return View(db.SetupVendors.ToList());
        }

        // GET: SetupVendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupVendor setupVendor = db.SetupVendors.Find(id);
            if (setupVendor == null)
            {
                return HttpNotFound();
            }
            return View(setupVendor);
        }

        // GET: SetupVendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupVendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,VendorName")] SetupVendor setupVendor)
        {
            if (ModelState.IsValid)
            {
                db.SetupVendors.Add(setupVendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setupVendor);
        }

        // GET: SetupVendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupVendor setupVendor = db.SetupVendors.Find(id);
            if (setupVendor == null)
            {
                return HttpNotFound();
            }
            return View(setupVendor);
        }

        // POST: SetupVendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,VendorName")] SetupVendor setupVendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setupVendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setupVendor);
        }

        // GET: SetupVendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupVendor setupVendor = db.SetupVendors.Find(id);
            if (setupVendor == null)
            {
                return HttpNotFound();
            }
            return View(setupVendor);
        }

        // POST: SetupVendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetupVendor setupVendor = db.SetupVendors.Find(id);
            db.SetupVendors.Remove(setupVendor);
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
