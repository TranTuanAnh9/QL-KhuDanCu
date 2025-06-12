using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class GiayTamVangBLL
    {
        private GiayTamVangDAl giaytamvangdal = new GiayTamVangDAl();

        public List<GiayTamVangDTO> LayDanhSachGiayTamVang()
        {
            return giaytamvangdal.LayDanhSachGiayTamVang();
        }
        public string ThemGiayTamVang(GiayTamVangDTO gtv)
        {
            // 0. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(gtv.MaGiayTamVang) ||
                string.IsNullOrWhiteSpace(gtv.MaNhanKhau) ||
                string.IsNullOrWhiteSpace(gtv.HoTen) ||
                string.IsNullOrWhiteSpace(gtv.CCCD) ||
                string.IsNullOrWhiteSpace(gtv.SoDienThoai) ||
                string.IsNullOrWhiteSpace(gtv.LyDo) ||
                string.IsNullOrWhiteSpace(gtv.NoiDi) ||
                string.IsNullOrWhiteSpace(gtv.TrangThai))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            // 1. Kiểm tra trùng mã giấy
            if (giaytamvangdal.KiemTraTrungMaGiay(gtv.MaGiayTamVang))
                return "Mã giấy tạm vắng đã tồn tại.";

            // 2. Kiểm tra nhân khẩu có tồn tại
            var nhanKhau = giaytamvangdal.LayNhanKhauTheoMa(gtv.MaNhanKhau);
            if (nhanKhau == null)
                return "Mã nhân khẩu không tồn tại.";

            // 3. Kiểm tra thông tin có khớp không
            if (nhanKhau.HoTen != gtv.HoTen ||
                nhanKhau.GioiTinh != gtv.GioiTinh ||
                nhanKhau.NgaySinh.Date != gtv.NgaySinh.Date ||
                nhanKhau.CCCD != gtv.CCCD ||
                nhanKhau.SoDienThoai != gtv.SoDienThoai)
            {
                return "Thông tin không khớp với nhân khẩu.";
            }
            // 5. Kiểm tra số ngày tạm vắng > 0
            int soNgay = (gtv.NgayVe - gtv.NgayDi).Days;
            if (soNgay <= 0)
                return "Số ngày phải lớn hơn 0.";
            gtv.SoNgay = soNgay;
            if (gtv.MaGiayTamVang != gtv.MaGiayTamVang.ToUpper())
                return "Mã giấy tạm vắng phải viết hoa toàn bộ.";
            if (gtv.MaNhanKhau != gtv.MaNhanKhau.ToUpper())
                return "Mã giấy nhân khẩu phải viết hoa toàn bộ.";
            if (!(gtv.MaGiayTamVang.StartsWith("GTV")))
            {
                return "Mã giấy tạm vắng phải bắt đầu bằng tiền tố GTV ";
            }
            // 6. Gọi DAL để thêm
            bool result = giaytamvangdal.ThemGiayTamVang(gtv);
            return result ? "Thêm Giấy Tạm Vắng Thành Công !." : "Thêm giấy tạm vắng thất bại !.";
        }
        public string SuaGiayTamVang(GiayTamVangDTO gtv)
        {
            // Kiểm tra rỗng
            if (
                string.IsNullOrWhiteSpace(gtv.MaNhanKhau) ||
                string.IsNullOrWhiteSpace(gtv.HoTen) ||
                string.IsNullOrWhiteSpace(gtv.CCCD) ||
                string.IsNullOrWhiteSpace(gtv.SoDienThoai) ||
                string.IsNullOrWhiteSpace(gtv.LyDo) ||
                string.IsNullOrWhiteSpace(gtv.NoiDi) ||
                string.IsNullOrWhiteSpace(gtv.TrangThai))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            // Kiểm tra nhân khẩu có tồn tại
            var nhanKhau = giaytamvangdal.LayNhanKhauTheoMa(gtv.MaNhanKhau);
            if (nhanKhau == null)
                return "Mã nhân khẩu không tồn tại.";

            // Kiểm tra thông tin có khớp không
            if (nhanKhau.HoTen != gtv.HoTen ||
                nhanKhau.GioiTinh != gtv.GioiTinh ||
                nhanKhau.NgaySinh.Date != gtv.NgaySinh.Date ||
                nhanKhau.CCCD != gtv.CCCD ||
                nhanKhau.SoDienThoai != gtv.SoDienThoai)
            {
                return "Thông tin không khớp với nhân khẩu.";
            }
            // Số ngày hợp lệ
            int soNgay = (gtv.NgayVe - gtv.NgayDi).Days;
            if (soNgay <= 0)
                return "Số ngày phải lớn hơn 0.";
            gtv.SoNgay = soNgay;
            if (gtv.MaNhanKhau != gtv.MaNhanKhau.ToUpper())
                return "Mã giấy nhân khẩu phải viết hoa toàn bộ.";
            bool result = giaytamvangdal.SuaGiayTamVang(gtv);
            return result ? "Sửa giấy tạm vắng thành công!" : "Sửa giấy tạm vắng thất bại!";
        }
        public string XoaGiayTamVang(string maGiayTamVang)
        {
            bool result = giaytamvangdal.XoaGiayTamVang(maGiayTamVang);
            return result ? "Xóa giấy tạm vắng thành công!" : "Xóa thất bại.";
        }
        public List<GiayTamVangDTO> TimKiemGiayTamVang(string MaGiayTamVang)
        {
            return giaytamvangdal.TimKiemGiayTamVang(MaGiayTamVang);
        }
        public bool CapNhatAnhNhanKhau1(string maGiayTamVang, byte[] anh)
        {
            return giaytamvangdal.CapNhatAnhNhanKhau1(maGiayTamVang, anh);
        }
        public byte[] LayAnhNhanKhau1(string maGiayTamVang)
        {
            return giaytamvangdal.LayAnhNhanKhau1(maGiayTamVang);
        }
        public bool CapNhatAnhNhaNhanKhau1(string maGiayTamVang, byte[] anh2)
        {
            return giaytamvangdal.CapNhatAnhNhaNhanKhau1(maGiayTamVang, anh2);
        }
        public byte[] LayAnhNhaNhanKhau1(string maGiayTamVang)
        {
            return giaytamvangdal.LayAnhNhaNhanKhau1(maGiayTamVang);
        }
    }
}
