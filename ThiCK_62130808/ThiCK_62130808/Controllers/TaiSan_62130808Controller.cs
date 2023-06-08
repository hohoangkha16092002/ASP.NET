using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiCK_62130808.Models;

namespace ThiCK_62130808.Controllers
{
    public class TaiSan_62130808Controller : Controller
    {
        private ThiCK_62130808Entities db = new ThiCK_62130808Entities();

        // GET: TaiSan_62130808
        public ActionResult Index()
        {
            var tAISANs = db.TAISANs.Include(t => t.LOAITAISAN);
            return View(tAISANs.ToList());
        }

        // GET: TaiSan_62130808/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAISAN tAISAN = db.TAISANs.Find(id);
            if (tAISAN == null)
            {
                return HttpNotFound();
            }
            return View(tAISAN);
        }

        // GET: TaiSan_62130808/Create
        public ActionResult Create()
        {
            ViewBag.MaLTS = new SelectList(db.LOAITAISANs, "MaLTS", "TenLTS");
            return View();
        }

        // POST: TaiSan_62130808/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTS,TenTS,DVT,XuatXu,DonGia,AnhMH,GhiChu,MaLTS")] TAISAN tAISAN)
        {
            if (ModelState.IsValid)
            {
                db.TAISANs.Add(tAISAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLTS = new SelectList(db.LOAITAISANs, "MaLTS", "TenLTS", tAISAN.MaLTS);
            return View(tAISAN);
        }
        [HttpGet]
        public ActionResult TimKiemTS_62130808(string tenTS = "", int donGiaFrom = 0, int donGiaTo = 0)
        {
            System.Data.Entity.Infrastructure.DbSqlQuery<TAISAN> tAISANs;
            ViewBag.tenTS = tenTS;
            ViewBag.donGiaFrom = donGiaFrom;
            ViewBag.donGiaTo = donGiaTo;
            if (tenTS != "")
            {
                if (donGiaFrom != 0)
                {
                    if (donGiaTo != 0)
                    {
                        tAISANs = db.TAISANs.SqlQuery("TimKiemTS_62130808 '" + tenTS + "', '" + donGiaFrom + "'", "'" + donGiaTo + "'");
                    }
                    else tAISANs = db.TAISANs.SqlQuery("TimKiemTS_62130808 '" + tenTS + "', '" + donGiaFrom + "'");
                }
                else tAISANs = db.TAISANs.SqlQuery("TimKiemTS_62130808 '" + tenTS + "'");
            }
            else if (tenTS == "" && donGiaFrom != 0 && donGiaTo != 0)
            {
                tAISANs = db.TAISANs.SqlQuery("TimKiemTS_62130808 @TenTS=N'" + tenTS + "'");
            }
            else tAISANs = db.TAISANs.SqlQuery("TimKiemTS_62130808");
            if (tAISANs.Count() == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin tìm kiếm.";
            }
            return View(tAISANs.ToList());
        }

        // GET: TaiSan_62130808/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAISAN tAISAN = db.TAISANs.Find(id);
            if (tAISAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLTS = new SelectList(db.LOAITAISANs, "MaLTS", "TenLTS", tAISAN.MaLTS);
            return View(tAISAN);
        }

        // POST: TaiSan_62130808/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTS,TenTS,DVT,XuatXu,DonGia,AnhMH,GhiChu,MaLTS")] TAISAN tAISAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAISAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLTS = new SelectList(db.LOAITAISANs, "MaLTS", "TenLTS", tAISAN.MaLTS);
            return View(tAISAN);
        }

        // GET: TaiSan_62130808/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAISAN tAISAN = db.TAISANs.Find(id);
            if (tAISAN == null)
            {
                return HttpNotFound();
            }
            return View(tAISAN);
        }

        // POST: TaiSan_62130808/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAISAN tAISAN = db.TAISANs.Find(id);
            db.TAISANs.Remove(tAISAN);
            db.SaveChanges();
            return RedirectToAction("Index");
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
