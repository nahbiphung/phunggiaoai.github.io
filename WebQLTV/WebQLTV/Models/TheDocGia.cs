using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class TheDocGia
    {
        [Key]
        public string IDTheDocGia { get; set; }
        public int IdLoaiDocGia { get; set; }
        public string TenTK { get; set; }

        public virtual LoaiDocGia LoaiDocGia { get; set; }
        public virtual ICollection<PhieuLapThe> PhieuLapThe { get; set; }
        public virtual ICollection<PhieuMuonSach> PhieuMuonSach { get; set; }
    }
}