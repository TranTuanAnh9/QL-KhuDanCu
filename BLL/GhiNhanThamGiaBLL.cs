using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class GhiNhanThamGiaBLL
    {
        private GhiNhanThamGiaDAL ghinanthamgiaDAL = new GhiNhanThamGiaDAL();

        public List<GhiNhanThamGiaDTO> LayDanhSachGhiNhan()
        {
            return ghinanthamgiaDAL.LayDanhSachGhiNhan();
        }
        public string ThemGhiNhan(GhiNhanThamGiaDTO ghiNhan)
        {
            // 0. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(ghiNhan.MaGhiNhan) ||
                string.IsNullOrWhiteSpace(ghiNhan.MaSinhHoat) ||
                string.IsNullOrWhiteSpace(ghiNhan.TenNguoiThamGia) ||
                string.IsNullOrWhiteSpace(ghiNhan.SoDienThoai) ||
                string.IsNullOrWhiteSpace(ghiNhan.TenBuoiSinhHoat) ||
                string.IsNullOrWhiteSpace(ghiNhan.MaHoKhau))
            {
                return "Vui lòng nhập đầy đủ thông tin!";
            }

            if (ghinanthamgiaDAL.KiemTraTrungMaGhiNhan(ghiNhan.MaGhiNhan))
            {
                return "Mã ghi nhận đã tồn tại!";
            }
            if (!ghinanthamgiaDAL.KiemTraTonTaiMaSinhHoat(ghiNhan.MaSinhHoat))
            {
                return "Mã sinh hoạt không tồn tại!";
            }
            if (!ghinanthamgiaDAL.KiemTraTonTaiMaHoKhau(ghiNhan.MaHoKhau))
            {
                return "Mã hộ khẩu không tồn tại!";
            }
            if (!Regex.IsMatch(ghiNhan.SoDienThoai, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            if (!Regex.IsMatch(ghiNhan.TenNguoiThamGia, @"^[\p{L}\s]+$"))
            {
                return "Tên người tham gia chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            if (!ghinanthamgiaDAL.KiemTraTenBuoiSinhHoatHopLe(ghiNhan.MaSinhHoat, ghiNhan.TenBuoiSinhHoat))
            {
                return "Tên buổi sinh hoạt không khớp với mã sinh hoạt!";
            }
            if (ghiNhan.MaGhiNhan != ghiNhan.MaGhiNhan.ToUpper())
                return "Mã ghi nhận phải viết hoa toàn bộ.";
            if (ghiNhan.MaSinhHoat != ghiNhan.MaSinhHoat.ToUpper())
                return "Mã sinh hoạt phải viết hoa toàn bộ.";
            if (ghiNhan.MaHoKhau != ghiNhan.MaHoKhau.ToUpper())
                return "Mã hộ khẩu phải viết hoa toàn bộ.";
            if (!(ghiNhan.MaGhiNhan.StartsWith("GNTG")))
            {
                return "Mã ghi nhận tham gia phải bắt đầu bằng tiền tố GNTG ";
            }
            bool ketQua = ghinanthamgiaDAL.ThemGhiNhan(ghiNhan);
            return ketQua ? "Thêm Hộ Đã Tham Gia Thành Công !." : "Thêm Hộ Đã Tham Gia Thất Bại !.";
        }
        public string SuaGhiNhan(GhiNhanThamGiaDTO ghiNhan)
        {
            // Kiểm tra dữ liệu đầu vào tương tự như khi thêm
            if (string.IsNullOrWhiteSpace(ghiNhan.MaGhiNhan) ||
                string.IsNullOrWhiteSpace(ghiNhan.MaSinhHoat) ||
                string.IsNullOrWhiteSpace(ghiNhan.TenNguoiThamGia) ||
                string.IsNullOrWhiteSpace(ghiNhan.SoDienThoai) ||
                string.IsNullOrWhiteSpace(ghiNhan.TenBuoiSinhHoat) ||
                string.IsNullOrWhiteSpace(ghiNhan.MaHoKhau))
            {
                return "Vui lòng nhập đầy đủ thông tin!";
            }

            if (!ghinanthamgiaDAL.KiemTraTonTaiMaSinhHoat(ghiNhan.MaSinhHoat))
            {
                return "Mã sinh hoạt không tồn tại!";
            }

            if (!ghinanthamgiaDAL.KiemTraTonTaiMaHoKhau(ghiNhan.MaHoKhau))
            {
                return "Mã hộ khẩu không tồn tại!";
            }
            if (ghiNhan.MaSinhHoat != ghiNhan.MaSinhHoat.ToUpper())
                return "Mã sinh hoạt phải viết hoa toàn bộ.";
            if (ghiNhan.MaHoKhau != ghiNhan.MaHoKhau.ToUpper())
                return "Mã hộ khẩu phải viết hoa toàn bộ.";

            if (!Regex.IsMatch(ghiNhan.SoDienThoai, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            if (!Regex.IsMatch(ghiNhan.TenNguoiThamGia, @"^[\p{L}\s]+$"))
            {
                return "Tên người tham gia chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            if (!ghinanthamgiaDAL.KiemTraTenBuoiSinhHoatHopLe(ghiNhan.MaSinhHoat, ghiNhan.TenBuoiSinhHoat))
            {
                return "Tên buổi sinh hoạt không khớp với mã sinh hoạt!";
            }
            bool ketQua = ghinanthamgiaDAL.SuaGhiNhan(ghiNhan);
            return ketQua ? "Cập nhật thông tin thành công!" : "Cập nhật thất bại!";
        }
        public string XoaGhiNhaThamGia(string maGhiNhan)
        {
            bool result = ghinanthamgiaDAL.XoaGhiNhanThamGia(maGhiNhan);
            return result ? "Xóa hộ đã tham gia thành công!" : "Xóa thất bại.";
        }
        public List<GhiNhanThamGiaDTO> TimKiemHoDaThamGia(string MaGhiNhan)
        {
            return ghinanthamgiaDAL.TimKiemHoDaThamGia(MaGhiNhan);
        }
    }
}
