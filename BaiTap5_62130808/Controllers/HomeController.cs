using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap5_62130808.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Default()
        {
            return View();
        }
        /*public ActionResult RegisterEmp()
        {
            return RedirectToAction("RegisterEmp", "RegisterEmp");
        }
        public ActionResult SendMail()
        {
            return RedirectToAction("SendMail", "SendMail");
        }
        public ActionResult ChangeBanner()
        {
            return RedirectToAction("ChangeBanner", "ChangeBanner");
        }*/
    }
}