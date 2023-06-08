USE MASTER
GO
CREATE DATABASE ThiCK_62130808
GO
USE ThiCK_62130808
GO
CREATE TABLE LOAITAISAN
(
	MaLTS VARCHAR(10) NOT NULL PRIMARY KEY,
	TenLTS NVARCHAR(100) NOT NULL
)
GO
CREATE TABLE TAISAN
(
	MaTS VARCHAR(10) NOT NULL PRIMARY KEY,
	TenTS NVARCHAR(50) NOT NULL,
	DVT NVARCHAR(50) NOT NULL,
	XuatXu bit DEFAULT(1),
	DonGia int,
	AnhMH VARCHAR(50),
	GhiChu NVARCHAR(50) NOT NULL,
	MaLTS VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES LOAITAISAN(MaLTS)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
DROP Table TAISAN
DROP Table LOAITAISAN
INSERT INTO LOAITAISAN(MaLTS, TenLTS)
VALUES
	('MT', N'Máy tính'),
	('DT', N'Điện thoại'),
	('TV', N'Tivi')
GO
INSERT INTO TAISAN(MaTS, TenTS, DVT, XuatXu, DonGia, AnhMH, GhiChu, MaLTS)
VALUES
	('MT001', N'LapTop Dell', N'Cái' , 0, 20000000, 'laptopDell.png', N'Pin, sạc, cáp, tai nghe, hộp', 'MT'),
	('DT002', N'IPhone 11', N'Cái', 0, 25000000, 'iphone11.png', N'Pin, sạc, cáp, tai nghe, hộp', 'DT'),
	('TV003', N'Tivi Sony', N'Cái', 1, 15000000, 'tiviSony.png', N'Pin, sạc, cáp, tai nghe, hộp', 'TV')
GO
CREATE OR ALTER PROC TimKiemTS_62130808
(
	@TenTS NVARCHAR(50) = NULL,
	@DonGiaFrom int,
	@DonGiaTo int
) AS
BEGIN
	DECLARE @Sqlstr NVARCHAR(4000),
			@ParamList NVARCHAR(2000)
	SELECT @Sqlstr =  'SELECT * FROM TAISAN WHERE (1=1) '
	IF @TenTS IS NOT NULL
		SELECT @Sqlstr = @Sqlstr + 'AND (TenTS LIKE ''%' + @TenTS + '%'')'
	IF @DonGiaFrom IS NOT NULL
       SELECT @SqlStr = @SqlStr + 'AND (''%' + @DonGiaFrom + '%'' > DonGia)'
	IF @DonGiaTo IS NOT NULL
       SELECT @SqlStr = @SqlStr + 'AND (@''%' + @DonGiaTo + '%'' < DonGia)'
	EXEC SP_EXECUTESQL @Sqlstr
END


