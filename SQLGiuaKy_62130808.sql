CREATE DATABASE ThiGK_62130808
GO
USE ThiGK_62130808
GO
CREATE TABLE LoaiDienThoai
(
	MaLDT nvarchar(10) PRIMARY KEY,
	TenLDT nvarchar(50) NOT NULL
)
GO
CREATE TABLE DienThoai
(
	MaDT nvarchar(10) PRIMARY KEY,
	TenDT nvarchar(50) NOT NULL,
	XuatXu bit DEFAULT(1),
	DonGia int,
	AnhDT nvarchar(50),
	MoTa nvarchar(50) NOT NULL,
	PhuKienKemTheo nvarchar(50) NOT NULL,
	MaLDT nvarchar(10) NOT NULL FOREIGN KEY REFERENCES LoaiDienThoai(MaLDT)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO LoaiDienThoai VALUES(N'NO',N'Nokia'),(N'IP',N'IPhone'),(N'BP',N'BPhone')
GO
INSERT DienThoai VALUES (N'NO001', N'Nokia A1', 0, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'NO')
INSERT DienThoai VALUES (N'NO002', N'Nokia A2', 0, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'NO')
INSERT DienThoai VALUES (N'NO003', N'Nokia A3', 0, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'NO')
INSERT DienThoai VALUES (N'IP004', N'IPhone B1', 0, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'IP')
INSERT DienThoai VALUES (N'IP005', N'IPhone B2', 0, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'IP')
INSERT DienThoai VALUES (N'IP006', N'IPhone B3', 0, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'IP')
INSERT DienThoai VALUES (N'BP007', N'BPhone C1', 1, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'BP')
INSERT DienThoai VALUES (N'BP008', N'BPhone C2', 1, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'BP')
INSERT DienThoai VALUES (N'BP009', N'BPhone C3', 1, 10000000, N'sinhvien.png', N'...', N'Pin, sạc, cáp, tai nghe, hộp', N'BP')
GO

CREATE PROCEDURE DienThoai_TimKiem
	@TenDT nvarchar(50)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM DienThoai
       WHERE  (1=1)
       '
IF @TenDT IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (@TenDT LIKE ''%'+@TenDT+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END
