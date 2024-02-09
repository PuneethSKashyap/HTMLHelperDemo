using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HtmlHelperDemo.Models;

namespace HtmlHelperDemo.Controllers
{
    public class UserController : Controller
    {
        UserDAL userobj;
        //fetch user details from users table
        //read operation
        public UserController() {
            userobj = new UserDAL();
        }
        
        public ActionResult UserDetailsT()
        {
            List<User> users = userobj.GetUsers();
            ViewData["datetime"] = DateTime.Now.ToString();
            ViewData["userinfo"] = users;
            ViewBag.userinfo = users;
            TempData["Company"] = "cloudkampus";
            TempData["estyear"] = 1998;
            TempData["userinfo"] = users;
            TempData.Keep("Company");
            TempData.Keep("estyear");
            TempData.Keep("userinfo");
            return View();
        }
        public ActionResult GetTempData() {
            return View();
        }
        public ActionResult GetTempData2()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            User user = userobj.GetUserbyId(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult SignUpT()
        {
            return View();
        }
        [HttpPost]
        //create new user (stored in users table)
        public ActionResult SignUpT(User user)
        {
            userobj.AddUser(user);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = userobj.GetUserbyId(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            userobj.updateUser(user);
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            User user = userobj.GetUserbyId(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(User user)
        {
            userobj.DeleteUser(user);
            return View();
        }

    }
}