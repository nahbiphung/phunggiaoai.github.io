namespace WebQLTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BDQLTV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTPhieuMuons",
                c => new
                    {
                        IDChiTietPhieuMuon = c.Int(nullable: false, identity: true),
                        IdPhieuMuon = c.Int(nullable: false),
                        MaSach = c.String(),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDChiTietPhieuMuon)
                .ForeignKey("dbo.PhieuMuonSaches", t => t.IdPhieuMuon, cascadeDelete: true)
                .Index(t => t.IdPhieuMuon);
            
            CreateTable(
                "dbo.PhieuMuonSaches",
                c => new
                    {
                        IDPhieuMuon = c.Int(nullable: false, identity: true),
                        IdTheDocGia = c.String(maxLength: 128),
                        NgayMuon = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDPhieuMuon)
                .ForeignKey("dbo.TheDocGias", t => t.IdTheDocGia)
                .Index(t => t.IdTheDocGia);
            
            CreateTable(
                "dbo.CTPhieuTras",
                c => new
                    {
                        IDChiTietPhieuTra = c.Int(nullable: false, identity: true),
                        IdPhieuMuon = c.Int(nullable: false),
                        NgayTra = c.DateTime(nullable: false),
                        TienPhatKiNay = c.Double(nullable: false),
                        TongNo = c.Double(nullable: false),
                        SoNgayMuon = c.Int(nullable: false),
                        TienPhat = c.Double(nullable: false),
                        PhieuTraSach_IDPhieuTra = c.Int(),
                    })
                .PrimaryKey(t => t.IDChiTietPhieuTra)
                .ForeignKey("dbo.PhieuMuonSaches", t => t.IdPhieuMuon, cascadeDelete: true)
                .ForeignKey("dbo.PhieuTraSaches", t => t.PhieuTraSach_IDPhieuTra)
                .Index(t => t.IdPhieuMuon)
                .Index(t => t.PhieuTraSach_IDPhieuTra);
            
            CreateTable(
                "dbo.PhieuTraSaches",
                c => new
                    {
                        IDPhieuTra = c.Int(nullable: false, identity: true),
                        IdChiTietPhieuTra = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPhieuTra);
            
            CreateTable(
                "dbo.PhieuThuTienPhats",
                c => new
                    {
                        IDPhieuThuTienPhat = c.Int(nullable: false, identity: true),
                        IdPhieuTra = c.Int(nullable: false),
                        SoTienThu = c.Double(nullable: false),
                        ConLai = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IDPhieuThuTienPhat)
                .ForeignKey("dbo.PhieuTraSaches", t => t.IdPhieuTra, cascadeDelete: true)
                .Index(t => t.IdPhieuTra);
            
            CreateTable(
                "dbo.TheDocGias",
                c => new
                    {
                        IDTheDocGia = c.String(nullable: false, maxLength: 128),
                        IdLoaiDocGia = c.Int(nullable: false),
                        TenTK = c.String(),
                    })
                .PrimaryKey(t => t.IDTheDocGia)
                .ForeignKey("dbo.LoaiDocGias", t => t.IdLoaiDocGia, cascadeDelete: true)
                .Index(t => t.IdLoaiDocGia);
            
            CreateTable(
                "dbo.LoaiDocGias",
                c => new
                    {
                        IDLoaiDocGia = c.Int(nullable: false, identity: true),
                        TenLoaiDocGia = c.String(),
                    })
                .PrimaryKey(t => t.IDLoaiDocGia);
            
            CreateTable(
                "dbo.PhieuLapThes",
                c => new
                    {
                        TenTK = c.String(nullable: false, maxLength: 128),
                        MatKhau = c.String(),
                        HoVaTen = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        DiaChi = c.String(),
                        Email = c.String(),
                        NgayLapThe = c.DateTime(nullable: false),
                        TheDocGia_IDTheDocGia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TenTK)
                .ForeignKey("dbo.TheDocGias", t => t.TheDocGia_IDTheDocGia)
                .Index(t => t.TheDocGia_IDTheDocGia);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        IDSach = c.String(nullable: false, maxLength: 128),
                        TenSach = c.String(),
                        IdLoaiSach = c.Int(nullable: false),
                        IdTacGia = c.Int(nullable: false),
                        IdNhaXuatBan = c.Int(nullable: false),
                        NamSanXuat = c.DateTime(nullable: false),
                        NgayNhap = c.DateTime(nullable: false),
                        TriGia = c.Double(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        CTPhieuMuon_IDChiTietPhieuMuon = c.Int(),
                    })
                .PrimaryKey(t => t.IDSach)
                .ForeignKey("dbo.CTPhieuMuons", t => t.CTPhieuMuon_IDChiTietPhieuMuon)
                .ForeignKey("dbo.LoaiSaches", t => t.IdLoaiSach, cascadeDelete: true)
                .ForeignKey("dbo.NhaXuatBans", t => t.IdNhaXuatBan, cascadeDelete: true)
                .ForeignKey("dbo.TacGias", t => t.IdTacGia, cascadeDelete: true)
                .Index(t => t.IdLoaiSach)
                .Index(t => t.IdTacGia)
                .Index(t => t.IdNhaXuatBan)
                .Index(t => t.CTPhieuMuon_IDChiTietPhieuMuon);
            
            CreateTable(
                "dbo.LoaiSaches",
                c => new
                    {
                        IDLoaiSach = c.Int(nullable: false, identity: true),
                        TenLoaiSach = c.String(),
                    })
                .PrimaryKey(t => t.IDLoaiSach);
            
            CreateTable(
                "dbo.NhaXuatBans",
                c => new
                    {
                        IDNhaXuatBan = c.Int(nullable: false, identity: true),
                        TenNhaXuatBan = c.String(),
                    })
                .PrimaryKey(t => t.IDNhaXuatBan);
            
            CreateTable(
                "dbo.TacGias",
                c => new
                    {
                        IDTacGia = c.Int(nullable: false, identity: true),
                        TenTacGia = c.String(),
                    })
                .PrimaryKey(t => t.IDTacGia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "IdTacGia", "dbo.TacGias");
            DropForeignKey("dbo.Saches", "IdNhaXuatBan", "dbo.NhaXuatBans");
            DropForeignKey("dbo.Saches", "IdLoaiSach", "dbo.LoaiSaches");
            DropForeignKey("dbo.Saches", "CTPhieuMuon_IDChiTietPhieuMuon", "dbo.CTPhieuMuons");
            DropForeignKey("dbo.PhieuMuonSaches", "IdTheDocGia", "dbo.TheDocGias");
            DropForeignKey("dbo.PhieuLapThes", "TheDocGia_IDTheDocGia", "dbo.TheDocGias");
            DropForeignKey("dbo.TheDocGias", "IdLoaiDocGia", "dbo.LoaiDocGias");
            DropForeignKey("dbo.PhieuThuTienPhats", "IdPhieuTra", "dbo.PhieuTraSaches");
            DropForeignKey("dbo.CTPhieuTras", "PhieuTraSach_IDPhieuTra", "dbo.PhieuTraSaches");
            DropForeignKey("dbo.CTPhieuTras", "IdPhieuMuon", "dbo.PhieuMuonSaches");
            DropForeignKey("dbo.CTPhieuMuons", "IdPhieuMuon", "dbo.PhieuMuonSaches");
            DropIndex("dbo.Saches", new[] { "CTPhieuMuon_IDChiTietPhieuMuon" });
            DropIndex("dbo.Saches", new[] { "IdNhaXuatBan" });
            DropIndex("dbo.Saches", new[] { "IdTacGia" });
            DropIndex("dbo.Saches", new[] { "IdLoaiSach" });
            DropIndex("dbo.PhieuLapThes", new[] { "TheDocGia_IDTheDocGia" });
            DropIndex("dbo.TheDocGias", new[] { "IdLoaiDocGia" });
            DropIndex("dbo.PhieuThuTienPhats", new[] { "IdPhieuTra" });
            DropIndex("dbo.CTPhieuTras", new[] { "PhieuTraSach_IDPhieuTra" });
            DropIndex("dbo.CTPhieuTras", new[] { "IdPhieuMuon" });
            DropIndex("dbo.PhieuMuonSaches", new[] { "IdTheDocGia" });
            DropIndex("dbo.CTPhieuMuons", new[] { "IdPhieuMuon" });
            DropTable("dbo.TacGias");
            DropTable("dbo.NhaXuatBans");
            DropTable("dbo.LoaiSaches");
            DropTable("dbo.Saches");
            DropTable("dbo.PhieuLapThes");
            DropTable("dbo.LoaiDocGias");
            DropTable("dbo.TheDocGias");
            DropTable("dbo.PhieuThuTienPhats");
            DropTable("dbo.PhieuTraSaches");
            DropTable("dbo.CTPhieuTras");
            DropTable("dbo.PhieuMuonSaches");
            DropTable("dbo.CTPhieuMuons");
        }
    }
}
