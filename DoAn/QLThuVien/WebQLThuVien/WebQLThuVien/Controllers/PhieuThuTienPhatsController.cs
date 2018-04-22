using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    public class PhieuThuTienPhatsController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: PhieuThuTienPhats
        public ActionResult Index()
        {
            var phieuThuTienPhats = db.PhieuThuTienPhats.Include(p => p.PhieuTraSach);
            return View(phieuThuTienPhats.ToList());
        }

        // GET: PhieuThuTienPhats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTienPhat phieuThuTienPhat = db.PhieuThuTienPhats.Find(id);
            if (phieuThuTienPhat == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuTienPhat);
        }

        // GET: PhieuThuTienPhats/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieuTra = new SelectList(db.PhieuTraSaches, "MaPhieuTra", "MaPhieuTra");
            return View();
        }

        // POST: PhieuThuTienPhats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuThuTienPhat,MaPhieuTra,SoTienThu,ConLai")] PhieuThuTienPhat phieuThuTienPhat)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThuTienPhats.Add(phieuThuTienPhat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhieuTra = new SelectList(db.PhieuTraSaches, "MaPhieuTra", "MaPhieuTra", phieuThuTienPhat.MaPhieuTra);
            return View(phieuThuTienPhat);
        }

        // GET: PhieuThuTienPhats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTienPhat phieuThuTienPhat = db.PhieuThuTienPhats.Find(id);
            if (phieuThuTienPhat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieuTra = new SelectList(db.PhieuTraSaches, "MaPhieuTra", "MaPhieuTra", phieuThuTienPhat.MaPhieuTra);
            return View(phieuThuTienPhat);
        }

        // POST: PhieuThuTienPhats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuThuTienPhat,MaPhieuTra,SoTienThu,ConLai")] PhieuThuTienPhat phieuThuTienPhat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThuTienPhat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieuTra = new SelectList(db.PhieuTraSaches, "MaPhieuTra", "MaPhieuTra", phieuThuTienPhat.MaPhieuTra);
            return View(phieuThuTienPhat);
        }

        // GET: PhieuThuTienPhats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTienPhat phieuThuTienPhat = db.PhieuThuTienPhats.Find(id);
            if (phieuThuTienPhat == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuTienPhat);
        }

        // POST: PhieuThuTienPhats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuThuTienPhat phieuThuTienPhat = db.PhieuThuTienPhats.Find(id);
            db.PhieuThuTienPhats.Remove(phieuThuTienPhat);
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
