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
    public class PhieuTraSachesController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: PhieuTraSaches
        public ActionResult Index()
        {
            var phieuTraSaches = db.PhieuTraSaches.Include(p => p.CTPhieuTra);
            return View(phieuTraSaches.ToList());
        }

        // GET: PhieuTraSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraSach phieuTraSach = db.PhieuTraSaches.Find(id);
            if (phieuTraSach == null)
            {
                return HttpNotFound();
            }
            return View(phieuTraSach);
        }

        // GET: PhieuTraSaches/Create
        public ActionResult Create()
        {
            ViewBag.MaCTPhieuTRa = new SelectList(db.CTPhieuTras, "MaCTPhieuTra", "MaCTPhieuTra");
            return View();
        }

        // POST: PhieuTraSaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuTra,MaCTPhieuTRa")] PhieuTraSach phieuTraSach)
        {
            if (ModelState.IsValid)
            {
                db.PhieuTraSaches.Add(phieuTraSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCTPhieuTRa = new SelectList(db.CTPhieuTras, "MaCTPhieuTra", "MaCTPhieuTra", phieuTraSach.MaCTPhieuTRa);
            return View(phieuTraSach);
        }

        // GET: PhieuTraSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraSach phieuTraSach = db.PhieuTraSaches.Find(id);
            if (phieuTraSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCTPhieuTRa = new SelectList(db.CTPhieuTras, "MaCTPhieuTra", "MaCTPhieuTra", phieuTraSach.MaCTPhieuTRa);
            return View(phieuTraSach);
        }

        // POST: PhieuTraSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuTra,MaCTPhieuTRa")] PhieuTraSach phieuTraSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuTraSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCTPhieuTRa = new SelectList(db.CTPhieuTras, "MaCTPhieuTra", "MaCTPhieuTra", phieuTraSach.MaCTPhieuTRa);
            return View(phieuTraSach);
        }

        // GET: PhieuTraSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraSach phieuTraSach = db.PhieuTraSaches.Find(id);
            if (phieuTraSach == null)
            {
                return HttpNotFound();
            }
            return View(phieuTraSach);
        }

        // POST: PhieuTraSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuTraSach phieuTraSach = db.PhieuTraSaches.Find(id);
            db.PhieuTraSaches.Remove(phieuTraSach);
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
