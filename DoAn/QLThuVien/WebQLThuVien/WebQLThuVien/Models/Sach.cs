namespace WebQLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            CTPhieuMuons = new HashSet<CTPhieuMuon>();
        }

        [Key]
        [StringLength(50)]
        public string MaSach { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        public int MaLoaiSach { get; set; }

        public int MaTacGia { get; set; }

        public int MaNhaXuatBan { get; set; }

        public DateTime NamXuatBan { get; set; }

        public DateTime NgayNhap { get; set; }

        public double TriGia { get; set; }

        public int SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuMuon> CTPhieuMuons { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        public virtual NXB NXB { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
