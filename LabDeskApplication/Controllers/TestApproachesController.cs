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
    public class TestApproachesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestApproaches
        public ActionResult Index()
        {
            return View(db.TestApproach.ToList());
        }

        // GET: TestApproaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestApproach testApproach = db.TestApproach.Find(id);
            if (testApproach == null)
            {
                return HttpNotFound();
            }
            return View(testApproach);
        }

        // GET: TestApproaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestApproaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestApproachID,TestName,TestStandard,TestApproachName01,TestApproachName02,TestApproachName03,TestApproachName04,TestApproachName05,Remarks")] TestApproach testApproach)
        {
            if (ModelState.IsValid)
            {
                db.TestApproach.Add(testApproach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testApproach);
        }

        // GET: TestApproaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestApproach testApproach = db.TestApproach.Find(id);
            if (testApproach == null)
            {
                return HttpNotFound();
            }
            return View(testApproach);
        }

        // POST: TestApproaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestApproachID,TestName,TestStandard,TestApproachName01,TestApproachName02,TestApproachName03,TestApproachName04,TestApproachName05,Remarks")] TestApproach testApproach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testApproach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testApproach);
        }

        // GET: TestApproaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestApproach testApproach = db.TestApproach.Find(id);
            if (testApproach == null)
            {
                return HttpNotFound();
            }
            return View(testApproach);
        }

        // POST: TestApproaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestApproach testApproach = db.TestApproach.Find(id);
            db.TestApproach.Remove(testApproach);
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
