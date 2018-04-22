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
MaTheDocGia NVARCHAR(50),
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
CREATE TABLE Sach
(
MaSach NVARCHAR(50),
TenSach NVarchar(50),
MaLoaiSach int FOREIGN KEY REFERENCES LoaiSach(MaLoaiSach),
MaTacGia int FOREIGN KEY REFERENCES TacGia(MaTacGia),
MaNhaXuatBan int FOREIGN KEY REFERENCES NXB(MaNhaXuatBan),
NamXuatBan DateTime,
NgayNhap DateTime,
TriGia FLOAT,
SoLuong INT,
CONSTRAINT PK_ThongTinSach PRIMARY KEY(MaSach)
)

GO
CREATE TABLE PhieuMuonSach
(
MaPhieuMuon INT IDENTITY(1,1),
MaTheDocGia NVARCHAR(50) FOREIGN KEY REFERENCES TheDocGia(MaTheDocGia),
NgayMuon Datetime,
CONSTRAINT PK_PhieuMuonSach PRIMARY KEY(MaPhieuMuon)
) 
GO
CREATE TABLE CTPhieuMuon
(
MaCTPhieuMuon INT IDENTITY(1,1),
MaPhieuMuon int FOREIGN KEY REFERENCES PhieuMuonSach(MaPhieuMuon),
MaSach NVARCHAR(50) FOREIGN KEY REFERENCES Sach(MaSach),
SoLuong int,
CONSTRAINT PK_CTPhieuMuon PRIMARY KEY(MaCTPhieuMuon)
) 
GO
CREATE TABLE CTPhieuTra
(
MaCTPhieuTra INT IDENTITY(1,1),
MaPhieumuon INT FOREIGN KEY REFERENCES PhieuMuonSach(MaPhieuMuon),
NgayTra datetime,
TienPhatKiNay FLOAT,
TongNo FLOAT,
SoNgayMuon int,
TienPhat FLOAT,
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
SoTienThu FLOAT,
ConLai FLOAT,
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
insert into LoaiSach(TenLoaiSach) values(N'Khoa học')
insert into LoaiSach(TenLoaiSach) values(N'Văn học')
insert into LoaiSach(TenLoaiSach) values(N'Truyện thiếu nhi')
insert into LoaiSach(TenLoaiSach) values(N'Truyện nước ngoài')
insert into LoaiSach(TenLoaiSach) values(N'Toán học')
GO
--TenTacGia
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn A')
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn B')
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn C')
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn D')
INSERT INTO	TacGia(TenTacGia) VALUES(N'Nguyễn Văn E')
insert into TacGia(TenTacGia) values(N'Tô Hoài')
insert into TacGia(TenTacGia) values(N'Xuân Diệu')
insert into TacGia(TenTacGia) values(N'Hồ Xuân Hương')


GO
--NhaXuatBan
INSERT INTO NXB(TenNhaXuatBan) VALUES(N'Kim Đồng')
INSERT INTO NXB(TenNhaXuatBan) VALUES(N'Nhân Văn')
INSERT INTO NXB(TenNhaXuatBan) VALUES(N'Thời trẻ')
insert into NXB(TenNhaXuatBan) values(N'Đại học Quốc gia TPHCM')
insert into NXB(TenNhaXuatBan) values(N'Lao Động')
insert into NXB(TenNhaXuatBan) values(N'Khoa học xã hội')
insert into NXB(TenNhaXuatBan) values(N'Khoa học tự nhiên và công nghệ')
insert into NXB(TenNhaXuatBan) values(N'Văn học')
GO

--PhieuLapThe
INSERT INTO PhieuLapThe(TenTK,MatKhau,HoVaTen,NgaySinh,DiaChi,Email,NgayLapThe) VALUES('admin','123',N'Phùng Gia Oai','10/10/2010','Đương ACV','phunggiaoai@gmail.com','04/04/2018')
INSERT INTO PhieuLapThe(TenTK,MatKhau,HoVaTen,NgaySinh,DiaChi,Email,NgayLapThe) VALUES('admin1','123',N'Tran Hai Bao','1/2/1997','Đương ACV','phunggiaoai@gmail.com','04/04/2018')
INSERT INTO PhieuLapThe(TenTK,MatKhau,HoVaTen,NgaySinh,DiaChi,Email,NgayLapThe) VALUES('admin2','123',N'Manh Khang','3/9/2010','Đương ACV','phunggiaoai@gmail.com','04/04/2018')
INSERT INTO PhieuLapThe(TenTK,MatKhau,HoVaTen,NgaySinh,DiaChi,Email,NgayLapThe) VALUES('admin3','123',N'My Tam','2/5/2010','Đương ACV','phunggiaoai@gmail.com','04/04/2018')
INSERT INTO PhieuLapThe(TenTK,MatKhau,HoVaTen,NgaySinh,DiaChi,Email,NgayLapThe) VALUES('admin4','123',N'Son Tung','5/4/2010','Đương ACV','phunggiaoai@gmail.com','04/04/2018')
--TheDocGia
insert into TheDocGia (MaTheDocGia, MaLoaiDocGia, TenTK) values ('V001', 1, 'admin');
insert into TheDocGia (MaTheDocGia, MaLoaiDocGia, TenTK) values ('V002', 1, 'admin1');
insert into TheDocGia (MaTheDocGia, MaLoaiDocGia, TenTK) values ('V003', 1, 'admin2');

--Sach  
insert into Sach(MaSach, TenSach, MaLoaiSach, MaTacGia, MaNhaXuatBan, NamXuatBan, NgayNhap, TriGia, SoLuong) values (N'TH001', N'Tempsoft', 1, 1, 7, '05/07/2017', '07/14/2017', '2.93', 13)
insert into Sach(MaSach, TenSach, MaLoaiSach, MaTacGia, MaNhaXuatBan, NamXuatBan, NgayNhap, TriGia, SoLuong) values (N'TH002', N'software', 1, 1, 7, '05/07/2017', '07/21/2017', '5.93', 13)
insert into Sach(MaSach, TenSach, MaLoaiSach, MaTacGia, MaNhaXuatBan, NamXuatBan, NgayNhap, TriGia, SoLuong) values (N'VH001', N'Van Hoc lop 1', 5, 6, 1,' 05/07/2017', '07/14/2017', 200000, 13)
insert into Sach(MaSach, TenSach, MaLoaiSach, MaTacGia, MaNhaXuatBan, NamXuatBan, NgayNhap, TriGia, SoLuong) values (N'VH002', N'Van Hoc lop 2', 5, 7, 8, '02/23/2017', '09/08/2017', 300000, 12)


 