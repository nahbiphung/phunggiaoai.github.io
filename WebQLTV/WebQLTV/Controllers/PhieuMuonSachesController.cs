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
    public class PhieuMuonSachesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: PhieuMuonSaches
        public ActionResult Index()
        {
            var phieuMuonSach = db.PhieuMuonSach.Include(p => p.TheDocGia);
            return View(phieuMuonSach.ToList());
        }

        // GET: PhieuMuonSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuMuonSach phieuMuonSach = db.PhieuMuonSach.Find(id);
            if (phieuMuonSach == null)
            {
                return HttpNotFound();
            }
            return View(phieuMuonSach);
        }

        // GET: PhieuMuonSaches/Create
        public ActionResult Create()
        {
            ViewBag.IdTheDocGia = new SelectList(db.TheDocGia, "IDTheDocGia", "TenTK");
            return View();
        }

        // POST: PhieuMuonSaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuMuon,IdTheDocGia,NgayMuon")] PhieuMuonSach phieuMuonSach)
        {
            if (ModelState.IsValid)
            {
                db.PhieuMuonSach.Add(phieuMuonSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTheDocGia = new SelectList(db.TheDocGia, "IDTheDocGia", "TenTK", phieuMuonSach.IdTheDocGia);
            return View(phieuMuonSach);
        }

        // GET: PhieuMuonSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuMuonSach phieuMuonSach = db.PhieuMuonSach.Find(id);
            if (phieuMuonSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTheDocGia = new SelectList(db.TheDocGia, "IDTheDocGia", "TenTK", phieuMuonSach.IdTheDocGia);
            return View(phieuMuonSach);
        }

        // POST: PhieuMuonSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuMuon,IdTheDocGia,NgayMuon")] PhieuMuonSach phieuMuonSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuMuonSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTheDocGia = new SelectList(db.TheDocGia, "IDTheDocGia", "TenTK", phieuMuonSach.IdTheDocGia);
            return View(phieuMuonSach);
        }

        // GET: PhieuMuonSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuMuonSach phieuMuonSach = db.PhieuMuonSach.Find(id);
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
            PhieuMuonSach phieuMuonSach = db.PhieuMuonSach.Find(id);
            db.PhieuMuonSach.Remove(phieuMuonSach);
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
