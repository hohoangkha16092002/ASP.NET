USE MASTER
GO
CREATE DATABASE KT0720_62133366 ON PRIMARY
(
	name = KT0720_62133366_Data,
	filename = 'D:\WebApp\Database\KT0720_62133366_Data.mdf'
)
GO
USE KT0720_62133366
GO
CREATE TABLE Lop
(
	MaLop VARCHAR(10) NOT NULL PRIMARY KEY,
	TenLop NVARCHAR(100) NOT NULL
)
GO
CREATE TABLE SinhVien
(
	MaSV VARCHAR(10) NOT NULL PRIMARY KEY,
	HoSV NVARCHAR(50) NOT NULL,
	TenSV NVARCHAR(50) NOT NULL,
	NgaySinh SMALLDATETIME NOT NULL,
	GioiTinh BIT DEFAULT(1),
	AnhSV VARCHAR(100),
	DiaChi NVARCHAR(100) NOT NULL,
	MaLop VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES Lop(MaLop)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO Lop(MaLop, TenLop)
VALUES
	('CNTT', N'Công nghệ thông tin'),
	('QTKD', N'Quản trị kinh doanh'),
	('KTDH', N'Kỹ thuật đồ họa')
GO
INSERT INTO SinhVien(MaSV, HoSV, TenSV, NgaySinh, GioiTinh, AnhSV, DiaChi, MaLop)
VALUES
	('SV008', N'Lê Thị Thùy', N'Duyên',  '1970-01-01'  , 0, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'CNTT'),
	('SV009', N'Nguyễn Thị Mỹ', N'Linh',  '2000-04-30'  , 0, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'CNTT'),
	('SV010', N'Nguyễn Hữu Vinh', N'Quang',  '2000-03-19'  , 1, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'CNTT'),
	('SV011', N'Nguyễn Công', N'Phương',  '1990-12-19'  , 1, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'CNTT'),
	('SV012', N'Nguyễn Thị', N'Diệu',  '1997-08-12'  , 0, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'QTKD'),
	('SV013', N'Lê Thị', N'Nhi',  '1970-01-01'  , 0, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'QTKD'),
	('SV014', N'Nguyễn Thị', N'Thảo',  '2000-04-30'  , 0, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'QTKD'),
	('SV015', N'Nguyễn Hữu Thái', N'Linh',  '2000-03-19'  , 1, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'QTKD'),
	('SV016', N'Nguyễn Công', N'Phượng',  '1990-12-19'  , 1, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'QTKD'),
	('SV001', N'Dương Anh', N'Tuấn', '2002-7-12', 1, 'sinhvien.png', N'Cam Ranh, Khánh Hòa', 'CNTT'),
	('SV002', N'Nguyễn Đăng', N'Khoa', '2002-6-22', 1, 'sinhvien.png', N'Diên Khánh, Khánh Hòa', 'CNTT'),
	('SV003', N'Đậu Thanh', N'Nga', '2002-7-1', 0, 'sinhvien.png', N'Cam Ranh, Khánh Hòa', 'CNTT'),
	('SV004', N'Đào Xuân', N'Quốc', '2002-2-22', 1, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'QTKD'),
	('SV005', N'Ngô Minh', N'Duy', '2002-5-2', 0, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'QTKD'),
	('SV006', N'Lê Diệu', N'Kiên', '2002-11-12', 0, 'sinhvien.png', N'Diên Khánh, Khánh Hòa', 'QTKD'),
	('SV007', N'Dương Minh', N'Thiên', '2002-7-7', 1, 'sinhvien.png', N'Cam Lâm, Khánh Hòa', 'KTDH'),
	('SV008', N'Lâm Nguyệt', N'Như', '2002-7-3', 1, 'sinhvien.png', N'Cam Ranh, Khánh Hòa', 'KTDH'),
	('SV009', N'Lý Nhật', N'Vy', '2002-9-21', 1, 'sinhvien.png', N'Cam Ranh, Khánh Hòa', 'KTDH'),
	('SV001', N'Vũ Tiến', N'Dương', '1995-11-23', 1, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'KTDH'),
	('SV006', N'Nguyễn Minh Phương', N'Thảo',  '1995-03-16'  , 0, 'sinhvien.png', N'Nha Trang, Khánh Hòa', 'KTDH')
GO
CREATE OR ALTER PROC TimKiemSinhVien
(
	@MaSV VARCHAR(20) = NULL,
	@HoTen NVARCHAR(100) = NULL
) AS
BEGIN
	SELECT *
	FROM SinhVien
	WHERE (1=1) AND
		(@MaSV IS NULL OR MaSV = @MaSV) AND
		(@HoTen IS NULL OR CONCAT(HoSV,' ',TenSV) LIKE '%' + @HoTen + '%') 
END
GO
CREATE OR ALTER PROC TimKiemSV
(
	@MaSV NVARCHAR(20) = NULL,
	@HoTen NVARCHAR(100) = NULL
) AS
BEGIN
	DECLARE @Sqlstr NVARCHAR(4000),
			@ParamList NVARCHAR(2000)
	SELECT @Sqlstr =  'SELECT * FROM SinhVien WHERE (1=1) '
	IF @MaSV IS NOT NULL
		SELECT @Sqlstr = @Sqlstr + 'AND (MaSV LIKE ''%' + @MaSV + '%'')'
	IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + 'AND (CONCAT(HoSV,'' '',TenSV) LIKE ''%' + @HoTen + '%'')'
	EXEC SP_EXECUTESQL @Sqlstr
END
EXEC TimKiemSinhVien @HoTen=N'Tuấn'
EXEC TimKiemSV @HoTen=N'Khoa'

