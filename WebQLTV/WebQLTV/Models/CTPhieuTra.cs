using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class CTPhieuTra
    {
        [Key]
        public int IDChiTietPhieuTra { get; set; }
        public int IdPhieuMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public double TienPhatKiNay { get; set; }
        public double TongNo { get; set; }
        public int SoNgayMuon { get; set; }
        public double TienPhat { get; set; }

        public virtual PhieuMuonSach PhieuMuonSach { get; set; }
        public virtual PhieuTraSach PhieuTraSach { get; set; }
    }
}