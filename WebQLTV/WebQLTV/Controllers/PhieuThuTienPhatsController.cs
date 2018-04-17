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
    public class PhieuThuTienPhatsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: PhieuThuTienPhats
        public ActionResult Index()
        {
            var phieuThuTienPhat = db.PhieuThuTienPhat.Include(p => p.PhieuTraSach);
            return View(phieuThuTienPhat.ToList());
        }

        // GET: PhieuThuTienPhats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTienPhat phieuThuTienPhat = db.PhieuThuTienPhat.Find(id);
            if (phieuThuTienPhat == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuTienPhat);
        }

        // GET: PhieuThuTienPhats/Create
        public ActionResult Create()
        {
            ViewBag.IdPhieuTra = new SelectList(db.PhieuTra, "IDPhieuTra", "IDPhieuTra");
            return View();
        }

        // POST: PhieuThuTienPhats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuThuTienPhat,IdPhieuTra,SoTienThu,ConLai")] PhieuThuTienPhat phieuThuTienPhat)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThuTienPhat.Add(phieuThuTienPhat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPhieuTra = new SelectList(db.PhieuTra, "IDPhieuTra", "IDPhieuTra", phieuThuTienPhat.IdPhieuTra);
            return View(phieuThuTienPhat);
        }

        // GET: PhieuThuTienPhats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTienPhat phieuThuTienPhat = db.PhieuThuTienPhat.Find(id);
            if (phieuThuTienPhat == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPhieuTra = new SelectList(db.PhieuTra, "IDPhieuTra", "IDPhieuTra", phieuThuTienPhat.IdPhieuTra);
            return View(phieuThuTienPhat);
        }

        // POST: PhieuThuTienPhats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuThuTienPhat,IdPhieuTra,SoTienThu,ConLai")] PhieuThuTienPhat phieuThuTienPhat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThuTienPhat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPhieuTra = new SelectList(db.PhieuTra, "IDPhieuTra", "IDPhieuTra", phieuThuTienPhat.IdPhieuTra);
            return View(phieuThuTienPhat);
        }

        // GET: PhieuThuTienPhats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTienPhat phieuThuTienPhat = db.PhieuThuTienPhat.Find(id);
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
            PhieuThuTienPhat phieuThuTienPhat = db.PhieuThuTienPhat.Find(id);
            db.PhieuThuTienPhat.Remove(phieuThuTienPhat);
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
