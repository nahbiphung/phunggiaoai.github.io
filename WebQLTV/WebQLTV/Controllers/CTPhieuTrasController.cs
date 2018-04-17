using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLTV.DAL;
using WebQLTV.Models;

namespace WebQLTV.Controllers
{
    public class CTPhieuTrasController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: CTPhieuTras
        public ActionResult Index()
        {
            var cTPhieuTra = db.CTPhieuTra.Include(c => c.PhieuMuonSach);
            return View(cTPhieuTra.ToList());
        }

        // GET: CTPhieuTras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuTra cTPhieuTra = db.CTPhieuTra.Find(id);
            if (cTPhieuTra == null)
            {
                return HttpNotFound();
            }
            return View(cTPhieuTra);
        }

        // GET: CTPhieuTras/Create
        public ActionResult Create()
        {
            ViewBag.IdPhieuMuon = new SelectList(db.PhieuMuonSach, "IDPhieuMuon", "IdTheDocGia");
            return View();
        }

        // POST: CTPhieuTras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDChiTietPhieuTra,IdPhieuMuon,NgayTra,TienPhatKiNay,TongNo,SoNgayMuon,TienPhat")] CTPhieuTra cTPhieuTra)
        {
            if (ModelState.IsValid)
            {
                db.CTPhieuTra.Add(cTPhieuTra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPhieuMuon = new SelectList(db.PhieuMuonSach, "IDPhieuMuon", "IdTheDocGia", cTPhieuTra.IdPhieuMuon);
            return View(cTPhieuTra);
        }

        // GET: CTPhieuTras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuTra cTPhieuTra = db.CTPhieuTra.Find(id);
            if (cTPhieuTra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPhieuMuon = new SelectList(db.PhieuMuonSach, "IDPhieuMuon", "IdTheDocGia", cTPhieuTra.IdPhieuMuon);
            return View(cTPhieuTra);
        }

        // POST: CTPhieuTras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDChiTietPhieuTra,IdPhieuMuon,NgayTra,TienPhatKiNay,TongNo,SoNgayMuon,TienPhat")] CTPhieuTra cTPhieuTra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTPhieuTra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPhieuMuon = new SelectList(db.PhieuMuonSach, "IDPhieuMuon", "IdTheDocGia", cTPhieuTra.IdPhieuMuon);
            return View(cTPhieuTra);
        }

        // GET: CTPhieuTras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuTra cTPhieuTra = db.CTPhieuTra.Find(id);
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
            CTPhieuTra cTPhieuTra = db.CTPhieuTra.Find(id);
            db.CTPhieuTra.Remove(cTPhieuTra);
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
