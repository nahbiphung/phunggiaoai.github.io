using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcThuVien.Models;
using PagedList;

namespace MvcThuVien.Controllers
{
    public class ThuVienController : Controller
    {
        dbQLTVDataContext data = new dbQLTVDataContext();
        private List<Sach> Laysachmoi(int count)
        {
            return data.Saches.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        // GET: ThuVien
        public ActionResult Index(int? page)
        {
            //số sản phẩm mỗi trang
            int pageSize = 6;
            //số trang
            int pageNum = (page ?? 1);

            var sachmoi = Laysachmoi(15);
            return View(sachmoi.ToPagedList(pageNum, pageSize));
        }
        //Khoa
        public ActionResult Khoa()
        {
            var khoa = from k in data.Khoas select k;
            return PartialView(khoa);
        }
        public ActionResult SPTheokhoa(int id)
        {
            var sach = from s in data.Saches where s.MaKhoa == id select s;
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = from s in data.Saches
                       where s.MaSach == id
                       select s;
            return View(sach.Single());
        }
        public ActionResult ThuVienPartial()
        {
            return PartialView();
        }
        public ActionResult DangnhapPartial()
        {
            return PartialView();
        }
    }
}