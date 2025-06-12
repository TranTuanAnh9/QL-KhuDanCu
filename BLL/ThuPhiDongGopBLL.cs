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
    public class ThuPhiDongGopBLL
    {
        private ThuPhiDongGopDAL thuphidonggopDAL = new ThuPhiDongGopDAL();

        public List<ThuPhiDongGopDTO> LayDanhSachThuPhi()
        {
            return thuphidonggopDAL.LayDanhSachThuPhi();
        }
        public string ThemThuPhi(ThuPhiDongGopDTO dto)
        {
            // 0. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(dto.MaThuPhi) ||
                string.IsNullOrWhiteSpace(dto.TenKhoanThu) ||
                string.IsNullOrWhiteSpace(dto.LyDoThu) ||
                string.IsNullOrWhiteSpace(dto.TrangThai))
            {
                return "Vui lòng nhập đầy đủ thông tin !";
            }
            if (thuphidonggopDAL.KiemTraMaThuPhiDaTonTai(dto.MaThuPhi))
            {
                return "Mã thu phí đã tồn tại.";
            }
            if (!Regex.IsMatch(dto.SoTien.ToString(), @"^\d+(\.\d{1,2})?$") || dto.SoTien <= 0)
            {
                return "Số tiền phải là số hợp lệ, lớn hơn 0 và tối đa 2 chữ số thập phân.";
            }
            if (!Regex.IsMatch(dto.TenKhoanThu, @"^[\p{L}\d\s]+$"))
            {
                return "Tên buổi sinh hoạt chỉ được chứa chữ cái, số và khoảng trắng, không được chứa ký tự đặc biệt.";
            }
            if (dto.MaThuPhi != dto.MaThuPhi.ToUpper())
                return "Mã thu phí phải viết hoa toàn bộ.";
            if (!(dto.MaThuPhi.StartsWith("TP")))
            {
                return "Mã thu phí phải bắt đầu bằng tiền tố TP ";
            }
            bool result = thuphidonggopDAL.ThemThuPhi(dto);
            return result ? "Thêm Khoản Thu Thành Công !." : "Thêm Khoản Thu Thất Bại !.";
        }
        public string SuaThuPhi(ThuPhiDongGopDTO dto)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(dto.MaThuPhi) ||
                string.IsNullOrWhiteSpace(dto.TenKhoanThu) ||
                string.IsNullOrWhiteSpace(dto.LyDoThu) ||
                string.IsNullOrWhiteSpace(dto.TrangThai))
            {
                return "Vui lòng nhập đầy đủ thông tin!";
            }
            if (!Regex.IsMatch(dto.SoTien.ToString(), @"^\d+(\.\d{1,2})?$") || dto.SoTien <= 0)
            {
                return "Số tiền phải là số hợp lệ, lớn hơn 0 và tối đa 2 chữ số thập phân.";
            }
            if (!Regex.IsMatch(dto.TenKhoanThu, @"^[\p{L}\d\s]+$"))
            {
                return "Tên buổi sinh hoạt chỉ được chứa chữ cái, số và khoảng trắng, không được chứa ký tự đặc biệt.";
            }
            // Gọi DAL để sửa
            bool result = thuphidonggopDAL.SuaThuPhi(dto);
            return result ? "Sửa Khoản Thu Thành Công!" : "Sửa Khoản Thu Thất Bại!";
        }
        public string XoaThuPhiDongGop(string maThuPhiDongGop)
        {
            bool result = thuphidonggopDAL.XoaThuPhiDongGop(maThuPhiDongGop);
            return result ? "Xóa khoản thu thành công!" : "Xóa thất bại.";
        }
        public List<ThuPhiDongGopDTO> TimKiemThuPhi(string MaThuPhi)
        {
            return thuphidonggopDAL.TimKiemThuPhi(MaThuPhi);
        }
    }
}
