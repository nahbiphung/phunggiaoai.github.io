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
    public class CTPhieuMuonsController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: CTPhieuMuons
        public ActionResult Index()
        {
            var cTPhieuMuons = db.CTPhieuMuons.Include(c => c.PhieuMuonSach).Include(c => c.Sach);
            return View(cTPhieuMuons.ToList());
        }

        // GET: CTPhieuMuons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuMuon cTPhieuMuon = db.CTPhieuMuons.Find(id);
            if (cTPhieuMuon == null)
            {
                return HttpNotFound();
            }
            return View(cTPhieuMuon);
        }

        // GET: CTPhieuMuons/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieuMuon = new SelectList(db.PhieuMuonSaches, "MaPhieuMuon", "MaTheDocGia");
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach");
            return View();
        }

        // POST: CTPhieuMuons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTPhieuMuon,MaPhieuMuon,MaSach,SoLuong")] CTPhieuMuon cTPhieuMuon)
        {
            if (ModelState.IsValid)
            {
                db.CTPhieuMuons.Add(cTPhieuMuon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhieuMuon = new SelectList(db.PhieuMuonSaches, "MaPhieuMuon", "MaTheDocGia", cTPhieuMuon.MaPhieuMuon);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", cTPhieuMuon.MaSach);
            return View(cTPhieuMuon);
        }

        // GET: CTPhieuMuons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuMuon cTPhieuMuon = db.CTPhieuMuons.Find(id);
            if (cTPhieuMuon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieuMuon = new SelectList(db.PhieuMuonSaches, "MaPhieuMuon", "MaTheDocGia", cTPhieuMuon.MaPhieuMuon);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", cTPhieuMuon.MaSach);
            return View(cTPhieuMuon);
        }

        // POST: CTPhieuMuons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTPhieuMuon,MaPhieuMuon,MaSach,SoLuong")] CTPhieuMuon cTPhieuMuon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTPhieuMuon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieuMuon = new SelectList(db.PhieuMuonSaches, "MaPhieuMuon", "MaTheDocGia", cTPhieuMuon.MaPhieuMuon);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", cTPhieuMuon.MaSach);
            return View(cTPhieuMuon);
        }

        // GET: CTPhieuMuons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuMuon cTPhieuMuon = db.CTPhieuMuons.Find(id);
            if (cTPhieuMuon == null)
            {
                return HttpNotFound();
            }
            return View(cTPhieuMuon);
        }

        // POST: CTPhieuMuons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTPhieuMuon cTPhieuMuon = db.CTPhieuMuons.Find(id);
            db.CTPhieuMuons.Remove(cTPhieuMuon);
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
