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
    public class LoaiDocGiasController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: LoaiDocGias
        public ActionResult Index()
        {
            return View(db.LoaiDocGia.ToList());
        }

        // GET: LoaiDocGias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDocGia loaiDocGia = db.LoaiDocGia.Find(id);
            if (loaiDocGia == null)
            {
                return HttpNotFound();
            }
            return View(loaiDocGia);
        }

        // GET: LoaiDocGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiDocGias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLoaiDocGia,TenLoaiDocGia")] LoaiDocGia loaiDocGia)
        {
            if (ModelState.IsValid)
            {
                db.LoaiDocGia.Add(loaiDocGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiDocGia);
        }

        // GET: LoaiDocGias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDocGia loaiDocGia = db.LoaiDocGia.Find(id);
            if (loaiDocGia == null)
            {
                return HttpNotFound();
            }
            return View(loaiDocGia);
        }

        // POST: LoaiDocGias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLoaiDocGia,TenLoaiDocGia")] LoaiDocGia loaiDocGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiDocGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiDocGia);
        }

        // GET: LoaiDocGias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDocGia loaiDocGia = db.LoaiDocGia.Find(id);
            if (loaiDocGia == null)
            {
                return HttpNotFound();
            }
            return View(loaiDocGia);
        }

        // POST: LoaiDocGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiDocGia loaiDocGia = db.LoaiDocGia.Find(id);
            db.LoaiDocGia.Remove(loaiDocGia);
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
