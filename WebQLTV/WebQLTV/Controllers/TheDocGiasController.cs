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
    public class TheDocGiasController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: TheDocGias
        public ActionResult Index()
        {
            var theDocGia = db.TheDocGia.Include(t => t.LoaiDocGia);
            return View(theDocGia.ToList());
        }

        // GET: TheDocGias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheDocGia theDocGia = db.TheDocGia.Find(id);
            if (theDocGia == null)
            {
                return HttpNotFound();
            }
            return View(theDocGia);
        }

        // GET: TheDocGias/Create
        public ActionResult Create()
        {
            ViewBag.IdLoaiDocGia = new SelectList(db.LoaiDocGia, "IDLoaiDocGia", "TenLoaiDocGia");
            return View();
        }

        // POST: TheDocGias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTheDocGia,IdLoaiDocGia,TenTK")] TheDocGia theDocGia)
        {
            if (ModelState.IsValid)
            {
                db.TheDocGia.Add(theDocGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLoaiDocGia = new SelectList(db.LoaiDocGia, "IDLoaiDocGia", "TenLoaiDocGia", theDocGia.IdLoaiDocGia);
            return View(theDocGia);
        }

        // GET: TheDocGias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheDocGia theDocGia = db.TheDocGia.Find(id);
            if (theDocGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLoaiDocGia = new SelectList(db.LoaiDocGia, "IDLoaiDocGia", "TenLoaiDocGia", theDocGia.IdLoaiDocGia);
            return View(theDocGia);
        }

        // POST: TheDocGias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTheDocGia,IdLoaiDocGia,TenTK")] TheDocGia theDocGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theDocGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLoaiDocGia = new SelectList(db.LoaiDocGia, "IDLoaiDocGia", "TenLoaiDocGia", theDocGia.IdLoaiDocGia);
            return View(theDocGia);
        }

        // GET: TheDocGias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheDocGia theDocGia = db.TheDocGia.Find(id);
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
            TheDocGia theDocGia = db.TheDocGia.Find(id);
            db.TheDocGia.Remove(theDocGia);
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
