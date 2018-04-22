namespace WebQLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPhieuTra")]
    public partial class CTPhieuTra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CTPhieuTra()
        {
            PhieuTraSaches = new HashSet<PhieuTraSach>();
        }

        [Key]
        public int MaCTPhieuTra { get; set; }

        public int? MaPhieumuon { get; set; }

        public DateTime? NgayTra { get; set; }

        public double? TienPhatKiNay { get; set; }

        public double? TongNo { get; set; }

        public int? SoNgayMuon { get; set; }

        public double? TienPhat { get; set; }

        public virtual PhieuMuonSach PhieuMuonSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuTraSach> PhieuTraSaches { get; set; }
    }
}
