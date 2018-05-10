using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcThuVien.Models;

namespace MvcThuVien.Controllers
{
    public class PhieuMuonController : Controller
    {
        ModelTV data = new ModelTV();
        //Lay gio hang
        public List<Phieumuon> LayPhieumuon()
        {
            List<Phieumuon> lstPhieumuon = Session["Phieumuon"] as List<Phieumuon>;
            if (lstPhieumuon == null)
            {
                //nếu giỏe hàng chưa tồn tại thì khởi tạo
                lstPhieumuon = new List<Phieumuon>();
                Session["Phieumuon"] = lstPhieumuon;
            }
            return lstPhieumuon;
        }
        //Thêm vào giở hàng
        public ActionResult ThemPhieumuon(int iMasach, string strURL)
        {
            List<Phieumuon> lstPhieumuon = LayPhieumuon();
            Phieumuon sanpham = lstPhieumuon.Find(n => n.iMasach == iMasach);
            if (sanpham == null)
            {
                sanpham = new Phieumuon(iMasach);
                lstPhieumuon.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        //Tổng số lượng
        private int Tongsoluong()
        {
            int iTongsoluong = 0;
            List<Phieumuon> lstPhieumuon = Session["Phieumuon"] as List<Phieumuon>;
            if (lstPhieumuon != null)
            {
                iTongsoluong = lstPhieumuon.Sum(n => n.iSoluong);
            }
            return iTongsoluong;
        }
        // GET: PhieuMuon
        public ActionResult Phieumuon()
        {
            List<Phieumuon> lstPhieumuon = LayPhieumuon();
            if (lstPhieumuon.Count == 0)
            {
                return RedirectToAction("Index", "ThuVien");
            }
            ViewBag.Tongsoluong = Tongsoluong();
            return View(lstPhieumuon);
        }
        //tạo partial view hiển thị thông tin giỏ hàng
        public ActionResult PhieumuonPartial()
        {
            ViewBag.Tongsoluong = Tongsoluong();
            return PartialView();
        }
        //Xóa 1 sanpham Giỏ hàng
        public ActionResult XoaPhieumuon(int iMaSP)
        {
            //Lay gio hang 
            List<Phieumuon> lstPhieumuon = LayPhieumuon();
            //kiểm tra sách có trong giỏ hàng
            Phieumuon sanpham = lstPhieumuon.SingleOrDefault(n => n.iMasach == iMaSP);
            if (sanpham != null)
            {
                lstPhieumuon.RemoveAll(n => n.iMasach == iMaSP);
                return RedirectToAction("Phieumuon");
            }
            if (lstPhieumuon.Count == 0)
            {
                return RedirectToAction("Index", "ThuVien");
            }
            return RedirectToAction("Phieumuon");
        }
        //Cập nhật giỏ hàng
        public ActionResult CapnhatPhieumuon(int iMaSP, FormCollection f)
        {
            //Lay gio hang 
            List<Phieumuon> lstPhieumuon = LayPhieumuon();
            //kiểm tra sách có trong giỏ hàng
            Phieumuon sanpham = lstPhieumuon.SingleOrDefault(n => n.iMasach == iMaSP);
            //nếu tồn tại thì cho sữa số lượng 
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Phieumuon");
        }
        //Xóa giỏ hàng
        public ActionResult XoaTatcaPhieumuon()
        {
            //Lay gio hang 
            List<Phieumuon> lstPhieumuon = LayPhieumuon();
            lstPhieumuon.Clear();
            return RedirectToAction("Phieumuon");
        }
        //Dat hang
        [HttpGet]
        public ActionResult DatPhieu()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            if (Session["Phieumuon"] == null)
            {
                return RedirectToAction("Index", "ThuVien");
            }
            //Lay gio hang tu session
            List<Phieumuon> lstPhieumuon = LayPhieumuon();
            ViewBag.Tongsoluong = Tongsoluong();
            return View(lstPhieumuon);
        }
        [HttpPost]
        public ActionResult DatPhieu(FormCollection collection)
        {
            PhieuMuonSach pms = new PhieuMuonSach();
            TheDocGia kh = (TheDocGia)Session["Taikhoan"];
            List<Phieumuon> lstPhieumuon = LayPhieumuon();
            pms.MaTheDocGia = kh.MaTheDocGia;
            pms.NgayMuon = DateTime.Now;
            pms.NgayTra = DateTime.Now.AddDays(7);
            data.PhieuMuonSaches.Add(pms);
            data.SaveChanges();
            foreach (var item in lstPhieumuon)
            {
                CTPhieuMuon ctpm = new CTPhieuMuon();
                ctpm.MaPhieuMuon = pms.MaPhieuMuon;
                ctpm.MaSach = item.iMasach;
                ctpm.SoLuong = item.iSoluong;                
                data.CTPhieuMuons.Add(ctpm);
            }
            data.SaveChanges();
            Session["Phieumuon"] = null;
            return RedirectToAction("XacnhanPhieumuon", "Phieumuon");
        }
        public ActionResult XacnhanPhieumuon()
        {
            return View();
        }
    }
}