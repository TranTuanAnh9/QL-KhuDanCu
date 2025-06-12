using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KhuTroBLL
    {
        private KhuTroDAL khutrodal = new KhuTroDAL();

        public List<KhuTroDTO> LayDanhSachKhuTro()
        {
            return khutrodal.LayDanhSachKhuTro();
        }
        public string ThemKhuTro(KhuTroDTO kt)
        {
            // 0. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(kt.MaKhuTro) ||
                string.IsNullOrWhiteSpace(kt.TenKhuTro) ||
                string.IsNullOrWhiteSpace(kt.MaNhanKhau) ||
                string.IsNullOrWhiteSpace(kt.HoTenChuTro) ||
                string.IsNullOrWhiteSpace(kt.SoDienThoaiChuTro) ||
                string.IsNullOrWhiteSpace(kt.DiaChi) ||
                string.IsNullOrWhiteSpace(kt.TrangThai))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            List<KhuTroDTO> ds = khutrodal.LayDanhSachKhuTro();
            if (ds.Any(x => x.MaKhuTro == kt.MaKhuTro)) return "Mã khu trọ đã tồn tại.";
            if (ds.Any(x => x.TenKhuTro == kt.TenKhuTro)) return "Tên khu trọ đã tồn tại.";

            var nhanKhauList = khutrodal.LayDanhSachNhanKhau();
            var nk = nhanKhauList.FirstOrDefault(x => x.MaNhanKhau == kt.MaNhanKhau);
            if (nk == null) return "Không tìm thấy mã nhân khẩu.";

            if (nk.HoTen != kt.HoTenChuTro || nk.SoDienThoai != kt.SoDienThoaiChuTro)
                return "Thông tin chủ trọ không trùng khớp với nhân khẩu.";
            if (!kt.DiaChi.ToLower().Contains("xã phù đổng"))
            {
                return "Địa chỉ phải chứa từ 'xã Phù Đổng'.";
            }
            if (kt.SoPhong <= 0) return "Số phòng phải lớn hơn 0.";
            if (kt.SoPhongTrong < 0) return "Số phòng trống phải >= 0.";
            if (kt.MaKhuTro != kt.MaKhuTro.ToUpper())
                return "Mã khu trọ phải viết hoa toàn bộ.";
            if (kt.MaNhanKhau != kt.MaNhanKhau.ToUpper())
                return "Mã nhân khẩu phải viết hoa toàn bộ.";
            if (!(kt.MaKhuTro.StartsWith("KT")))
            {
                return "Mã khu trọ phải bắt đầu bằng tiền tố KT ";
            }
            return khutrodal.ThemKhuTro(kt) ? "Thêm Khu Trọ Thành Công !." : "Thêm Khu Trọ Thất Bại !.";
        }
        public string SuaKhuTro(KhuTroDTO kt)
        {
            // Kiểm tra rỗng
            if (
                string.IsNullOrWhiteSpace(kt.TenKhuTro) ||
                string.IsNullOrWhiteSpace(kt.DiaChi) ||
                string.IsNullOrWhiteSpace(kt.HoTenChuTro) ||
                string.IsNullOrWhiteSpace(kt.SoDienThoaiChuTro) ||
                string.IsNullOrWhiteSpace(kt.MaNhanKhau) ||
                string.IsNullOrWhiteSpace(kt.TrangThai))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            var nhanKhauList = khutrodal.LayDanhSachNhanKhau();
            var nk = nhanKhauList.FirstOrDefault(x => x.MaNhanKhau == kt.MaNhanKhau);
            if (nk == null) return "Không có mã nhân khẩu này.";
            if (nk.HoTen != kt.HoTenChuTro || nk.SoDienThoai != kt.SoDienThoaiChuTro)
                return "Thông tin chủ trọ không trùng khớp với nhân khẩu.";
            if (!kt.DiaChi.ToLower().Contains("xã phù đổng"))
            {
                return "Địa chỉ phải chứa từ 'xã Phù Đổng'.";
            }
            if (kt.SoPhong <= 0) return "Số phòng phải lớn hơn 0.";
            if (kt.SoPhongTrong < 0) return "Số phòng trống phải >= 0.";
            if (kt.MaNhanKhau != kt.MaNhanKhau.ToUpper())
                return "Mã nhân khẩu phải viết hoa toàn bộ.";
            // ⚠ Kiểm tra số phòng không được nhỏ hơn số phòng trống hiện tại trong DB
            var khuTroHienTai = khutrodal.LayKhuTroTheoMa(kt.MaKhuTro); // <-- bạn cần có hàm này trong DAL
            if (khuTroHienTai == null) return "Không tìm thấy khu trọ để sửa.";

            if (kt.SoPhong < khuTroHienTai.SoPhongTrong)
            {
                return $"Không thể cập nhật: Số phòng ({kt.SoPhong}) không được nhỏ hơn số phòng trống hiện tại ({khuTroHienTai.SoPhongTrong}).";
            }
            return khutrodal.SuaKhuTro(kt) ? "Sửa khu trọ thành công!" : "Sửa khu trọ thất bại!";
        }
        public string XoaKhuTro(string maKhuTro)
        {
            return khutrodal.XoaKhuTro(maKhuTro) ? "Xóa khu trọ thành công!" : "Xóa khu trọ thất bại!";
        }
        public List<KhuTroDTO> TimKiemKhutro(string MaKhuTro)
        {
            return khutrodal.TimKiemKhuTro(MaKhuTro);
        }
        public bool CapNhatAnhKhuTro2(string maKhuTro, byte[] anh)
        {
            return khutrodal.CapNhatAnhKhuTro2(maKhuTro, anh);
        }
        public byte[] LayAnhKhuTro2(string maKhuTro)
        {
            return khutrodal.LayAnhKhuTro2(maKhuTro);
        }
        public int DemTongkhutro()
        {
            return khutrodal.DemTongkhutro();
        }
    }
}
