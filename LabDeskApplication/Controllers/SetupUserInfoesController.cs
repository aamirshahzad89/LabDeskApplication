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
    public class SetupUserInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SetupUserInfoes
        public ActionResult Index()
        {
            return View(db.SetupUserInfoes.ToList());
        }

        // GET: SetupUserInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupUserInfo setupUserInfo = db.SetupUserInfoes.Find(id);
            if (setupUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(setupUserInfo);
        }

        // GET: SetupUserInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupUserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,Password,Role")] SetupUserInfo setupUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.SetupUserInfoes.Add(setupUserInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setupUserInfo);
        }

        // GET: SetupUserInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupUserInfo setupUserInfo = db.SetupUserInfoes.Find(id);
            if (setupUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(setupUserInfo);
        }

        // POST: SetupUserInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,Password,Role")] SetupUserInfo setupUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setupUserInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setupUserInfo);
        }

        // GET: SetupUserInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetupUserInfo setupUserInfo = db.SetupUserInfoes.Find(id);
            if (setupUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(setupUserInfo);
        }

        // POST: SetupUserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetupUserInfo setupUserInfo = db.SetupUserInfoes.Find(id);
            db.SetupUserInfoes.Remove(setupUserInfo);
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
