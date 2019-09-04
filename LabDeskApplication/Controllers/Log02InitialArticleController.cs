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
    public class Log02InitialArticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Log02InitialArticle
        public ActionResult Index(string Search, int? page)
        {
            if (Search == null)
            {
                var log02InitialArticle = db.LogInitialArticle.Include(l => l.LogInitialVendor).Include(l => l.SetupProduct);
                log02InitialArticle = log02InitialArticle.OrderByDescending(x => x.ArticleID);
                return View(log02InitialArticle.ToList().ToPagedList(page ?? 1, 10));
            }
            else
            {
                var log02InitialArticle = db.LogInitialArticle.Where(l => l.StyleCode.Contains(Search));
                return View(log02InitialArticle.ToList().ToPagedList(page ?? 1, 10));
            }

        }

        // GET: Log02InitialArticle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log02InitialArticle log02InitialArticle = db.LogInitialArticle.Find(id);
            if (log02InitialArticle == null)
            {
                return HttpNotFound();
            }
            return View(log02InitialArticle);
        }

        // GET: Log02InitialArticle/Create
        public ActionResult Create()
        {
            ViewBag.LabID = new SelectList(db.LogInitialVendor, "LabID", "LabID");
            ViewBag.ProductID = new SelectList(db.SetupProducts, "ProductID", "ProductName");
            return View();
        }

        // POST: Log02InitialArticle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleID,StyleCode,ProductID,LabID")] Log02InitialArticle log02InitialArticle)
        {
            if (ModelState.IsValid)
            {
                db.LogInitialArticle.Add(log02InitialArticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LabID = new SelectList(db.LogInitialVendor, "LabID", "LabID", log02InitialArticle.LabID);
            ViewBag.ProductID = new SelectList(db.SetupProducts, "ProductID", "ProductName", log02InitialArticle.ProductID);
            return View(log02InitialArticle);
        }

        // GET: Log02InitialArticle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log02InitialArticle log02InitialArticle = db.LogInitialArticle.Find(id);
            if (log02InitialArticle == null)
            {
                return HttpNotFound();
            }
            ViewBag.LabID = new SelectList(db.LogInitialVendor, "LabID", "LabID", log02InitialArticle.LabID);
            ViewBag.ProductID = new SelectList(db.SetupProducts, "ProductID", "ProductName", log02InitialArticle.ProductID);
            return View(log02InitialArticle);
        }

        // POST: Log02InitialArticle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleID,StyleCode,ProductID,LabID")] Log02InitialArticle log02InitialArticle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log02InitialArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LabID = new SelectList(db.LogInitialVendor, "LabID", "LabID", log02InitialArticle.LabID);
            ViewBag.ProductID = new SelectList(db.SetupProducts, "ProductID", "ProductName", log02InitialArticle.ProductID);
            return View(log02InitialArticle);
        }

        // GET: Log02InitialArticle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log02InitialArticle log02InitialArticle = db.LogInitialArticle.Find(id);
            if (log02InitialArticle == null)
            {
                return HttpNotFound();
            }
            return View(log02InitialArticle);
        }

        // POST: Log02InitialArticle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Log02InitialArticle log02InitialArticle = db.LogInitialArticle.Find(id);
            db.LogInitialArticle.Remove(log02InitialArticle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Proceed(int Id)
        {
            return RedirectToAction("Create", new RouteValueDictionary(new { controller = "Log03InitialStyle", action = "Create", Id = Id }));
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
