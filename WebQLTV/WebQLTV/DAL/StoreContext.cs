using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebQLTV.Models;

namespace WebQLTV.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("QLThuVien") { }
        public DbSet<LoaiDocGia> LoaiDocGia { get; set; }
        public DbSet<PhieuLapThe> PhieuLapThe { get; set; }
        public DbSet<LoaiSach> LoaiSach { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public DbSet<TacGia> TacGia { get; set; }
        public DbSet<TheDocGia> TheDocGia { get; set; }
        public DbSet<Sach> Sach { get; set; }
        public DbSet<PhieuMuonSach> PhieuMuonSach { get; set; }
        public DbSet<CTPhieuMuon> CTPhieuMuon { get; set; }
        public DbSet<CTPhieuTra> CTPhieuTra { get; set; }
        public DbSet<PhieuTraSach> PhieuTra { get; set; }
        public DbSet<PhieuThuTienPhat> PhieuThuTienPhat { get; set; }
    }
}