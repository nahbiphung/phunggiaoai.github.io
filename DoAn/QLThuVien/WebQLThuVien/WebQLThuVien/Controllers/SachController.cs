using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    public class SachController : Controller
    {
        ModelQLThuVien db = new ModelQLThuVien();
        // GET: Sach
        public ActionResult ListSach()
        {
            return View(db.Saches.ToList());
        }
        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "ReportSach.rpt"));
            rd.SetDataSource(db.Saches.ToList());
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
        }
    }
}