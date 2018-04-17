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
    public class SachesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Saches
        public ActionResult Index()
        {
            var sach = db.Sach.Include(s => s.LoaiSach).Include(s => s.NhaXuatBan).Include(s => s.TacGia);
            return View(sach.ToList());
        }

        // GET: Saches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches/Create
        public ActionResult Create()
        {
            ViewBag.IdLoaiSach = new SelectList(db.LoaiSach, "IDLoaiSach", "TenLoaiSach");
            ViewBag.IdNhaXuatBan = new SelectList(db.NhaXuatBan, "IDNhaXuatBan", "TenNhaXuatBan");
            ViewBag.IdTacGia = new SelectList(db.TacGia, "IDTacGia", "TenTacGia");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSach,TenSach,IdLoaiSach,IdTacGia,IdNhaXuatBan,NamSanXuat,NgayNhap,TriGia,SoLuong")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Sach.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLoaiSach = new SelectList(db.LoaiSach, "IDLoaiSach", "TenLoaiSach", sach.IdLoaiSach);
            ViewBag.IdNhaXuatBan = new SelectList(db.NhaXuatBan, "IDNhaXuatBan", "TenNhaXuatBan", sach.IdNhaXuatBan);
            ViewBag.IdTacGia = new SelectList(db.TacGia, "IDTacGia", "TenTacGia", sach.IdTacGia);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLoaiSach = new SelectList(db.LoaiSach, "IDLoaiSach", "TenLoaiSach", sach.IdLoaiSach);
            ViewBag.IdNhaXuatBan = new SelectList(db.NhaXuatBan, "IDNhaXuatBan", "TenNhaXuatBan", sach.IdNhaXuatBan);
            ViewBag.IdTacGia = new SelectList(db.TacGia, "IDTacGia", "TenTacGia", sach.IdTacGia);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSach,TenSach,IdLoaiSach,IdTacGia,IdNhaXuatBan,NamSanXuat,NgayNhap,TriGia,SoLuong")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLoaiSach = new SelectList(db.LoaiSach, "IDLoaiSach", "TenLoaiSach", sach.IdLoaiSach);
            ViewBag.IdNhaXuatBan = new SelectList(db.NhaXuatBan, "IDNhaXuatBan", "TenNhaXuatBan", sach.IdNhaXuatBan);
            ViewBag.IdTacGia = new SelectList(db.TacGia, "IDTacGia", "TenTacGia", sach.IdTacGia);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sach sach = db.Sach.Find(id);
            db.Sach.Remove(sach);
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
