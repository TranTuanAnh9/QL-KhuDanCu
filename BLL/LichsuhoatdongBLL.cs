using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LichsuhoatdongBLL
    {
        private LichsuhoatdongDAL lichsuhoatdongDAL = new LichsuhoatdongDAL();

        // Thêm lịch sử hoạt động
        public bool ThemLichSuHoatDong(LichsuhoatdongDTO ls)
        {
            // Có thể kiểm tra dữ liệu ở đây trước khi gọi DAL (vd: kiểm tra null, định dạng,...)
            if (string.IsNullOrWhiteSpace(ls.TenDangNhap) ||
                string.IsNullOrWhiteSpace(ls.HanhDong) ||
                ls.ThoiGian == default)
            {
                return false;
            }

            return lichsuhoatdongDAL.ThemLichSuHoatDong(ls);
        }

        // Lấy danh sách lịch sử hoạt động
        public List<LichsuhoatdongDTO> LayDanhSachLichSu()
        {
            return lichsuhoatdongDAL.LayDanhSachLichSu();
        }
        // Lấy lịch sử theo ngày được chọn
        public List<LichsuhoatdongDTO> LayLichSuTheoNgay(DateTime ngayChon)
        {
            return lichsuhoatdongDAL.LayLichSuTheoNgay(ngayChon);
        }
    }
}
