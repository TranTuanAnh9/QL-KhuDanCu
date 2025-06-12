using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class GhiNhanBenhNhanBLL
    {
        private GhiNhanBenhNhanDAL ghinhanbenhnhanDAL = new GhiNhanBenhNhanDAL();

        public List<GhiNhanBenhNhanDTO> LayDanhSachBenhNhan()
        {
            return ghinhanbenhnhanDAL.LayDanhSachBenhNhan();
        }
        public string ThemBenhNhan(GhiNhanBenhNhanDTO bn)
        {
            // 0. Kiểm tra các trường không được để trống
            if (string.IsNullOrWhiteSpace(bn.MaBenhNhan) ||
                string.IsNullOrWhiteSpace(bn.MaDichBenh) ||
                string.IsNullOrWhiteSpace(bn.MaNhanKhau) ||
                string.IsNullOrWhiteSpace(bn.HoTen) ||
                string.IsNullOrWhiteSpace(bn.CCCD) ||
                string.IsNullOrWhiteSpace(bn.SoDienThoai) ||
                string.IsNullOrWhiteSpace(bn.DiaChi) ||
                string.IsNullOrWhiteSpace(bn.TrangThai) ||
                string.IsNullOrWhiteSpace(bn.MucDoNghiemTrong) ||
                string.IsNullOrWhiteSpace(bn.TenBenh))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            // 1. Kiểm tra trùng mã bệnh nhân
            if (ghinhanbenhnhanDAL.KiemTraTrungMaBenhNhan(bn.MaBenhNhan))
            {
                return "Mã bệnh nhân đã tồn tại.";
            }

            // 2. Kiểm tra mã dịch bệnh và mã nhân khẩu có tồn tại
            if (!ghinhanbenhnhanDAL.KiemTraTonTaiMaDichBenh(bn.MaDichBenh))
            {
                return "Mã dịch bệnh không tồn tại.";
            }

            if (!ghinhanbenhnhanDAL.KiemTraTonTaiMaNhanKhau(bn.MaNhanKhau))
            {
                return "Mã nhân khẩu không tồn tại.";
            }

            // 3. Kiểm tra đồng bộ thông tin nhân khẩu
            var (hoTen, cccd, ngaySinh, gioiTinh, sdt) = ghinhanbenhnhanDAL.LayThongTinNhanKhau(bn.MaNhanKhau);
            if (bn.HoTen != hoTen || bn.CCCD != cccd || bn.NgaySinh != ngaySinh ||
                bn.GioiTinh != gioiTinh || bn.SoDienThoai != sdt)
            {
                return "Thông tin nhân khẩu không khớp với mã nhân khẩu.";
            }
            string tenBenhDB = ghinhanbenhnhanDAL.LayThongTinDichBenh(bn.MaDichBenh);
            if (bn.TenBenh != tenBenhDB)
            {
                return "Tên bệnh không khớp với mã dịch bệnh.";
            }
            if (bn.MaDichBenh != bn.MaDichBenh.ToUpper())
                return "Mã dịch bệnh phải viết hoa toàn bộ.";
            if (bn.MaNhanKhau != bn.MaNhanKhau.ToUpper())
                return "Mã nhân khẩu phải viết hoa toàn bộ.";
            if (bn.MaBenhNhan != bn.MaBenhNhan.ToUpper())
                return "Mã bệnh nhân phải viết hoa toàn bộ.";
            if (!(bn.MaBenhNhan.StartsWith("BN")))
            {
                return "Mã bệnh nhân phải bắt đầu bằng tiền tố BN ";
            }
            if (!bn.DiaChi.ToLower().Contains("xã phù đổng"))
            {
                return "Địa chỉ phải chứa từ 'xã Phù Đổng'.";
            }
            // 5. Gửi xuống DAL thực hiện thêm
            bool ketQua = ghinhanbenhnhanDAL.ThemBenhNhan(bn);
            return ketQua ? "Thêm bệnh nhân thành công !." : "Thêm thất bại.";
        }
        public string CapNhatBenhNhan(GhiNhanBenhNhanDTO bn)
        {
            // 1. Kiểm tra rỗng
            if (
                string.IsNullOrWhiteSpace(bn.MaDichBenh) ||
                string.IsNullOrWhiteSpace(bn.MaNhanKhau) ||
                string.IsNullOrWhiteSpace(bn.HoTen) ||
                string.IsNullOrWhiteSpace(bn.CCCD) ||
                string.IsNullOrWhiteSpace(bn.SoDienThoai) ||
                string.IsNullOrWhiteSpace(bn.DiaChi) ||
                string.IsNullOrWhiteSpace(bn.TrangThai) ||
                string.IsNullOrWhiteSpace(bn.MucDoNghiemTrong) ||
                string.IsNullOrWhiteSpace(bn.TenBenh))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            // 3. Mã nhân khẩu, mã dịch bệnh phải tồn tại
            if (!ghinhanbenhnhanDAL.KiemTraTonTaiMaNhanKhau(bn.MaNhanKhau))
            {
                return "Mã nhân khẩu không tồn tại.";
            }

            if (!ghinhanbenhnhanDAL.KiemTraTonTaiMaDichBenh(bn.MaDichBenh))
            {
                return "Mã dịch bệnh không tồn tại.";
            }

            // 6. Kiểm tra thông tin nhân khẩu phải khớp
            var (hoTen, cccd, ngaySinh, gioiTinh, sdt) = ghinhanbenhnhanDAL.LayThongTinNhanKhau(bn.MaNhanKhau);
            if (bn.HoTen != hoTen || bn.CCCD != cccd || bn.NgaySinh != ngaySinh || bn.GioiTinh != gioiTinh || bn.SoDienThoai != sdt)
            {
                return "Thông tin nhân khẩu không khớp với mã nhân khẩu.";
            }

            string tenBenhDB = ghinhanbenhnhanDAL.LayThongTinDichBenh(bn.MaDichBenh);
            if (bn.TenBenh != tenBenhDB)
            {
                return "Tên bệnh không khớp với mã dịch bệnh.";
            }
            if (!bn.DiaChi.ToLower().Contains("xã phù đổng"))
            {
                return "Địa chỉ phải chứa từ 'xã Phù Đổng'.";
            }
            if (bn.MaNhanKhau != bn.MaNhanKhau.ToUpper())
                return "Mã nhân khẩu phải viết hoa toàn bộ.";
            if (bn.MaBenhNhan != bn.MaBenhNhan.ToUpper())
                return "Mã bệnh nhân phải viết hoa toàn bộ.";
            // 7. Thực hiện cập nhật
            bool kq = ghinhanbenhnhanDAL.CapNhatBenhNhan(bn);
            return kq ? "Cập nhật bệnh nhân thành công." : "Cập nhật thất bại.";
        }
        public string XoaBenhNhan(string maGhiNhan)
        {
            bool result = ghinhanbenhnhanDAL.XoaBenhNhan(maGhiNhan);
            return result ? "Xóa bệnh nhân thành công!" : "Xóa thất bại.";
        }
        public List<GhiNhanBenhNhanDTO> TimKiemBenhNhan(string MaDich)
        {
            return ghinhanbenhnhanDAL.TimKiemBenhNhan(MaDich);
        }
        public List<ThongKeBenhNhanTheoLoaiBenhDTO> ThongKeBenhNhanTheoLoaiBenh()
        {
            return ghinhanbenhnhanDAL.ThongKeBenhNhanTheoLoaiBenh();
        }
        public List<ThongKeBenhNhanTheoTinhTrangDTO> ThongKeBenhNhanTheoTinhTrang()
        {
            return ghinhanbenhnhanDAL.ThongKeBenhNhanTheoTinhTrang();
        }
    }
}
