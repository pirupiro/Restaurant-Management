CREATE DATABASE QuanLyQuanAn
GO


USE QuanLyQuanAn
GO


-- TẠO BẢNG NHÂN VIÊN
CREATE TABLE NHANVIEN
(
	MANHANVIEN			INT IDENTITY,
	HOTEN				NVARCHAR(100),
	NGAYSINH			DATE,
	GIOITINH			NVARCHAR(3)				CHECK(GIOITINH = N'Nam' OR GIOITINH = N'Nữ'),
	DIACHI				NVARCHAR(250),
	SODIENTHOAI			VARCHAR(10),
	NGAYVAOLAM			DATE,
	CHUCVU				NVARCHAR(15),
	LUONG				INT,

	PRIMARY KEY(MANHANVIEN)
)
GO


-- TẠO BẢNG NHÂN VIÊN CŨ
CREATE TABLE NHANVIENCU
(
	MANHANVIEN			INT,
	HOTEN				NVARCHAR(100),
	NGAYSINH			DATE,
	GIOITINH			NVARCHAR(3)				CHECK(GIOITINH = N'Nam' OR GIOITINH = N'Nữ'),
	DIACHI				NVARCHAR(250),
	SODIENTHOAI			VARCHAR(10),
	NGAYVAOLAM			DATE,
	CHUCVU				NVARCHAR(15),
	LUONG				INT,

	PRIMARY KEY(MANHANVIEN)
)


-- TẠO BẢNG ĐĂNG NHẬP
CREATE TABLE DANGNHAP
(
	TAIKHOAN			VARCHAR(10),
	MATKHAU				VARCHAR(10),
	MANHANVIEN			INT,

	PRIMARY KEY(TAIKHOAN)
)
GO


-- TẠO BẢNG THỰC ĐƠN
CREATE TABLE THUCDON
(
	TENMON				NVARCHAR(100),
	DONGIA				INT,
	DONVI				NVARCHAR(10)			CHECK(DONVI = N'Phần' OR DONVI = N'Ly' OR DONVI = N'Chai'),

	PRIMARY KEY(TENMON)
)
GO


-- TẠO BẢNG	HÓA ĐƠN
CREATE TABLE HOADON
(
	MAHOADON			INT IDENTITY,
	MABAN				INT,
	MANHANVIEN			INT,
	THOIGIANLAP			DATETIME,
	TONGTIEN			INT DEFAULT 0,

	PRIMARY KEY(MAHOADON)
)
GO


-- TẠO BẢNG BÀN
CREATE TABLE BAN
(
	MABAN				INT,
	TINHTRANG			NVARCHAR(15)			CHECK(TINHTRANG = N'Còn trống' OR TINHTRANG = N'Đã được đặt'),
	PRIMARY KEY(MABAN)
)
GO


-- TẠO BẢNG CHI TIẾT HÓA ĐƠN
CREATE TABLE CHITIETHOADON
(
	MAHOADON			INT,
	TENMON				NVARCHAR(100),
	SOLUONG				INT,
	THANHTIEN			INT DEFAULT 0,

	PRIMARY KEY(MAHOADON, TENMON)
)
GO


-- TẠO CÁC RÀNG BUỘC KHÓA NGOẠI                                                                         
ALTER TABLE DANGNHAP		ADD CONSTRAINT FK_DN_NV		FOREIGN KEY(MANHANVIEN)		REFERENCES NHANVIEN(MANHANVIEN)		ON DELETE CASCADE
ALTER TABLE HOADON			ADD CONSTRAINT FK_HD_NV		FOREIGN KEY(MANHANVIEN)		REFERENCES NHANVIEN(MANHANVIEN)		ON DELETE CASCADE
ALTER TABLE HOADON			ADD CONSTRAINT FK_HD_B		FOREIGN KEY(MABAN)			REFERENCES BAN(MABAN)				ON DELETE CASCADE
ALTER TABLE CHITIETHOADON	ADD CONSTRAINT FK_CTHD_HD	FOREIGN KEY(MAHOADON)		REFERENCES HOADON(MAHOADON)			ON DELETE CASCADE
ALTER TABLE CHITIETHOADON	ADD CONSTRAINT FK_CTHD_MA	FOREIGN KEY(TENMON)			REFERENCES THUCDON(TENMON)			ON DELETE CASCADE
GO


-- THÊM DỮ LIỆU MÓN ĂN
INSERT INTO THUCDON VALUES(N'Tôm xào xả ớt', 60000, N'Phần')
INSERT INTO THUCDON VALUES(N'Tôm nướng hấp bia', 65000, N'Phần')
INSERT INTO THUCDON VALUES(N'Tôm bao bột rán', 60000, N'Phần')
INSERT INTO THUCDON VALUES(N'Tôm xào chua ngọt', 55000, N'Phần')
INSERT INTO THUCDON VALUES(N'Cua ghẹ nướng', 70000, N'Phần')
INSERT INTO THUCDON VALUES(N'Cua xào chua ngọt', 75000, N'Phần')
INSERT INTO THUCDON VALUES(N'Nem cua', 55000, N'Phần')
INSERT INTO THUCDON VALUES(N'Ngao luộc nướng', 100000, N'Phần')
INSERT INTO THUCDON VALUES(N'Ngao tẩm bột rán', 45000, N'Phần')
INSERT INTO THUCDON VALUES(N'Ngao hấp bia', 70000, N'Phần')
INSERT INTO THUCDON VALUES(N'Sò nướng luộc', 50000, N'Phần')
INSERT INTO THUCDON VALUES(N'Sò hấp sả', 45000, N'Phần')
INSERT INTO THUCDON VALUES(N'Sò xào bánh đa', 40000, N'Phần')
INSERT INTO THUCDON VALUES(N'Cá hấp bia', 65000, N'Phần')
INSERT INTO THUCDON VALUES(N'Cá nấu canh chua', 65000, N'Phần')
INSERT INTO THUCDON VALUES(N'Cá hấp ngũ vị', 75000, N'Phần')
INSERT INTO THUCDON VALUES(N'Súp hải sản', 30000, N'Phần')
INSERT INTO THUCDON VALUES(N'Súp thập cẩm', 35000, N'Phần')
INSERT INTO THUCDON VALUES(N'Nước ngọt Coca Cola', 12000, N'Chai')
INSERT INTO THUCDON VALUES(N'Bia Guinness', 130000, N'Chai')
INSERT INTO THUCDON VALUES(N'Trà xanh không độ', 12000, N'Chai')
INSERT INTO THUCDON VALUES(N'Trà Oolong', 12000, N'Chai')
INSERT INTO THUCDON VALUES(N'Nước ngọt Sting', 14000, N'Chai')
INSERT INTO THUCDON VALUES(N'Nước ngọt Pepsi', 12000, N'Chai')
INSERT INTO THUCDON VALUES(N'Nước ngọt Redbull', 14000, N'Chai')
INSERT INTO THUCDON VALUES(N'Cà phê', 16000, N'Ly')
INSERT INTO THUCDON VALUES(N'Trà hoa cúc', 16000, N'Ly')
INSERT INTO THUCDON VALUES(N'Sữa tươi', 14000, N'Ly')
INSERT INTO THUCDON VALUES(N'Trà bắc', 16000, N'Ly')
INSERT INTO THUCDON VALUES(N'Trà Atiso', 16000, N'Ly')
INSERT INTO THUCDON VALUES(N'Trà Lipton', 12000, N'Ly')																				
GO


-- THÊM DỮ LIỆU BÀN
DECLARE @i INT = 0
WHILE @i < 30
BEGIN
	INSERT INTO BAN VALUES(@i + 1, N'Còn trống')
	SET @i = @i + 1
END
GO


-- THÊM DỮ LIỆU NHÂN VIÊN
INSERT INTO NHANVIEN VALUES(N'Đường Ngọc Long', '1990-4-22', N'Nam', N'1 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550173', '2016-7-8', N'Quản lý', 30000000)
INSERT INTO NHANVIEN VALUES(N'Lương Minh Châu', '1992-3-13', N'Nữ', N'2 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550116', '2016-9-19', N'Thu ngân', 15000000)
INSERT INTO NHANVIEN VALUES(N'Trương Mộng Tuyền', '1992-10-10', N'Nữ', N'3 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550126', '2017-3-18', N'Tiếp tân', 12000000)
INSERT INTO NHANVIEN VALUES(N'Đào Việt Duy', '1993-10-15', N'Nam', N'4 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550133', '2018-2-14', N'Phục vụ', 5000000)
INSERT INTO NHANVIEN VALUES(N'Cao Nghi', '1992-9-5', N'Nam', N'5 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550155', '2017-4-25', N'Đầu bếp', 25000000)
INSERT INTO NHANVIEN VALUES(N'Chu Minh', '1988-7-20', N'Nam', N'6 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550493', '2016-6-21', N'Đầu bếp', 30000000)
INSERT INTO NHANVIEN VALUES(N'Lưu Tiểu Hân', '1991-5-5', N'Nữ', N'7 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550231', '2017-5-14', N'Phụ bếp', 18000000)
INSERT INTO NHANVIEN VALUES(N'Điền Thanh Thanh', '1990-3-4', N'Nữ', N'8 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550357', '2016-7-17', N'Thu ngân', 15000000)
INSERT INTO NHANVIEN VALUES(N'Kiều Hồng Ngọc', '1991-7-5', N'Nữ', N'9 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550222', '2018-5-13', N'Tiếp tân', 10000000)
INSERT INTO NHANVIEN VALUES(N'Võ Tấn Đào', '1991-4-12', N'Nam', N'10 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550357', '2016-5-3', N'Phụ bếp', 15000000)
INSERT INTO NHANVIEN VALUES(N'Phượng Thanh Nhi', '1994-10-11', N'Nữ', N'11 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550927', '2017-7-20', N'Phục vụ', 1000000)
INSERT INTO NHANVIEN VALUES(N'Hồ Khải', '1993-2-22', N'Nam', N'12 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550678', '2015-8-18', N'Quản lý', 30000000)
INSERT INTO NHANVIEN VALUES(N'Triệu Thị Trinh Lan', '1992-3-3', N'Nữ', N'13 Trần Hưng Đạo, Quận 1, TP.HCM', '2025550606', '2018-1-21', N'Thu ngân', 15000000)
GO


-- THÊM DỮ LIỆU ĐĂNG NHẬP
INSERT INTO DANGNHAP VALUES('quanly', 'q', 1)
INSERT INTO DANGNHAP VALUES('thungan1', 't1', 2)
INSERT INTO DANGNHAP VALUES('thungan2', 't2', 13)
GO


-- THÊM DỮ LIỆU HÓA ĐƠN TỪ NGÀY 1 THÁNG 1 NĂM 2010 ĐẾN THỜI ĐIỂM HIỆN TẠI
DECLARE @STARTDATE DATETIME
DECLARE @ENDDATE DATETIME
DECLARE @CURRENTDATE DATETIME

SET @STARTDATE = '1/1/2010'
SET @ENDDATE = GETDATE()
SET @CURRENTDATE = @STARTDATE

WHILE (@CURRENTDATE < @ENDDATE)
BEGIN
	INSERT INTO HOADON VALUES(1, 13, @CURRENTDATE, 500000 + RAND() * 1000000)
    SET @CURRENTDATE = CONVERT(varchar(30), DATEADD(DAY, 1, @CURRENTDATE), 101)
END
GO


---------------------------------------------------------------------------------------------------------------------------------
--                                                                                                                             --
--                                      NHỮNG THỦ TỤC LIÊN QUAN ĐẾN TÀI KHOẢN ĐĂNG NHẬP                                        --
--                                                                                                                             --
---------------------------------------------------------------------------------------------------------------------------------


-- KIỂM TRA SỰ TỒN TẠI CỦA TÀI KHOẢN
CREATE PROCEDURE proc_CheckAccount(@TAIKHOAN VARCHAR(10), @MATKHAU VARCHAR(10))
AS
BEGIN
	SELECT *
	FROM DANGNHAP
	WHERE TAIKHOAN = @TAIKHOAN
	AND MATKHAU = @MATKHAU
END
GO


-- CẬP NHẬT MẬT KHẨU
CREATE PROCEDURE proc_UpdatePassword(@TAIKHOAN VARCHAR(10), @MATKHAU VARCHAR(10))
AS
BEGIN
	UPDATE DANGNHAP
	SET MATKHAU = @MATKHAU
	WHERE TAIKHOAN = @TAIKHOAN
END
GO


-- LẤY THÔNG TIN TÀI KHOẢN
CREATE PROCEDURE proc_GetAccount(@TAIKHOAN VARCHAR(10))
AS
BEGIN
	SELECT *
	FROM DANGNHAP
	WHERE TAIKHOAN = @TAIKHOAN
END
GO

-- XÓA TÀI KHOẢN
CREATE PROCEDURE proc_DeleteAccount(@TAIKHOAN VARCHAR(10))
AS
BEGIN
	DELETE FROM DANGNHAP
	WHERE TAIKHOAN = @TAIKHOAN
END
GO


-- TẠO TÀI KHOẢN
CREATE PROCEDURE proc_CreateAccount(@TAIKHOAN VARCHAR(10), @MATKHAU VARCHAR(10), @MANHANVIEN INT)
AS
BEGIN
	INSERT INTO DANGNHAP VALUES(@TAIKHOAN, @MATKHAU, @MANHANVIEN)
END
GO


-- LẤY THÔNG TIN TẤT CẢ TÀI KHOẢN
CREATE PROCEDURE proc_LoadAllAccounts
AS
BEGIN
	SELECT TAIKHOAN, HOTEN, CHUCVU
	FROM DANGNHAP, NHANVIEN
	WHERE NHANVIEN.MANHANVIEN = DANGNHAP.MANHANVIEN
END
GO


---------------------------------------------------------------------------------------------------------------------------------
--                                                                                                                             --
--                                              NHỮNG THỦ TỤC LIÊN QUAN ĐẾN BÀN						                           --
--                                                                                                                             --
---------------------------------------------------------------------------------------------------------------------------------


-- LẤY THÔNG TIN TẤT CẢ BÀN
CREATE PROCEDURE proc_LoadAllTables
AS
BEGIN
	SELECT *
	FROM BAN
END
GO


-- CẬP NHẬT TÌNH TRẠNG BÀN
CREATE PROCEDURE proc_UpdateStatus(@MABAN INT, @TINHTRANG NVARCHAR(15))
AS
BEGIN
	UPDATE BAN
	SET TINHTRANG = @TINHTRANG
	WHERE MABAN = @MABAN
END
GO


-- LẤY SỐ LƯỢNG BÀN HIỆN TẠI
CREATE PROCEDURE proc_GetNumberOfTables
AS
BEGIN
	SELECT COUNT(*)
	FROM BAN
END
GO


-- THÊM BÀN
CREATE PROCEDURE proc_AddTable(@MABAN INT)
AS
BEGIN
	INSERT INTO BAN VALUES(@MABAN, N'Còn trống')
END
GO
 

-- XÓA BÀN
CREATE PROCEDURE proc_RemoveTable(@SOLUONG INT)
AS
BEGIN
	DELETE FROM BAN
	WHERE MABAN IN (SELECT TOP (@SOLUONG) MABAN
					FROM BAN
					ORDER BY MABAN DESC)
END
GO


---------------------------------------------------------------------------------------------------------------------------------
--                                                                                                                             --
--                                              NHỮNG THỦ TỤC LIÊN QUAN ĐẾN THỰC ĐƠN						                   --
--                                                                                                                             --
---------------------------------------------------------------------------------------------------------------------------------


-- LẤY THÔNG TIN MÓN ĂN
CREATE PROCEDURE proc_LoadAllDishes
AS
BEGIN
	SELECT *
	FROM THUCDON
END
GO


-- LẤY THÔNG TIN TẤT CẢ MÓN ĂN CÓ TÊN MÓN CHỨA CHUỖI CHO TRƯỚC
CREATE PROCEDURE proc_LoadAllDishesWithName(@TENMON NVARCHAR(100))
AS
BEGIN
	SELECT *
	FROM THUCDON
	WHERE TENMON LIKE '%' + @TENMON + '%' 
END
GO


-- XÓA MÓN ĂN
CREATE PROCEDURE proc_RemoveDish(@TENMON NVARCHAR(100))
AS
BEGIN
	DELETE FROM THUCDON
	WHERE TENMON = @TENMON
END
GO


-- CẬP NHẬT GIÁ MÓN ĂN
CREATE PROCEDURE proc_UpdateDishPrice(@TENMON NVARCHAR(100), @DONGIA INT)
AS
BEGIN
	UPDATE THUCDON
	SET DONGIA = @DONGIA
	WHERE TENMON = @TENMON
END
GO


-- THÊM MÓN ĂN
CREATE PROCEDURE proc_AddDish(@TENMON NVARCHAR(100), @DONGIA INT, @DONVI NVARCHAR(10))
AS
BEGIN
	INSERT INTO THUCDON VALUES(@TENMON, @DONGIA, @DONVI)
END
GO


---------------------------------------------------------------------------------------------------------------------------------
--                                                                                                                             --
--                                            NHỮNG THỦ TỤC LIÊN QUAN ĐẾN NHÂN VIÊN						                       --
--                                                                                                                             --
---------------------------------------------------------------------------------------------------------------------------------


-- LẤY THÔNG TIN NHÂN VIÊN
CREATE PROCEDURE proc_GetEmployee(@MANHANVIEN INT)
AS
BEGIN
	SELECT *
	FROM NHANVIEN
	WHERE MANHANVIEN = @MANHANVIEN
END
GO


-- LẤY THÔNG TIN TẤT CẢ NHÂN VIÊN
CREATE PROCEDURE proc_LoadAllEmployees
AS
BEGIN
	SELECT *
	FROM NHANVIEN
END
GO


-- LẤY THÔNG TIN TẤT CẢ NHÂN VIÊN CÓ HỌ TÊN CHỨA CHUỖI CHO TRƯỚC
CREATE PROCEDURE proc_LoadAllEmployeesWithName(@HOTEN NVARCHAR(100))
AS
BEGIN
	SELECT *
	FROM NHANVIEN
	WHERE HOTEN LIKE '%' + @HOTEN + '%'
END
GO


-- LẤY THÔNG TIN TẤT CẢ NHÂN VIÊN CŨ
CREATE PROCEDURE proc_LoadAllOldEmployees
AS
BEGIN
	SELECT *
	FROM NHANVIENCU
END
GO


-- LẤY THÔNG TIN TẤT CẢ NHÂN VIÊN CŨ CÓ HỌ TÊN CHỨA CHUỖI CHO TRƯỚC
CREATE PROCEDURE proc_LoadAllOldEmployeesWithName(@HOTEN NVARCHAR(100))
AS
BEGIN
	SELECT *
	FROM NHANVIENCU
	WHERE HOTEN LIKE '%' + @HOTEN + '%'
END
GO


-- XÓA NHÂN VIÊN
CREATE PROCEDURE proc_RemoveEmployee(@MANHANVIEN INT)
AS
BEGIN
	DELETE FROM NHANVIEN
	WHERE MANHANVIEN = @MANHANVIEN
END
GO


-- THÊM DỮ LIỆU VÀO BẢNG NHÂN VIÊN CŨ SAU KHI XÓA NHÂN VIÊN
CREATE TRIGGER trig_RemoveEmployee
ON NHANVIEN
FOR DELETE
AS
	INSERT INTO NHANVIENCU SELECT * FROM DELETED
GO


-- CẬP NHẬT THÔNG TIN NHÂN VIÊN
CREATE PROCEDURE proc_UpdateEmployee(@MANHANVIEN	INT,			@HOTEN		NVARCHAR(100),		@NGAYSINH		DATE, 
									 @GIOITINH		NVARCHAR(3),	@DIACHI		NVARCHAR(250),		@SODIENTHOAI	VARCHAR(10), 
									 @NGAYVAOLAM	DATE,			@CHUCVU		NVARCHAR(15),		@LUONG			 INT)
AS
BEGIN
	UPDATE NHANVIEN
	SET HOTEN = @HOTEN, NGAYSINH = @NGAYSINH, GIOITINH = @GIOITINH, DIACHI = @DIACHI,
		SODIENTHOAI = @SODIENTHOAI, NGAYVAOLAM = @NGAYVAOLAM, CHUCVU = @CHUCVU, LUONG = @LUONG
	WHERE MANHANVIEN = @MANHANVIEN
END
GO


-- THÊM NHÂN VIÊN
CREATE PROCEDURE proc_AddEmployee(@HOTEN			NVARCHAR(100),		@NGAYSINH			DATE, 
								  @GIOITINH			NVARCHAR(3),		@DIACHI				NVARCHAR(250), 
								  @SODIENTHOAI		VARCHAR(10),		@NGAYVAOLAM			DATE, 
								  @CHUCVU			NVARCHAR(15),		@LUONG				INT)
AS
BEGIN
	INSERT INTO NHANVIEN VALUES(@HOTEN, @NGAYSINH, @GIOITINH, @DIACHI, @SODIENTHOAI, @NGAYVAOLAM, @CHUCVU, @LUONG)
END
GO


---------------------------------------------------------------------------------------------------------------------------------
--                                                                                                                             --
--                                              NHỮNG THỦ TỤC LIÊN QUAN ĐẾN HÓA ĐƠN						                       --
--                                                                                                                             --
---------------------------------------------------------------------------------------------------------------------------------


-- THÊM HÓA ĐƠN
CREATE PROCEDURE proc_AddBill(@MABAN INT, @MANHANVIEN INT, @TONGTIEN INT)
AS
BEGIN
	INSERT INTO HOADON VALUES(@MABAN, @MANHANVIEN, NULL, @TONGTIEN)
END
GO


-- LẤY THÔNG TIN HÓA ĐƠN CUỐI CÙNG DỰA VÀO MÃ BÀN
CREATE PROCEDURE proc_GetLastBill(@MABAN INT)
AS
BEGIN
	SELECT TOP 1 *
	FROM HOADON
	WHERE MABAN = @MABAN
	ORDER BY MAHOADON DESC
END
GO


-- CẬP NHẬT THỜI ĐIỂM LẬP HÓA ĐƠN
CREATE PROCEDURE proc_UpdateInvoicingTime(@MAHOADON INT)
AS
BEGIN
	UPDATE HOADON
	SET THOIGIANLAP = GETDATE()
	WHERE MAHOADON = @MAHOADON
END
GO


-- CẬP NHẬT TỔNG TIỀN CHO HÓA ĐƠN
CREATE PROCEDURE proc_UpdateTotalPrice(@MAHOADON INT, @TONGTIEN INT)
AS
BEGIN
	UPDATE HOADON
	SET TONGTIEN = @TONGTIEN
	WHERE MAHOADON = @MAHOADON
END
GO


-- LẤY THÔNG TIN TẤT CẢ HÓA ĐƠN THEO SỐ TRANG
CREATE PROCEDURE proc_LoadAllBills(@PAGENUMBER INT, @BILLSPERPAGE INT)
AS
BEGIN
	SELECT *
	FROM (SELECT TOP (@PAGENUMBER * @BILLSPERPAGE) *
		  FROM HOADON
		  ORDER BY MAHOADON DESC) X
	EXCEPT
	SELECT *
	FROM (SELECT TOP ((@PAGENUMBER - 1) * @BILLSPERPAGE) *
		  FROM HOADON
		  ORDER BY MAHOADON DESC) Y
END
GO


--  LẤY THÔNG TIN TẤT CẢ HÓA ĐƠN THEO SỐ TRANG TRONG KHOẢNG THỜI GIAN CHO TRƯỚC
CREATE PROCEDURE proc_LoadAllBillsByTime(@PAGENUMBER INT, @BILLSPERPAGE INT, @FROM DATETIME, @TO DATETIME)
AS
BEGIN
	SELECT *
	FROM (SELECT TOP (@PAGENUMBER * @BILLSPERPAGE) *
		  FROM HOADON
		  WHERE THOIGIANLAP BETWEEN @FROM AND @TO
		  ORDER BY MAHOADON DESC) X
	EXCEPT
	SELECT *
	FROM (SELECT TOP ((@PAGENUMBER - 1) * @BILLSPERPAGE) *
		  FROM HOADON
		  WHERE THOIGIANLAP BETWEEN @FROM AND @TO
		  ORDER BY MAHOADON DESC) Y
END
GO


-- LẤY THÔNG TIN HÓA ĐƠN
CREATE PROCEDURE proc_GetBill(@MAHOADON INT)
AS
BEGIN
	SELECT *
	FROM HOADON
	WHERE MAHOADON = @MAHOADON
END
GO


-- LẤY SỐ LƯỢNG HÓA ĐƠN
CREATE PROCEDURE proc_GetNumberOfBills
AS
BEGIN
	SELECT COUNT(*)
	FROM HOADON
END
GO


-- LẤY SỐ LƯỢNG HÓA ĐƠN TRONG KHOẢNG THỜI GIAN CHO TRƯỚC
CREATE PROCEDURE proc_GetNumberOfBillsByTime(@FROM DATETIME, @TO DATETIME)
AS
BEGIN
	SELECT COUNT(*)
	FROM HOADON
	WHERE THOIGIANLAP BETWEEN @FROM AND @TO
END
GO


-- LẤY NĂM NHỎ NHẤT
CREATE PROCEDURE proc_GetMinYear
AS
BEGIN
	SELECT MIN(YEAR(THOIGIANLAP))
	FROM HOADON
END
GO


-- LẤY NĂM LỚN NHẤT
CREATE PROCEDURE proc_GetMaxYear
AS
BEGIN
	SELECT MAX(YEAR(THOIGIANLAP))
	FROM HOADON
END
GO


-- LẤY TỔNG TIỀN THEO NGÀY
CREATE PROCEDURE proc_GetTotalPriceByDay(@DAY INT, @MONTH INT, @YEAR INT)
AS
BEGIN
	SELECT SUM(TONGTIEN)
	FROM HOADON
	WHERE DAY(THOIGIANLAP) = @DAY
	AND MONTH(THOIGIANLAP) = @MONTH
	AND YEAR(THOIGIANLAP) = @YEAR
END
GO


-- LẤY TỔNG TIỀN THEO THÁNG
CREATE PROCEDURE proc_GetTotalPriceByMonth(@MONTH INT, @YEAR INT)
AS
BEGIN
	SELECT SUM(TONGTIEN)
	FROM HOADON
	WHERE MONTH(THOIGIANLAP) = @MONTH
	AND YEAR(THOIGIANLAP) = @YEAR
END
GO


-- LẤY TỔNG TIỀN THEO NĂM
CREATE PROCEDURE proc_GetTotalPriceByYear(@YEAR INT)
AS
BEGIN
	SELECT SUM(TONGTIEN)
	FROM HOADON
	WHERE YEAR(THOIGIANLAP) = @YEAR
END
GO


---------------------------------------------------------------------------------------------------------------------------------
--                                                                                                                             --
--                                        NHỮNG THỦ TỤC LIÊN QUAN ĐẾN CHI TIẾT HÓA ĐƠN						                   --
--                                                                                                                             --
---------------------------------------------------------------------------------------------------------------------------------


-- THÊM CHI TIẾT HÓA ĐƠN
CREATE PROCEDURE proc_AddBillDetail(@MAHOADON INT, @TENMON NVARCHAR(100), @SOLUONG INT, @THANHTIEN INT)
AS
BEGIN
	INSERT INTO CHITIETHOADON VALUES(@MAHOADON, @TENMON, @SOLUONG, @THANHTIEN)
END
GO


-- CẬP NHẬT CHI TIẾT HÓA ĐƠN
CREATE PROCEDURE proc_UpdateBillDetail(@MAHOADON INT, @TENMON NVARCHAR(100), @SOLUONG INT, @THANHTIEN INT)
AS
BEGIN
	UPDATE CHITIETHOADON
	SET SOLUONG = @SOLUONG, THANHTIEN = @THANHTIEN
	WHERE MAHOADON = @MAHOADON
	AND TENMON = @TENMON
END
GO


-- LẤY THÔNG TIN CHI TIẾT HÓA ĐƠN
CREATE PROCEDURE proc_GetBillDetail(@MAHOADON INT, @TENMON NVARCHAR(100))
AS
BEGIN
	SELECT *
	FROM CHITIETHOADON
	WHERE MAHOADON = @MAHOADON
	AND TENMON = @TENMON
END
GO


-- LẤY THÔNG TIN TẤT CẢ CHI TIẾT HÓA ĐƠN CỦA MỘT HÓA ĐƠN
CREATE PROCEDURE proc_LoadAllBillDetails(@MAHOADON INT)
AS
BEGIN
	SELECT *
	FROM CHITIETHOADON
	WHERE MAHOADON = @MAHOADON
END
GO


-- LẤY THÔNG TIN TẤT CẢ CHI TIẾT HÓA ĐƠN CỦA MỘT HÓA ĐƠN (CÓ ĐƠN GIÁ)
CREATE PROCEDURE proc_LoadAllExtendedBillDetails(@MAHOADON INT)
AS
BEGIN
	SELECT THUCDON.TENMON, DONGIA, SOLUONG, THANHTIEN
	FROM CHITIETHOADON, THUCDON
	WHERE CHITIETHOADON.TENMON = THUCDON.TENMON
	AND MAHOADON = @MAHOADON
END
GO