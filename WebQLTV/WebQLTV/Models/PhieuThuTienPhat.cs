using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class PhieuThuTienPhat
    {
        [Key]
        public int IDPhieuThuTienPhat { get; set; }
        public int IdPhieuTra { get; set; }
        public double SoTienThu { get; set; }
        public double ConLai { get; set; }

        public virtual PhieuTraSach PhieuTraSach { get; set; }
    }
}