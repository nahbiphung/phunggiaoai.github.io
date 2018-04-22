namespace WebQLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuTraSach")]
    public partial class PhieuTraSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuTraSach()
        {
            PhieuThuTienPhats = new HashSet<PhieuThuTienPhat>();
        }

        [Key]
        public int MaPhieuTra { get; set; }

        public int? MaCTPhieuTRa { get; set; }

        public virtual CTPhieuTra CTPhieuTra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThuTienPhat> PhieuThuTienPhats { get; set; }
    }
}
