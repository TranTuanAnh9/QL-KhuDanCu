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
    public class SinhHoatCuocHopBLL
    {
        private SinhHoatCuocHopDAL sinhhoatcuochopDAL = new SinhHoatCuocHopDAL();

        public List<SinhHoatCuocHopDTO> LayDanhSachSinhHoat()
        {
            return sinhhoatcuochopDAL.LayDanhSachSinhHoat();
        }
        public string ThemSinhHoat(SinhHoatCuocHopDTO sh)
        {
            // 0. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(sh.MaSinhHoat) ||
                string.IsNullOrWhiteSpace(sh.TenSinhHoat) ||
                string.IsNullOrWhiteSpace(sh.DiaDiem) ||
                 string.IsNullOrWhiteSpace(sh.TrangThai) ||
                  string.IsNullOrWhiteSpace(sh.NguoiToChuc) ||
                   string.IsNullOrWhiteSpace(sh.SoDienThoaiNguoiToChuc) ||
                string.IsNullOrWhiteSpace(sh.NoiDung))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            if (sinhhoatcuochopDAL.KiemTraMaSinhHoatTonTai(sh.MaSinhHoat))
                return "Mã sinh hoạt đã tồn tại!";
            if (!Regex.IsMatch(sh.TenSinhHoat, @"^[\p{L}\d\s]+$"))
            {
                return "Tên buổi sinh hoạt chỉ được chứa chữ cái, số và khoảng trắng, không được chứa ký tự đặc biệt.";
            }
            if (!Regex.IsMatch(sh.NguoiToChuc, @"^[\p{L}\s]+$"))
            {
                return "Tên ngươi tổ chức hoạt chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            if (!Regex.IsMatch(sh.SoDienThoaiNguoiToChuc, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            if (sh.MaSinhHoat != sh.MaSinhHoat.ToUpper())
                return "Mã sinh hoạt cuộc họp phải viết hoa toàn bộ.";
            if (!(sh.MaSinhHoat.StartsWith("SH")))
            {
                return "Mã sinh hoạt phải bắt đầu bằng tiền tố SH ";
            }
            bool thanhCong = sinhhoatcuochopDAL.ThemSinhHoat(sh);
            return thanhCong ? "Thêm Buổi Sinh Hoạt , Cuộc Họp Thành Công !." : "Thêm Buổi Sinh Hoạt , Cuộc Họp Thất Bại !.";
        }
        public string SuaSinhHoat(SinhHoatCuocHopDTO sh)
        {
            // 0. Kiểm tra rỗng
            if (
                string.IsNullOrWhiteSpace(sh.TenSinhHoat) ||
                string.IsNullOrWhiteSpace(sh.DiaDiem) ||
                string.IsNullOrWhiteSpace(sh.TrangThai) ||
                string.IsNullOrWhiteSpace(sh.NguoiToChuc) ||
                string.IsNullOrWhiteSpace(sh.SoDienThoaiNguoiToChuc) ||
                string.IsNullOrWhiteSpace(sh.NoiDung))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            if (!Regex.IsMatch(sh.TenSinhHoat, @"^[\p{L}\d\s]+$"))
            {
                return "Tên buổi sinh hoạt chỉ được chứa chữ cái, số và khoảng trắng, không được chứa ký tự đặc biệt.";
            }
            if (!Regex.IsMatch(sh.NguoiToChuc, @"^[\p{L}\s]+$"))
            {
                return "Tên ngươi tổ chức hoạt chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            if (!Regex.IsMatch(sh.SoDienThoaiNguoiToChuc, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            bool thanhCong = sinhhoatcuochopDAL.SuaSinhHoat(sh);
            return thanhCong ? "Sửa buổi sinh hoạt thành công!" : "Sửa buổi sinh hoạt thất bại!";
        }
        public string XoaSinhHoatCuocHop(string maSinhHoatCuocHop)
        {
            bool result = sinhhoatcuochopDAL.XoaSinhHoatCuocHop(maSinhHoatCuocHop);
            return result ? "Xóa cuộc họp thành công!" : "Xóa thất bại.";
        }
        public List<SinhHoatCuocHopDTO> TimKiemSinhHoat(string MaSinhHoat)
        {
            return sinhhoatcuochopDAL.TimKiemSinhHoat(MaSinhHoat);
        }
    }
}
