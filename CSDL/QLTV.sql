-- DATABASE CSDL 
-- XOA CSDL 
USE MASTER 
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QLTV') 
DROP DATABASE QLTV
GO 
-- TAO CSDL 
CREATE DATABASE QLTV
GO -- SU DUNG CSDL SalesERPDAL 
USE QLTV
GO 
-- TABLES CSDL 
CREATE TABLE PhieuLapThe
(
TenTK NVARCHAR(50) NOT NULL,
MatKhau NVARCHAR(50) NOT NULL,
HoVaTen NVARCHAR(50) NOT NULL,
NgaySinh DateTime,
DiaChi NVarchar(50),
Email NVARCHAR(50),
NgayLapThe DateTime,
CONSTRAINT PK_PhieuLapThe PRIMARY KEY(TenTK)
) 
GO
CREATE TABLE LoaiDocGia
(
MaLoaiDocGia INT IDENTITY(1,1),
TenLoai nvarchar(50),
CONSTRAINT PK_LoaiDocGia PRIMARY KEY(MaLoaiDocGia)
)
GO
CREATE TABLE TheDocGia
(
MaTheDocGia INT IDENTITY(1,1),
MaLoaiDocGia int FOREIGN KEY REFERENCES LoaiDocGia(MaLoaiDocGia),
TenTK NVARCHAR(50) FOREIGN KEY REFERENCES PhieuLapThe(TenTK),
CONSTRAINT PK_TheDocGia PRIMARY KEY(MaTheDocGia)
)
GO
CREATE TABLE LoaiSach
(
MaLoaiSach INT IDENTITY(1,1),
TenLoaiSach nvarchar(50),
CONSTRAINT PK_LoaiSach PRIMARY KEY(MaLoaiSach)
) 
GO
CREATE TABLE TacGia
(
MaTacGia INT IDENTITY(1,1),
TenTacGia nvarchar(50),
CONSTRAINT PK_TacGia PRIMARY KEY(MaTacGia)
) 
GO
CREATE TABLE NXB
(
MaNhaXuatBan INT IDENTITY(1,1),
TenNhaXuatBan nvarchar(50),
CONSTRAINT PK_NXB PRIMARY KEY(MaNhaXuatBan)
) 
GO
CREATE TABLE ThongTinSach
(
MaThongTinSach INT IDENTITY(1,1),
MaLoaiSach int FOREIGN KEY REFERENCES LoaiSach(MaLoaiSach),
MaTacGia int FOREIGN KEY REFERENCES TacGia(MaTacGia),
MaNhaXuatBan int FOREIGN KEY REFERENCES NXB(MaNhaXuatBan),
TenSach NVarchar(50),
NamXuatBan DateTime,
NgayNhap DateTime,
TriGia float,
CONSTRAINT PK_ThongTinSach PRIMARY KEY(MaThongTinSach)
)
GO
CREATE TABLE DanhSachSach
(
MaSach INT IDENTITY(1,1),
MaThongTinSach int FOREIGN KEY REFERENCES ThongTinSach(MaThongTinSach),
TinhTrang nvarchar(10)
CONSTRAINT PK_DanhSachSach PRIMARY KEY(MaSach)
)
GO
CREATE TABLE PhieuMuonSach
(
MaPhieuMuon INT IDENTITY(1,1),
MaTheDocGia int FOREIGN KEY REFERENCES TheDocGia(MaTheDocGia),
NgayMuon Datetime,
CONSTRAINT PK_PhieuMuonSach PRIMARY KEY(MaPhieuMuon)
) 
GO
CREATE TABLE CTPhieuMuon
(
MaCTPhieuMuon INT IDENTITY(1,1),
MaPhieuMuon int FOREIGN KEY REFERENCES PhieuMuonSach(MaPhieuMuon),
MaSach int FOREIGN KEY REFERENCES DanhSachSach(MaSach),
SoLuong int,
CONSTRAINT PK_CTPhieuMuon PRIMARY KEY(MaCTPhieuMuon)
) 
GO
CREATE TABLE CTPhieuTra
(
MaCTPhieuTra INT IDENTITY(1,1),
MaPhieumuon INT FOREIGN KEY REFERENCES PhieuMuonSach(MaPhieuMuon),
NgayTra datetime,
TienPhatKyNay int,
TongNo int,
SoNgayMuon int,
TienPhat int,
CONSTRAINT PK_CTPhieuTra PRIMARY KEY(MaCTPhieuTra)
) 
GO
CREATE TABLE PhieuTraSach
(
MaPhieuTra INT IDENTITY(1,1),
MaCTPhieuTRa int FOREIGN KEY REFERENCES CTPhieuTra(MaCTPhieuTra),
CONSTRAINT PK_PhieuTraSach PRIMARY KEY(MaPhieuTra)
) 
GO
CREATE TABLE PhieuThuTienPhat
(
MaPhieuThuTienPhat INT IDENTITY(1,1),
MaPhieuTra int FOREIGN KEY REFERENCES PhieuTraSach(MaPhieuTra),
SoTienThu int,
ConLai int,
CONSTRAINT PK_PhieuThuTienPhat PRIMARY KEY(MaPhieuThuTienPhat)
) 
GO
CREATE TABLE ThamSo
(
MaThamSo INT IDENTITY(1,1),
TenThamSo nvarchar(50),
GhiChu nvarchar(50),
CONSTRAINT PK_ThamSo PRIMARY KEY(MaThamSo)
) 

--LoaiDocGia
INSERT INTO LoaiDocGia(TenLoai) VALUES('VIP')
INSERT INTO	LoaiDocGia(TenLoai) VALUES('THUONG')
GO
--ThamSo
INSERT INTO	ThamSo(TenThamSo,GhiChu) VALUES(6,N'Thẻ có giá trị 6 tháng')
INSERT INTO	ThamSo(TenThamSo,GhiChu) VALUES(8,N'Nhận các sách xuất bản trong vòng 8 năm')
GO
--LoaiSash
INSERT INTO	LoaiSach(TenLoaiSach) VALUES(N'Tin học')
INSERT INTO	LoaiSach(TenLoaiSach) VALUES(N'Luật')
INSERT INTO	LoaiSach(TenLoaiSach) VALUES(N'Ngoại ngữ')
GO
--TenTacGia
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn A')
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn B')
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn C')
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn D')
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn E')
GO
--NhaXuatBan
INSERT INTO NXB(TenNhaXuatBan) VALUES(N'Kim Đồng')
INSERT INTO NXB(TenNhaXuatBan) VALUES(N'Nhân Văn')
INSERT INTO NXB(TenNhaXuatBan) VALUES(N'Thời trẻ')
GO

--PhieuLapThe
INSERT INTO PhieuLapThe(TenTK,MatKhau,HoVaTen,NgaySinh,DiaChi,Email,NgayLapThe) VALUES('admin','123',N'Phùng Gia Oai','10/10/2010','Đương ACV','phunggiaoai@gmail.com','04/04/2018')

--ThongTinSach
INSERT INTO dbo.ThongTinSach
        ( MaLoaiSach ,
          MaTacGia ,
          MaNhaXuatBan ,
          TenSach ,
          NamXuatBan ,
          NgayNhap ,
          TriGia
        )
VALUES  ( 1 , -- MaLoaiSach - int
          1 , -- MaTacGia - int
          1 , -- MaNhaXuatBan - int
          N'Tin học' , -- TenSach - nvarchar(50)
          '1/1/2000' , -- NamXuatBan - datetime
          GETDATE() , -- NgayNhap - datetime
          50.000  -- TriGia - float
        )
--danh sách sách
INSERT INTO dbo.DanhSachSach
        ( MaThongTinSach, TinhTrang )
VALUES  ( 1, -- MaThongTinSach - int
          N'Còn'  -- TinhTrang - nvarchar(10)
          )
--Thẻ đọc giả
INSERT INTO dbo.TheDocGia
        ( MaLoaiDocGia, TenTK )
VALUES  ( 1, -- MaLoaiDocGia - int
          'admin'  
          )
--Phiếu mượn sách
INSERT INTO dbo.PhieuMuonSach
        ( MaTheDocGia, NgayMuon )
VALUES  ( 1, -- MaCTPhieuMuon - int
          GETDATE()  -- NgayMuon - datetime
          )
--CT Phiếu mượn
INSERT INTO dbo.CTPhieuMuon
        ( MaPhieuMuon, MaSach, SoLuong )
VALUES  ( 1, -- MaTheDocGia - int
          1, -- MaSach - int
          1  -- SoLuong - int
          )
