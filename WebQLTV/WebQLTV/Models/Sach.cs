using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class Sach
    {
        [Key]
        public string IDSach { get; set; }
        public string TenSach { get; set; }
        public int IdLoaiSach { get; set; }
        public int IdTacGia { get; set; }
        public int IdNhaXuatBan { get; set; }
        public DateTime NamSanXuat { get; set; }
        public DateTime NgayNhap { get; set; }
        public double TriGia { get; set; }
        public int SoLuong { get; set; }

        public virtual TacGia TacGia { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual LoaiSach LoaiSach { get; set; }
        public virtual CTPhieuMuon CTPhieuMuon { get; set; }
    }
}