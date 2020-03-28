using FlexGains.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlexGains.Controllers
{
    public class HomeController : Controller
    {
        private FlexGainsEntities db = new FlexGainsEntities();
        public ActionResult Index()
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.UserDisplayName = db.Accounts.Find(User.Identity.GetUserId())?.UserName;
            ViewBag.Message = "Your contact page.";

            return View();
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