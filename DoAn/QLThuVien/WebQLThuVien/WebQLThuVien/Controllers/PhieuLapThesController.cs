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
    public class PhieuLapThesController : Controller
    {
        private ModelQLThuVien db = new ModelQLThuVien();

        // GET: PhieuLapThes
        public ActionResult Index()
        {
            return View(db.PhieuLapThes.ToList());
        }

        //Làm nút bấm xuất
        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "ReportPhieuLapThe.rpt"));
            rd.SetDataSource(db.PhieuLapThes.Select(plt => new
            {
                TenTK = plt.TenTK,
                MatKhau = plt.MatKhau,
                HoVaTen = plt.HoVaTen,
                NgaySinh = plt.NgaySinh,
                DiaChi = plt.DiaChi,
                Email = plt.Email,
                NgayLapThe = plt.NgayLapThe,               
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "List_PhieuLapThe.pdf");
            }
            catch
            {
                throw;
            }
        }
        // GET: PhieuLapThes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuLapThe phieuLapThe = db.PhieuLapThes.Find(id);
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
                db.PhieuLapThes.Add(phieuLapThe);
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
            PhieuLapThe phieuLapThe = db.PhieuLapThes.Find(id);
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
            PhieuLapThe phieuLapThe = db.PhieuLapThes.Find(id);
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
            PhieuLapThe phieuLapThe = db.PhieuLapThes.Find(id);
            db.PhieuLapThes.Remove(phieuLapThe);
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
