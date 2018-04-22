namespace WebQLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThuTienPhat")]
    public partial class PhieuThuTienPhat
    {
        [Key]
        public int MaPhieuThuTienPhat { get; set; }

        public int? MaPhieuTra { get; set; }

        public double? SoTienThu { get; set; }

        public double? ConLai { get; set; }

        public virtual PhieuTraSach PhieuTraSach { get; set; }
    }
}
