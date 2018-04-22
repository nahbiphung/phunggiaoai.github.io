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
    public class PhieuMuonSachesController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: PhieuMuonSaches
        public ActionResult Index()
        {
            var phieuMuonSaches = db.PhieuMuonSaches.Include(p => p.TheDocGia);
            return View(phieuMuonSaches.ToList());
        }

        // GET: PhieuMuonSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuMuonSach phieuMuonSach = db.PhieuMuonSaches.Find(id);
            if (phieuMuonSach == null)
            {
                return HttpNotFound();
            }
            return View(phieuMuonSach);
        }

        // GET: PhieuMuonSaches/Create
        public ActionResult Create()
        {
            ViewBag.MaTheDocGia = new SelectList(db.TheDocGias, "MaTheDocGia", "TenTK");
            return View();
        }

        // POST: PhieuMuonSaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuMuon,MaTheDocGia,NgayMuon")] PhieuMuonSach phieuMuonSach)
        {
            if (ModelState.IsValid)
            {
                db.PhieuMuonSaches.Add(phieuMuonSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTheDocGia = new SelectList(db.TheDocGias, "MaTheDocGia", "TenTK", phieuMuonSach.MaTheDocGia);
            return View(phieuMuonSach);
        }

        // GET: PhieuMuonSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuMuonSach phieuMuonSach = db.PhieuMuonSaches.Find(id);
            if (phieuMuonSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTheDocGia = new SelectList(db.TheDocGias, "MaTheDocGia", "TenTK", phieuMuonSach.MaTheDocGia);
            return View(phieuMuonSach);
        }

        // POST: PhieuMuonSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuMuon,MaTheDocGia,NgayMuon")] PhieuMuonSach phieuMuonSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuMuonSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTheDocGia = new SelectList(db.TheDocGias, "MaTheDocGia", "TenTK", phieuMuonSach.MaTheDocGia);
            return View(phieuMuonSach);
        }

        // GET: PhieuMuonSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuMuonSach phieuMuonSach = db.PhieuMuonSaches.Find(id);
            if (phieuMuonSach == null)
            {
                return HttpNotFound();
            }
            return View(phieuMuonSach);
        }

        // POST: PhieuMuonSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuMuonSach phieuMuonSach = db.PhieuMuonSaches.Find(id);
            db.PhieuMuonSaches.Remove(phieuMuonSach);
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
