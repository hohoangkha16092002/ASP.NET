CREATE DATABASE BAIMAU_62130808
GO
USE BAIMAU_62130808
GO
CREATE TABLE Lop
(
	MaLop nvarchar(10) PRIMARY KEY,
	TenLop nvarchar(50) NOT NULL
)
GO
CREATE TABLE SinhVien
(
	MaSV nvarchar(10) PRIMARY KEY,
	HoSV nvarchar(50) NOT NULL,
	TenSV nvarchar(10) NOT NULL,
	NgaySinh date,
	GioiTinh bit DEFAULT(1),
	AnhSV nvarchar(50),
	DiaChi nvarchar(100) NOT NULL,
	MaLop nvarchar(10) NOT NULL FOREIGN KEY REFERENCES Lop(MaLop)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO Lop VALUES(N'CNTT',N'Công Nghệ Thông Tin'),(N'KT',N'Kế Toán'),(N'DL',N'Du Lịch')
GO
INSERT SinhVien VALUES (N'SV001', N'Vũ Tiến', N'Dương', CAST(N'1995-11-23' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'CNTT')
INSERT SinhVien VALUES (N'SV002', N'Bùi Chí', N'Thành', CAST(N'1990-01-01' AS Date), 1, N'sinhvien.png', N'Nha Trang - Khánh Hòa', N'CNTT')
INSERT SinhVien VALUES (N'SV003', N'Phạm Thành', N'Ân', CAST(N'1993-12-08' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'CNTT')
INSERT SinhVien VALUES (N'SV004', N'Nguyễn Hồng', N'Chương', CAST(N'1990-02-02' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'CNTT')
INSERT SinhVien VALUES (N'SV005', N'Dương Hồng', N'Đức', CAST(N'1994-04-06' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'CNTT')
INSERT SinhVien VALUES (N'SV006', N'Nguyễn Minh Phương', N'Thảo', CAST(N'1995-03-16' AS Date), 0, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'CNTT')
INSERT SinhVien VALUES (N'SV007', N'Nguyễn Thị', N'Liên', CAST(N'1997-08-12' AS Date), 0, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'CNTT')
INSERT SinhVien VALUES (N'SV008', N'Lê Thị Thùy', N'Duyên', CAST(N'1970-01-01' AS Date), 0, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'KT')
INSERT SinhVien VALUES (N'SV009', N'Nguyễn Thị Mỹ', N'Linh', CAST(N'2000-04-30' AS Date), 0, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'KT')
INSERT SinhVien VALUES (N'SV010', N'Nguyễn Hữu Vinh', N'Quang', CAST(N'2000-03-19' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'KT')
INSERT SinhVien VALUES (N'SV011', N'Nguyễn Công', N'Phương', CAST(N'1990-12-19' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'KT')
INSERT SinhVien VALUES (N'SV012', N'Nguyễn Thị', N'Diệu', CAST(N'1997-08-12' AS Date), 0, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'DL')
INSERT SinhVien VALUES (N'SV013', N'Lê Thị', N'Nhi', CAST(N'1970-01-01' AS Date), 0, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'DL')
INSERT SinhVien VALUES (N'SV014', N'Nguyễn Thị', N'Thảo', CAST(N'2000-04-30' AS Date), 0, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'DL')
INSERT SinhVien VALUES (N'SV015', N'Nguyễn Hữu Thái', N'Linh', CAST(N'2000-03-19' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'DL')
INSERT SinhVien VALUES (N'SV016', N'Nguyễn Công', N'Phượng', CAST(N'1990-12-19' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'DL')
GO

CREATE PROCEDURE SinhVien_TimKiem
    @MaSV varchar(10)=NULL,
	@HoTen nvarchar(50)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM SinhVien
       WHERE  (1=1)
       '
IF @MaSV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaSV LIKE ''%'+@MaSV+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoSV+'' ''+TenSV LIKE ''%'+@HoTen+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END
