using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DichBenhBLL
    {
        private DichBenhDAL dichbenhDAL = new DichBenhDAL();

        public List<DichBenhDTO> LayDanhSachDichBenh()
        {
            return dichbenhDAL.LayDanhSachDichBenh();
        }
        public string ThemDichBenh(DichBenhDTO db)
        {
            // 1. Kiểm tra các trường không được để trống
            if (string.IsNullOrWhiteSpace(db.MaDich) ||
                string.IsNullOrWhiteSpace(db.TenDich) ||
                string.IsNullOrWhiteSpace(db.MucDoNguyHiem) ||
                 string.IsNullOrWhiteSpace(db.TrangThai) ||
                string.IsNullOrWhiteSpace(db.NoiBungPhat))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }
            if (dichbenhDAL.KiemTraTrungMaDich(db.MaDich))
                return "Mã dịch đã tồn tại.";

            if (db.NgayBungPhat > DateTime.Now)
            {
                return "Ngày bùng phát không được lớn hơn ngày hiện tại.";
            }
            if (db.MaDich != db.MaDich.ToUpper())
                return "Mã dịch phải viết hoa toàn bộ.";
            if (!(db.MaDich.StartsWith("DB")))
            {
                return "Mã dịch bệnh phải bắt đầu bằng tiền tố DB ";
            }
            bool ketQua = dichbenhDAL.ThemDichBenh(db);
            return ketQua ? "Thêm dịch bệnh thành công!" : "Thêm thất bại!";
        }
        public string SuaDichBenh(DichBenhDTO db)
        {
            if (
                string.IsNullOrWhiteSpace(db.TenDich) ||
                string.IsNullOrWhiteSpace(db.MucDoNguyHiem) ||
                string.IsNullOrWhiteSpace(db.TrangThai) ||
                string.IsNullOrWhiteSpace(db.NoiBungPhat))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            if (db.NgayBungPhat > DateTime.Now)
            {
                return "Ngày bùng phát không được lớn hơn ngày hiện tại.";
            }
            bool ketQua = dichbenhDAL.SuaDichBenh(db);
            return ketQua ? "Cập nhật dịch bệnh thành công!" : "Cập nhật thất bại!";
        }
        public string XoaDichBenh(string maDichBenh)
        {
            bool result = dichbenhDAL.XoaDichBenh(maDichBenh);
            return result ? "Xóa dịch bệnh thành công!" : "Xóa thất bại.";
        }
        public List<DichBenhDTO> TimKiemDichBenh(string MaDich)
        {
            return dichbenhDAL.TimKiemDichBenh(MaDich);
        }
    }
}
