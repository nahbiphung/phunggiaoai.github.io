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
    public class CTPhieuMuonsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: CTPhieuMuons
        public ActionResult Index()
        {
            var cTPhieuMuon = db.CTPhieuMuon.Include(c => c.PhieuMuonSach);
            return View(cTPhieuMuon.ToList());
        }

        // GET: CTPhieuMuons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuMuon cTPhieuMuon = db.CTPhieuMuon.Find(id);
            if (cTPhieuMuon == null)
            {
                return HttpNotFound();
            }
            return View(cTPhieuMuon);
        }

        // GET: CTPhieuMuons/Create
        public ActionResult Create()
        {
            ViewBag.IdPhieuMuon = new SelectList(db.PhieuMuonSach, "IDPhieuMuon", "IdTheDocGia");
            return View();
        }

        // POST: CTPhieuMuons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDChiTietPhieuMuon,IdPhieuMuon,MaSach,SoLuong")] CTPhieuMuon cTPhieuMuon)
        {
            if (ModelState.IsValid)
            {
                db.CTPhieuMuon.Add(cTPhieuMuon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPhieuMuon = new SelectList(db.PhieuMuonSach, "IDPhieuMuon", "IdTheDocGia", cTPhieuMuon.IdPhieuMuon);
            return View(cTPhieuMuon);
        }

        // GET: CTPhieuMuons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuMuon cTPhieuMuon = db.CTPhieuMuon.Find(id);
            if (cTPhieuMuon == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPhieuMuon = new SelectList(db.PhieuMuonSach, "IDPhieuMuon", "IdTheDocGia", cTPhieuMuon.IdPhieuMuon);
            return View(cTPhieuMuon);
        }

        // POST: CTPhieuMuons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDChiTietPhieuMuon,IdPhieuMuon,MaSach,SoLuong")] CTPhieuMuon cTPhieuMuon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTPhieuMuon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPhieuMuon = new SelectList(db.PhieuMuonSach, "IDPhieuMuon", "IdTheDocGia", cTPhieuMuon.IdPhieuMuon);
            return View(cTPhieuMuon);
        }

        // GET: CTPhieuMuons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPhieuMuon cTPhieuMuon = db.CTPhieuMuon.Find(id);
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
            CTPhieuMuon cTPhieuMuon = db.CTPhieuMuon.Find(id);
            db.CTPhieuMuon.Remove(cTPhieuMuon);
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
