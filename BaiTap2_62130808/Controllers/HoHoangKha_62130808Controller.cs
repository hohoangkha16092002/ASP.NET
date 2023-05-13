using BT2_62130808.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT2_62130808.Controllers
{
    public class HoHoangKha_62130808Controller : Controller
    {
        // GET: HoHoangKha_62130808
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //Request
        public ActionResult Register1()
        {
            string Id = Request["Id"];
            string Name = Request["Name"];
            double Marks = Convert.ToDouble(Request["Marks"]);
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Marks = Marks;
            return View();
        }
        [HttpPost]
        //Đối số của Action
        public ActionResult Register2(string Id, string Name, double Marks)
        {
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Marks = Marks;
            return View();
        }
        [HttpPost]
        // Form Collection
        public ActionResult Register3(FormCollection field)
        {
            ViewBag.Id = field["Id"];
            ViewBag.Name = field["Name"];
            ViewBag.Marks = field["Marks"];
            return View(ViewBag);
        }
        [HttpPost]
        //Model
        public ActionResult Register4(SinhVienModel sv)
        {
            ViewBag.Id = sv.Id;
            ViewBag.Name = sv.Name;
            ViewBag.Marks = sv.Marks;
            return View(ViewBag);
        }
        [HttpPost]
        public ActionResult Detail()
        {
            ViewBag.Id = "SV001";
            ViewBag.Name = "Nguyễn Tuấn Anh";
            ViewData["Marks"] = 9.5;
            return View();
        }
    }
}