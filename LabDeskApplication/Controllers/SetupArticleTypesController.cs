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
    public class SetupArticleTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SetupArticleTypes
        public ActionResult Index()
        {
            return View(db.SetupArticleTypes.ToList());
        }

        // GET: SetupArticleTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupArticleType setupArticleType = db.SetupArticleTypes.Find(id);
            if (setupArticleType == null)
            {
                return HttpNotFound();
            }
            return View(setupArticleType);
        }

        // GET: SetupArticleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupArticleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleTypeId,ArticleType")] SetupArticleType setupArticleType)
        {
            if (ModelState.IsValid)
            {
                db.SetupArticleTypes.Add(setupArticleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setupArticleType);
        }

        // GET: SetupArticleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupArticleType setupArticleType = db.SetupArticleTypes.Find(id);
            if (setupArticleType == null)
            {
                return HttpNotFound();
            }
            return View(setupArticleType);
        }

        // POST: SetupArticleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleTypeId,ArticleType")] SetupArticleType setupArticleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setupArticleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setupArticleType);
        }

        // GET: SetupArticleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupArticleType setupArticleType = db.SetupArticleTypes.Find(id);
            if (setupArticleType == null)
            {
                return HttpNotFound();
            }
            return View(setupArticleType);
        }

        // POST: SetupArticleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetupArticleType setupArticleType = db.SetupArticleTypes.Find(id);
            db.SetupArticleTypes.Remove(setupArticleType);
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
