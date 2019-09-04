using LabDeskApplication.Models;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace LabDeskApplication.Controllers
{
    public class FetchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult FetchData(string SearchBy, string Search, int ? page)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (SearchBy == "LabID")
                {
                    var logInitialStyle = db.LogInitialStyle.Where(x => x.LogInitialArticle.LogInitialVendor.LabID == Search);
                    logInitialStyle = logInitialStyle.OrderByDescending(x => x.LogInitialArticle.LogInitialVendor.FormDate);
                    return View(logInitialStyle.ToList().ToPagedList(page ?? 1, 10));
                }
                else if (SearchBy == "StyleCode")
                {
                    var logInitialStyle = db.LogInitialStyle.Where(x => x.LogInitialArticle.StyleCode.Contains(Search));
                    logInitialStyle = logInitialStyle.OrderByDescending(x => x.LogInitialArticle.ArticleID);
                    return View(logInitialStyle.ToList().ToPagedList(page ?? 1, 10));
                }
                else
                {
                    var logInitialStyle = db.LogInitialStyle.OrderByDescending(x => x.LogInitialArticle.LogInitialVendor.FormDate);
                    return View(logInitialStyle.ToList().ToPagedList(page ?? 1, 10));
                }
            }
            else
            {
                if (SearchBy == "LabID")
                {
                    var logInitialStyle = db.LogInitialStyle.Where(x => x.LogInitialArticle.LogInitialVendor.LabID == Search);
                    logInitialStyle = logInitialStyle.OrderByDescending(x => x.LogInitialArticle.LogInitialVendor.FormDate);
                    return View(logInitialStyle.ToList().ToPagedList(page ?? 1, 10));
                }
                else if (SearchBy == "StyleCode")
                {
                    var logInitialStyle = db.LogInitialStyle.Where(x => x.LogInitialArticle.StyleCode == Search);
                    logInitialStyle = logInitialStyle.OrderByDescending(x => x.LogInitialArticle.ArticleID);
                    return View(logInitialStyle.ToList().ToPagedList(page ?? 1, 10));
                }
                else
                {
                    var logInitialStyle = db.LogInitialStyle.Where(x => x.LogInitialArticle.LogInitialVendor.LabID == "");
                    return View(logInitialStyle.ToList().ToPagedList(page ?? 1, 10));
                }
            }
        }
        // GET: Fetch
        public ActionResult Index()
        {
            return View();
        }
    }
}