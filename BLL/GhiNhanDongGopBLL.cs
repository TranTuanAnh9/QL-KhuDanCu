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
    public class GhiNhanDongGopBLL
    {
        private GhiNhanDongGopDAL ghinhandonggopDAL = new GhiNhanDongGopDAL();

        public List<GhiNhanDongGopDTO> LayDanhSachGhiNhan()
        {
            return ghinhandonggopDAL.LayDanhSachGhiNhan();
        }
        public string ThemGhiNhan(GhiNhanDongGopDTO ghiNhan)
        {
            // 0. Kiểm tra dữ liệu rỗng
            if (string.IsNullOrWhiteSpace(ghiNhan.MaGhiNhan) ||
                string.IsNullOrWhiteSpace(ghiNhan.MaHoKhau) ||
                string.IsNullOrWhiteSpace(ghiNhan.TenNguoiDong) ||
                string.IsNullOrWhiteSpace(ghiNhan.MaThuPhi))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            if (!Regex.IsMatch(ghiNhan.SoTienDong.ToString(), @"^\d+(\.\d{1,2})?$") || ghiNhan.SoTienDong <= 0)
            {
                return "Số tiền phải là số hợp lệ, lớn hơn 0 và tối đa 2 chữ số thập phân.";
            }
            if (!Regex.IsMatch(ghiNhan.TenNguoiDong, @"^[\p{L}\s]+$"))
            {
                return "Tên khoản thu chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            // 1. Kiểm tra trùng mã ghi nhận
            if (ghinhandonggopDAL.KiemTraTrungMaGhiNhan(ghiNhan.MaGhiNhan))
                return "Mã ghi nhận đã tồn tại.";

            // 2. Kiểm tra tồn tại mã hộ khẩu
            if (!ghinhandonggopDAL.KiemTraTonTaiMaHoKhau(ghiNhan.MaHoKhau))
                return "Mã hộ khẩu không tồn tại.";

            // 3. Kiểm tra tồn tại mã thu phí
            if (!ghinhandonggopDAL.KiemTraTonTaiMaThuPhi(ghiNhan.MaThuPhi))
                return "Mã thu phí không tồn tại.";

            // 4. Kiểm tra số tiền đóng đúng với số tiền trong bảng ThuPhi
            decimal? soTienPhaiDong = ghinhandonggopDAL.LaySoTienThuPhi(ghiNhan.MaThuPhi);
            if (soTienPhaiDong == null)
                return "Không thể lấy số tiền thu phí";

            if (ghiNhan.SoTienDong != soTienPhaiDong)
                return $"Số tiền đóng phải đúng bằng {soTienPhaiDong.Value:N0} VNĐ.";

            if (ghiNhan.MaThuPhi != ghiNhan.MaThuPhi.ToUpper())
                return "Mã khoản thu phải viết hoa toàn bộ.";
            if (ghiNhan.MaGhiNhan != ghiNhan.MaGhiNhan.ToUpper())
                return "Mã ghi nhận phải viết hoa toàn bộ.";
            if (ghiNhan.MaHoKhau != ghiNhan.MaHoKhau.ToUpper())
                return "Mã hộ khẩu phải viết hoa toàn bộ.";
            if (!(ghiNhan.MaGhiNhan.StartsWith("GNTP")))
            {
                return "Mã ghi nhận thu phí phải bắt đầu bằng tiền tố GNTP ";
            }
            // Nếu tất cả kiểm tra đều hợp lệ → gọi DAL để thêm
            bool result = ghinhandonggopDAL.ThemGhiNhan(ghiNhan);
            return result ? "Thêm hộ đã thu thành công !." : "Thêm hộ đã thu thất bại.";
        }
        public string SuaGhiNhan(GhiNhanDongGopDTO ghiNhan)
        {
            // 0. Kiểm tra dữ liệu rỗng
            if (
                string.IsNullOrWhiteSpace(ghiNhan.MaHoKhau) ||
                string.IsNullOrWhiteSpace(ghiNhan.TenNguoiDong) ||
                string.IsNullOrWhiteSpace(ghiNhan.MaThuPhi))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            if (!Regex.IsMatch(ghiNhan.SoTienDong.ToString(), @"^\d+(\.\d{1,2})?$") || ghiNhan.SoTienDong <= 0)
            {
                return "Số tiền phải là số hợp lệ, lớn hơn 0 và tối đa 2 chữ số thập phân.";
            }
            if (!Regex.IsMatch(ghiNhan.TenNguoiDong, @"^[\p{L}\s]+$"))
            {
                return "Tên khoản thu chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            // 2. Kiểm tra tồn tại mã hộ khẩu
            if (!ghinhandonggopDAL.KiemTraTonTaiMaHoKhau(ghiNhan.MaHoKhau))
                return "Mã hộ khẩu không tồn tại.";

            // 3. Kiểm tra tồn tại mã thu phí
            if (!ghinhandonggopDAL.KiemTraTonTaiMaThuPhi(ghiNhan.MaThuPhi))
                return "Mã thu phí không tồn tại.";

            // 4. Kiểm tra số tiền đóng đúng với số tiền trong bảng ThuPhi
            decimal? soTienPhaiDong = ghinhandonggopDAL.LaySoTienThuPhi(ghiNhan.MaThuPhi);
            if (soTienPhaiDong == null)
                return "Không thể lấy số tiền thu phí.";

            if (ghiNhan.SoTienDong != soTienPhaiDong)
                return $"Số tiền đóng phải đúng bằng {soTienPhaiDong.Value:N0} VNĐ.";

            // 5. Gọi DAL để cập nhật thông tin
            bool result = ghinhandonggopDAL.SuaGhiNhan(ghiNhan);
            return result ? "Sửa ghi nhận đóng góp thành công !" : "Cập nhật thất bại.";
        }
        public string XoaGhiNhanDongGop(string maGhiNhan)
        {
            bool result = ghinhandonggopDAL.XoaGhiNhanDongGop(maGhiNhan);
            return result ? "Xóa hộ đã đóng thành công!" : "Xóa thất bại.";
        }
        public List<GhiNhanDongGopDTO> TimKiemHoDaDongTien(string MaGhiNhan)
        {
            return ghinhandonggopDAL.TimKiemHoDaDongTien(MaGhiNhan);
        }
    }
}
