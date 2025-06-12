CREATE DATABASE QLKhuDanCu;
GO

USE QLKhuDanCu;
GO

-- Bảng HoKhau
CREATE TABLE HoKhau (
    MaHoKhau VARCHAR(10) PRIMARY KEY, 
    TenChuHo NVARCHAR(50) NOT NULL, 
    CCCDChuHo VARCHAR(12) NOT NULL UNIQUE, 
    DiaChi NVARCHAR(255) NOT NULL, 
    SoThanhVien INT NOT NULL, 
    NgayLap DATE NOT NULL, 
    TrangThai NVARCHAR(50) DEFAULT N'Đang sinh sống', -- tí code phần mặc định này
    MoTa NVARCHAR(255) NULL
);

ALTER TABLE HoKhau
ADD AnhDinhKem VARBINARY(MAX) NULL;

-- Bảng NhanKhau
CREATE TABLE NhanKhau (
    MaNhanKhau VARCHAR(10) PRIMARY KEY, 
	MaHoKhau VARCHAR(10) NOT NULL, 
    HoTen NVARCHAR(50) NOT NULL, 
    CCCD VARCHAR(12) NOT NULL UNIQUE, 
    NgaySinh DATE NOT NULL, 
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ')) NOT NULL, 
    QuanHeVoiChuHo NVARCHAR(50) NOT NULL, 
    TrangThai NVARCHAR(50) DEFAULT N'Đang sinh sống' NOT NULL, 
    GhiChu NVARCHAR(255) NULL, 
    Email NVARCHAR(50) NOT NULL, -- tí code phần trùng lập email với người thuê trọ
    SoDienThoai VARCHAR(15) NOT NULL, -- tí code phần trùng lập sdt với người thuê trọ
    FOREIGN KEY (MaHoKhau) REFERENCES HoKhau(MaHoKhau)
);
ALTER TABLE NhanKhau
ADD AnhDinhKem2 VARBINARY(MAX) NULL;
ALTER TABLE NhanKhau
ADD AnhDinhKem3 VARBINARY(MAX) NULL;



-- Bảng GiayTamVang
CREATE TABLE GiayTamVang (
    MaGiayTamVang VARCHAR(10) PRIMARY KEY, 
    MaNhanKhau VARCHAR(10) NOT NULL, 
    HoTen NVARCHAR(100) NOT NULL, 
    CCCD VARCHAR(12) NOT NULL, 
    NgaySinh DATE NOT NULL, 
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ')) NOT NULL, 
    SoDienThoai VARCHAR(15) NOT NULL, 
    NoiDi NVARCHAR(255) NOT NULL, 
    NgayDi DATE NOT NULL, 
    NgayVe DATE NOT NULL, 
    LyDo NVARCHAR(255) NOT NULL, 
    TrangThai NVARCHAR(50) DEFAULT N'Đang có hiệu lực' NOT NULL, 
    SoNgay AS DATEDIFF(DAY, NgayDi, NgayVe), 
    FOREIGN KEY (MaNhanKhau) REFERENCES NhanKhau(MaNhanKhau)
);
ALTER TABLE GiayTamVang
ADD AnhDinhKem4 VARBINARY(MAX) NULL;
ALTER TABLE GiayTamVang
ADD AnhDinhKem5 VARBINARY(MAX) NULL;

-- Bảng GiayTamTru
CREATE TABLE GiayTamTru (
    MaGiayTamTru VARCHAR(10) PRIMARY KEY, 
    MaNguoiThue VARCHAR(10) NOT NULL, 
    HoTen NVARCHAR(100) NOT NULL, 
    GioiTinh NVARCHAR(10) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')), 
    NgaySinh DATE NOT NULL, 
    CCCD VARCHAR(12) NOT NULL, 
    QueQuan NVARCHAR(255) NOT NULL, 
    SoDienThoai VARCHAR(15), 
    NoiTamTru NVARCHAR(255) NOT NULL, 
    NgayBatDau DATE NOT NULL, 
    NgayKetThuc DATE NOT NULL, 
    LyDo NVARCHAR(255) NOT NULL, 
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang có hiệu lực', 
    SoNgay AS DATEDIFF(DAY, NgayBatDau, NgayKetThuc), 
    FOREIGN KEY (MaNguoiThue) REFERENCES NguoiThueTro(MaNguoiThue)
);
ALTER TABLE GiayTamTru
ADD AnhDinhKem9 VARBINARY(MAX) NULL;
ALTER TABLE GiayTamTru
ADD AnhDinhKem10 VARBINARY(MAX) NULL;

-- Bảng KhuTro
CREATE TABLE KhuTro (
    MaKhuTro VARCHAR(10) PRIMARY KEY, 
    TenKhuTro NVARCHAR(100) NOT NULL, 
    DiaChi NVARCHAR(255) NOT NULL, 
    HoTenChuTro NVARCHAR(100) NOT NULL, 
    SoDienThoaiChuTro VARCHAR(15) NOT NULL, 
    MaNhanKhau VARCHAR(10) NOT NULL, 
    SoPhong INT CHECK (SoPhong > 0) NOT NULL, 
    SoPhongTrong INT CHECK (SoPhongTrong >= 0) NOT NULL, 
    TrangThai NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaNhanKhau) REFERENCES NhanKhau(MaNhanKhau)
);
ALTER TABLE KhuTro
ADD AnhDinhKem8 VARBINARY(MAX) NULL;

-- Bảng NguoiThueTro
CREATE TABLE NguoiThueTro(
    MaNguoiThue VARCHAR(10) PRIMARY KEY, 
    HoTen NVARCHAR(100) NOT NULL, 
    NgaySinh DATE NOT NULL, 
    GioiTinh NVARCHAR(10) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')), 
    CCCD VARCHAR(12) NOT NULL UNIQUE, -- tí code phần trùng lập cccd với nhân khẩu
    SoDienThoai VARCHAR(15) NOT NULL, -- tí code phần trùng lập sdt với nhân khẩu
    Email NVARCHAR(50) NOT NULL, -- tí code phần trùng lập email với nhân khẩu
    QueQuan NVARCHAR(255) NOT NULL, 
    NgayBatDauThue DATE NOT NULL, 
    MaKhuTro VARCHAR(10) NOT NULL, 
    SoPhong VARCHAR(10) NOT NULL, 
    FOREIGN KEY (MaKhuTro) REFERENCES KhuTro(MaKhuTro)
);
ALTER TABLE NguoiThueTro
ADD AnhDinhKem6 VARBINARY(MAX) NULL;
ALTER TABLE NguoiThueTro
ADD AnhDinhKem7 VARBINARY(MAX) NULL;

-- Bảng PhanAnh
CREATE TABLE PhanAnh (
    MaPhanAnh INT IDENTITY(1,1) PRIMARY KEY, 
    MaHoKhau VARCHAR(10) NOT NULL, 
    HoTen NVARCHAR(100) NOT NULL, 
    SoDienThoai VARCHAR(15) NOT NULL, 
    NoiDung NVARCHAR(255) NOT NULL, 
    NgayPhanAnh DATE NOT NULL, 
    TrangThai NVARCHAR(50) DEFAULT N'Đang xử lý' NULL,
    FOREIGN KEY (MaHoKhau) REFERENCES HoKhau(MaHoKhau)
);

-- Bảng SinhHoat
CREATE TABLE SinhHoat (
    MaSinhHoat VARCHAR(10) PRIMARY KEY, 
    TenSinhHoat NVARCHAR(100) NOT NULL, 
    NgayToChuc DATE NOT NULL, 
    DiaDiem NVARCHAR(255) NOT NULL, 
    NoiDung NVARCHAR(255) NOT NULL, 
    MoTa NVARCHAR(255) NULL, 
    NguoiToChuc NVARCHAR(100) NOT NULL, 
    SoDienThoaiNguoiToChuc VARCHAR(15) NOT NULL, 
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Chưa diễn ra'
);

-- Bảng GhiNhan
CREATE TABLE GhiNhanThamGia (
    MaGhiNhan VARCHAR(10) PRIMARY KEY, 
    MaHoKhau VARCHAR(10) NOT NULL, 
    MaSinhHoat VARCHAR(10) NOT NULL, 
    TenBuoiSinhHoat NVARCHAR(100) NOT NULL, 
    TenNguoiThamGia NVARCHAR(100) NOT NULL, 
    SoDienThoai VARCHAR(15) NOT NULL, 
    GhiChu NVARCHAR(255) NULL,
    FOREIGN KEY (MaHoKhau) REFERENCES HoKhau(MaHoKhau),
    FOREIGN KEY (MaSinhHoat) REFERENCES SinhHoat(MaSinhHoat)
);

-- Bảng ThuPhi
CREATE TABLE ThuPhi (
    MaThuPhi VARCHAR(10) PRIMARY KEY, 
    TenKhoanThu NVARCHAR(100) NOT NULL, 
    SoTien DECIMAL(10, 2) NOT NULL, 
    HanDong DATE NOT NULL, 
    LyDoThu NVARCHAR(255) NOT NULL, 
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang Thu'
);

-- Bảng GhiNhanThuPhi
CREATE TABLE GhiNhanThuPhi (
    MaGhiNhan VARCHAR(10) PRIMARY KEY, 
    MaHoKhau VARCHAR(10) NOT NULL,
    MaThuPhi VARCHAR(10) NOT NULL, 
    TenNguoiDong NVARCHAR(100) NOT NULL, 
    NgayDong DATE NOT NULL, 
    SoTienDong DECIMAL(10, 2) NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    FOREIGN KEY (MaHoKhau) REFERENCES HoKhau(MaHoKhau),
    FOREIGN KEY (MaThuPhi) REFERENCES ThuPhi(MaThuPhi)
);

-- Bảng DichBenh
CREATE TABLE DichBenh (
    MaDich VARCHAR(10) PRIMARY KEY, 
    TenDich NVARCHAR(100) NOT NULL, 
    NgayBungPhat DATE NOT NULL, 
    MucDoNguyHiem NVARCHAR(50) NOT NULL, 
    NoiBungPhat NVARCHAR(255) NOT NULL, 
    MoTa NVARCHAR(255) NULL, 
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang Bùng Phát'
);

-- Bảng BenhNhan
CREATE TABLE BenhNhan (
    MaBenhNhan VARCHAR(10) PRIMARY KEY, 
    MaDichBenh VARCHAR(10) NOT NULL, 
    MaNhanKhau VARCHAR(10) NOT NULL, 
    HoTen NVARCHAR(100) NOT NULL, 
    CCCD VARCHAR(12) NOT NULL, 
    NgaySinh DATE NOT NULL, 
    GioiTinh NVARCHAR(10) NOT NULL, 
    SoDienThoai VARCHAR(15) NOT NULL, 
    DiaChi NVARCHAR(255) NOT NULL, 
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang Nhiễm Bệnh', 
    MucDoNghiemTrong NVARCHAR(50) NOT NULL, 
    TenBenh NVARCHAR(100) NOT NULL, 
    MoTa NVARCHAR(500) NULL,
    FOREIGN KEY (MaDichBenh) REFERENCES DichBenh(MaDich),
    FOREIGN KEY (MaNhanKhau) REFERENCES NhanKhau(MaNhanKhau)
);

-- Bảng User
CREATE TABLE [User] (
    MaUser INT IDENTITY(1,1) PRIMARY KEY,  
    TenDangNhap VARCHAR(50) NOT NULL, 
    MatKhau VARCHAR(255) NOT NULL, 
    VaiTro NVARCHAR(50) NOT NULL
);

-- MỞ RỘNG CỦA ĐỀ TÀI
-- Bảng lịch sử hoạt động
CREATE TABLE LichSuHoatDong (
    ID INT IDENTITY PRIMARY KEY,
    TenDangNhap NVARCHAR(50),
    ChucVu NVARCHAR(50),
    HanhDong NVARCHAR(100),
    NoiDung NVARCHAR(MAX),
    ThoiGian DATETIME DEFAULT GETDATE()
);
-- Bảng Khảo Sát
CREATE TABLE KhaoSat (
    MaKhaoSat INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe NVARCHAR(255) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) NOT NULL
);
-- Bảng Câu Hỏi
CREATE TABLE CauHoi (
    MaCauHoi INT IDENTITY(1,1) PRIMARY KEY,
    MaKhaoSat INT NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    Kieu NVARCHAR(20) NOT NULL,
    ThuTu INT NOT NULL,
    FOREIGN KEY (MaKhaoSat) REFERENCES KhaoSat(MaKhaoSat)ON DELETE CASCADE
);
-- Bảng Đáp án
CREATE TABLE DapAn (
    MaDapAn INT IDENTITY(1,1) PRIMARY KEY,
    MaCauHoi INT NOT NULL,
    NoiDungDapAn NVARCHAR(255) NOT NULL,
    FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi)ON DELETE CASCADE
);
CREATE TABLE BaiLamKhaoSat (
    MaBaiLam INT IDENTITY(1,1) PRIMARY KEY,
    MaUser INT NOT NULL,
    MaKhaoSat INT NOT NULL,
    NgayNop DATETIME DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1, -- 1: Đã làm, 0: Chưa làm
    FOREIGN KEY (MaUser) REFERENCES [User](MaUser),
    FOREIGN KEY (MaKhaoSat) REFERENCES KhaoSat(MaKhaoSat)
);
CREATE TABLE CauTraLoi (
    MaCauTraLoi INT IDENTITY(1,1) PRIMARY KEY,
    MaBaiLam INT NOT NULL,
    MaCauHoi INT NOT NULL,
    MaDapAn INT NULL, -- Nếu là trắc nghiệm
    TraLoiTuLuan NVARCHAR(MAX) NULL, -- Nếu là tự luận
    FOREIGN KEY (MaBaiLam) REFERENCES BaiLamKhaoSat(MaBaiLam),
    FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi),
    FOREIGN KEY (MaDapAn) REFERENCES DapAn(MaDapAn)
);

CREATE TABLE ThongBao (
    MaThongBao INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe NVARCHAR(200),
    NoiDung NVARCHAR(MAX),
    NgayGui DATETIME DEFAULT GETDATE()
);

CREATE TABLE ThongBao_NguoiNhan (
    MaThongBao INT,
    MaNguoiNhan NVARCHAR(20), 
    DaXem BIT DEFAULT 0,
    FOREIGN KEY (MaThongBao) REFERENCES ThongBao(MaThongBao)
);
CREATE PROCEDURE XoaUser
    @MaUser INT
AS
BEGIN
    -- Xóa câu trả lời của các bài làm
    DELETE FROM CauTraLoi
    WHERE MaBaiLam IN (SELECT MaBaiLam FROM BaiLamKhaoSat WHERE MaUser = @MaUser)

    -- Xóa bài làm của user
    DELETE FROM BaiLamKhaoSat
    WHERE MaUser = @MaUser

    -- Xóa user
    DELETE FROM [User]
    WHERE MaUser = @MaUser
END

CREATE PROCEDURE proc_XoaKhaoSat
    @MaKhaoSat INT
AS
BEGIN
    -- Xóa câu trả lời của các bài làm
    DELETE FROM CauTraLoi
    WHERE MaBaiLam IN (SELECT MaBaiLam FROM BaiLamKhaoSat WHERE MaKhaoSat = @MaKhaoSat)

    -- Xóa bài làm
    DELETE FROM BaiLamKhaoSat
    WHERE MaKhaoSat = @MaKhaoSat

    -- Xóa khảo sát (CauHoi và DapAn sẽ tự động xóa do ON DELETE CASCADE)
    DELETE FROM KhaoSat
    WHERE MaKhaoSat = @MaKhaoSat
END

CREATE PROCEDURE proc_XoaCauHoi
    @MaCauHoi INT
AS
BEGIN
    -- Xóa câu trả lời
    DELETE FROM CauTraLoi WHERE MaCauHoi = @MaCauHoi
    -- Xóa câu hỏi (các đáp án sẽ tự động xóa vì ON DELETE CASCADE)
    DELETE FROM CauHoi WHERE MaCauHoi = @MaCauHoi
END

CREATE PROCEDURE proc_XoaDapAn
    @MaDapAn INT
AS
BEGIN
    DELETE FROM CauTraLoi WHERE MaDapAn = @MaDapAn
    DELETE FROM DapAn WHERE MaDapAn = @MaDapAn
END

CREATE PROCEDURE sp_XemKetQuaKhaoSat
    @MaUser INT,
    @MaKhaoSat INT
AS
BEGIN
    SELECT 
        ch.NoiDung AS CauHoi,
        ch.Kieu,
        da.NoiDungDapAn AS DapAnChon,
        ctl.TraLoiTuLuan,
        ctl.MaDapAn,
        ctl.MaCauHoi
    FROM BaiLamKhaoSat blks
    INNER JOIN CauTraLoi ctl ON blks.MaBaiLam = ctl.MaBaiLam
    INNER JOIN CauHoi ch ON ctl.MaCauHoi = ch.MaCauHoi
    LEFT JOIN DapAn da ON ctl.MaDapAn = da.MaDapAn
    WHERE blks.MaUser = @MaUser AND blks.MaKhaoSat = @MaKhaoSat
END

exec sp_XemKetQuaKhaoSat 19,2


-- INSERT Dữ liệu Bảng HoKhau

INSERT INTO HoKhau (MaHoKhau, TenChuHo, CCCDChuHo, DiaChi, SoThanhVien, NgayLap, TrangThai, MoTa)
VALUES 
('HK1', N'Nguyễn Văn Khát ', '012345678901', N'123 Lê Lợi, Q.1, TP.HCM', 4, '2022-01-15', N'Đang sinh sống', NULL),
('HK2', N'Lê Thị Bình', '012345678902', N'56 Nguyễn Huệ, Q.1, TP.HCM', 3, '2021-12-20', N'Đang sinh sống', N'Hộ gia đình buôn bán nhỏ'),
('HK3', N'Trần Văn Côn', '012345678903', N'89 Hai Bà Trưng, Q.3, TP.HCM', 5, '2023-03-10', N'Chuyển đi', NULL),
('HK4', N'Phạm Thị Diên', '012345678904', N'77 Lý Thường Kiệt, Q.10, TP.HCM', 2, '2022-05-08', N'Đang sinh sống', N'Công nhân viên chức'),
('HK5', N'Võ Văn Bich', '012345678905', N'31 Trường Chinh, Q.Tân Bình, TP.HCM', 6, '2023-07-12', N'Đang sinh sống', NULL),
('HK6', N'Huỳnh Thị Mai', '012345678906', N'222 Cộng Hòa, Q.Tân Bình, TP.HCM', 4, '2021-11-01', N'Chuyển đi', N'Đã chuyển ra Hà Nội'),
('HK7', N'Đặng Văn Giang', '012345678907', N'15 Phan Xích Long, Q.Phú Nhuận, TP.HCM', 3, '2022-09-22', N'Đang sinh sống', NULL),
('HK8', N'Ngô Thị Hiền', '012345678908', N'45 Phạm Văn Đồng, Q.Thủ Đức, TP.HCM', 4, '2020-06-30', N'Tạm vắng', N'Đang đi nước ngoài'),
('HK9', N'Mai Văn Cao', '012345678909', N'12A Võ Thị Sáu, Q.3, TP.HCM', 5, '2021-02-14', N'Đang sinh sống', NULL),
('HK10', N'Hồ Thị Hoa Anh', '012345678910', N'19 Nguyễn Văn Trỗi, Q.Phú Nhuận, TP.HCM', 2, '2022-08-05', N'Đang sinh sống', N'Sống cùng con trai'),

('HK11', N'Nguyễn Văn Kiên', '012345678911', N'88 Đinh Bộ Lĩnh, Q.Bình Thạnh, TP.HCM', 4, '2023-04-01', N'Đang sinh sống', NULL),
('HK12', N'Lê Thị Lan', '012345678912', N'121 Tô Hiến Thành, Q.10, TP.HCM', 3, '2021-07-18', N'Tạm vắng', N'Về quê chăm sóc cha mẹ'),
('HK13', N'Trần Văn Minh', '012345678913', N'101 Bạch Đằng, Q.Bình Thạnh, TP.HCM', 6, '2022-03-11', N'Đang sinh sống', NULL),
('HK14', N'Phạm Thị Ngọc', '012345678914', N'200 Lý Chính Thắng, Q.3, TP.HCM', 3, '2020-10-10', N'Chuyển đi', N'Chuyển ra miền Trung'),
('HK15', N'Võ Văn Oanh', '012345678915', N'32 Hoàng Văn Thụ, Q.Phú Nhuận, TP.HCM', 2, '2022-12-25', N'Đang sinh sống', NULL),
('HK16', N'Huỳnh Thị Phượng', '012345678916', N'9 Nguyễn Văn Cừ, Q.5, TP.HCM', 4, '2021-03-05', N'Đang sinh sống', N'Hộ khá giả'),
('HK17', N'Đặng Văn Quyền', '012345678917', N'333 Nguyễn Trãi, Q.1, TP.HCM', 3, '2023-05-20', N'Tạm vắng', NULL),
('HK18', N'Ngô Thị Thanh Hoa', '012345678918', N'12 Pasteur, Q.1, TP.HCM', 5, '2023-06-30', N'Đang sinh sống', N'Mới lập hộ khẩu'),
('HK19', N'Mai Văn Vinh', '012345678919', N'101 Nguyễn Đình Chiểu, Q.3, TP.HCM', 2, '2021-01-01', N'Chuyển đi', NULL),
('HK20', N'Hồ Thị Trúc', '012345678920', N'66A Lê Văn Sỹ, Q.3, TP.HCM', 4, '2022-11-11', N'Đang sinh sống', N'Sống cùng con gái');


-- INSERT Dữ Liệu Bảng NhanKhau

INSERT INTO NhanKhau (MaNhanKhau, MaHoKhau, HoTen, CCCD, NgaySinh, GioiTinh, QuanHeVoiChuHo, TrangThai, GhiChu, Email, SoDienThoai) VALUES
-- HK1: 4 người
('NK11', 'HK1', N'Nguyễn Văn Khát ', '012345678901', '1980-05-10', N'Nam', N'Chủ hộ', N'Đang sinh sống', N'Hộ có 2 trẻ nhỏ', 'vana1@gmail.com', '0901000001'),
('NK12', 'HK1', N'Trần Thị Cúc', '012345342', '1982-07-12', N'Nữ', N'Vợ', N'Đang sinh sống', NUll, 'trank@gmail.com', '0901000002'),
('NK13', 'HK1', N'Nguyễn Văn Bách', '01237855513', '2010-03-21', N'Nam', N'Con', N'Đang sinh sống', Null, 'vanb@gmail.com', '0901000003'),
('NK14', 'HK1', N'Nguyễn Thị Hồng', '01342267444', '2013-06-15', N'Nữ', N'Con', N'Đang sinh sống', N'Học tiểu học', 'thic@gmail.com', '0901000004'),

-- HK2: 3 người
('NK21', 'HK2', N'Trần Thị B', '012345678902', '1985-08-18', N'Nữ', N'Chủ hộ', N'Đang sinh sống', NULL, 'tranb@gmail.com', '0902000001'),
('NK22', 'HK2', N'Nguyễn Văn D', '012345678916', '1983-02-22', N'Nam', N'Chồng', N'Đang sinh sống', N'Làm việc tự do', 'vand@gmail.com', '0902000002'),
('NK23', 'HK2', N'Nguyễn Thị E', '012345678917', '2012-09-09', N'Nữ', N'Con', N'Đang sinh sống', N'Học sinh', 'thie@gmail.com', '0902000003'),

-- HK3: 5 người
('NK31', 'HK3', N'Lê Văn C', '012345678903', '1970-04-14', N'Nam', N'Chủ hộ', N'Chuyển đi', N'Dọn đi tỉnh khác', 'vanc3@gmail.com', '0903000001'),
('NK32', 'HK3', N'Phạm Thị F', '012345678919', '1972-05-23', N'Nữ', N'Vợ', N'Chuyển đi', NULL, 'phamf@gmail.com', '0903000002'),
('NK33', 'HK3', N'Lê Văn G', '012345678920', '1998-12-30', N'Nam', N'Con', N'Chuyển đi', N'Sinh viên', 'vang@gmail.com', '0903000003'),
('NK34', 'HK3', N'Lê Thị H', '012345678921', '2001-01-15', N'Nữ', N'Con', N'Chuyển đi', NULL, 'thih@gmail.com', '0903000004'),
('NK35', 'HK3', N'Lê Văn I', '012345678922', '1965-10-20', N'Nam', N'Bố', N'Chuyển đi', NULL, 'vani@gmail.com', '0903000005'),

-- HK4: 2 người
('NK41', 'HK4', N'Phạm Thị D', '012345678904', '1986-06-06', N'Nữ', N'Chủ hộ', N'Đang sinh sống', NULL, 'phamd@gmail.com', '0904000001'),
('NK42', 'HK4', N'Nguyễn Văn J', '012345678924', '1990-09-09', N'Nam', N'Em trai', N'Đang sinh sống', N'Làm công ty', 'vanj@gmail.com', '0904000002'),

-- HK5: 6 người
('NK51', 'HK5', N'Hoàng Văn E', '012345678905', '1975-03-17', N'Nam', N'Chủ hộ', N'Đang sinh sống', N'Hộ đông người', 'vane@gmail.com', '0905000001'),
('NK52', 'HK5', N'Đinh Thị K', '012345678926', '1978-11-25', N'Nữ', N'Vợ', N'Đang sinh sống', NULL, 'thik@gmail.com', '0905000002'),
('NK53', 'HK5', N'Hoàng Văn L', '012345678927', '2002-08-18', N'Nam', N'Con', N'Đang sinh sống', NULL, 'vanl@gmail.com', '0905000003'),
('NK54', 'HK5', N'Hoàng Thị M', '012345678928', '2005-05-05', N'Nữ', N'Con', N'Đang sinh sống', NULL, 'thim@gmail.com', '0905000004'),
('NK55', 'HK5', N'Hoàng Văn N', '012345678929', '1950-04-01', N'Nam', N'Bố', N'Đang sinh sống', NULL, 'vann@gmail.com', '0905000005'),
('NK56', 'HK5', N'Hoàng Thị O', '012345678930', '1952-02-02', N'Nữ', N'Mẹ', N'Đang sinh sống', NULL, 'thio@gmail.com', '0905000006');

-- HK6: 1 người
INSERT INTO NhanKhau VALUES
('NK61', 'HK6', N'Đỗ Thị F', '012345678906', '1990-12-01', N'Nữ', N'Chủ hộ', N'Tạm vắng', N'Đi công tác nước ngoài', 'thif@gmail.com', '0906000001');

-- HK7: 3 người
INSERT INTO NhanKhau VALUES
('NK71', 'HK7', N'Võ Văn G', '012345678907', '1984-04-10', N'Nam', N'Chủ hộ', N'Đang sinh sống', NULL, 'vang@gmail.com', '0907000001'),
('NK72', 'HK7', N'Lê Thị P', '012345678933', '1987-08-12', N'Nữ', N'Vợ', N'Đang sinh sống', NULL, 'thip@gmail.com', '0907000002'),
('NK73', 'HK7', N'Võ Văn Q', '012345678934', '2015-03-28', N'Nam', N'Con', N'Đang sinh sống', NULL, 'vanq@gmail.com', '0907000003');

-- HK8: 4 người
INSERT INTO NhanKhau VALUES
('NK81', 'HK8', N'Ngô Thị H', '012345678908', '1978-07-07', N'Nữ', N'Chủ hộ', N'Đang sinh sống', NULL, 'thih@gmail.com', '0908000001'),
('NK82', 'HK8', N'Nguyễn Văn R', '012345678936', '1976-03-10', N'Nam', N'Chồng', N'Đang sinh sống', NULL, 'vanr@gmail.com', '0908000002'),
('NK83', 'HK8', N'Nguyễn Thị S', '012345678937', '2000-11-20', N'Nữ', N'Con', N'Đang sinh sống', NULL, 'this@gmail.com', '0908000003'),
('NK84', 'HK8', N'Nguyễn Văn T', '012345678938', '2003-05-05', N'Nam', N'Con', N'Đang sinh sống', NULL, 'vant@gmail.com', '0908000004');

-- HK9: 5 người
INSERT INTO NhanKhau VALUES
('NK91', 'HK9', N'Huỳnh Văn I', '012345678909', '1955-10-15', N'Nam', N'Chủ hộ', N'Đang sinh sống', N'Có người cao tuổi', 'vani@gmail.com', '0909000001'),
('NK92', 'HK9', N'Ngô Thị U', '012345678940', '1958-12-12', N'Nữ', N'Vợ', N'Đang sinh sống', NULL, 'thiu@gmail.com', '0909000002'),
('NK93', 'HK9', N'Huỳnh Văn V', '012345678941', '1985-06-25', N'Nam', N'Con', N'Đang sinh sống', NULL, 'vanv@gmail.com', '0909000003'),
('NK94', 'HK9', N'Phạm Thị W', '012345678942', '1988-08-08', N'Nữ', N'Dâu', N'Đang sinh sống', NULL, 'thiw@gmail.com', '0909000004'),
('NK95', 'HK9', N'Huỳnh Văn X', '012345678943', '2010-01-01', N'Nam', N'Cháu', N'Đang sinh sống', NULL, 'vanx@gmail.com', '0909000005');

-- HK10: 2 người
INSERT INTO NhanKhau VALUES
('NK101', 'HK10', N'Bùi Thị J', '012345678910', '1992-02-14', N'Nữ', N'Chủ hộ', N'Sắp chuyển', NULL, 'thij@gmail.com', '0910000001'),
('NK102', 'HK10', N'Nguyễn Văn Y', '012345678945', '1990-01-30', N'Nam', N'Chồng', N'Sắp chuyển', NULL, 'vany@gmail.com', '0910000002');

-- INSERT Dữ Liệu Bảng Giấy Tạm Vắng
INSERT INTO GiayTamVang (MaGiayTamVang, MaNhanKhau, HoTen, CCCD, NgaySinh, GioiTinh, SoDienThoai, NoiDi, NgayDi, NgayVe, LyDo, TrangThai)
VALUES
('TV1011', 'NK61', N'Bùi Thị J', '012345678910', '1992-02-14', N'Nữ', '0910000001', N'Mỹ', '2025-03-01', '2025-06-01', N'Công tác nước ngoài', N'Đang có hiệu lực'),
('TV911', 'NK33', N'Huỳnh Văn I', '012345678909', '1955-10-15', N'Nam', '0909000001', N'Hà Nội', '2025-02-10', '2025-03-10', N'Ôn thi đại học', N'Sắp hết Hạn'),
('TV841', 'NK72', N'Nguyễn Văn T', '012345678938', '2003-05-05', N'Nam', '0908000004', N'Đà Nẵng', '2025-01-15', '2025-04-15', N'Chăm người thân', N'Đang có hiệu lực');

-- INSERT Dữ Liệu Bảng Giấy Tạm Trú
INSERT INTO GiayTamTru (MaGiayTamTru, MaNguoiThue, HoTen, GioiTinh, NgaySinh, CCCD, QueQuan, SoDienThoai, NoiTamTru, NgayBatDau, NgayKetThuc, LyDo, TrangThai)
VALUES
('TT111', 'NT11', N'Nguyễn Văn K', N'Nam', '1995-03-15', '1234561', N'Hà Nội', '090111100112', N'Phòng 101, Khu A', '2024-03-01', '2024-06-01', N'Công tác', N'Sắp hết hạ'),
('TT121', 'NT12', N'Trần Thị L', N'Nữ', '1998-07-22', '123456224', N'Hải Phòng', '090111100242', N'Phòng 102, Khu A', '2024-02-15', '2024-05-15', N'Học tập', DEFAULT),
('TT211', 'NT21', N'Lê Văn M', N'Nam', '1992-11-05', '123453241', N'TP.HCM', '090111100366', N'Phòng 103, Khu B', '2024-01-01', '2024-04-01', N'Làm việc', N'Hết Hạn'),
('TT221', 'NT22', N'Phạm Thị N', N'Nữ', '1996-09-12', '12344124', N'Bình Dương', '0901111004754', N'Phòng 104, Khu B', '2024-03-15', '2024-07-15', N'Chăm sóc người thân', DEFAULT),
('TT311', 'NT31', N'Hoàng Văn O', N'Nam', '1994-06-18', '123911555', N'Cần Thơ', '0901111005432', N'Phòng 105, Khu C', '2024-02-01', '2024-05-01', N'Công tác', DEFAULT),
('TT611', 'NT61', N'Vũ Thị P', N'Nữ', '1997-12-25', '1234689', N'Đà Nẵng', '090111100624', N'Phòng 106, Khu C', '2024-03-20', '2024-06-20', N'Thực tập', DEFAULT),
('TT411', 'NT41', N'Đặng Văn Q', N'Nam', '1993-04-08', '12341120', N'Nam Định', '090111100712', N'Phòng 107, Khu D', '2024-04-01', '2024-07-01', N'Làm việc', DEFAULT),
('TT511', 'NT51', N'Ngô Thị R', N'Nữ', '1999-10-30', '1232234', N'Nghệ An', '090111100822', N'Phòng 108, Khu D', '2024-03-10', '2024-06-10', N'Chăm sóc sức khỏe', DEFAULT),
('TT612', 'NT62', N'Bùi Văn S', N'Nam', '1991-01-20', '12341224', N'Thái Bình', '090111100979', N'Phòng 109, Khu E', '2024-01-25', '2024-04-25', N'Học tập', DEFAULT),
('TT711', 'NT71', N'Đinh Thị T', N'Nữ', '1990-08-14', '12340678', N'Lâm Đồng', '090111101065', N'Phòng 110, Khu E', '2024-02-20', '2024-05-20', N'Làm việc', DEFAULT);

-- INSERT Dữ Liệu Bảng Khu Trọ



-- INSERT Dữ Liệu Bảng Người Thuê Trọ
INSERT INTO NguoiThueTro (MaNguoiThue, HoTen, NgaySinh, GioiTinh, CCCD, SoDienThoai, Email, QueQuan, NgayBatDauThue, MaKhuTro, SoPhong)
VALUES
('NT11', N'Nguyễn Văn K', '1995-03-15', N'Nam', '1234561', '090111100112', 'nvgk@gmail.com', N'Hà Nội', '2021-01-01', 'KT1', 'P101'),
('NT12', N'Trần Thị L', '1998-07-22', N'Nữ', '123456224', '090111100242', 'ttfl@gmail.com', N'Hải Phòng', '2022-02-10', 'KT1', 'P102'),
('NT21', N'Lê Văn M', '1992-11-05', N'Nam', '123453241', '090111100366', 'lsfvm@gmail.com', N'TP.HCM', '2023-03-01', 'KT2', 'P201'),
('NT22', N'Phạm Thị N', '1996-09-12', N'Nữ', '12344124', '0901111004754', 'pstn@gmail.com', N'Bình Dương', '2025-03-20', 'KT2', 'P202'),
('NT31', N'Hoàng Văn O', '1994-06-18', N'Nam', '123911555', '0901111005432', 'hvo@gmail.com', N'Cần Thơ', '2018-04-01', 'KT3', 'P301'),
('NT61', N'Vũ Thị P', '1997-12-25', N'Nữ', '1234689', '090111100624', 'vtpua@gmail.com', N'Đà Nẵng', '2023-04-10', 'KT6', 'P302'),
('NT41', N'Đặng Văn Q', '1993-04-08', N'Nam', '12341120', '090111100712', 'dvqdf@gmail.com', N'Nam Định', '2022-04-15', 'KT4', 'P401'),
('NT51', N'Ngô Thị R', '1999-10-30', N'Nữ', '1232234', '090111100822', 'ntrg@gmail.com', N'Nghệ An', '2021-04-20', 'KT5', 'P501'),
('NT62', N'Bùi Văn S', '1991-01-20', N'Nam', '12341224', '090111100979', 'bvsc@gmail.com', N'Thái Bình', '2025-05-01', 'KT6', 'P601'),
('NT71', N'Đinh Thị T', '1990-08-14', N'Nữ', '12340678', '090111101065', 'dttb@gmail.com', N'Lâm Đồng', '2024-05-05', 'KT7', 'P701');

-- INSERT Bảng Sinh Hoạt Cuộc Họp
INSERT INTO SinhHoat (MaSinhHoat, TenSinhHoat, NgayToChuc, DiaDiem, NoiDung, MoTa, NguoiToChuc, SoDienThoaiNguoiToChuc, TrangThai)
VALUES
('SH1', N'Họp tổ dân phố tháng 4', '2025-04-20', N'Nhà văn hóa khu phố A', N'Thảo luận kế hoạch tháng', N'Bàn về các hoạt động vệ sinh, an ninh', N'Lê Văn C', '0903000001',N'Đang diễn ra'),
('SH2', N'Chiếu phim cộng đồng', '2025-04-25', N'Sân chung cư B', N'Chiếu phim giáo dục gia đình', N'Dành cho mọi lứa tuổi', N'Lê Văn I', '0903000005', N'Đã kết thúc'),
('SH3', N'Ngày hội thiếu nhi', '2025-05-01', N'Công viên khu C', N'Tổ chức trò chơi cho trẻ em', N'Có quà và biểu diễn nghệ thuật', N'Bùi Thị J', '0910000001', DEFAULT);

-- INSERT Bảng Ghi Nhận Tham Gia
INSERT INTO GhiNhanThamGia (MaGhiNhan, MaHoKhau, MaSinhHoat, TenBuoiSinhHoat, TenNguoiThamGia, SoDienThoai, GhiChu)
VALUES 
('GN1', 'HK1', 'SH1', N'Họp tổ dân phố tháng 4', N'Nguyễn Văn A', '012345678901', N'Tham gia đầy đủ'),
('GN2', 'HK2', 'SH2', N'Chiếu phim cộng đồng', N'Trần Thị B', '012345678902', N'Tham gia cùng gia đình'),
('GN3', 'HK3', 'SH1', N'Họp tổ dân phố tháng 4', N'Lê Văn C', '012345678903', N'Người tổ chức cũng tham gia'),
('GN4', 'HK4', 'SH3', N'Ngày hội thiếu nhi', N'Phạm Thị D', '012345678904', N'Dẫn theo trẻ em'),
('GN5', 'HK10', 'SH3', N'Ngày hội thiếu nhi', N'Bùi Thị J', '012345678945', N'Người tổ chức sự kiện');

-- INSERT Bảng Thu Phí Đóng Góp 
INSERT INTO ThuPhi (MaThuPhi, TenKhoanThu, SoTien, HanDong, LyDoThu, TrangThai)
VALUES 
('TP1', N'Phí vệ sinh môi trường', 50000.00, '2025-04-30', N'Thu hàng tháng để duy trì vệ sinh khu phố', N'Đang Thu'),
('TP2', N'Phí bảo trì cơ sở vật chất', 100000.00, '2025-05-15', N'Thu hàng quý để sửa chữa và nâng cấp hạ tầng', N'Chưa thu'),
('TP3', N'Quỹ khuyến học', 75000.00, '2025-05-10', N'Hỗ trợ học sinh, sinh viên có hoàn cảnh khó khăn', N'Đang Thu'),
('TP4', N'Phí an ninh khu vực', 60000.00, '2025-04-25', N'Thu để hỗ trợ hoạt động bảo vệ, an ninh', N'Đã thu'),
('TP5', N'Quỹ tổ chức lễ hội', 80000.00, '2025-06-01', N'Phục vụ tổ chức các sự kiện văn hóa cộng đồng', N'Đang Thu');

-- INSERT Bảng Ghi Nhận Thu Phí 
INSERT INTO GhiNhanThuPhi (MaGhiNhan, MaHoKhau, MaThuPhi, TenNguoiDong, NgayDong, SoTienDong, GhiChu)
VALUES
('GNTP11', 'HK1', 'TP1', N'Nguyễn Văn A', '2025-04-15', 50000.00, N'Đã đóng đủ'),
('GNTP22', 'HK2', 'TP2', N'Trần Thị B', '2025-04-18', 100000.00, N'Đóng trước hạn'),
('GNTP33', 'HK3', 'TP3', N'Lê Văn C', '2025-04-20', 75000.00, NULL),
('GNTP44', 'HK4', 'TP4', N'Phạm Thị D', '2025-04-22', 60000.00, N'Thanh toán tiền mặt'),
('GNTP55', 'HK5', 'TP5', N'Hoàng Văn E', '2025-04-25', 80000.00, N'Sẽ đóng định kỳ mỗi năm');

-- INSERT Bảng Dịch Bệnh 
INSERT INTO DichBenh (MaDich, TenDich, NgayBungPhat, MucDoNguyHiem, NoiBungPhat, MoTa, TrangThai)
VALUES
('DB1', N'Covid19', '2025-04-01', N'Cao', N'Bọn Chó Trung Quốc', N'Lây lan qua muỗi vằn, cần phun thuốc diệt muỗi', N'Đang Bùng Phát'),
('DB2', N'Viêm Não ', '2025-03-25', N'Trung bình', N'Phường Linh Đông, TP.Thủ Đức', N'Chủ yếu ở trẻ nhỏ, cần tăng cường vệ sinh trường học', N'Đang Bùng Phát');

-- INSERT Dữ Liệu Bảng Ghi Nhận Bệnh Nhân 
INSERT INTO BenhNhan (MaBenhNhan, MaDichBenh, MaNhanKhau, HoTen, CCCD, NgaySinh, GioiTinh, SoDienThoai, DiaChi, TrangThai, MucDoNghiemTrong, TenBenh, MoTa)
VALUES
-- Bệnh nhân bị Covid19
('BN111', 'DB1', 'NK11', N'Nguyễn Văn A', '012345678901', '1980-05-10', N'Nam', '0901000001', N'123 Đường Lê Lợi, Quận 1, TP.HCM', N'Đang Nhiễm Bệnh', N'Nặng', N'Covid19', N'Sốt cao, khó thở'),
('BN112', 'DB1', 'NK12', N'Trần Thị K', '012345678912', '1982-07-12', N'Nữ', '0901000002', N'123 Đường Lê Lợi, Quận 1, TP.HCM', N'Đang Nhiễm Bệnh', N'Nhẹ', N'Covid19', N'Có triệu chứng nhẹ, tự cách ly tại nhà'),

-- Bệnh nhân bị Viêm Não
('BN213', 'DB2', 'NK13', N'Nguyễn Văn B', '012345678913', '2010-03-21', N'Nam', '0901000003', N'123 Đường Lê Lợi, Quận 1, TP.HCM', N'Đang Nhiễm Bệnh', N'Vừa', N'Viêm Não', N'Tiếp xúc ở trường học, đang điều trị'),
('BN223', 'DB2', 'NK23', N'Nguyễn Thị E', '012345678917', '2012-09-09', N'Nữ', '0902000003', N'45/6 Đường Trường Chinh, Quận Tân Bình, TP.HCM', N'Đang Nhiễm Bệnh', N'Nặng', N'Viêm Não', N'Được nhập viện theo dõi chặt chẽ'),

-- Bệnh nhân lớn tuổi - trường hợp đặc biệt
('BN135', 'DB1', 'NK35', N'Lê Văn I', '012345678922', '1965-10-20', N'Nam', '0903000005', N'89 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', N'Đang Nhiễm Bệnh', N'Nặng', N'Covid19', N'Có bệnh nền, cần hỗ trợ y tế đặc biệt');

-- INSERT Dữ Liệu Bảng Phản Ánh Kiến Nghị
INSERT INTO PhanAnh (MaHoKhau, HoTen, SoDienThoai, NoiDung, NgayPhanAnh, TrangThai)
VALUES
('HK1', N'Nguyễn Văn A', '0901000001', N'Đề nghị thu gom rác đúng giờ hơn vào buổi sáng.', '2025-04-10', N'Đang xử lý'),
('HK2', N'Trần Thị B', '0902000001', N'Khu vực bị mất điện nhiều lần không báo trước.', '2025-04-09', N'Đã xử lý'),
('HK3', N'Lê Văn C', '0903000001', N'Tình trạng tiếng ồn vào ban đêm do hàng xóm.', '2025-04-07', N'Đang xử lý'),
('HK4', N'Phạm Thị D', '0904000001', N'Đề nghị sửa chữa đèn đường bị hỏng trước nhà.', '2025-04-11', N'Đang xử lý'),
('HK5', N'Hoàng Văn E', '0905000001', N'Cống trước nhà bị nghẹt, nước tràn lên vỉa hè.', '2025-04-08', N'Đã Tiếp Nhận');

-- INSERT Dữ Liệu Bảng User
INSERT INTO [User] (TenDangNhap, MatKhau, VaiTro)
VALUES 
('NK11', 'matkhau123', N'Chủ Trọ'),
('NK54', 'matkhau123', N'Cư dân'),
('NT11', 'matkhau123', N'Tạm trú'),
('NT22', 'matkhau123', N'Tạm trú'),
('NT61', 'matkhau123', N'Tạm trú');


-- Proc Thêm HoKhau
CREATE PROCEDURE ThemHoKhau
    @MaHoKhau VARCHAR(10),
    @TenChuHo NVARCHAR(50),
    @CCCDChuHo VARCHAR(12),
    @DiaChi NVARCHAR(255),
    @SoThanhVien INT,
    @NgayLap DATE,
    @TrangThai NVARCHAR(50),
    @MoTa NVARCHAR(255)
AS
BEGIN
    INSERT INTO HoKhau (MaHoKhau, TenChuHo, CCCDChuHo, DiaChi, SoThanhVien, NgayLap, TrangThai, MoTa)
    VALUES (@MaHoKhau, @TenChuHo, @CCCDChuHo, @DiaChi, @SoThanhVien, @NgayLap, @TrangThai, @MoTa);
END;

-- Test Proc Thêm HoKhau
EXEC ThemHoKhau 
    @MaHoKhau = 'HK11',
    @TenChuHo = N'Nguyễn Văn Abc',
    @CCCDChuHo = '1234424242',
    @DiaChi = N'12324 Đường ABC, Quận 14',
    @SoThanhVien = 4,
    @NgayLap = '2019-04-14',
    @TrangThai = N'Đang Tạm Vắng',
    @MoTa = N'Tạm Vắng Cả Nhà'


-- Proc Thêm NhanKhau
CREATE PROCEDURE ThemNhanKhau
    @MaNhanKhau VARCHAR(10),
    @MaHoKhau VARCHAR(10),
    @HoTen NVARCHAR(50),
    @CCCD VARCHAR(12),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @QuanHeVoiChuHo NVARCHAR(50),
    @TrangThai NVARCHAR(50),
    @GhiChu NVARCHAR(255),
    @Email NVARCHAR(50),
    @SoDienThoai VARCHAR(15)
AS
BEGIN
    INSERT INTO NhanKhau (
        MaNhanKhau, MaHoKhau, HoTen, CCCD, NgaySinh, GioiTinh,
        QuanHeVoiChuHo, TrangThai, GhiChu, Email, SoDienThoai
    )
    VALUES (
        @MaNhanKhau, @MaHoKhau, @HoTen, @CCCD, @NgaySinh, @GioiTinh,
        @QuanHeVoiChuHo, @TrangThai, @GhiChu, @Email, @SoDienThoai
    );
END

-- Test Proc Thêm NhanKhau
EXEC ThemNhanKhau 
    @MaNhanKhau = 'NK111',
    @MaHoKhau = 'HK11',
    @HoTen = N'Lê Thị Bwm',
    @CCCD = '987652425098',
    @NgaySinh = '1992-08-15',
    @GioiTinh = N'Nữ',
    @QuanHeVoiChuHo = N'Vợ',
    @TrangThai = N'Đang sinh sống',
    @GhiChu = NUll,
    @Email = N'lethi.b@example.com',
    @SoDienThoai = '0912345678'


-- Proc Thêm GiayTamVang
CREATE PROCEDURE ThemGiayTamVang
    @MaGiayTamVang VARCHAR(10),
    @MaNhanKhau VARCHAR(10),
    @HoTen NVARCHAR(100),
    @CCCD VARCHAR(12),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @SoDienThoai VARCHAR(15),
    @NoiDi NVARCHAR(255),
    @NgayDi DATE,
    @NgayVe DATE,
    @LyDo NVARCHAR(255),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    INSERT INTO GiayTamVang (
        MaGiayTamVang, MaNhanKhau, HoTen, CCCD, NgaySinh, GioiTinh,
        SoDienThoai, NoiDi, NgayDi, NgayVe, LyDo, TrangThai
    )
    VALUES (
        @MaGiayTamVang, @MaNhanKhau, @HoTen, @CCCD, @NgaySinh, @GioiTinh,
        @SoDienThoai, @NoiDi, @NgayDi, @NgayVe, @LyDo, @TrangThai
    );
END

-- Test Proc Thêm GiayTamVang
EXEC ThemGiayTamVang 
    @MaGiayTamVang = 'TV111',
    @MaNhanKhau = 'NK111',
    @HoTen = N'Lê Thị Bwm',
    @CCCD = '987652425098',
    @NgaySinh = '1992-08-15',
    @GioiTinh = N'Nữ',
    @SoDienThoai = '987652425098',
    @NoiDi = N'Đà Nẵng',
    @NgayDi = '2024-04-01',
    @NgayVe = '2024-04-20',
    @LyDo = N'Thăm người thân',
	@TrangThai =N'Đã kết thúc';


-- Proc Thêm KhuTro 
ALTER  PROCEDURE ThemKhuTro
    @MaKhuTro VARCHAR(10),
    @TenKhuTro NVARCHAR(100),
    @DiaChi NVARCHAR(255),
    @HoTenChuTro NVARCHAR(100),
    @SoDienThoaiChuTro VARCHAR(15),
    @MaNhanKhau VARCHAR(10),
    @SoPhong INT,
    @SoPhongTrong INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    INSERT INTO KhuTro (
        MaKhuTro, TenKhuTro, DiaChi, HoTenChuTro, SoDienThoaiChuTro,
        MaNhanKhau, SoPhong, SoPhongTrong, TrangThai
    )
    VALUES (
        @MaKhuTro, @TenKhuTro, @DiaChi, @HoTenChuTro, @SoDienThoaiChuTro,
        @MaNhanKhau, @SoPhong, @SoPhongTrong, @TrangThai
    );
END

-- Test Thêm KhuTro
EXEC ThemKhuTro 
    @MaKhuTro = 'KT12',
    @TenKhuTro = N'Khu trọ Minh Anh',
    @DiaChi = N'123 Đường ABC, Quận 1, TP.HCM',
    @HoTenChuTro = N'Nguyễn Văn D',
    @SoDienThoaiChuTro = '012345678916',
    @MaNhanKhau = 'NK22',
    @SoPhong = 10,
    @SoPhongTrong = 0,
    @TrangThai = N'Đã Hết Phòng';


-- Proc Thêm NguoiThueTro
CREATE PROCEDURE ThemNguoiThueTro
    @MaNguoiThue VARCHAR(10),
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @CCCD VARCHAR(12),
    @SoDienThoai VARCHAR(15),
    @Email NVARCHAR(50),
    @QueQuan NVARCHAR(255),
    @NgayBatDauThue DATE,
    @MaKhuTro VARCHAR(10),
    @SoPhong VARCHAR(10)
AS
BEGIN
    INSERT INTO NguoiThueTro (
        MaNguoiThue, HoTen, NgaySinh, GioiTinh, CCCD,
        SoDienThoai, Email, QueQuan, NgayBatDauThue,
        MaKhuTro, SoPhong
    )
    VALUES (
        @MaNguoiThue, @HoTen, @NgaySinh, @GioiTinh, @CCCD,
        @SoDienThoai, @Email, @QueQuan, @NgayBatDauThue,
        @MaKhuTro, @SoPhong
    );
END

-- Test Proc Thêm NguoiThueTro
EXEC ThemNguoiThueTro 
    @MaNguoiThue = 'NTT52',
    @HoTen = N'Phạm Thị Thu',
    @NgaySinh = '1998-06-20',
    @GioiTinh = N'Nữ',
    @CCCD = '123456123',
    @SoDienThoai = '0987651',
    @Email = 'pham.thu@example.com',
    @QueQuan = N'Hà Tĩnh',
    @NgayBatDauThue = '2024-10-01',
    @MaKhuTro = 'KT5',
    @SoPhong = 'P101';


-- Proc Thêm GiayTamTru
CREATE PROCEDURE ThemGiayTamTru
    @MaGiayTamTru VARCHAR(10),
    @MaNguoiThue VARCHAR(10),
    @HoTen NVARCHAR(100),
    @GioiTinh NVARCHAR(10),
    @NgaySinh DATE,
    @CCCD VARCHAR(12),
    @QueQuan NVARCHAR(255),
    @SoDienThoai VARCHAR(15),
    @NoiTamTru NVARCHAR(255),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @LyDo NVARCHAR(255),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    INSERT INTO GiayTamTru (
        MaGiayTamTru, MaNguoiThue, HoTen, GioiTinh, NgaySinh,
        CCCD, QueQuan, SoDienThoai, NoiTamTru,
        NgayBatDau, NgayKetThuc, LyDo, TrangThai
    )
    VALUES (
        @MaGiayTamTru, @MaNguoiThue, @HoTen, @GioiTinh, @NgaySinh,
        @CCCD, @QueQuan, @SoDienThoai, @NoiTamTru,
        @NgayBatDau, @NgayKetThuc, @LyDo, @TrangThai
    );
END

EXEC ThemGiayTamTru 
    @MaGiayTamTru = 'GTT521',
    @MaNguoiThue = 'NTT52',
    @HoTen = N'Phạm Thị Thu',
    @GioiTinh = N'Nữ',
    @NgaySinh = '1998-06-20',
    @CCCD = '123456789123',
    @QueQuan = N'Hà Tĩnh',
    @SoDienThoai = '123456123',
    @NoiTamTru = N'Phòng 101, Khu Trọ An Bình, Q.1',
    @NgayBatDau = '2025-05-01',
    @NgayKetThuc = '2025-08-01',
    @LyDo = N'Ở tạm để đi làm',
	@TrangThai = N'Sắp Hết Hạn';


-- Proc Thêm Đơn PhanAnhKienNghi
CREATE PROCEDURE ThemPhanAnh
    @MaHoKhau VARCHAR(10),
    @HoTen NVARCHAR(100),
    @SoDienThoai VARCHAR(15),
    @NoiDung NVARCHAR(255),
    @NgayPhanAnh DATE,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    INSERT INTO PhanAnh (
        MaHoKhau, HoTen, SoDienThoai, NoiDung, NgayPhanAnh, TrangThai
    )
    VALUES (
        @MaHoKhau, @HoTen, @SoDienThoai, @NoiDung, @NgayPhanAnh, @TrangThai
    );
END

-- Test Proc Thêm Đơn PhanAnhKienNghi
EXEC ThemPhanAnh 
    @MaHoKhau = 'HK11',
    @HoTen = N'Nguyễn Văn Abc',
    @SoDienThoai = '1234424242',
    @NoiDung = N'Đèn đường bị hỏng không sáng vào ban đêm',
    @NgayPhanAnh = '2025-04-14',
	@TrangThai = N'Đang Xử Lý';


-- Proc Thêm Đơn SinhHoatCuocHop
CREATE PROCEDURE ThemSinhHoat
    @MaSinhHoat VARCHAR(10),
    @TenSinhHoat NVARCHAR(100),
    @NgayToChuc DATE,
    @DiaDiem NVARCHAR(255),
    @NoiDung NVARCHAR(255),
    @MoTa NVARCHAR(255) = NULL,
    @NguoiToChuc NVARCHAR(100),
    @SoDienThoaiNguoiToChuc VARCHAR(15),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    INSERT INTO SinhHoat (
        MaSinhHoat, TenSinhHoat, NgayToChuc, DiaDiem,
        NoiDung, MoTa, NguoiToChuc, SoDienThoaiNguoiToChuc, TrangThai
    )
    VALUES (
        @MaSinhHoat, @TenSinhHoat, @NgayToChuc, @DiaDiem,
        @NoiDung, @MoTa, @NguoiToChuc, @SoDienThoaiNguoiToChuc, @TrangThai
    );
END

-- Test Proc Thêm Đơn SinhHoatCuocHop
EXEC ThemSinhHoat 
    @MaSinhHoat = 'SH12',
    @TenSinhHoat = N'Tổ Chức Hội Nghị Đại Biểu',
    @NgayToChuc = '2025-04-20',
    @DiaDiem = N'Nhà Văn Hóa Khu Phố 3',
    @NoiDung = N'Thảo luận kế hoạch bảo vệ môi trường',
    @MoTa = N'Họp định kỳ hàng tháng',
    @NguoiToChuc = N'Nguyễn Văn Abc',
    @SoDienThoaiNguoiToChuc = '1234424242',
	@TrangThai = N'Chưa diễn ra'

-- Proc Thêm GhiNhanThamGia
CREATE PROCEDURE ThemGhiNhanThamGia
    @MaGhiNhan VARCHAR(10),
    @MaHoKhau VARCHAR(10),
    @MaSinhHoat VARCHAR(10),
    @TenBuoiSinhHoat NVARCHAR(100),
    @TenNguoiThamGia NVARCHAR(100),
    @SoDienThoai VARCHAR(15),
    @GhiChu NVARCHAR(255) = NULL
AS
BEGIN
    INSERT INTO GhiNhanThamGia (
        MaGhiNhan, MaHoKhau, MaSinhHoat,
        TenBuoiSinhHoat, TenNguoiThamGia,
        SoDienThoai, GhiChu
    )
    VALUES (
        @MaGhiNhan, @MaHoKhau, @MaSinhHoat,
        @TenBuoiSinhHoat, @TenNguoiThamGia,
        @SoDienThoai, @GhiChu
    );
END


-- Test Thêm GhiNhanThamGia
EXEC ThemGhiNhanThamGia
    @MaGhiNhan = 'GNTG111',
    @MaHoKhau = 'HK11',
    @MaSinhHoat = 'SH1',
    @TenBuoiSinhHoat = N'Họp tổ dân phố tháng 4',
    @TenNguoiThamGia = N'Nguyễn Văn Abc',
    @SoDienThoai = '1234424242',
    @GhiChu = N'Tham gia đầy đủ';


-- Proc Thêm ThuPhiDongGop
CREATE PROCEDURE ThemThuPhi
    @MaThuPhi VARCHAR(10),
    @TenKhoanThu NVARCHAR(100),
    @SoTien DECIMAL(10, 2),
    @HanDong DATE,
    @LyDoThu NVARCHAR(255),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    INSERT INTO ThuPhi (
        MaThuPhi, TenKhoanThu, SoTien,
        HanDong, LyDoThu, TrangThai
    )
    VALUES (
        @MaThuPhi, @TenKhoanThu, @SoTien,
        @HanDong, @LyDoThu, @TrangThai
    );
END


-- Test Thêm ThuPhiDongGop
EXEC ThemThuPhi
    @MaThuPhi = 'TP12',
    @TenKhoanThu = N'Phí vệ sinh chung cư tháng 5',
    @SoTien = 50000.00,
    @HanDong = '2025-04-25',
    @LyDoThu = N'Thu phí vệ sinh định kỳ',
    @TrangThai = N'Đang Thu';



-- Proc Thêm GhiNhaThuPhi
CREATE PROCEDURE ThemGhiNhanThuPhi
    @MaGhiNhan VARCHAR(10),
    @MaHoKhau VARCHAR(10),
    @MaThuPhi VARCHAR(10),
    @TenNguoiDong NVARCHAR(100),
    @NgayDong DATE,
    @SoTienDong DECIMAL(10,2),
    @GhiChu NVARCHAR(255) = NULL
AS
BEGIN
    INSERT INTO GhiNhanThuPhi (
        MaGhiNhan, MaHoKhau, MaThuPhi,
        TenNguoiDong, NgayDong, SoTienDong, GhiChu
    )
    VALUES (
        @MaGhiNhan, @MaHoKhau, @MaThuPhi,
        @TenNguoiDong, @NgayDong, @SoTienDong, @GhiChu
    );
END

-- Proc Test GhiNhanThuPhi
EXEC ThemGhiNhanThuPhi
    @MaGhiNhan = 'GNTP111',
    @MaHoKhau = 'HK11',
    @MaThuPhi = 'TP1',
    @TenNguoiDong = N'Nguyễn Văn Abc',
    @NgayDong = '2025-04-10',
    @SoTienDong = 250000,
    @GhiChu = N'Đã nộp trực tiếp';


-- Proc Thêm DichBenh
CREATE PROCEDURE ThemDichBenh
    @MaDich VARCHAR(10),
    @TenDich NVARCHAR(100),
    @NgayBungPhat DATE,
    @MucDoNguyHiem NVARCHAR(50),
    @NoiBungPhat NVARCHAR(255),
    @MoTa NVARCHAR(255) = NULL,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    INSERT INTO DichBenh (
        MaDich, TenDich, NgayBungPhat,
        MucDoNguyHiem, NoiBungPhat, MoTa, TrangThai
    )
    VALUES (
        @MaDich, @TenDich, @NgayBungPhat,
        @MucDoNguyHiem, @NoiBungPhat, @MoTa, @TrangThai
    );
END

-- Test Proc Thêm DichBenh
EXEC ThemDichBenh
    @MaDich = 'DB4',
    @TenDich = N'Sốt xuất huyết',
    @NgayBungPhat = '2025-03-20',
    @MucDoNguyHiem = N'Cao',
    @NoiBungPhat = N'Phường 5, Quận 10',
    @MoTa = N'Bùng phát nhanh tại khu vực đông dân cư',
    @TrangThai = N'Đang Bùng Phát';

-- Proc Thêm BenhNhan
ALTER PROCEDURE ThemBenhNhan
    @MaBenhNhan VARCHAR(10),
    @MaDichBenh VARCHAR(10),
    @MaNhanKhau VARCHAR(10),
    @HoTen NVARCHAR(100),
    @CCCD VARCHAR(12),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @SoDienThoai VARCHAR(15),
    @DiaChi NVARCHAR(255),
    @TrangThai NVARCHAR(50),
    @MucDoNghiemTrong NVARCHAR(50),
    @TenBenh NVARCHAR(100),
    @MoTa NVARCHAR(500) = NULL
AS
BEGIN
    INSERT INTO BenhNhan (
        MaBenhNhan, MaDichBenh, MaNhanKhau, HoTen, CCCD,
        NgaySinh, GioiTinh, SoDienThoai, DiaChi, TrangThai,
        MucDoNghiemTrong, TenBenh, MoTa
    )
    VALUES (
        @MaBenhNhan, @MaDichBenh, @MaNhanKhau, @HoTen, @CCCD,
        @NgaySinh, @GioiTinh, @SoDienThoai, @DiaChi, @TrangThai,
        @MucDoNghiemTrong, @TenBenh, @MoTa
    );
END


-- Test Proc Thêm BenhNhan
EXEC ThemBenhNhan
    @MaBenhNhan = 'BN412',
    @MaDichBenh = 'DB4',
    @MaNhanKhau = 'NK12',
    @HoTen = N'Trần Thị K',
    @CCCD = '012345678912',
    @NgaySinh = '7/12/1982',
    @GioiTinh = N'Nữ',
    @SoDienThoai = '0901000002',
    @DiaChi = N'123 Đường ABC, Quận 5',
    @TrangThai = N'Đang Nhiễm Bệnh',
    @MucDoNghiemTrong = N'Nặng',
    @TenBenh = N'Sốt xuất huyết',
    @MoTa = N'Bệnh nhân có dấu hiệu sốt cao, đau đầu';

-- Proc Thêm User
ALTER PROCEDURE ThemUser
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(255),
    @VaiTro NVARCHAR(50)
AS
BEGIN

    INSERT INTO [User] (TenDangNhap, MatKhau, VaiTro)
    VALUES (@TenDangNhap, @MatKhau, @VaiTro);
END

-- Test Thêm User
EXEC ThemUser
    @TenDangNhap = 'admin01',
    @MatKhau = 'matkhau123', 
    @VaiTro = N'Quản trị viên';

CREATE PROCEDURE ThemLichSuHoatDong
    @TenDangNhap NVARCHAR(50),
    @ChucVu NVARCHAR(50),
    @HanhDong NVARCHAR(255),
    @NoiDung NVARCHAR(MAX),
    @ThoiGian DATETIME
AS
BEGIN
    INSERT INTO LichSuHoatDong (TenDangNhap, ChucVu, HanhDong, NoiDung, ThoiGian)
    VALUES (@TenDangNhap, @ChucVu, @HanhDong, @NoiDung, @ThoiGian);
END


-- PHẦN MỞ RỘNG CỦA ĐỀ TÀI 

-- PROC THÊM KHẢO SÁT 
CREATE PROCEDURE sp_ThemKhaoSat
    @TieuDe NVARCHAR(255),
    @NgayTao DATETIME
AS
BEGIN
    INSERT INTO KhaoSat (TieuDe, NgayTao, TrangThai)
    VALUES (@TieuDe, @NgayTao, N'Đang thử nghiệm');

    SELECT SCOPE_IDENTITY();
END

-- PROC THÊM CÂU HỎI
CREATE PROCEDURE sp_ThemCauHoi
    @MaKhaoSat INT,
    @NoiDung NVARCHAR(MAX),
    @Kieu NVARCHAR(20),
    @ThuTu INT
AS
BEGIN
    INSERT INTO CauHoi (MaKhaoSat, NoiDung, Kieu, ThuTu)
    VALUES (@MaKhaoSat, @NoiDung, @Kieu, @ThuTu);

    -- Trả về mã câu hỏi mới thêm
    SELECT SCOPE_IDENTITY() AS MaCauHoi;
END

-- LẤY CÂU HỎI THEO KHẢO SÁT

-- PROC THÊM ĐÁP ÁN
CREATE PROCEDURE sp_ThemDapAn
    @MaCauHoi INT,
    @NoiDungDapAn NVARCHAR(255)
AS
BEGIN
    INSERT INTO DapAn (MaCauHoi, NoiDungDapAn)
    VALUES (@MaCauHoi, @NoiDungDapAn);

    SELECT SCOPE_IDENTITY(); -- Trả về ID vừa thêm
END
-- Proc Sửa HoKhau
CREATE PROCEDURE SuaHoKhau
    @MaHoKhau VARCHAR(10),
    @TenChuHo NVARCHAR(50),
    @CCCDChuHo VARCHAR(12),
    @DiaChi NVARCHAR(255),
    @SoThanhVien INT,
    @NgayLap DATE,
    @TrangThai NVARCHAR(50),
    @MoTa NVARCHAR(255)
AS
BEGIN
    UPDATE HoKhau
    SET
        TenChuHo = @TenChuHo,
        CCCDChuHo = @CCCDChuHo,
        DiaChi = @DiaChi,
        SoThanhVien = @SoThanhVien,
        NgayLap = @NgayLap,
        TrangThai = @TrangThai,
        MoTa = @MoTa
    WHERE MaHoKhau = @MaHoKhau;
END

-- Test Proc Sửa HoKhau
EXEC SuaHoKhau
    @MaHoKhau = 'HK4',
    @TenChuHo = N'Phạm Thị D',
    @CCCDChuHo = '012345678904',
    @DiaChi = N'123 Đường Sửa Lại, Quận 5',
    @SoThanhVien = 5,
    @NgayLap = '2022-10-10',
    @TrangThai = N'Đã chuyển đi',
    @MoTa = NULL;


-- Proc Sửa NhanKhau
CREATE PROCEDURE SuaNhanKhau
    @MaNhanKhau VARCHAR(10),
    @MaHoKhau VARCHAR(10),
    @HoTen NVARCHAR(50),
    @CCCD VARCHAR(12),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @QuanHeVoiChuHo NVARCHAR(50),
    @TrangThai NVARCHAR(50),
    @GhiChu NVARCHAR(255),
    @Email NVARCHAR(50),
    @SoDienThoai VARCHAR(15)
AS
BEGIN

    UPDATE NhanKhau
    SET
        MaHoKhau = @MaHoKhau,
        HoTen = @HoTen,
        CCCD = @CCCD,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        QuanHeVoiChuHo = @QuanHeVoiChuHo,
        TrangThai = @TrangThai,
        GhiChu = @GhiChu,
        Email = @Email,
        SoDienThoai = @SoDienThoai
    WHERE MaNhanKhau = @MaNhanKhau;
END

-- Test Proc Sửa NhanKhau
EXEC SuaNhanKhau
    @MaNhanKhau = 'NK111',
    @MaHoKhau = 'HK11',
    @HoTen = N'Lê Thị Bwm Updated',
    @CCCD = '987652425098',
    @NgaySinh = '1992-08-15',
    @GioiTinh = N'Nữ',
    @QuanHeVoiChuHo = N'Vợ',
    @TrangThai = N'Tạm vắng',
    @GhiChu = N'Cập nhật ghi chú',
    @Email = N'lethi.bwm@example.com',
    @SoDienThoai = '0912345679';


-- Proc Sửa GiayTamVang
ALTER PROCEDURE SuaGiayTamVang
    @MaGiayTamVang VARCHAR(10),
    @MaNhanKhau VARCHAR(10),
    @HoTen NVARCHAR(100),
    @CCCD VARCHAR(12),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @SoDienThoai VARCHAR(15),
    @NoiDi NVARCHAR(255),
    @NgayDi DATE,
    @NgayVe DATE,
    @LyDo NVARCHAR(255),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE GiayTamVang
    SET
        MaNhanKhau = @MaNhanKhau,
        HoTen = @HoTen,
        CCCD = @CCCD,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        SoDienThoai = @SoDienThoai,
        NoiDi = @NoiDi,
        NgayDi = @NgayDi,
        NgayVe = @NgayVe,
        LyDo = @LyDo,
        TrangThai = @TrangThai
    WHERE MaGiayTamVang = @MaGiayTamVang;
END

-- Test Proc Sửa GiayTamVang
EXEC SuaGiayTamVang
    @MaGiayTamVang = 'TV1011',
    @MaNhanKhau = 'NK61',
    @HoTen = N'Bùi Thị J',
    @CCCD = '012345678910',
    @NgaySinh = '2/14/1992',
    @GioiTinh = N'Nữ',
    @SoDienThoai = '0910000001',
    @NoiDi = N'Mỹ',
    @NgayDi = '2025-04-01',
    @NgayVe = '2025-04-20',
    @LyDo = N'Thăm người thân',
    @TrangThai = N'Đã kết thúc';


-- Proc Sửa KhuTro
CREATE PROCEDURE SuaKhuTro
    @MaKhuTro VARCHAR(10),
    @TenKhuTro NVARCHAR(100),
    @DiaChi NVARCHAR(255),
    @HoTenChuTro NVARCHAR(100),
    @SoDienThoaiChuTro VARCHAR(15),
    @MaNhanKhau VARCHAR(10),
    @SoPhong INT,
    @SoPhongTrong INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE KhuTro
    SET
        TenKhuTro = @TenKhuTro,
        DiaChi = @DiaChi,
        HoTenChuTro = @HoTenChuTro,
        SoDienThoaiChuTro = @SoDienThoaiChuTro,
        MaNhanKhau = @MaNhanKhau,
        SoPhong = @SoPhong,
        SoPhongTrong = @SoPhongTrong,
        TrangThai = @TrangThai
    WHERE MaKhuTro = @MaKhuTro;
END

-- Test Proc Sửa KhuTro
EXEC SuaKhuTro
    @MaKhuTro = 'KT12',
    @TenKhuTro = N'Khu trọ Bình Minh',
    @DiaChi = N'123 Lê Lợi, TP Huế',
    @HoTenChuTro = N'Nguyễn Văn D',
    @SoDienThoaiChuTro = '012345678916',
    @MaNhanKhau = 'NK22',
    @SoPhong = 20,
    @SoPhongTrong = 0,
    @TrangThai = N'Đã hết phòng';


-- Proc Sửa NguoiThueTro
CREATE PROCEDURE SuaNguoiThueTro
    @MaNguoiThue VARCHAR(10),
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @CCCD VARCHAR(12),
    @SoDienThoai VARCHAR(15),
    @Email NVARCHAR(50),
    @QueQuan NVARCHAR(255),
    @NgayBatDauThue DATE,
    @MaKhuTro VARCHAR(10),
    @SoPhong VARCHAR(10)
AS
BEGIN
    UPDATE NguoiThueTro
    SET
        HoTen = @HoTen,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        CCCD = @CCCD,
        SoDienThoai = @SoDienThoai,
        Email = @Email,
        QueQuan = @QueQuan,
        NgayBatDauThue = @NgayBatDauThue,
        MaKhuTro = @MaKhuTro,
        SoPhong = @SoPhong
  WHERE MaNguoiThue = @MaNguoiThue;
END


-- Test Proc Sửa NguoiThueTro
EXEC SuaNguoiThueTro
    @MaNguoiThue = 'NT12',
    @HoTen = N'Trần Thị L',
    @NgaySinh = '7/22/1998',
    @GioiTinh = N'Nữ',
    @CCCD = '123456789999',
    @SoDienThoai = '0987654321',
    @Email = N'phamlan@example.com',
    @QueQuan = N'Hải Phòng',
    @NgayBatDauThue = '2024-05-01',
    @MaKhuTro = 'KT1',
    @SoPhong = '102A';


-- Proc Sửa GiayTamTru
CREATE PROCEDURE SuaGiayTamTru
    @MaGiayTamTru VARCHAR(10),
    @MaNguoiThue VARCHAR(10),
    @HoTen NVARCHAR(100),
    @GioiTinh NVARCHAR(10),
    @NgaySinh DATE,
    @CCCD VARCHAR(12),
    @QueQuan NVARCHAR(255),
    @SoDienThoai VARCHAR(15),
    @NoiTamTru NVARCHAR(255),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @LyDo NVARCHAR(255),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE GiayTamTru
    SET
        MaNguoiThue = @MaNguoiThue,
        HoTen = @HoTen,
        GioiTinh = @GioiTinh,
        NgaySinh = @NgaySinh,
        CCCD = @CCCD,
        QueQuan = @QueQuan,
        SoDienThoai = @SoDienThoai,
        NoiTamTru = @NoiTamTru,
        NgayBatDau = @NgayBatDau,
        NgayKetThuc = @NgayKetThuc,
        LyDo = @LyDo,
        TrangThai = @TrangThai
    WHERE MaGiayTamTru = @MaGiayTamTru;
END

-- Test Proc Sửa GiayTamTru
EXEC SuaGiayTamTru
    @MaGiayTamTru = 'GTT521',
    @MaNguoiThue = 'NTT52',
    @HoTen = N'Phạm Thị Thu',
    @GioiTinh = N'Nữ',
    @NgaySinh = '6/20/1998',
    @CCCD = '123456789123',
    @QueQuan = N'Hà Tĩnh',
    @SoDienThoai = '123456123',
    @NoiTamTru = N'Phòng 102, Khu trọ An Bình',
    @NgayBatDau = '2024-06-01',
    @NgayKetThuc = '2024-12-31',
    @LyDo = N'Làm việc tạm thời',
    @TrangThai = N'Đang có hiệu lực';


-- Proc Sửa PhanAnhKienNghi
ALTER PROCEDURE SuaPhanAnh
    @MaPhanAnh INT,
    @MaHoKhau VARCHAR(10),
    @HoTen NVARCHAR(100),
    @SoDienThoai VARCHAR(15),
    @NoiDung NVARCHAR(255),
    @NgayPhanAnh DATE,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE PhanAnh
    SET
        MaHoKhau = @MaHoKhau,
        HoTen = @HoTen,
        SoDienThoai = @SoDienThoai,
        NoiDung = @NoiDung,
        NgayPhanAnh = @NgayPhanAnh,
        TrangThai = @TrangThai
  WHERE MaPhanAnh = @MaPhanAnh;
END

-- Test Proc Sửa PhanAnhKienNghi
EXEC SuaPhanAnh
    @MaPhanAnh = 1,
    @MaHoKhau = 'HK1',
    @HoTen = N'Nguyễn Văn A',
    @SoDienThoai = '0901000001',
    @NoiDung = N'Phản ánh về vấn đề rác thải sinh hoạt không được thu gom đúng giờ',
    @NgayPhanAnh = '2025-04-10',
    @TrangThai = N'Đã xử lý';


-- Proc Sửa SinhHoatCuocHop
CREATE PROCEDURE SuaSinhHoat
    @MaSinhHoat VARCHAR(10),
    @TenSinhHoat NVARCHAR(100),
    @NgayToChuc DATE,
    @DiaDiem NVARCHAR(255),
    @NoiDung NVARCHAR(255),
    @MoTa NVARCHAR(255),
    @NguoiToChuc NVARCHAR(100),
    @SoDienThoaiNguoiToChuc VARCHAR(15),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE SinhHoat
    SET
        TenSinhHoat = @TenSinhHoat,
        NgayToChuc = @NgayToChuc,
        DiaDiem = @DiaDiem,
        NoiDung = @NoiDung,
        MoTa = @MoTa,
        NguoiToChuc = @NguoiToChuc,
        SoDienThoaiNguoiToChuc = @SoDienThoaiNguoiToChuc,
        TrangThai = @TrangThai
    WHERE MaSinhHoat = @MaSinhHoat;
END

-- Test Proc Sửa SinhHoatCuocHop
EXEC SuaSinhHoat
    @MaSinhHoat = 'SH1',
    @TenSinhHoat = N'Họp dân phố quý 1',
    @NgayToChuc = '2025-05-15',
    @DiaDiem = N'Nhà văn hóa tổ 3',
    @NoiDung = N'Thảo luận về các khoản thu chi và an ninh tổ dân phố',
    @MoTa = N'Cuộc họp định kỳ đầu năm',
    @NguoiToChuc = N'Lê Văn C',
    @SoDienThoaiNguoiToChuc = '0903000001',
    @TrangThai = N'Chưa diễn ra';


-- Proc Sửa GhiNhanThamGia
CREATE PROCEDURE SuaGhiNhanThamGia
    @MaGhiNhan VARCHAR(10),
    @MaHoKhau VARCHAR(10),
    @MaSinhHoat VARCHAR(10),
    @TenBuoiSinhHoat NVARCHAR(100),
    @TenNguoiThamGia NVARCHAR(100),
    @SoDienThoai VARCHAR(15),
    @GhiChu NVARCHAR(255)
AS
BEGIN
    UPDATE GhiNhanThamGia
    SET
        MaHoKhau = @MaHoKhau,
        MaSinhHoat = @MaSinhHoat,
        TenBuoiSinhHoat = @TenBuoiSinhHoat,
        TenNguoiThamGia = @TenNguoiThamGia,
        SoDienThoai = @SoDienThoai,
        GhiChu = @GhiChu
    WHERE MaGhiNhan = @MaGhiNhan;
END

-- Test Proc Sửa GhiNhanThamGia
EXEC SuaGhiNhanThamGia
    @MaGhiNhan = 'GN11',
    @MaHoKhau = 'HK1',
    @MaSinhHoat = 'SH1',
    @TenBuoiSinhHoat = N'Sinh hoạt cộng đồng quý 2',
    @TenNguoiThamGia = N'Nguyễn Văn A',
    @SoDienThoai = '012345678901',
    @GhiChu = N'Tham gia đầy đủ';

-- Proc Sửa ThuPhiDongGop
CREATE PROCEDURE SuaThuPhi
    @MaThuPhi VARCHAR(10),
    @TenKhoanThu NVARCHAR(100),
    @SoTien DECIMAL(10, 2),
    @HanDong DATE,
    @LyDoThu NVARCHAR(255),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE ThuPhi
    SET
        TenKhoanThu = @TenKhoanThu,
        SoTien = @SoTien,
        HanDong = @HanDong,
        LyDoThu = @LyDoThu,
        TrangThai = @TrangThai
    WHERE MaThuPhi = @MaThuPhi;
END

-- Test Proc Sửa ThuPhiDongGop
EXEC SuaThuPhi
    @MaThuPhi = 'TP1',
    @TenKhoanThu = N'Phí vệ sinh môi trường',
    @SoTien = 50000.00,
    @HanDong = '4/30/2025',
    @LyDoThu = N'Thu hàng tháng để duy trì vệ sinh khu phố',
    @TrangThai = N'Đã hết hạn đóng';


-- Proc Sửa GhiNhanDongGop
CREATE PROCEDURE SuaGhiNhanThuPhi
    @MaGhiNhan VARCHAR(10),
    @MaHoKhau VARCHAR(10),
    @MaThuPhi VARCHAR(10),
    @TenNguoiDong NVARCHAR(100),
    @NgayDong DATE,
    @SoTienDong DECIMAL(10,2),
    @GhiChu NVARCHAR(255)
AS
BEGIN
    UPDATE GhiNhanThuPhi
    SET 
        MaHoKhau = @MaHoKhau,
        MaThuPhi = @MaThuPhi,
        TenNguoiDong = @TenNguoiDong,
        NgayDong = @NgayDong,
        SoTienDong = @SoTienDong,
        GhiChu = @GhiChu
    WHERE MaGhiNhan = @MaGhiNhan
END


-- Proc Sửa DichBenh
ALTER PROCEDURE SuaDichBenh
    @MaDich VARCHAR(10),
    @TenDich NVARCHAR(100),
    @NgayBungPhat DATE,
    @MucDoNguyHiem NVARCHAR(50),
    @NoiBungPhat NVARCHAR(255),
    @MoTa NVARCHAR(255),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE DichBenh
    SET
        TenDich = @TenDich,
        NgayBungPhat = @NgayBungPhat,
        MucDoNguyHiem = @MucDoNguyHiem,
        NoiBungPhat = @NoiBungPhat,
        MoTa = @MoTa,
        TrangThai = @TrangThai
  WHERE MaDich = @MaDich;
END

-- Test Proc Sửa DichBenh
EXEC SuaDichBenh
    @MaDich = 'DB1',
    @TenDich = N'Cúm A H5N1',
    @NgayBungPhat = '2025-03-15',
    @MucDoNguyHiem = N'Cao',
    @NoiBungPhat = N'Phường 5, Quận 10',
    @MoTa = N'Bệnh lây lan nhanh qua đường hô hấp',
    @TrangThai = N'Đã kiểm soát';

-- Proc Sửa GhiNhanBenhNhan
CREATE PROCEDURE SuaBenhNhan
    @MaBenhNhan VARCHAR(10),
    @MaDichBenh VARCHAR(10),
    @MaNhanKhau VARCHAR(10),
    @HoTen NVARCHAR(100),
    @CCCD VARCHAR(12),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @SoDienThoai VARCHAR(15),
    @DiaChi NVARCHAR(255),
    @TrangThai NVARCHAR(50),
    @MucDoNghiemTrong NVARCHAR(50),
    @TenBenh NVARCHAR(100),
    @MoTa NVARCHAR(500)
AS
BEGIN
    UPDATE BenhNhan
    SET
        MaDichBenh = @MaDichBenh,
        MaNhanKhau = @MaNhanKhau,
        HoTen = @HoTen,
        CCCD = @CCCD,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        SoDienThoai = @SoDienThoai,
        DiaChi = @DiaChi,
        TrangThai = @TrangThai,
        MucDoNghiemTrong = @MucDoNghiemTrong,
        TenBenh = @TenBenh,
        MoTa = @MoTa
  WHERE MaBenhNhan = @MaBenhNhan;
END

-- Test Proc Sửa GhiNhanThamGia
EXEC SuaBenhNhan
    @MaBenhNhan = 'BN111',
    @MaDichBenh = 'DB1',
    @MaNhanKhau = 'NK11',
    @HoTen = N'Nguyễn Văn A',
    @CCCD = '012345678901',
    @NgaySinh = '5/10/1980',
    @GioiTinh = N'Nam',
    @SoDienThoai = '0901000001',
    @DiaChi = N'123 Đường ABC, Quận 1',
    @TrangThai = N'Đã Khỏi',
    @MucDoNghiemTrong = N'Trung Bình',
    @TenBenh = N'Cúm A H5N1',
    @MoTa = N'Bệnh nhẹ, đã được điều trị tại nhà';


-- Proc Sửa User
CREATE PROCEDURE SuaUser
    @MaUser INT,
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(255),
    @VaiTro NVARCHAR(50)
AS
BEGIN
    UPDATE [User]
    SET
        TenDangNhap = @TenDangNhap,
        MatKhau = @MatKhau,
        VaiTro = @VaiTro
    WHERE MaUser = @MaUser;
END

-- Test Proc Sửa User
EXEC SuaUser
    @MaUser = 6,
    @TenDangNhap = 'CD123',
    @MatKhau = 'matkhau_moi123',
    @VaiTro = N'Cư Dân';

-- PHẦN MỞ RỘNG CỦA ĐỀ TÀI
-- PROC SỬA KHẢO SÁT

CREATE PROCEDURE sp_SuaKhaoSat
    @MaKhaoSat INT,
    @TieuDe NVARCHAR(255),
    @NgayTao DATETIME
AS
BEGIN
    UPDATE KhaoSat
    SET TieuDe = @TieuDe,
        NgayTao = @NgayTao
    WHERE MaKhaoSat = @MaKhaoSat
END

--PROC UPDATE TRẠNG THÁI BÀI KHẢO SÁT 

-- PROC SỬA CÂU HỎI
CREATE PROCEDURE sp_SuaCauHoi
    @MaCauHoi INT,
    @NoiDung NVARCHAR(MAX),
    @Kieu NVARCHAR(50),
    @ThuTu INT
AS
BEGIN
    UPDATE CauHoi
    SET 
        NoiDung = @NoiDung,
        Kieu = @Kieu,
        ThuTu = @ThuTu
    WHERE MaCauHoi = @MaCauHoi
END

-- Sủa đáp án
CREATE PROCEDURE sp_SuaDapAn
    @MaDapAn INT,
    @NoiDungDapAn NVARCHAR(255)
AS
BEGIN
    UPDATE DapAn
    SET NoiDungDapAn = @NoiDungDapAn
    WHERE MaDapAn = @MaDapAn;
END

-- Xóa GiayTamTru
CREATE PROCEDURE XoaGiayTamTru
    @MaGiayTamTru NVARCHAR(50)
AS
BEGIN
    DELETE FROM GiayTamTru WHERE MaGiayTamTru = @MaGiayTamTru
END

-- Xóa GiayTamVang
CREATE PROCEDURE XoaGiayTamVang
    @MaGiayTamVang NVARCHAR(50)
AS
BEGIN
    DELETE FROM GiayTamVang WHERE MaGiayTamVang = @MaGiayTamVang
END

-- Xóa PhanAnhKienNghi
CREATE PROCEDURE XoaPhanAnhKienNghi
    @MaPhanAnh NVARCHAR(50)
AS
BEGIN
    DELETE FROM PhanAnh WHERE MaPhanAnh = @MaPhanAnh
END

-- Xóa GhiNhanThamGia
CREATE PROCEDURE XoaGhiNhanThamGia
    @MaGhiNhan NVARCHAR(50)
AS
BEGIN
    DELETE FROM GhiNhanThamGia WHERE MaGhiNhan = @MaGhiNhan
END


-- Xóa GhiNhanThuPhiDongGop
CREATE PROCEDURE XoaGhiNhanThuPhi
    @MaGhiNhan NVARCHAR(50)
AS
BEGIN
    DELETE FROM GhiNhanThuPhi WHERE MaGhiNhan = @MaGhiNhan
END


-- Xóa GhiNhanBenhNhan
CREATE PROCEDURE XoaBenhNhan
    @MaBenhNhan NVARCHAR(50)
AS
BEGIN
    DELETE FROM BenhNhan WHERE MaBenhNhan = @MaBenhNhan
END

-- Xóa NhanKhau 
ALTER PROCEDURE XoaNhanKhau
    @MaNhanKhau NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        -- Xóa giấy tạm trú liên quan đến người thuê trọ của khu trọ do nhân khẩu này quản lý
        DELETE FROM GiayTamTru
        WHERE MaNguoiThue IN (
            SELECT MaNguoiThue FROM NguoiThueTro
            WHERE MaKhuTro IN (
                SELECT MaKhuTro FROM KhuTro WHERE MaNhanKhau = @MaNhanKhau
            )
        )

        -- Xóa người thuê trọ thuộc khu trọ của nhân khẩu này
        DELETE FROM NguoiThueTro
        WHERE MaKhuTro IN (
            SELECT MaKhuTro FROM KhuTro WHERE MaNhanKhau = @MaNhanKhau
        )

        -- Xóa khu trọ thuộc nhân khẩu này
        DELETE FROM KhuTro WHERE MaNhanKhau = @MaNhanKhau

        -- Xóa các liên kết khác trực tiếp tới nhân khẩu (nếu có)
        DELETE FROM GiayTamVang WHERE MaNhanKhau = @MaNhanKhau
        DELETE FROM BenhNhan WHERE MaNhanKhau = @MaNhanKhau

        -- Cuối cùng: xóa nhân khẩu
        DELETE FROM NhanKhau WHERE MaNhanKhau = @MaNhanKhau

        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
        PRINT 'Lỗi: ' + ERROR_MESSAGE()
    END CATCH
END


-- Xóa HoKhau 
CREATE PROCEDURE XoaHoKhau
    @MaHoKhau NVARCHAR(50)
AS
BEGIN
    -- Xóa các bảng phụ thuộc
    DELETE FROM GhiNhanThamGia WHERE MaHoKhau = @MaHoKhau
    DELETE FROM GhiNhanThuPhi WHERE MaHoKhau = @MaHoKhau
    DELETE FROM PhanAnh WHERE MaHoKhau = @MaHoKhau

    -- Lấy danh sách nhân khẩu thuộc hộ khẩu
    DECLARE @MaNhanKhau NVARCHAR(50)

    DECLARE cur CURSOR FOR
        SELECT MaNhanKhau FROM NhanKhau WHERE MaHoKhau = @MaHoKhau

    OPEN cur
    FETCH NEXT FROM cur INTO @MaNhanKhau

    WHILE @@FETCH_STATUS = 0
    BEGIN
        EXEC XoaNhanKhau @MaNhanKhau
        FETCH NEXT FROM cur INTO @MaNhanKhau
    END

    CLOSE cur
    DEALLOCATE cur

    -- Cuối cùng xóa hộ khẩu
    DELETE FROM HoKhau WHERE MaHoKhau = @MaHoKhau
END

-- Xóa NguoiThueTro
CREATE PROCEDURE XoaNguoiThueTro
    @MaNguoiThue NVARCHAR(50)
AS
BEGIN
    DELETE FROM GiayTamTru WHERE MaNguoiThue = @MaNguoiThue
    DELETE FROM NguoiThueTro WHERE MaNguoiThue = @MaNguoiThue
END


-- Xóa KhuTro
CREATE PROCEDURE XoaKhuTro
    @MaKhuTro NVARCHAR(50)
AS
BEGIN
    -- Lấy danh sách người thuê thuộc khu trọ
    DECLARE @MaNguoiThue NVARCHAR(50)

    DECLARE cur CURSOR FOR
        SELECT MaNguoiThue FROM NguoiThueTro WHERE MaKhuTro = @MaKhuTro

    OPEN cur
    FETCH NEXT FROM cur INTO @MaNguoiThue

    WHILE @@FETCH_STATUS = 0
    BEGIN
        EXEC XoaNguoiThueTro @MaNguoiThue
        FETCH NEXT FROM cur INTO @MaNguoiThue
    END

    CLOSE cur
    DEALLOCATE cur

    DELETE FROM KhuTro WHERE MaKhuTro = @MaKhuTro
END

-- Xóa SinhHoatCuocHop
CREATE PROCEDURE XoaSinhHoatCuocHop
    @MaSinhHoat NVARCHAR(50)
AS
BEGIN
    DELETE FROM GhiNhanThamGia WHERE MaSinhHoat = @MaSinhHoat
    DELETE FROM SinhHoat WHERE MaSinhHoat = @MaSinhHoat
END

-- Xóa ThuPhiDongGop
CREATE PROCEDURE XoaThuPhiDongGop
    @MaThuPhi NVARCHAR(50)
AS
BEGIN
    DELETE FROM GhiNhanThuPhi WHERE MaThuPhi = @MaThuPhi
    DELETE FROM ThuPhi WHERE MaThuPhi = @MaThuPhi
END

-- Xóa DichBenh
CREATE PROCEDURE XoaDichBenh
    @MaDich NVARCHAR(50)
AS
BEGIN
    DELETE FROM BenhNhan WHERE MaDichBenh = @MaDich
    DELETE FROM DichBenh WHERE MaDich = @MaDich
END

-- Xóa User
CREATE PROCEDURE XoaUser
    @MaUser NVARCHAR(50)
AS
BEGIN
    DELETE FROM [User] WHERE MaUser = @MaUser
END


-- Trigger 1: Giảm số phòng trống khi thêm người thuê
CREATE TRIGGER trg_GiamSoPhongTrong_WhenInsert_NguoiThueTro
ON NguoiThueTro
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE KhuTro
    SET SoPhongTrong = SoPhongTrong - 1,
        TrangThai = CASE WHEN SoPhongTrong - 1 = 0 THEN N'Đã hết phòng' ELSE N'Còn phòng' END
    FROM KhuTro
    INNER JOIN inserted i ON KhuTro.MaKhuTro = i.MaKhuTro
END
GO

-- Trigger 2: Tăng số phòng trống khi xóa người thuê
CREATE TRIGGER trg_TangSoPhongTrong_WhenDelete_NguoiThueTro
ON NguoiThueTro
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE KhuTro
    SET SoPhongTrong = SoPhongTrong + 1,
        TrangThai = N'Còn phòng'
    FROM KhuTro
    INNER JOIN deleted d ON KhuTro.MaKhuTro = d.MaKhuTro
END
GO

-- Trigger 3: Cập nhật số phòng trống khi sửa số phòng trong khu trọ
CREATE TRIGGER trg_CapNhatSoPhongTrong_WhenUpdate_SoPhong
ON KhuTro
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(SoPhong)
    BEGIN
        -- Sử dụng alias để phân biệt các trường 'SoPhongTrong' từ bảng KhuTro, INSERTED và DELETED
        UPDATE KhuTro
        SET KhuTro.SoPhongTrong = KhuTro.SoPhongTrong + (i.SoPhong - d.SoPhong),
            KhuTro.TrangThai = CASE 
                                WHEN KhuTro.SoPhongTrong + (i.SoPhong - d.SoPhong) = 0 
                                THEN N'Đã hết phòng' 
                                ELSE N'Còn phòng' 
                              END
        FROM KhuTro
        INNER JOIN inserted i ON KhuTro.MaKhuTro = i.MaKhuTro
        INNER JOIN deleted d ON KhuTro.MaKhuTro = d.MaKhuTro
    END
END
GO

-- TRIGGER Cập Nhập Trạng Thái Giấy Tạm Vắng
CREATE TRIGGER CapNhatTrangThaiTamVang
ON GiayTamVang
AFTER INSERT, UPDATE
AS
BEGIN
    -- Cập nhật trạng thái nếu số ngày < 5
    UPDATE GiayTamVang
    SET TrangThai = N'Sắp hết hạn'
    WHERE SoNgay < 5
      AND MaGiayTamVang IN (SELECT MaGiayTamVang FROM inserted);
    
END;


-- TRIGGER Cập Nhập Trạng Thái Giấy Tạm Trú
CREATE TRIGGER CapNhatTrangThaiTamTru
ON GiayTamTru
AFTER INSERT, UPDATE
AS
BEGIN
    -- Cập nhật trạng thái nếu số ngày < 5
    UPDATE GiayTamTru
    SET TrangThai = N'Sắp hết hạn'
    WHERE SoNgay < 5
      AND MaGiayTamTru IN (SELECT MaGiayTamTru FROM inserted);
END;

-- TRIGGER Cập Nhập Trạng Thái Nhân Khẩu Khi Có Giấy Tạm Vắng
CREATE TRIGGER CapNhatTrangThaiNhanKhau_TamVang
ON GiayTamVang
AFTER INSERT, UPDATE
AS
BEGIN
    -- Cập nhật trạng thái NhanKhau thành 'Đang tạm vắng' nếu có giấy tạm vắng SoNgay > 10
    UPDATE NhanKhau
    SET TrangThai = N'Đang tạm vắng'
    WHERE MaNhanKhau IN (
        SELECT gv.MaNhanKhau
        FROM GiayTamVang gv
        JOIN inserted i ON gv.MaGiayTamVang = i.MaGiayTamVang
        WHERE gv.SoNgay > 10
    );
END;

-- TRIGGER Cập Nhập Trạng Thái Của SinhHoatCuocHop
CREATE TRIGGER CapNhatTrangThaiSinhHoat
ON GhiNhanThamGia
AFTER INSERT
AS
BEGIN
    -- Cập nhật trạng thái của các buổi sinh hoạt được ghi nhận là đã tham gia
    UPDATE SinhHoat
    SET TrangThai = N'Đã kết thúc'
    WHERE MaSinhHoat IN (
        SELECT DISTINCT MaSinhHoat
        FROM inserted
    );
END;


-- TRIGGER Cập Nhập Mức Độ Nguy Hiểm Của Bệnh 
CREATE TRIGGER CapNhatMucDoNguyHiem
ON BenhNhan
AFTER INSERT
AS
BEGIN
    -- Cập nhật MucDoNguyHiem trong bảng DichBenh nếu có hơn 5 người nhiễm cùng một tên bệnh
    UPDATE DichBenh
    SET MucDoNguyHiem = N'Cao'
    WHERE TenDich IN (
        SELECT TenBenh
        FROM BenhNhan
        GROUP BY TenBenh
        HAVING COUNT(*) > 5
    )
    AND MucDoNguyHiem != N'Cao'; -- Tránh cập nhật lại nếu đã là Cao
END;

-- TRIGGER TĂNG VÀ GIẢM SỐ THÀNH VIÊN KHI THÊM HOẶC XÓA NHÂN KHẨU 
CREATE TRIGGER TangSoThanhVien
ON NhanKhau
AFTER INSERT
AS
BEGIN
    UPDATE HoKhau
    SET SoThanhVien = SoThanhVien + 1
    FROM HoKhau H
    INNER JOIN inserted I ON H.MaHoKhau = I.MaHoKhau;
END;

CREATE TRIGGER GiamSoThanhVien
ON NhanKhau
AFTER DELETE
AS
BEGIN
    UPDATE HoKhau
    SET SoThanhVien = SoThanhVien - 1
    FROM HoKhau H
    INNER JOIN deleted D ON H.MaHoKhau = D.MaHoKhau;
END;


-- TÌM KIẾM THEO MÃ VÀ CCCD CHỦ HỘ TRONG BẢNG HỘ KHẨU 
CREATE PROCEDURE TimKiemHoKhau
    @TuKhoa NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM HoKhau
    WHERE MaHoKhau = @TuKhoa OR CCCDChuHo = @TuKhoa;
END


-- TÌM KIẾM THEO MÃ NHÂN KHẨU VÀ CCCD
CREATE PROCEDURE TimKiemNhanKhau
    @TuKhoa1 NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM NhanKhau
    WHERE MaNhanKhau= @TuKhoa1 OR CCCD = @TuKhoa1;
END

-- Tìm Kiếm Giấy Tạm Vắng
CREATE PROCEDURE TimKiemGiayTamVang
    @MaGiayTamVang VARCHAR(10)
AS
BEGIN
    SELECT * FROM GiayTamVang WHERE MaGiayTamVang = @MaGiayTamVang
END
GO

-- Tìm Kiếm Giấy Tạm Trú
CREATE PROCEDURE TimKiemGiayTamTru
    @MaGiayTamTru VARCHAR(10)
AS
BEGIN
    SELECT * FROM GiayTamTru WHERE MaGiayTamTru = @MaGiayTamTru
END
GO

-- Tìm Kiếm Khu Trọ
CREATE PROCEDURE TimKiemKhuTro
    @MaKhuTro VARCHAR(10)
AS
BEGIN
    SELECT * FROM KhuTro WHERE MaKhuTro = @MaKhuTro
END
GO

-- Người Thuê Trọ
CREATE PROCEDURE TimKiemNguoiThueTro
    @MaNguoiThue VARCHAR(10)
AS
BEGIN
    SELECT * FROM NguoiThueTro WHERE MaNguoiThue = @MaNguoiThue
END
GO

-- Tìm Kiếm Phản Ánh
ALTER PROCEDURE TimKiemPhanAnh
    @TuKhoa3 NVARCHAR(50)
AS
BEGIN
    SELECT * FROM PhanAnh
    WHERE MaHoKhau LIKE '%' + @TuKhoa3 + '%'
END

-- Tìm Kiếm Sinh Hoạt
CREATE PROCEDURE TimKiemSinhHoat
    @MaSinhHoat VARCHAR(10)
AS
BEGIN
    SELECT * FROM SinhHoat WHERE MaSinhHoat = @MaSinhHoat
END
GO

-- Tìm Kiếm Ghi Nhận Tham Gia
CREATE PROCEDURE TimKiemGhiNhanThamGia
    @MaGhiNhan VARCHAR(10)
AS
BEGIN
    SELECT * FROM GhiNhanThamGia WHERE MaGhiNhan = @MaGhiNhan
END
GO

-- Tìm Kiếm Thu Phí
CREATE PROCEDURE TimKiemThuPhi
    @MaThuPhi VARCHAR(10)
AS
BEGIN
    SELECT * FROM ThuPhi WHERE MaThuPhi = @MaThuPhi
END
GO

-- Tìm Kiếm Ghi Nhận Thu Phí
CREATE PROCEDURE TimKiemGhiNhanThuPhi
    @MaGhiNhan VARCHAR(10)
AS
BEGIN
    SELECT * FROM GhiNhanThuPhi WHERE MaGhiNhan = @MaGhiNhan
END
GO

-- Tìm Kiếm Dịch Bệnh
CREATE PROCEDURE TimKiemDichBenh
    @MaDich VARCHAR(10)
AS
BEGIN
    SELECT * FROM DichBenh WHERE MaDich = @MaDich
END
GO

-- Tìm Kiếm Bệnh Nhân
CREATE PROCEDURE TimKiemBenhNhan
    @MaBenhNhan VARCHAR(10)
AS
BEGIN
    SELECT * FROM BenhNhan WHERE MaBenhNhan = @MaBenhNhan
END
GO

-- Tìm kiếm User
CREATE PROCEDURE TimKiemUserTheoTenDangNhap
    @TenDangNhap VARCHAR(50)
AS
BEGIN
    SELECT * FROM [User] WHERE TenDangNhap = @TenDangNhap
END
GO

-- Thống kê tổng số hộ khẩu theo năm
CREATE PROCEDURE ThongKeHoKhauTheoNam
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        YEAR(NgayLap) AS Nam,
        COUNT(*) AS TongSoHoKhau
    FROM HoKhau
    GROUP BY YEAR(NgayLap)
    ORDER BY Nam;
END

-- Thống kê số hộ khẩu theo trạng thái
CREATE PROCEDURE ThongKeHoKhauTheoTrangThai
AS
BEGIN
    SELECT TrangThai, COUNT(*) AS TongSoHoKhau
    FROM HoKhau
    GROUP BY TrangThai
END

-- Thống kê số lượng nhân khẩu theo độ tuổi
CREATE PROCEDURE ThongKeNhanKhauTheoDoTuoi
AS
BEGIN
    SELECT 
        CASE 
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) <= 18 THEN '0-18'
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 19 AND 35 THEN '19-35'
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 36 AND 60 THEN '36-60'
            ELSE 'Trên 60'
        END AS NhomTuoi,
        COUNT(*) AS SoLuong
    FROM NhanKhau
    GROUP BY 
        CASE 
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) <= 18 THEN '0-18'
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 19 AND 35 THEN '19-35'
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 36 AND 60 THEN '36-60'
            ELSE 'Trên 60'
        END
END

-- Thống kê nhân khẩu theo giới tính
CREATE PROCEDURE ThongKeNhanKhauTheoGioiTinh
AS
BEGIN
    SELECT 
        GioiTinh,
        COUNT(*) AS SoLuong
    FROM 
        NhanKhau
    GROUP BY 
        GioiTinh
END

-- Thống kê giấy tạm trú theo giới tính 
CREATE PROCEDURE ThongKeGiayTamTruTheoGioiTinh
AS
BEGIN
    SELECT 
        GioiTinh,
        COUNT(*) AS SoLuong
    FROM GiayTamTru
    GROUP BY GioiTinh
END

-- Thống kê giấy tạm trú theo số ngày 
CREATE PROCEDURE ThongKeGiayTamTruTheoSoNgay
AS
BEGIN
    SELECT 
        CASE 
            WHEN SoNgay <= 7 THEN N'Ngắn hạn'
            WHEN SoNgay BETWEEN 8 AND 30 THEN N'Trung hạn'
            ELSE N'Dài hạn'
        END AS NhomSoNgay,
        COUNT(*) AS SoLuong
    FROM GiayTamTru
    GROUP BY 
        CASE 
            WHEN SoNgay <= 7 THEN N'Ngắn hạn'
            WHEN SoNgay BETWEEN 8 AND 30 THEN N'Trung hạn'
            ELSE N'Dài hạn'
        END
END

-- Thống kê số lượng bệnh nhân theo loại dịch
CREATE PROCEDURE ThongKeBenhNhanTheoLoaiBenh
AS
BEGIN
    SELECT 
        d.TenDich AS TenBenh, 
        COUNT(b.MaBenhNhan) AS SoLuongBenhNhan
    FROM BenhNhan b
    JOIN DichBenh d ON b.MaDichBenh = d.MaDich
    GROUP BY d.TenDich
END

exec ThongKeBenhNhanTheoLoaiBenh


-- Thống kê bệnh nhân theo tình trạng 
CREATE PROCEDURE ThongKeBenhNhanTheoTinhTrang
AS
BEGIN
    SELECT 
        b.TrangThai, 
        COUNT(b.MaBenhNhan) AS SoLuongBenhNhan
    FROM BenhNhan b
    GROUP BY b.TrangThai
END
exec ThongKeBenhNhanTheoTinhTrang

-- Thống kê số người thuê trọ theo khu trọ 
CREATE PROCEDURE ThongKeNguoiThueTheoKhuTro
AS
BEGIN
    SELECT 
        MaKhuTro,
        COUNT(*) AS SoLuongNguoiThue
    FROM NguoiThueTro
    GROUP BY MaKhuTro
END

-- Thống kê người thuê trọ theo giới tính 
CREATE PROCEDURE ThongKeNguoiThueTheoGioiTinh
AS
BEGIN
    SELECT 
        GioiTinh,
        COUNT(*) AS SoLuong
    FROM NguoiThueTro
    GROUP BY GioiTinh
END

-- Thống kê người thuê trọ theo độ tuổi 
ALTER PROCEDURE ThongKeNguoiThueTheoDoTuoi
AS
BEGIN
    SELECT 
        CASE 
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) < 18 THEN N'Dưới 18'
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 18 AND 30 THEN '18 - 30'
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 31 AND 50 THEN '31 - 50'
            ELSE 'Trên 50'
        END AS DoTuoi,
        COUNT(*) AS SoLuong
    FROM NguoiThueTro
    GROUP BY 
        CASE 
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) < 18 THEN N'Dưới 18'
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 18 AND 30 THEN '18 - 30'
            WHEN DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 31 AND 50 THEN '31 - 50'
            ELSE 'Trên 50'
        END
END


















































