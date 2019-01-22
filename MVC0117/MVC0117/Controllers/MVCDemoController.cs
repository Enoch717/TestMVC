using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC0117.Controllers
{
    public class MVCDemoController : Controller
    {
        // GET: MVCDemo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HelperTest()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ShowWidget()
        {
            return PartialView("~/Views/Shared/_PartialPageWidget.cshtml");
        }

        public ActionResult SharedDateDemo()
        {
            ViewBag.Datetime = DateTime.Now;
            return View();
        }

        [ChildActionOnly]
        public ActionResult PartialViewDate()
        {
            ViewBag.Datetime = DateTime.Now.AddMinutes(10);
            return PartialView("_PartialPageDateTime");
        }

    }
}