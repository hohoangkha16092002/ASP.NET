using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTap6_62130808.Models;

namespace BaiTap6_62130808.Controllers
{
    public class PhongBans62130808Controller : Controller
    {
        private QLNV_62130808Entities db = new QLNV_62130808Entities();

        // GET: PhongBans62130808
        public ActionResult Index()
        {
            return View(db.PhongBans.ToList());
        }

        // GET: PhongBans62130808/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBans.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // GET: PhongBans62130808/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhongBans62130808/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPB,TenPB")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                db.PhongBans.Add(phongBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongBan);
        }

        // GET: PhongBans62130808/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBans.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // POST: PhongBans62130808/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPB,TenPB")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongBan);
        }

        // GET: PhongBans62130808/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBans.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // POST: PhongBans62130808/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhongBan phongBan = db.PhongBans.Find(id);
            db.PhongBans.Remove(phongBan);
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
