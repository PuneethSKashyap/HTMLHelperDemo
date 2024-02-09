using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlHelperDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult StandardHtmlHelper()
        {
            return View();
        }
        public ActionResult StronglyHtmlHelper()
        {
            return View();
        }
    }
}