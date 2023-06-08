using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT0720_62130808_Remake.Models;

namespace KT0720_62130808_Remake.Controllers
{
    public class SinhVien0720_62130808Controller : Controller
    {
        private KT0720_62130808Entities db = new KT0720_62130808Entities();

        // GET: SinhVien0720_62130808
        public ActionResult GioiThieu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Search(string maSV = "", string hoTen = "")
        {
            System.Data.Entity.Infrastructure.DbSqlQuery<SinhVien> sinhViens;
            ViewBag.maSV = maSV;
            ViewBag.hoTen = hoTen;
            if (maSV != "")
            {
                if (hoTen != "")
                {
                    sinhViens = db.SinhViens.SqlQuery("TimKiem_SinhVien '" + maSV + "', N'" + hoTen + "'");
                }
                else
                {
                    sinhViens = db.SinhViens.SqlQuery("TimKiem_SinhVien '" + maSV + "'");
                }
            }
            else if (maSV == "" && hoTen != "")
            {
                sinhViens = db.SinhViens.SqlQuery("TimKiem_SinhVien @Hoten=N'" + hoTen + "'");
            }
            else sinhViens = db.SinhViens.SqlQuery("TimKiem_SinhVien");
            if (sinhViens.Count() == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin tìm kiếm.";
            }
            return View(sinhViens.ToList());
        }
        public ActionResult Index()
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop);
            return View(sinhViens.ToList());
        }

        // GET: SinhViensKT0720_62130808/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }   
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViensKT0720_62130808/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop");
            return View();
        }

        // POST: SinhViensKT0720_62130808/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhViensKT0720_62130808/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // POST: SinhViensKT0720_62130808/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhViensKT0720_62130808/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViensKT0720_62130808/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
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
