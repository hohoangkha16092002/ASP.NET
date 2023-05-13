using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT0720_62133366.Models;

namespace KT0720_62133366.Controllers
{
    public class SinhVienKT0720_62133366Controller : Controller
    {
        private KT0720_62133366Entities1 db = new KT0720_62133366Entities1();

        string LayMaSV()
        {
            var maMax = db.SinhViens.ToList().Select(n => n.MaSV).Max();
            int maSV = int.Parse(maMax.Substring(2)) + 1;
            string SV = String.Concat("00", maSV.ToString());
            return "SV" + SV.Substring(maSV.ToString().Length - 1);
        }

        // GET: SinhVienKT0720_62133366
        public ActionResult Introduction()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string maSV="",string hoTen="")
        {
            System.Data.Entity.Infrastructure.DbSqlQuery<SinhVien> sinhViens;
            ViewBag.maSV = maSV;
            ViewBag.hoTen = hoTen;
            if (maSV != "")
            {
                if (hoTen!="")
                {
                    sinhViens = db.SinhViens.SqlQuery("TimKiemSinhVien '" + maSV + "', N'" + hoTen + "'");
                }
                else
                {
                    sinhViens = db.SinhViens.SqlQuery("TimKiemSinhVien '" + maSV + "'");
                }
            }
            else if (maSV=="" && hoTen!="")
            {
                sinhViens = db.SinhViens.SqlQuery("TimKiemSinhVien @Hoten=N'" + hoTen + "'");
            }
            else sinhViens = db.SinhViens.SqlQuery("TimKiemSinhVien");
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

        // GET: SinhVienKT0720_62133366/Details/5
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

        // GET: SinhVienKT0720_62133366/Create
        public ActionResult Create()
        {
            ViewBag.MaSV = LayMaSV();
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop");
            return View();
        }

        // POST: SinhVienKT0720_62133366/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SinhVien sinhVien)
        {
            string maSV = LayMaSV();
            var imgSV = Request.Files["Avatar"];
            string postedFileName = System.IO.Path.GetFileName(imgSV.FileName);
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSV.SaveAs(path);
            if (ModelState.IsValid)
            {
                sinhVien.MaSV = maSV;
                sinhVien.AnhSV = postedFileName;
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhVienKT0720_62133366/Edit/5
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

        // POST: SinhVienKT0720_62133366/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SinhVien sinhVien)
        {
            var imgSV = Request.Files["Avatar"];
            string postedFileName = System.IO.Path.GetFileName(imgSV.FileName);
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSV.SaveAs(path);
            if (ModelState.IsValid)
            {
                sinhVien.AnhSV = postedFileName;
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhVienKT0720_62133366/Delete/5
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

        // POST: SinhVienKT0720_62133366/Delete/5
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
