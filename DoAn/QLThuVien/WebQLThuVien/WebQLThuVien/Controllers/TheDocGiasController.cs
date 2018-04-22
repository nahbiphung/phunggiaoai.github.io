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
    public class TheDocGiasController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: TheDocGias
        public ActionResult Index()
        {
            var theDocGias = db.TheDocGias.Include(t => t.LoaiDocGia).Include(t => t.PhieuLapThe);
            return View(theDocGias.ToList());
        }

        // GET: TheDocGias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheDocGia theDocGia = db.TheDocGias.Find(id);
            if (theDocGia == null)
            {
                return HttpNotFound();
            }
            return View(theDocGia);
        }

        // GET: TheDocGias/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGias, "MaLoaiDocGia", "TenLoai");
            ViewBag.TenTK = new SelectList(db.PhieuLapThes, "TenTK", "MatKhau");
            return View();
        }

        // POST: TheDocGias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTheDocGia,MaLoaiDocGia,TenTK")] TheDocGia theDocGia)
        {
            if (ModelState.IsValid)
            {
                db.TheDocGias.Add(theDocGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGias, "MaLoaiDocGia", "TenLoai", theDocGia.MaLoaiDocGia);
            ViewBag.TenTK = new SelectList(db.PhieuLapThes, "TenTK", "MatKhau", theDocGia.TenTK);
            return View(theDocGia);
        }

        // GET: TheDocGias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheDocGia theDocGia = db.TheDocGias.Find(id);
            if (theDocGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGias, "MaLoaiDocGia", "TenLoai", theDocGia.MaLoaiDocGia);
            ViewBag.TenTK = new SelectList(db.PhieuLapThes, "TenTK", "MatKhau", theDocGia.TenTK);
            return View(theDocGia);
        }

        // POST: TheDocGias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTheDocGia,MaLoaiDocGia,TenTK")] TheDocGia theDocGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theDocGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGias, "MaLoaiDocGia", "TenLoai", theDocGia.MaLoaiDocGia);
            ViewBag.TenTK = new SelectList(db.PhieuLapThes, "TenTK", "MatKhau", theDocGia.TenTK);
            return View(theDocGia);
        }

        // GET: TheDocGias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheDocGia theDocGia = db.TheDocGias.Find(id);
            if (theDocGia == null)
            {
                return HttpNotFound();
            }
            return View(theDocGia);
        }

        // POST: TheDocGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TheDocGia theDocGia = db.TheDocGias.Find(id);
            db.TheDocGias.Remove(theDocGia);
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
