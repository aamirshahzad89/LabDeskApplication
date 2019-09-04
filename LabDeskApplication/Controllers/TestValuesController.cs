using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabDeskApplication.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using PagedList.Mvc;
using PagedList;

namespace LabDeskApplication.Controllers
{
    [Authorize]
    public class TestValuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        SqlConnection xConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        // GET: TestValues
        public ActionResult Index(string Search, int? page)
        {
            if (Search == null)
            {
                var testValues = db.TestValues.Include(t => t.LogInitialStyle).Include(t => t.SetupResult).Include(t => t.TestApproach);
                testValues = testValues.OrderByDescending(x => x.TestNameID);
                return View(testValues.ToList().ToPagedList(page ?? 1, 10));
            }
            else
            {
                var testValues = db.TestValues.Where(l => l.LogInitialStyle.LogInitialArticle.StyleCode.Contains(Search));
                return View(testValues.ToList().ToPagedList(page ?? 1, 10));
            }
        }
        public JsonResult UpdateResult(TestValues TV, Log03InitialStyle LIS)
        {
            //string msg = string.Empty;
            try
            {
                SqlCommand xCommand = new SqlCommand("SP_UpdateResult", xConn);
                xCommand.CommandType = CommandType.StoredProcedure;

                xCommand.Parameters.AddWithValue("@ResultID", TV.ResultID);
                xCommand.Parameters.AddWithValue("@StyleID", TV.StyleID);

                xConn.Open();
                xCommand.ExecuteNonQuery();
                xConn.Close();
                //msg = "Data Inserted";
                return Json("Successfully Updated", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
                //msg = "Error ...!";
                //return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: TestValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestValues testValues = db.TestValues.Find(id);
            if (testValues == null)
            {
                return HttpNotFound();
            }
            return View(testValues);
        }

        // GET: TestValues/Create
        public ActionResult Create()
        {
            List<TestApproach> data = db.TestApproach.ToList();
            var json = JsonConvert.SerializeObject(data);

            var fromDatabaseEF = new SelectList(data, "TestApproachID", "TestName");
            ViewData["DBMySkills"] = fromDatabaseEF;
            ViewData["DBMySkillsJson"] = json;

            ViewBag.StyleID = new SelectList(db.LogInitialStyle, "StyleID", "StyleID");
            ViewBag.ResultID = new SelectList(db.SetupResults, "ResultID", "ResultName");
            ViewBag.TestApproachID = new SelectList(db.TestApproach, "TestApproachID", "TestName");
            return View();
        }

        // POST: TestValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestNameID,TestDate,TestApproachID,TestValues01,TestValues02,TestValues03,TestValues04,TestValues05,ResultID,StyleID")] TestValues testValues)
        {
            if (ModelState.IsValid)
            {
                db.TestValues.Add(testValues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StyleID = new SelectList(db.LogInitialStyle, "StyleID", "StyleID", testValues.StyleID);
            ViewBag.ResultID = new SelectList(db.SetupResults, "ResultID", "ResultName", testValues.ResultID);
            ViewBag.TestApproachID = new SelectList(db.TestApproach, "TestApproachID", "TestName", testValues.TestApproachID);
            return View(testValues);
        }

        // GET: TestValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestValues testValues = db.TestValues.Find(id);
            if (testValues == null)
            {
                return HttpNotFound();
            }
            ViewBag.StyleID = new SelectList(db.LogInitialStyle, "StyleID", "StyleID", testValues.StyleID);
            ViewBag.ResultID = new SelectList(db.SetupResults, "ResultID", "ResultName", testValues.ResultID);
            ViewBag.TestApproachID = new SelectList(db.TestApproach, "TestApproachID", "TestName", testValues.TestApproachID);
            return View(testValues);
        }

        // POST: TestValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestNameID,TestDate,TestApproachID,TestValues01,TestValues02,TestValues03,TestValues04,TestValues05,ResultID,StyleID")] TestValues testValues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testValues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StyleID = new SelectList(db.LogInitialStyle, "StyleID", "StyleID", testValues.StyleID);
            ViewBag.ResultID = new SelectList(db.SetupResults, "ResultID", "ResultName", testValues.ResultID);
            ViewBag.TestApproachID = new SelectList(db.TestApproach, "TestApproachID", "TestName", testValues.TestApproachID);
            return View(testValues);
        }

        // GET: TestValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestValues testValues = db.TestValues.Find(id);
            if (testValues == null)
            {
                return HttpNotFound();
            }
            return View(testValues);
        }

        // POST: TestValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestValues testValues = db.TestValues.Find(id);
            db.TestValues.Remove(testValues);
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
