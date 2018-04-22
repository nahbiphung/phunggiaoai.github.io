namespace WebQLThuVien.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelQLThuVien : DbContext
    {
        public ModelQLThuVien()
            : base("name=ModelQLThuVien")
        {
        }

        public virtual DbSet<CTPhieuMuon> CTPhieuMuons { get; set; }
        public virtual DbSet<CTPhieuTra> CTPhieuTras { get; set; }
        public virtual DbSet<LoaiDocGia> LoaiDocGias { get; set; }
        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<NXB> NXBs { get; set; }
        public virtual DbSet<PhieuLapThe> PhieuLapThes { get; set; }
        public virtual DbSet<PhieuMuonSach> PhieuMuonSaches { get; set; }
        public virtual DbSet<PhieuThuTienPhat> PhieuThuTienPhats { get; set; }
        public virtual DbSet<PhieuTraSach> PhieuTraSaches { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<ThamSo> ThamSoes { get; set; }
        public virtual DbSet<TheDocGia> TheDocGias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
