namespace WebQLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThamSo")]
    public partial class ThamSo
    {
        [Key]
        public int MaThamSo { get; set; }

        [StringLength(50)]
        public string TenThamSo { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }
    }
}
