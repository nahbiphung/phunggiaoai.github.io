namespace WebQLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuonSach")]
    public partial class PhieuMuonSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuonSach()
        {
            CTPhieuMuons = new HashSet<CTPhieuMuon>();
            CTPhieuTras = new HashSet<CTPhieuTra>();
        }

        [Key]
        public int MaPhieuMuon { get; set; }

        [StringLength(50)]
        public string MaTheDocGia { get; set; }

        public DateTime? NgayMuon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuMuon> CTPhieuMuons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuTra> CTPhieuTras { get; set; }

        public virtual TheDocGia TheDocGia { get; set; }
    }
}
