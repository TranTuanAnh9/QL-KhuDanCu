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
    public class HoKhauBLL
    {
        private HoKhauDAL hoKhauDAL = new HoKhauDAL();
        public List<HoKhauDTO> LayDanhSachHoKhau()
        {
            return hoKhauDAL.LayDanhSachHoKhau();
        }
        public string ThemHoKhau(HoKhauDTO hk)
        {
            // Kiểm tra rỗng cho các trường string
            if (string.IsNullOrWhiteSpace(hk.MaHoKhau) ||
                string.IsNullOrWhiteSpace(hk.TenChuHo) ||
                string.IsNullOrWhiteSpace(hk.CCCDChuHo) ||
                string.IsNullOrWhiteSpace(hk.DiaChi))
            {
                return "Vui lòng điền đầy đủ thông tin.";
            }
            if (hoKhauDAL.KiemTraTrungMaHoKhau(hk.MaHoKhau))
                return "Đã có hộ khẩu với mã này.";

            if (hoKhauDAL.KiemTraTrungCCCD(hk.CCCDChuHo))
                return "Đã có CCCD này.";
            // Kiểm tra số thành viên phải là một số từ 1 đến 7
            if (hk.SoThanhVien != 0)
            {
                return "Số thành viên bắt buộc phải là 0 khi mới tạo hộ khẩu và không được chứa kí tự chữ hoặc kí tự đặc biệt.";
            }
            if (!Regex.IsMatch(hk.CCCDChuHo, @"^\d{12,20}$"))
            {
                return "cccd phải ít nhất là 12 số và nhiều nhất là 20 số và chỉ là số.";
            }
            if (hk.NgayLap > DateTime.Now)
            {
                return "Ngày lập không được lớn hơn ngày hiện tại.";
            }
            if (!Regex.IsMatch(hk.TenChuHo, @"^[\p{L}\s]+$"))
            {
                return "Họ tên chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            // Kiểm tra địa chỉ phải chứa từ 'xã Phù Đổng'
            if (!hk.DiaChi.ToLower().Contains("xã phù đổng"))
            {
                return "Địa chỉ phải chứa từ 'xã Phù Đổng'.";
            }
            if (hk.MaHoKhau != hk.MaHoKhau.ToUpper())
                return "Mã hộ khẩu phải viết hoa toàn bộ.";
            if (!(hk.MaHoKhau.StartsWith("HK")))
            {
                return "Mã hộ khẩu phải bắt đầu bằng tiền tố HK ";
            }
            if (string.IsNullOrWhiteSpace(hk.TrangThai))
            {
                hk.TrangThai = "Đang sinh sống";
            }
            bool ketQua = hoKhauDAL.ThemHoKhau(hk);
            return ketQua ? "Thêm Hộ Khẩu Thành Công !" : "Thêm Hộ Khẩu Thất Bại !";
        }
        public string SuaHoKhau(HoKhauDTO hk)
        {
            if (string.IsNullOrWhiteSpace(hk.MaHoKhau) ||
                string.IsNullOrWhiteSpace(hk.TenChuHo) ||
                string.IsNullOrWhiteSpace(hk.CCCDChuHo) ||
                string.IsNullOrWhiteSpace(hk.DiaChi))
            {
                return "Vui lòng điền đầy đủ thông tin.";
            }
            if (!Regex.IsMatch(hk.CCCDChuHo, @"^\d{12,20}$"))
            {
                return "cccd phải ít nhất là 12 số và nhiều nhất là 20 số và chỉ là số.";
            }
            if (hk.NgayLap > DateTime.Now)
            {
                return "Ngày lập không được lớn hơn ngày hiện tại.";
            }
            if (!Regex.IsMatch(hk.TenChuHo, @"^[\p{L}\s]+$"))
            {
                return "Họ tên chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            // Kiểm tra địa chỉ phải chứa từ 'xã Phù Đổng'
            if (!hk.DiaChi.ToLower().Contains("xã phù đổng"))
            {
                return "Địa chỉ phải chứa từ 'xã Phù Đổng'.";
            }
            if (string.IsNullOrWhiteSpace(hk.TrangThai))
            {
                hk.TrangThai = "Đang sinh sống";
            }
            bool ketQua = hoKhauDAL.SuaHoKhau(hk);
            return ketQua ? "Sửa Hộ Khẩu Thành Công !" : "Sửa Hộ Khẩu Thất Bại !";
        }
        public string XoaHoKhau(string maHoKhau)
        {
            bool ketQua = hoKhauDAL.XoaHoKhau(maHoKhau);
            return ketQua ? "Xóa Hộ Khẩu Thành Công !" : "Xóa Hộ Khẩu Thất Bại !";
        }
        // Thêm phương thức tìm kiếm hộ khẩu
        public List<HoKhauDTO> TimKiemHoKhau(string tuKhoa)
        {     
            return hoKhauDAL.TimKiemHoKhau(tuKhoa);
        }
        public bool CapNhatAnhHoKhau(string maHoKhau, byte[] anh)
        {
            return hoKhauDAL.CapNhatAnhHoKhau(maHoKhau, anh);
        }
        public byte[] LayAnhHoKhau(string maHoKhau)
        {
            return hoKhauDAL.LayAnhHoKhau(maHoKhau);
        }
        public List<ThongKeHoKhauTheoNamDTO> ThongKeHoKhauTheoNam()
        {
            return hoKhauDAL.ThongKeHoKhauTheoNam();
        }
        public List<ThongKeHoKhauTheoTrangThaiDTO> ThongKeHoKhauTheoTrangThai()
        {
            return hoKhauDAL.ThongKeHoKhauTheoTrangThai();
        }
        // BUS_HoKhau.cs
        public int DemTongHoKhau()
        {
            return hoKhauDAL.DemTongHoKhau();
        }
    }
}
