using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiMau_62130808.Models;

namespace BaiMau_62130808.Controllers
{
    public class SinhViens62130808Controller : Controller
    {
        private BAIMAU_62130808Entities db = new BAIMAU_62130808Entities();

        // GET: SinhViens62130808
        public ActionResult GioiThieu()
        {
            return View();
        }
        
        // GET: SinhVien0720_62130808
        public ActionResult Index()
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop);
            return View(sinhViens.ToList());
        }

        // GET: SinhVien0720_62130808/Details/5
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
        public ActionResult TimKiem()
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop);
            return View(sinhViens.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem(string maSV/*, string HoTen = ""*/)
        {

            //var sinhViens = db.SinhViens.SqlQuery("exec NhanVien_DS '"+maNV+"' ");
            /// var sinhViens = db.SinhViens.SqlQuery("SELECT * FROM NhanVien WHERE MaNV='" + maNV + "'");
            //var sinhViens = db.SinhViens.Where(abc => abc.MaNV == maNV); //Tìm chính xác
            //var sinhViens = db.SinhViens.Where(abc => abc.MaSV.Contains(maSV)); //Tìm gần chính xác

            /*ViewBag.MaSV = MaSV;
            ViewBag.HoTen = HoTen;
            var sinhViens = db.SinhViens.SqlQuery("SinhVien_TimKiem'" + MaSV + "','" + HoTen + "'");
            if (sinhViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";*/
            var sinhViens = db.SinhViens.Where(abc => abc.MaSV.Contains(maSV));
            return View(sinhViens.ToList());
        }
        [HttpGet]

        public ActionResult TimKiem_62130808(string maSV = "", string hoTen = "")
        {
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop");
            var sinhViens = db.Lops.SqlQuery("SinhVien_TimKiem'" + maSV + "','" + hoTen + "'");
            if (sinhViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(sinhViens.ToList());
        }

        // GET: SinhVien0720_62130808/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop");
            return View();
        }

        // POST: SinhVien0720_62130808/Create
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

        // GET: SinhVien0720_62130808/Edit/5
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

        // POST: SinhVien0720_62130808/Edit/5
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

        // GET: SinhVien0720_62130808/Delete/5
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

        // POST: SinhVien0720_62130808/Delete/5
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
