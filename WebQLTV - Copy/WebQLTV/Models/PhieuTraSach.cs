using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class PhieuTraSach
    {
        [Key]
        public int IDPhieuTra { get; set; }
        public int IdChiTietPhieuTra { get; set; }

        public virtual ICollection<CTPhieuTra> CTPhieuTra { get; set; }
        public virtual ICollection<PhieuThuTienPhat> PhieuThuTienPhat { get; set; }
    }
}