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
CREATE TABLE TheDocGia
(
	MaTheDocGia INT IDENTITY(1,1),
	HoTen nvarchar(50) NOT NULL,
	TaiKhoan varchar(50) UNIQUE,
	MatKhau varchar(50) NOT NULL,
	Email varchar(100) UNIQUE,
	DiachiKH nvarchar (200),
	DienthoaiKH NVARCHAR(50),
	Ngaysinh DATETIME,
	Ngaylapthe DATETIME,
	CONSTRAINT PK_TheDocGia PRIMARY KEY (MaTheDocGia)
)
GO
CREATE TABLE Khoa
(
MaKhoa INT IDENTITY(1,1),
TenKhoa nvarchar(50) NOT NULL,
CONSTRAINT PK_Khoa PRIMARY KEY(MaKhoa)
) 
GO
CREATE TABLE Sach
(
	MaSach INT IDENTITY(1,1),
	TenSach NVARCHAR(50) NOT NULL,
	AnhBia VARCHAR(50),
	NgayCapNhat DATETIME,		
	SoLuong INT CHECK(SoLuong>0),
	MaKhoa INT,
	CONSTRAINT PK_Sach PRIMARY KEY(Masach),
	CONSTRAINT FK_Khoa FOREIGN KEY(MaKhoa) REFERENCES dbo.Khoa(MaKhoa)
)

GO
CREATE TABLE PhieuMuonSach
(
	MaPhieuMuon INT IDENTITY(1,1),
	MaTheDocGia INT,
	NgayMuon DATETIME,
	NgayTra DATETIME,
	CONSTRAINT PK_PhieuMuonSach PRIMARY KEY(MaPhieuMuon),
	CONSTRAINT FK_DocGia FOREIGN KEY(MaTheDocGia) REFERENCES dbo.TheDocGia(MaTheDocGia)
) 
GO
CREATE TABLE CTPhieuMuon
(	
	MaPhieuMuon INT,
	MaSach INT,
	SoLuong INT,
	CONSTRAINT PK_CTPhieuMuon PRIMARY KEY(MaPhieuMuon,MaSach),
	CONSTRAINT FK_MaPhieuMuon FOREIGN KEY(MaPhieuMuon) REFERENCES dbo.PhieuMuonSach(MaPhieuMuon),
	CONSTRAINT FK_MaSach FOREIGN KEY(MaSach) REFERENCES dbo.Sach(MaSach)
) 

-- Khoa
GO 
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Ngoại ngữ')
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Công nghệ thông tin')
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Đông phương')
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Quan hệ quốc tế')
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Quản trị kinh doanh')
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Du lịch - Khách sạn')
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Kinh tế - tài chính')
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Lý luận chính trị')
INSERT INTO dbo.Khoa( TenKhoa )VALUES  ( N'Luật')

-- Sach
GO
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 1' ,'sach.png' ,GETDATE() , 2 ,1)
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 2' ,'sach.png' ,GETDATE() , 2 ,2)
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 3' ,'sach.png' ,GETDATE() , 2 ,3)
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 4' ,'sach.png' ,GETDATE() , 2 ,4)
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 5' ,'sach.png' ,GETDATE() , 2 ,5)
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 6' ,'sach.png' ,GETDATE() , 2 ,6)
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 7' ,'sach.png' ,GETDATE() , 2 ,7)
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 8' ,'sach.png' ,GETDATE() , 2 ,8)
INSERT INTO dbo.Sach( TenSach ,AnhBia ,NgayCapNhat ,SoLuong ,MaKhoa)VALUES  ( N'Sách 9' ,'sach.png' ,GETDATE() , 2 ,9)

-- Admin
Go
CREATE TABLE Admin
(
	UserAdmin varchar(30) PRIMARY KEY,
	PassAdmin varchar(30) NOT NULL,
	Hoten nvarchar(50)
)
GO
INSERT INTO dbo.Admin
        ( UserAdmin, PassAdmin, Hoten )
VALUES  ( 'admin', -- UserAdmin - varchar(30)
          '123456', -- PassAdmin - varchar(30)
          N'Phùng Gia Oai'  -- Hoten - nvarchar(50)
          )
INSERT INTO dbo.Admin
        ( UserAdmin, PassAdmin, Hoten )
VALUES  ( 'user', -- UserAdmin - varchar(30)
          '654321', -- PassAdmin - varchar(30)
          N'ABC'  -- Hoten - nvarchar(50)
          )
GO