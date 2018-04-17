using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class PhieuLapThe
    {
        [Key]
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime NgayLapThe { get; set; }

        public virtual TheDocGia TheDocGia { get; set; }
    }
}