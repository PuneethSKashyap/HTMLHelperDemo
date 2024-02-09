using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlHelperDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["name"] = "puneeth";
            TempData["age"] = 32;
            TempData.Keep("name");
            TempData.Keep("age");
            return View();
        }

        public ActionResult About()
        {
            TempData.Keep("name");
            TempData.Keep("age");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}