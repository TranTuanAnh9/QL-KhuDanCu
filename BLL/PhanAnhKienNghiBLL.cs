using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Text.RegularExpressions;

namespace BLL
{
    public class PhanAnhKienNghiBLL
    {
        private PhanAnhKienNghiDAL phananhkiennghidal = new PhanAnhKienNghiDAL();

        public List<PhanAnhKienNghiDTO> LayDanhSachPhanAnh()
        {
            return phananhkiennghidal.LayDanhSachPhanAnh();
        }
        public bool KiemTraMaHoKhauTonTai(string maHoKhau)
        {
            return phananhkiennghidal.KiemTraMaHoKhauTonTai(maHoKhau);
        }
        public string ThemPhanAnh(PhanAnhKienNghiDTO phanAnh)
        {
            if (string.IsNullOrWhiteSpace(phanAnh.MaHoKhau) ||
                string.IsNullOrWhiteSpace(phanAnh.HoTen) ||
                string.IsNullOrWhiteSpace(phanAnh.SoDienThoai) ||
                string.IsNullOrWhiteSpace(phanAnh.NoiDung))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            if (!KiemTraMaHoKhauTonTai(phanAnh.MaHoKhau))
            {
                return "Mã hộ khẩu không tồn tại.";
            }
            if(string.IsNullOrWhiteSpace(phanAnh.TrangThai))
            {
                phanAnh.TrangThai = "Đang xử lý";
            }    
            if (phanAnh.NgayPhanAnh > DateTime.Now)
            {
                return "Ngày phản ánh không được lớn hơn ngày hiện tại.";
            }
            if (!Regex.IsMatch(phanAnh.SoDienThoai, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            if (phanAnh.MaHoKhau != phanAnh.MaHoKhau.ToUpper())
                return "Mã hộ khẩu phải viết hoa toàn bộ.";
            bool ketQua = phananhkiennghidal.ThemPhanAnh(phanAnh);
            return ketQua ? "Thêm phản ánh thành công !." : "Thêm thất bại.";
        }
        public string SuaPhanAnh(PhanAnhKienNghiDTO phanAnh)
        {
            if (string.IsNullOrWhiteSpace(phanAnh.MaHoKhau) ||
                string.IsNullOrWhiteSpace(phanAnh.HoTen) ||
                string.IsNullOrWhiteSpace(phanAnh.SoDienThoai) ||
                string.IsNullOrWhiteSpace(phanAnh.NoiDung))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            if (!KiemTraMaHoKhauTonTai(phanAnh.MaHoKhau))
            {
                return "Mã hộ khẩu không tồn tại.";
            }
            if (string.IsNullOrWhiteSpace(phanAnh.TrangThai))
            {
                phanAnh.TrangThai = "Đang xử lý";
            }
            if (phanAnh.NgayPhanAnh > DateTime.Now)
            {
                return "Ngày phản ánh không được lớn hơn ngày hiện tại.";
            }
            if (!Regex.IsMatch(phanAnh.SoDienThoai, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            if (phanAnh.MaHoKhau != phanAnh.MaHoKhau.ToUpper())
                return "Mã hộ khẩu phải viết hoa toàn bộ.";
            bool ketQua = phananhkiennghidal.SuaPhanAnh(phanAnh);
            return ketQua ? "Sửa phản ánh thành công!" : "Sửa thất bại.";
        }
        public string XoaPhanAnh(int TuKhoa3)
        {
            bool ketQua = phananhkiennghidal.XoaPhanAnh(TuKhoa3);
            return ketQua ? "Xóa phản ánh thành công!" : "Xóa thất bại.";
        }
        public List<PhanAnhKienNghiDTO> TimKiemDonPhanAnh(string MaPhanAnh)
        {
            return phananhkiennghidal.TimKiemDonPhanAnh(MaPhanAnh);
        }
    }
}
