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
    public class CTPhieuTrasController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: CTPhieuTras
        public ActionResult Index()
        {
            var cTPhieuTras = db.CTPhieuTras.Include(c => c.PhieuMuonSach);
            return View(cTPhieuTras.ToList());
        }

        // GET: CTPhieuTras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuTra cTPhieuTra = db.CTPhieuTras.Find(id);
            if (cTPhieuTra == null)
            {
                return HttpNotFound();
            }
            return View(cTPhieuTra);
        }

        // GET: CTPhieuTras/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieumuon = new SelectList(db.PhieuMuonSaches, "MaPhieuMuon", "MaTheDocGia");
            return View();
        }

        // POST: CTPhieuTras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTPhieuTra,MaPhieumuon,NgayTra,TienPhatKiNay,TongNo,SoNgayMuon,TienPhat")] CTPhieuTra cTPhieuTra)
        {
            if (ModelState.IsValid)
            {
                db.CTPhieuTras.Add(cTPhieuTra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhieumuon = new SelectList(db.PhieuMuonSaches, "MaPhieuMuon", "MaTheDocGia", cTPhieuTra.MaPhieumuon);
            return View(cTPhieuTra);
        }

        // GET: CTPhieuTras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuTra cTPhieuTra = db.CTPhieuTras.Find(id);
            if (cTPhieuTra == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieumuon = new SelectList(db.PhieuMuonSaches, "MaPhieuMuon", "MaTheDocGia", cTPhieuTra.MaPhieumuon);
            return View(cTPhieuTra);
        }

        // POST: CTPhieuTras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTPhieuTra,MaPhieumuon,NgayTra,TienPhatKiNay,TongNo,SoNgayMuon,TienPhat")] CTPhieuTra cTPhieuTra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTPhieuTra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieumuon = new SelectList(db.PhieuMuonSaches, "MaPhieuMuon", "MaTheDocGia", cTPhieuTra.MaPhieumuon);
            return View(cTPhieuTra);
        }

        // GET: CTPhieuTras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuTra cTPhieuTra = db.CTPhieuTras.Find(id);
            if (cTPhieuTra == null)
            {
                return HttpNotFound();
            }
            return View(cTPhieuTra);
        }

        // POST: CTPhieuTras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTPhieuTra cTPhieuTra = db.CTPhieuTras.Find(id);
            db.CTPhieuTras.Remove(cTPhieuTra);
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
