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
    public class SetupProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SetupProducts
        public ActionResult Index()
        {
            return View(db.SetupProducts.ToList());
        }

        // GET: SetupProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupProduct setupProduct = db.SetupProducts.Find(id);
            if (setupProduct == null)
            {
                return HttpNotFound();
            }
            return View(setupProduct);
        }

        // GET: SetupProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName")] SetupProduct setupProduct)
        {
            if (ModelState.IsValid)
            {
                db.SetupProducts.Add(setupProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setupProduct);
        }

        // GET: SetupProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupProduct setupProduct = db.SetupProducts.Find(id);
            if (setupProduct == null)
            {
                return HttpNotFound();
            }
            return View(setupProduct);
        }

        // POST: SetupProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName")] SetupProduct setupProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setupProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setupProduct);
        }

        // GET: SetupProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupProduct setupProduct = db.SetupProducts.Find(id);
            if (setupProduct == null)
            {
                return HttpNotFound();
            }
            return View(setupProduct);
        }

        // POST: SetupProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetupProduct setupProduct = db.SetupProducts.Find(id);
            db.SetupProducts.Remove(setupProduct);
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
