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
    public class PhieuTraSachesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: PhieuTraSaches
        public ActionResult Index()
        {
            return View(db.PhieuTra.ToList());
        }

        // GET: PhieuTraSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraSach phieuTraSach = db.PhieuTra.Find(id);
            if (phieuTraSach == null)
            {
                return HttpNotFound();
            }
            return View(phieuTraSach);
        }

        // GET: PhieuTraSaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuTraSaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuTra,IdChiTietPhieuTra")] PhieuTraSach phieuTraSach)
        {
            if (ModelState.IsValid)
            {
                db.PhieuTra.Add(phieuTraSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieuTraSach);
        }

        // GET: PhieuTraSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraSach phieuTraSach = db.PhieuTra.Find(id);
            if (phieuTraSach == null)
            {
                return HttpNotFound();
            }
            return View(phieuTraSach);
        }

        // POST: PhieuTraSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuTra,IdChiTietPhieuTra")] PhieuTraSach phieuTraSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuTraSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuTraSach);
        }

        // GET: PhieuTraSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraSach phieuTraSach = db.PhieuTra.Find(id);
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
            PhieuTraSach phieuTraSach = db.PhieuTra.Find(id);
            db.PhieuTra.Remove(phieuTraSach);
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
