using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class CTPhieuMuon
    {
        [Key]
        public int IDChiTietPhieuMuon { get; set; }
        public int IdPhieuMuon { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }

        public virtual PhieuMuonSach PhieuMuonSach { get; set; }
        public virtual ICollection<Sach> Sach { get; set; }
    }
}