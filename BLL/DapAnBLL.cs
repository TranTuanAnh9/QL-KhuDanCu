using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class DapAnBLL
    {
        private DapAnDAL dal = new DapAnDAL();

        // Lấy danh sách đáp án theo mã câu hỏi
        public List<DapAnDTO> LayDanhSachDapAnTheoCauHoi(int maCauHoi)
        {
            return dal.LayDanhSachDapAnTheoCauHoi(maCauHoi);
        }

        // Thêm đáp án (có kiểm tra điều kiện)
        public string ThemDapAn(DapAnDTO da)
        {
            if (string.IsNullOrWhiteSpace(da.NoiDungDapAn))
                return "Nội dung đáp án không được để trống.";

            var danhSachDapAn = dal.LayDanhSachDapAnTheoCauHoi(da.MaCauHoi);
            if (danhSachDapAn.Count >= 4)
                return "Chỉ được thêm tối đa 4 đáp án cho mỗi câu hỏi.";

            int id = dal.ThemDapAn(da);
            return (id > 0) ? "Thêm thành công." : "Thêm thất bại.";
        }

        // Sửa đáp án
        public string SuaDapAn(DapAnDTO da)
        {
            if (string.IsNullOrWhiteSpace(da.NoiDungDapAn))
                return "Nội dung đáp án không được để trống.";

            bool result = dal.SuaDapAn(da);
            return result ? "Cập nhật thành công." : "Cập nhật thất bại.";
        }
        public string XoaDapAn(string madapan)
        {
            bool result = dal.XoaDapAn(madapan);
            return result ? "Xóa đáp án thành công!" : "Xóa thất bại.";
        }
    }
}
