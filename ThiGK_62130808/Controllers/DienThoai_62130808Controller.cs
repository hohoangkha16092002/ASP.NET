using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiGK_62130808.Models;

namespace ThiGK_62130808.Controllers
{
    public class DienThoai_62130808Controller : Controller
    {
        private ThiGK_62130808Entities db = new ThiGK_62130808Entities();

        public ActionResult TimKiem()
        {
            var dienThoais = db.DienThoais.Include(n => n.LoaiDienThoai);
            return View(dienThoais.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem(string tenDT)
        {
            //var nhanViens = db.NhanViens.SqlQuery("exec NhanVien_DS '"+maNV+"' ");
            /// var nhanViens = db.NhanViens.SqlQuery("SELECT * FROM NhanVien WHERE MaNV='" + maNV + "'");
            //var nhanViens = db.NhanViens.Where(abc => abc.MaNV == maNV); //Tìm chính xác
            var dienThoais = db.DienThoais.Where(abc => abc.TenDT.Contains(tenDT)); //Tìm gần chính xác
            return View(dienThoais.ToList());
        }
        [HttpGet]

        // GET: DienThoai_62130808
        public ActionResult Index()
        {
            var dienThoais = db.DienThoais.Include(d => d.LoaiDienThoai);
            return View(dienThoais.ToList());
        }

        // GET: DienThoai_62130808/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DienThoai dienThoai = db.DienThoais.Find(id);
            if (dienThoai == null)
            {
                return HttpNotFound();
            }
            return View(dienThoai);
        }

        // GET: DienThoai_62130808/Create
        public ActionResult Create()
        {
            ViewBag.MaLDT = new SelectList(db.LoaiDienThoais, "MaLDT", "TenLDT");
            return View();
        }

        // POST: DienThoai_62130808/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDT,TenDT,XuatXu,DonGia,AnhDT,MoTa,PhuKienKemTheo,MaLDT")] DienThoai dienThoai)
        {
            if (ModelState.IsValid)
            {
                db.DienThoais.Add(dienThoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLDT = new SelectList(db.LoaiDienThoais, "MaLDT", "TenLDT", dienThoai.MaLDT);
            return View(dienThoai);
        }

        // GET: DienThoai_62130808/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DienThoai dienThoai = db.DienThoais.Find(id);
            if (dienThoai == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLDT = new SelectList(db.LoaiDienThoais, "MaLDT", "TenLDT", dienThoai.MaLDT);
            return View(dienThoai);
        }

        // POST: DienThoai_62130808/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDT,TenDT,XuatXu,DonGia,AnhDT,MoTa,PhuKienKemTheo,MaLDT")] DienThoai dienThoai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dienThoai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLDT = new SelectList(db.LoaiDienThoais, "MaLDT", "TenLDT", dienThoai.MaLDT);
            return View(dienThoai);
        }

        // GET: DienThoai_62130808/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DienThoai dienThoai = db.DienThoais.Find(id);
            if (dienThoai == null)
            {
                return HttpNotFound();
            }
            return View(dienThoai);
        }

        // POST: DienThoai_62130808/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DienThoai dienThoai = db.DienThoais.Find(id);
            db.DienThoais.Remove(dienThoai);
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
