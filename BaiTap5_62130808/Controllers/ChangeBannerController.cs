using BaiTap5_62130808.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap5_62130808.Controllers
{
    public class ChangeBannerController : Controller
    {
        // GET: ChangeBanner
        public ActionResult ChangeBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeBanner(HttpPostedFileBase banner)
        {
            string postedFileName =
           System.IO.Path.GetFileName(banner.FileName);
            var path = Server.MapPath("/Images/" + postedFileName);
            banner.SaveAs(path);
            string fSave = Server.MapPath("/banner.txt");
            System.IO.File.WriteAllText(fSave, postedFileName);
            return View();
        }
     
        /*public ActionResult Default()
        {
            return RedirectToAction("Default", "Home");
        }
        public ActionResult RegisterEmp()
        {
            return RedirectToAction("RegisterEmp", "RegisterEmp");
        }
        public ActionResult SendMail()
        {
            return RedirectToAction("SendMail", "SendMail");
        }*/
    }
}