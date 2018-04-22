namespace WebQLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPhieuMuon")]
    public partial class CTPhieuMuon
    {
        [Key]
        public int MaCTPhieuMuon { get; set; }

        public int? MaPhieuMuon { get; set; }

        [StringLength(50)]
        public string MaSach { get; set; }

        public int? SoLuong { get; set; }

        public virtual PhieuMuonSach PhieuMuonSach { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
