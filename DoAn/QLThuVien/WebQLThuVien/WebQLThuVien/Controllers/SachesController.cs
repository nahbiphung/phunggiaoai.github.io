using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLThuVien.Models;


namespace WebQLThuVien.Controllers
{
    public class SachesController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: Saches
        public ActionResult Index()
        {
            var saches = db.Saches.Include(s => s.LoaiSach).Include(s => s.NXB).Include(s => s.TacGia);
            ViewBag.ListSach = db.Saches.ToList();//Thêm vào để lấy list sách
            return View(db.Saches.ToList());
        }
        //Làm nút bấm xuất
        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"),"ReportSach.rpt"));
            rd.SetDataSource(db.Saches.Select(sach => new
            {
                MaSach = sach.MaSach,
                TenSach = sach.TenSach,
                MaLoaiSach = sach.MaLoaiSach,
                MaTacGia = sach.MaTacGia,
                MaNhaXuatBan = sach.MaNhaXuatBan,
                NamXuatBan = sach.NamXuatBan,
                NgayNhap = sach.NgayNhap,
                TriGia = sach.TriGia,
                SoLuong = sach.SoLuong,
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "List_Sach.pdf");
            }
            catch
            {
                throw;
            }
            //rd.SetDataSource(db.Saches.Select(sach => new
            //{
            //    MaSach = sach.MaSach,
            //    TenSach = sach.TenSach,
            //    MaLoaiSach = sach.MaLoaiSach.Value,
            //    MaTacGia = sach.MaTacGia.Value,
            //    MaNhaXuatBan = sach.MaNhaXuatBan.Value,
            //    NamXuatBan = sach.NamXuatBan,
            //    NgayNhap = sach.NgayNhap,
            //    TriGia = sach.TriGia.Value,
            //    SoLuong = sach.SoLuong.Value,
            //}).ToList());
            //Response.Buffer = false;
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //stream.Seek(0, SeekOrigin.Begin);
            //return File(stream,"application/pdf","ListSach.pdf");
        }
        // GET: Saches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach");
            ViewBag.MaNhaXuatBan = new SelectList(db.NXBs, "MaNhaXuatBan", "TenNhaXuatBan");
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,MaLoaiSach,MaTacGia,MaNhaXuatBan,NamXuatBan,NgayNhap,TriGia,SoLuong")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            ViewBag.MaNhaXuatBan = new SelectList(db.NXBs, "MaNhaXuatBan", "TenNhaXuatBan", sach.MaNhaXuatBan);
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sach.MaTacGia);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            ViewBag.MaNhaXuatBan = new SelectList(db.NXBs, "MaNhaXuatBan", "TenNhaXuatBan", sach.MaNhaXuatBan);
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sach.MaTacGia);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,MaLoaiSach,MaTacGia,MaNhaXuatBan,NamXuatBan,NgayNhap,TriGia,SoLuong")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            ViewBag.MaNhaXuatBan = new SelectList(db.NXBs, "MaNhaXuatBan", "TenNhaXuatBan", sach.MaNhaXuatBan);
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sach.MaTacGia);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
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
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
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
