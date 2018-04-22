namespace WebQLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheDocGia")]
    public partial class TheDocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheDocGia()
        {
            PhieuMuonSaches = new HashSet<PhieuMuonSach>();
        }

        [Key]
        [StringLength(50)]
        public string MaTheDocGia { get; set; }

        public int? MaLoaiDocGia { get; set; }

        [StringLength(50)]
        public string TenTK { get; set; }

        public virtual LoaiDocGia LoaiDocGia { get; set; }

        public virtual PhieuLapThe PhieuLapThe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuonSach> PhieuMuonSaches { get; set; }
    }
}
