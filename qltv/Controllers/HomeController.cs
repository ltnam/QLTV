using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qltv.Models;

namespace qltv.Controllers
{
    public class HomeController : Controller
    {
        private QLTVEntities1 db = new QLTVEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name,string password)
        {
            if(name =="admin" && password == "123")
            {
                Session["user"] = new User() { Login = name, Name = "Lai Quang Hung" };
                return RedirectToAction("dIndex", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult About()
        {
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