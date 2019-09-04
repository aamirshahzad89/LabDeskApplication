using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabDeskApplication.Models;
using System.Web.Routing;
using PagedList.Mvc;
using PagedList;

namespace LabDeskApplication.Controllers
{
    [Authorize]
    public class Log01InitialVendorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Log01InitialVendor
        public ActionResult Index(string Search, int ? page)
        {
            if (Search == null)
            {
                var log01InitialVendor = db.LogInitialVendor.Include(l => l.SetupVendor);
                log01InitialVendor = log01InitialVendor.OrderByDescending(x => x.FormDate);
                return View(log01InitialVendor.ToList().ToPagedList(page ?? 1, 10));
            }
            else
            {
                var log01InitialVendor = db.LogInitialVendor.Where(l => l.LabID.Contains(Search));
                return View(log01InitialVendor.ToList().ToPagedList(page ?? 1, 10));
            }
        }

        // GET: Log01InitialVendor/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log01InitialVendor log01InitialVendor = db.LogInitialVendor.Find(id);
            if (log01InitialVendor == null)
            {
                return HttpNotFound();
            }
            return View(log01InitialVendor);
        }

        // GET: Log01InitialVendor/Create
        public ActionResult Create()
        {
            ViewBag.VendorID = new SelectList(db.SetupVendors, "VendorID", "VendorName");
            return View();
        }

        // POST: Log01InitialVendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LabID,FormDate,Composition,VendorID")] Log01InitialVendor log01InitialVendor)
        {
            if (ModelState.IsValid)
            {
                db.LogInitialVendor.Add(log01InitialVendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendorID = new SelectList(db.SetupVendors, "VendorID", "VendorName", log01InitialVendor.VendorID);
            return View(log01InitialVendor);
        }

        // GET: Log01InitialVendor/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log01InitialVendor log01InitialVendor = db.LogInitialVendor.Find(id);
            if (log01InitialVendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorID = new SelectList(db.SetupVendors, "VendorID", "VendorName", log01InitialVendor.VendorID);
            return View(log01InitialVendor);
        }

        // POST: Log01InitialVendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LabID,FormDate,Composition,VendorID")] Log01InitialVendor log01InitialVendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log01InitialVendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorID = new SelectList(db.SetupVendors, "VendorID", "VendorName", log01InitialVendor.VendorID);
            return View(log01InitialVendor);
        }

        // GET: Log01InitialVendor/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log01InitialVendor log01InitialVendor = db.LogInitialVendor.Find(id);
            if (log01InitialVendor == null)
            {
                return HttpNotFound();
            }
            return View(log01InitialVendor);
        }

        // POST: Log01InitialVendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Log01InitialVendor log01InitialVendor = db.LogInitialVendor.Find(id);
            db.LogInitialVendor.Remove(log01InitialVendor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Proceed(string Id)
        {
            return RedirectToAction("Create", new RouteValueDictionary(new { controller = "Log02InitialArticle", action = "Create", Id = Id }));
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
