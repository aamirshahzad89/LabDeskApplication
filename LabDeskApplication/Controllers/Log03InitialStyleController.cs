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
    public class Log03InitialStyleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Log03InitialStyle
        public ActionResult Index(string Search, int? page)
        {
            if (Search == null)
            {
                var logInitialStyle = db.LogInitialStyle.Include(l => l.LogInitialArticle).Include(l => l.SetupArticleType).Include(l => l.SetupColour).Include(l => l.SetupResult).Include(l => l.SetupUserInfo);
                logInitialStyle = logInitialStyle.OrderByDescending(x => x.ArticleID);
                return View(logInitialStyle.ToList().ToPagedList(page ?? 1, 10));
            }
            else
            {
                var log03InitialStyle = db.LogInitialStyle.Where(l => l.LogInitialArticle.StyleCode.Contains(Search));
                return View(log03InitialStyle.ToList().ToPagedList(page ?? 1, 10));
            }
        }

        // GET: Log03InitialStyle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log03InitialStyle log03InitialStyle = db.LogInitialStyle.Find(id);
            if (log03InitialStyle == null)
            {
                return HttpNotFound();
            }
            return View(log03InitialStyle);
        }

        // GET: Log03InitialStyle/Create
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.LogInitialArticle, "ArticleID", "StyleCode");
            ViewBag.ArticleTypeId = new SelectList(db.SetupArticleTypes, "ArticleTypeId", "ArticleType");
            ViewBag.ColourID = new SelectList(db.SetupColours, "ColourID", "ColourName");
            ViewBag.ResultID = new SelectList(db.SetupResults, "ResultID", "ResultName");
            ViewBag.UserID = new SelectList(db.SetupUserInfoes, "UserID", "UserName");
            return View();
        }

        // POST: Log03InitialStyle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StyleID,SampleDate,Sample,Volume,Year,Width,ColourID,ArticleTypeId,ResultID,UserID,ArticleID")] Log03InitialStyle log03InitialStyle)
        {
            if (ModelState.IsValid)
            {
                db.LogInitialStyle.Add(log03InitialStyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.LogInitialArticle, "ArticleID", "StyleCode", log03InitialStyle.ArticleID);
            ViewBag.ArticleTypeId = new SelectList(db.SetupArticleTypes, "ArticleTypeId", "ArticleType", log03InitialStyle.ArticleTypeId);
            ViewBag.ColourID = new SelectList(db.SetupColours, "ColourID", "ColourName", log03InitialStyle.ColourID);
            ViewBag.ResultID = new SelectList(db.SetupResults, "ResultID", "ResultName", log03InitialStyle.ResultID);
            ViewBag.UserID = new SelectList(db.SetupUserInfoes, "UserID", "UserName", log03InitialStyle.UserID);
            return View(log03InitialStyle);
        }

        // GET: Log03InitialStyle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log03InitialStyle log03InitialStyle = db.LogInitialStyle.Find(id);
            if (log03InitialStyle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.LogInitialArticle, "ArticleID", "StyleCode", log03InitialStyle.ArticleID);
            ViewBag.ArticleTypeId = new SelectList(db.SetupArticleTypes, "ArticleTypeId", "ArticleType", log03InitialStyle.ArticleTypeId);
            ViewBag.ColourID = new SelectList(db.SetupColours, "ColourID", "ColourName", log03InitialStyle.ColourID);
            ViewBag.ResultID = new SelectList(db.SetupResults, "ResultID", "ResultName", log03InitialStyle.ResultID);
            ViewBag.UserID = new SelectList(db.SetupUserInfoes, "UserID", "UserName", log03InitialStyle.UserID);
            return View(log03InitialStyle);
        }

        // POST: Log03InitialStyle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StyleID,SampleDate,Sample,Volume,Year,Width,ColourID,ArticleTypeId,ResultID,UserID,ArticleID")] Log03InitialStyle log03InitialStyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log03InitialStyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.LogInitialArticle, "ArticleID", "StyleCode", log03InitialStyle.ArticleID);
            ViewBag.ArticleTypeId = new SelectList(db.SetupArticleTypes, "ArticleTypeId", "ArticleType", log03InitialStyle.ArticleTypeId);
            ViewBag.ColourID = new SelectList(db.SetupColours, "ColourID", "ColourName", log03InitialStyle.ColourID);
            ViewBag.ResultID = new SelectList(db.SetupResults, "ResultID", "ResultName", log03InitialStyle.ResultID);
            ViewBag.UserID = new SelectList(db.SetupUserInfoes, "UserID", "UserName", log03InitialStyle.UserID);
            return View(log03InitialStyle);
        }

        // GET: Log03InitialStyle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log03InitialStyle log03InitialStyle = db.LogInitialStyle.Find(id);
            if (log03InitialStyle == null)
            {
                return HttpNotFound();
            }
            return View(log03InitialStyle);
        }

        // POST: Log03InitialStyle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Log03InitialStyle log03InitialStyle = db.LogInitialStyle.Find(id);
            db.LogInitialStyle.Remove(log03InitialStyle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Proceed(int Id)
        {
            return RedirectToAction("Create", new RouteValueDictionary(new { controller = "TestValues", action = "Create", Id = Id }));
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
