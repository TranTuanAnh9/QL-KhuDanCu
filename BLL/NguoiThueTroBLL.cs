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
    public class NguoiThueTroBLL
    {
        private NguoiThueTroDAL nguoithuetroDAL = new NguoiThueTroDAL();

        public List<NguoiThueTroDTO> LayDanhSachNguoiThueTro()
        {
            return nguoithuetroDAL.LayDanhSachNguoiThueTro();
        }
        public string ThemNguoiThueTro(NguoiThueTroDTO dto)
        {
            // 0. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(dto.MaNguoiThue) ||
                string.IsNullOrWhiteSpace(dto.HoTen) ||
                string.IsNullOrWhiteSpace(dto.CCCD) ||
                string.IsNullOrWhiteSpace(dto.SoDienThoai) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.QueQuan) ||
                string.IsNullOrWhiteSpace(dto.SoPhong) ||
                string.IsNullOrWhiteSpace(dto.MaKhuTro))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            // 1. Kiểm tra trùng MaNguoiThue
            if (nguoithuetroDAL.KiemTraTrungMaNguoiThue(dto.MaNguoiThue))
                return "Mã người thuê đã tồn tại !";

            // 6. Kiểm tra mã khu trọ có tồn tại
            if (!nguoithuetroDAL.KiemTraTonTaiMaKhuTro(dto.MaKhuTro))
                return "Mã khu trọ không tồn tại!";
            // 2. Kiểm tra trùng CCCD
            if (nguoithuetroDAL.KiemTraTrungCCCD(dto.CCCD))
                return "CCCD đã có trong hệ thống !";

            if (!Regex.IsMatch(dto.HoTen, @"^[\p{L}\s]+$"))
            {
                return "Họ tên chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            if (!Regex.IsMatch(dto.CCCD, @"^\d{12,20}$"))
            {
                return "cccd phải ít nhất là 12 số và nhiều nhất là 20 số và chỉ là số.";
            }
            // 3. Kiểm tra trùng SĐT
            if (nguoithuetroDAL.KiemTraTrungSoDienThoai(dto.SoDienThoai))
                return "Số điện thoại đã có trong hệ thống !";

            if (!Regex.IsMatch(dto.SoDienThoai, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            // 4. Kiểm tra trùng Email
            if (nguoithuetroDAL.KiemTraTrungEmail(dto.Email))
                return "Email đã đã có trong hệ thống !";

            // 5. Kiểm tra giới tính hợp lệ
            string gt = dto.GioiTinh.Trim().ToLower();
            if (gt != "nam" && gt != "nữ")
                return "Giới tính chỉ được là 'Nam' hoặc 'Nữ'.";

            if (dto.NgaySinh > DateTime.Now)
            {
                return "Ngày sinh không được lớn hơn ngày hiện tại.";
            }
            // 6.5. Kiểm tra khu trọ còn phòng trống không
            if (!nguoithuetroDAL.KiemTraKhuTroConPhong(dto.MaKhuTro))
                return "Khu trọ đã hết phòng, không thể thêm người thuê mới.";
            if (dto.MaKhuTro != dto.MaKhuTro.ToUpper())
                return "Mã khu trọ phải viết hoa toàn bộ.";

            if (!(dto.MaNguoiThue.StartsWith("NTT")))
            {
                return "Mã người thuê trọ phải bắt đầu bằng tiền tố NTT ";
            }
            if (nguoithuetroDAL.KiemTraCCCDNhanKhau(dto.CCCD))
            {
                return "CCCD đã bị trùng với CCCD nhân khẩu!";
            }
            if (nguoithuetroDAL.KiemTraSoDienThoaiNhanKhau(dto.SoDienThoai))
            {
                return "SoDienThoai đã bị trùng với SoDienThoai nhân khẩu";
            }
            if (nguoithuetroDAL.KiemTraEmailNhanKhau(dto.Email))
            {
                return "Email đã bị trùng với Email nhân khẩu";
            }
            // 7. Nếu tất cả hợp lệ => gọi DAL thêm
            bool thanhCong = nguoithuetroDAL.ThemNguoiThue(dto);
            return thanhCong ? "Thêm người thuê trọ thành công!." : "Thêm người thuê trọ thất bại!";
        }
        public string SuaNguoiThue(NguoiThueTroDTO dto)
        {
            if(
                string.IsNullOrWhiteSpace(dto.HoTen) ||
                string.IsNullOrWhiteSpace(dto.CCCD) ||
                string.IsNullOrWhiteSpace(dto.SoDienThoai) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.QueQuan) ||
                string.IsNullOrWhiteSpace(dto.SoPhong) ||
                string.IsNullOrWhiteSpace(dto.MaKhuTro))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            // Kiểm tra giới tính hợp lệ
            string gt = dto.GioiTinh.Trim().ToLower();
            if (gt != "nam" && gt != "nữ")
                return "Giới tính chỉ được là 'Nam' hoặc 'Nữ'.";

            if (!nguoithuetroDAL.KiemTraTonTaiMaKhuTro(dto.MaKhuTro))
                return "Mã khu trọ không tồn tại!";

            if (dto.NgaySinh > DateTime.Now)
                return "Ngày sinh không được lớn hơn ngày hiện tại.";

            if (!Regex.IsMatch(dto.SoDienThoai, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            if (!Regex.IsMatch(dto.CCCD, @"^\d{12,20}$"))
            {
                return "cccd phải ít nhất là 12 số và nhiều nhất là 20 số và chỉ là số.";
            }
            if (!Regex.IsMatch(dto.HoTen, @"^[\p{L}\s]+$"))
            {
                return "Họ tên chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            if (nguoithuetroDAL.KiemTraCCCDNhanKhau(dto.CCCD))
            {
                return "CCCD đã bị trùng với CCCD nhân khẩu!";
            }
            if (nguoithuetroDAL.KiemTraSoDienThoaiNhanKhau(dto.SoDienThoai))
            {
                return "SoDienThoai đã bị trùng với SoDienThoai nhân khẩu";
            }
            if (nguoithuetroDAL.KiemTraEmailNhanKhau(dto.Email))
            {
                return "Email đã bị trùng với Email nhân khẩu";
            }
            // 6.5. Kiểm tra khu trọ còn phòng trống không
            if (!nguoithuetroDAL.KiemTraKhuTroConPhong(dto.MaKhuTro))
                return "Khu trọ đã hết phòng, không thể chuyển người thuê sang khu trọ này.";

            bool thanhCong = nguoithuetroDAL.CapNhatNguoiThue(dto);
            return thanhCong ? "Cập nhật người thuê trọ thành công!" : "Cập nhật thất bại!";
        }
        public string XoaNguoiThueTro(string maNguoiThueTro)
        {
            bool result = nguoithuetroDAL.XoaNguoiThueTro(maNguoiThueTro);
            return result ? "Xóa người thuê trọ thành công!" : "Xóa thất bại.";
        }
        public List<NguoiThueTroDTO> TimKiemNguoiThueTro(string MaNguoiThueTro)
        {
            return nguoithuetroDAL.TimKiemNguoiThueTro(MaNguoiThueTro);
        }
        public bool CapNhatAnhNguoiThueTro(string maNguoiThueTro, byte[] anh)
        {
            return nguoithuetroDAL.CapNhatAnhNguoiThueTro(maNguoiThueTro, anh);
        }
        public byte[] LayAnhNguoiThueTro(string maNguoiThueTro)
        {
            return nguoithuetroDAL.LayAnhNguoiThueTro(maNguoiThueTro);
        }
        public bool CapNhatAnhKhuTro(string maNguoiThueTro, byte[] anh2)
        {
            return nguoithuetroDAL.CapNhatAnhKhuTro(maNguoiThueTro, anh2);
        }
        public byte[] LayAnhNhaKhuTro(string maNguoiThueTro)
        {
            return nguoithuetroDAL.LayAnhNhaKhuTro(maNguoiThueTro);
        }
        public List<ThongKeNguoiThueTheoKhuTroDTO> ThongKeTheoKhuTro()
        {
            return nguoithuetroDAL.ThongKeNguoiThueTheoKhuTro();
        }
        public List<ThongKeNguoiThueTheoGioiTinhDTO> ThongKeTheoGioiTinh()
        {
            return nguoithuetroDAL.ThongKeTheoGioiTinh();
        }
        public List<ThongKeNguoiThueTheoDoTuoiDTO> ThongKeTheoDoTuoi()
        {
            return nguoithuetroDAL.ThongKeTheoDoTuoi();
        }
        public int DemTongnguoithuetro()
        {
            return nguoithuetroDAL.DemTongnguoithuetro();
        }
    }
}
