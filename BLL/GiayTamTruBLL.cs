using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class GiayTamTruBLL
    {
        private GiayTamTruDAL giaytamtruDAL = new GiayTamTruDAL();

        public List<GiayTamTruDTO> LayDanhSachGiayTamTru()
        {
            return giaytamtruDAL.LayDanhSachGiayTamTru();
        }
        public string ThemGiayTamTru(GiayTamTruDTO gtt)
        {
            // 0. Kiểm tra rỗng các trường bắt buộc
            if (string.IsNullOrWhiteSpace(gtt.MaGiayTamTru) ||
                string.IsNullOrWhiteSpace(gtt.MaNguoiThue) ||
                string.IsNullOrWhiteSpace(gtt.HoTen) ||
                string.IsNullOrWhiteSpace(gtt.CCCD) ||
                string.IsNullOrWhiteSpace(gtt.QueQuan) ||
                string.IsNullOrWhiteSpace(gtt.NoiTamTru) ||
                string.IsNullOrWhiteSpace(gtt.LyDo) ||
                string.IsNullOrWhiteSpace(gtt.TrangThai) ||
                string.IsNullOrWhiteSpace(gtt.SoDienThoai))

            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            // 1. Kiểm tra trùng mã giấy tạm trú
            if (giaytamtruDAL.KiemTraTrungMaGiayTamTru(gtt.MaGiayTamTru))
                return "Mã giấy tạm trú đã tồn tại.";

            // 2. Kiểm tra thông tin người thuê
            var nguoiThue = giaytamtruDAL.LayNguoiThueTheoMa(gtt.MaNguoiThue);
            if (nguoiThue == null)
                return "Mã người thuê không tồn tại.";

            // 3. Kiểm tra thông tin nhập có khớp với người thuê không
            if (nguoiThue.HoTen != gtt.HoTen ||
                nguoiThue.GioiTinh != gtt.GioiTinh ||
                nguoiThue.NgaySinh.Date != gtt.NgaySinh.Date ||
                nguoiThue.CCCD != gtt.CCCD ||
                nguoiThue.QueQuan != gtt.QueQuan ||
                nguoiThue.SoDienThoai != gtt.SoDienThoai)
            {
                return "Thông tin không khớp với người thuê.";
            }
            // 5. Kiểm tra số ngày tạm trú > 0
            int soNgay = (gtt.NgayKetThuc - gtt.NgayBatDau).Days;
            if (soNgay <= 0)
                return "Số ngày phải lớn hơn 0.";
            gtt.SoNgay = soNgay;
            if (gtt.MaGiayTamTru != gtt.MaGiayTamTru.ToUpper())
                return "Mã giấy tạm trú phải viết hoa toàn bộ.";
            if (gtt.MaNguoiThue != gtt.MaNguoiThue.ToUpper())
                return "Mã người thuê phải viết hoa toàn bộ.";
            if (!(gtt.MaGiayTamTru.StartsWith("GTT")))
            {
                return "Mã giấy tạm trú phải bắt đầu bằng tiền tố GTT ";
            }
            // 6. Gọi DAL để thêm
            bool result = giaytamtruDAL.ThemGiayTamTru(gtt);
            return result ? "Thêm Giấy Tạm Trú thành công!." : "Thêm giấy tạm trú thất bại !.";
        }
        public string SuaGiayTamTru(GiayTamTruDTO gtt)
        {
            // 0. Kiểm tra rỗng các trường bắt buộc
            if (
                string.IsNullOrWhiteSpace(gtt.MaNguoiThue) ||
                string.IsNullOrWhiteSpace(gtt.HoTen) ||
                string.IsNullOrWhiteSpace(gtt.CCCD) ||
                string.IsNullOrWhiteSpace(gtt.QueQuan) ||
                string.IsNullOrWhiteSpace(gtt.NoiTamTru) ||
                string.IsNullOrWhiteSpace(gtt.LyDo) ||
                string.IsNullOrWhiteSpace(gtt.TrangThai) ||
                string.IsNullOrWhiteSpace(gtt.SoDienThoai))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            // 2. Kiểm tra thông tin người thuê
            var nguoiThue = giaytamtruDAL.LayNguoiThueTheoMa(gtt.MaNguoiThue);
            if (nguoiThue == null)
                return "Mã người thuê không tồn tại.";

            // 3. Kiểm tra thông tin có khớp với người thuê không
            if (nguoiThue.HoTen != gtt.HoTen ||
                nguoiThue.GioiTinh != gtt.GioiTinh ||
                nguoiThue.NgaySinh.Date != gtt.NgaySinh.Date ||
                nguoiThue.CCCD != gtt.CCCD ||
                nguoiThue.QueQuan != gtt.QueQuan ||
                nguoiThue.SoDienThoai != gtt.SoDienThoai)
            {
                return "Thông tin không khớp với người thuê.";
            }

            // 4. Kiểm tra số ngày tạm trú > 0
            int soNgay = (gtt.NgayKetThuc - gtt.NgayBatDau).Days;
            if (soNgay <= 0)
                return "Số ngày phải lớn hơn 0.";

            gtt.SoNgay = soNgay;

            // 5. Gọi DAL để sửa
            bool result = giaytamtruDAL.SuaGiayTamTru(gtt);
            return result ? "Sửa Giấy Tạm Trú thành công!" : "Sửa giấy tạm trú thất bại!";
        }
        public string XoaGiayTamTru(string maGiayTamTru)
        {
            bool ketQua = giaytamtruDAL.XoaGiayTamTru(maGiayTamTru);
            return ketQua ? "Xóa giấy tạm trú thành công!" : "Xóa thất bại.";
        }
        public List<GiayTamTruDTO> TimKiemGiayTamTru(string MaGiayTamTru)
        {
            return giaytamtruDAL.TimKiemGiayTamTru(MaGiayTamTru);
        }
        public bool CapNhatAnhNguoixincapTamtru(string maGiayTamTru, byte[] anh)
        {
            return giaytamtruDAL.CapNhatAnhNguoixincapTamtru(maGiayTamTru, anh);
        }
        public byte[] LayAnhNguoiXinCapTamTru(string maGiayTamTru)
        {
            return giaytamtruDAL.LayAnhNguoiXinCapTamTru(maGiayTamTru);
        }
        public bool CapNhapAnhKhuTroTamTru(string maGiayTamTru, byte[] anh2)
        {
            return giaytamtruDAL.CapNhapAnhKhuTroTamTru(maGiayTamTru, anh2);
        }
        public byte[] LayAnhKhuTroTamTru(string maGiayTamTru)
        {
            return giaytamtruDAL.LayAnhKhuTroTamTru(maGiayTamTru);
        }
        public List<ThongKeGiayTamTruTheoGioiTinhDTO> ThongKeGiayTamTruTheoGioiTinh()
        {
            return giaytamtruDAL.ThongKeGiayTamTruTheoGioiTinh();
        }
        public List<ThongKeGiayTamTruTheoSoNgayDTO> ThongKeGiayTamTruTheoSoNgay()
        {
            return giaytamtruDAL.ThongKeGiayTamTruTheoSoNgay();
        }
    }
}