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
    public class NhanKhauBLL
    {
        private NhanKhauDAL nhankhaudal = new NhanKhauDAL();

        // Lấy danh sách tất cả nhân khẩu
        public List<NhanKhauDTO> LayDanhSachNhanKhau()
        {
            return nhankhaudal.LayDanhSachNhanKhau();
        }
        public string ThemNhanKhau(NhanKhauDTO nk)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(nk.MaNhanKhau) ||
                string.IsNullOrWhiteSpace(nk.MaHoKhau) ||
                string.IsNullOrWhiteSpace(nk.HoTen) ||
                string.IsNullOrWhiteSpace(nk.CCCD) ||
                string.IsNullOrWhiteSpace(nk.QuanHeVoiChuHo) ||
                string.IsNullOrWhiteSpace(nk.TrangThai) ||
                string.IsNullOrWhiteSpace(nk.Email) ||
                string.IsNullOrWhiteSpace(nk.SoDienThoai))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            // Kiểm tra mã nhân khẩu
            if (nhankhaudal.KiemTraTrungMaNhanKhau(nk.MaNhanKhau))
            {
                return "Mã nhân khẩu đã tồn tại.";
            }
            // Kiểm tra mã hộ khẩu
            if (!nhankhaudal.KiemTraTonTaiMaHoKhau(nk.MaHoKhau))
            {
                return "Mã hộ khẩu không tồn tại.";
            }

            // Kiểm tra trùng CCCD
            if (nhankhaudal.KiemTraTrungCCCD(nk.CCCD))
            {
                return "CCCD đã tồn tại.";
            }

            // Kiểm tra trùng Email
            if (nhankhaudal.KiemTraTrungEmail(nk.Email))
            {
                return "Email đã tồn tại.";
            }

            // Kiểm tra trùng Số điện thoại
            if (nhankhaudal.KiemTraTrungSoDienThoai(nk.SoDienThoai))
            {
                return "Số điện thoại đã tồn tại.";
            }

            // Kiểm tra giới tính
            if (nk.GioiTinh != "Nam" && nk.GioiTinh != "Nữ")
            {
                return "Giới tính chỉ được nhập 'Nam' hoặc 'Nữ'.";
            }
            if (nk.NgaySinh > DateTime.Now)
            {
                return "Ngày sinh không được lớn hơn ngày hiện tại.";
            }
            // Nếu là Chủ hộ thì HoTen và CCCD phải giống trong bảng HoKhau
            if (nk.QuanHeVoiChuHo == "Chủ hộ")
            {
                string cccdChuHo = nhankhaudal.LayCCCDChuHoTheoMaHoKhau(nk.MaHoKhau);
                string hoTenChuHo = nhankhaudal.LayHoTenChuHoTheoMaHoKhau(nk.MaHoKhau);

                if (nk.CCCD != cccdChuHo || nk.HoTen != hoTenChuHo)
                {
                    return "Thông tin chủ hộ không khớp với hộ khẩu.";
                }
            }
            else
            {
                // Nếu không phải chủ hộ nhưng trùng với chủ hộ thì báo lỗi
                string cccdChuHo = nhankhaudal.LayCCCDChuHoTheoMaHoKhau(nk.MaHoKhau);
                string hoTenChuHo = nhankhaudal.LayHoTenChuHoTheoMaHoKhau(nk.MaHoKhau);

                if (nk.CCCD == cccdChuHo && nk.HoTen == hoTenChuHo)
                {
                    return "Người này là chủ hộ nhưng Quan hệ với chủ hộ không phải 'Chủ hộ'.";
                }
            }
            if (!Regex.IsMatch(nk.HoTen, @"^[\p{L}\s]+$"))
            {
                return "Họ tên chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            if (!Regex.IsMatch(nk.CCCD, @"^\d{12,20}$"))
            {
                return "cccd phải ít nhất là 12 số và nhiều nhất là 20 số và chỉ là số.";
            }
            if (nhankhaudal.KiemTraCCCDNguoiThueTro(nk.CCCD))
            {
                return "CCCD đã bị trùng với CCCD người thuê trọ!";
            }
            if (nhankhaudal.KiemTraSoDienThoaiNguoiThueTro(nk.SoDienThoai))
            {
                return "SoDienThoai đã bị trùng với SoDienThoai người thuê trọ!";
            }
            if (nhankhaudal.KiemTraEmailNguoiThueTro(nk.Email))
            {
                return "Email đã bị trùng với Email người thuê trọ!";
            }
            if (!Regex.IsMatch(nk.SoDienThoai, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }
            if (!(nk.MaNhanKhau.StartsWith("CB") ||
      nk.MaNhanKhau.StartsWith("CD") ||
      nk.MaNhanKhau.StartsWith("TT") ||
      nk.MaNhanKhau.StartsWith("CT")))
            {
                return "Mã nhân khẩu phải bắt đầu bằng một trong các tiền tố: CB, CD, TT, CT.";
            }
            if (nk.MaHoKhau != nk.MaHoKhau.ToUpper())
                return "Mã hộ khẩu phải viết hoa toàn bộ.";
            // Thêm nhân khẩu nếu qua tất cả kiểm tra
            bool thanhCong = nhankhaudal.ThemNhanKhau(nk);
            return thanhCong ? "Thêm nhân khẩu thành công !." : "Thêm nhân khẩu thất bại.";
        }
        public string SuaNhanKhau(NhanKhauDTO nk)
        {
            if (
                string.IsNullOrWhiteSpace(nk.MaHoKhau) ||
                string.IsNullOrWhiteSpace(nk.HoTen) ||
                string.IsNullOrWhiteSpace(nk.CCCD) ||
                string.IsNullOrWhiteSpace(nk.QuanHeVoiChuHo) ||
                string.IsNullOrWhiteSpace(nk.TrangThai) ||
                string.IsNullOrWhiteSpace(nk.Email) ||
                string.IsNullOrWhiteSpace(nk.SoDienThoai))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            if (!nhankhaudal.KiemTraTonTaiMaHoKhau(nk.MaHoKhau))
                return "Mã hộ khẩu không tồn tại.";

            if (nk.GioiTinh != "Nam" && nk.GioiTinh != "Nữ")
                return "Giới tính chỉ được nhập 'Nam' hoặc 'Nữ'.";

            if (nk.NgaySinh > DateTime.Now)
                return "Ngày sinh không được lớn hơn ngày hiện tại.";

            if (!Regex.IsMatch(nk.HoTen, @"^[\p{L}\s]+$"))
            {
                return "Họ tên chỉ được chứa chữ cái và khoảng trắng, không được chứa số hoặc ký tự đặc biệt.";
            }
            if (!Regex.IsMatch(nk.CCCD, @"^\d{12,20}$"))
            {
                return "cccd phải ít nhất là 12 số và nhiều nhất là 20 số và chỉ là số.";
            }
            if (nhankhaudal.KiemTraCCCDNguoiThueTro(nk.CCCD))
            {
                return "CCCD đã bị trùng với CCCD người thuê trọ!";
            }
            if (nhankhaudal.KiemTraSoDienThoaiNguoiThueTro(nk.SoDienThoai))
            {
                return "SoDienThoai đã bị trùng với SoDienThoai người thuê trọ!";
            }
            if (nhankhaudal.KiemTraEmailNguoiThueTro(nk.Email))
            {
                return "Email đã bị trùng với Email người thuê trọ!";
            }
            if (!Regex.IsMatch(nk.SoDienThoai, @"^\d{9,12}$"))
            {
                return "Số điện thoại phải từ 9 đến 12 chữ số và chỉ chứa số.";
            }

                // Kiểm tra logic chủ hộ như ở thêm
                if (nk.QuanHeVoiChuHo == "Chủ hộ")
            {
                string cccdChuHo = nhankhaudal.LayCCCDChuHoTheoMaHoKhau(nk.MaHoKhau);
                string hoTenChuHo = nhankhaudal.LayHoTenChuHoTheoMaHoKhau(nk.MaHoKhau);

                if (nk.CCCD != cccdChuHo || nk.HoTen != hoTenChuHo)
                {
                    return "Thông tin chủ hộ không khớp với thông tin trong sổ hộ khẩu.";
                }
            }
            else
            {
                string cccdChuHo = nhankhaudal.LayCCCDChuHoTheoMaHoKhau(nk.MaHoKhau);
                string hoTenChuHo = nhankhaudal.LayHoTenChuHoTheoMaHoKhau(nk.MaHoKhau);

                if (nk.CCCD == cccdChuHo && nk.HoTen == hoTenChuHo)
                {
                    return "Quan hệ với chủ hộ không hợp lệ: Đây là chủ hộ nhưng không chọn 'Chủ hộ'.";
                }
            }
            if (nk.MaHoKhau != nk.MaHoKhau.ToUpper())
                return "Mã hộ khẩu phải viết hoa toàn bộ.";
            // Nếu mọi thứ ok, tiến hành sửa
            bool kq = nhankhaudal.SuaNhanKhau(nk);
            return kq ? "Sửa nhân khẩu thành công." : "Sửa nhân khẩu thất bại.";
        }
        public string XoaNhanKhau(string maNhanKhau)
        {
            bool ketQua = nhankhaudal.XoaNhanKhau(maNhanKhau);
            return ketQua ? "Xóa Nhân Khẩu Thành Công !" : "Xóa Nhân Khẩu Thất Bại !";
        }
        public List<NhanKhauDTO> TimKiemNhanKhau(string tuKhoa1)
        {
            return nhankhaudal.TimKiemNhanKhau(tuKhoa1);
        }
        public bool CapNhatAnhNhanKhau(string maNhanKhau, byte[] anh)
        {
            return nhankhaudal.CapNhatAnhNhanKhau(maNhanKhau, anh);
        }
        public byte[] LayAnhNhanKhau(string maNhanKhau)
        {
            return nhankhaudal.LayAnhNhanKhau(maNhanKhau);
        }
        public bool CapNhatAnhNhaNhanKhau(string maNhanKhau, byte[] anh2)
        {
            return nhankhaudal.CapNhatAnhNhaNhanKhau(maNhanKhau, anh2);
        }
        public byte[] LayAnhNhaNhanKhau(string maNhanKhau)
        {
            return nhankhaudal.LayAnhNhaNhanKhau(maNhanKhau);
        }
        public List<ThongKeNhanKhauTheoDoTuoiDTO> ThongKeNhanKhauTheoDoTuoi()
        {
            return nhankhaudal.ThongKeNhanKhauTheoDoTuoi();
        }
        public List<ThongKeNhanKhauTheoGioiTinhDTO> ThongKeNhanKhauTheoGioiTinh()
        {
            return nhankhaudal.ThongKeNhanKhauTheoGioiTinh();
        }
        public int DemTongNhanKhau()
        {
            return nhankhaudal.DemTongNhanKhau();
        }
    }
}
