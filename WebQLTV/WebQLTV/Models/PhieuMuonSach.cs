using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class PhieuMuonSach
    {
        [Key]
        public int IDPhieuMuon { get; set; }
        public string IdTheDocGia { get; set; }
        public DateTime NgayMuon { get; set; }

        public virtual TheDocGia TheDocGia { get; set; }
        public virtual ICollection<CTPhieuMuon> CTPhieuMuon { get; set; }
        public virtual ICollection<CTPhieuTra> CTPhieuTra { get; set; }
    }
}