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
    public class PhieuLapThesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: PhieuLapThes
        public ActionResult Index()
        {
            return View(db.PhieuLapThe.ToList());
        }

        // GET: PhieuLapThes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuLapThe phieuLapThe = db.PhieuLapThe.Find(id);
            if (phieuLapThe == null)
            {
                return HttpNotFound();
            }
            return View(phieuLapThe);
        }

        // GET: PhieuLapThes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuLapThes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenTK,MatKhau,HoVaTen,NgaySinh,DiaChi,Email,NgayLapThe")] PhieuLapThe phieuLapThe)
        {
            if (ModelState.IsValid)
            {
                db.PhieuLapThe.Add(phieuLapThe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieuLapThe);
        }

        // GET: PhieuLapThes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuLapThe phieuLapThe = db.PhieuLapThe.Find(id);
            if (phieuLapThe == null)
            {
                return HttpNotFound();
            }
            return View(phieuLapThe);
        }

        // POST: PhieuLapThes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenTK,MatKhau,HoVaTen,NgaySinh,DiaChi,Email,NgayLapThe")] PhieuLapThe phieuLapThe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuLapThe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuLapThe);
        }

        // GET: PhieuLapThes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuLapThe phieuLapThe = db.PhieuLapThe.Find(id);
            if (phieuLapThe == null)
            {
                return HttpNotFound();
            }
            return View(phieuLapThe);
        }

        // POST: PhieuLapThes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuLapThe phieuLapThe = db.PhieuLapThe.Find(id);
            db.PhieuLapThe.Remove(phieuLapThe);
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
