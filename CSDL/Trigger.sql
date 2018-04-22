USE QLTV
GO

SELECT * FROM dbo.PhieuLapThe
GO
--thêm user
CREATE TRIGGER UTG_InsertDocGia
ON dbo.PhieuLapThe
FOR INSERT, UPDATE
AS
BEGIN	
	SELECT * FROM Inserted
	WHERE YEAR(GETDATE())-YEAR(Inserted.NgaySinh) < 18
	ROLLBACK TRAN
	PRINT'user chua 18'
END

GO

--thêm sách
CREATE TRIGGER UTG_InsertSach
ON dbo.ThongTinSach
FOR INSERT,UPDATE 
AS 
BEGIN
	IF EXISTS (SELECT * FROM Inserted
	WHERE YEAR(GETDATE())-YEAR(Inserted.NamXuatBan) > 8)
	BEGIN
		ROLLBACK TRAN
		PRINT 'Sach qua cu~'
	END 
END
GO


--thêm sách mượn
CREATE TRIGGER UTG_InsertPhieuMuon
ON dbo.CTPhieuMuon
FOR INSERT,UPDATE 
AS 
BEGIN
	DECLARE @Count INT =5
	SELECT COUNT(*) FROM Inserted
	IF(COUNT(*)> @Count)
	BEGIN
	PRINT 'Da toi da so sach duoc muon'
	ROLLBACK TRAN
	End    
END
GO

