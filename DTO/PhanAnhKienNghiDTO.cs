using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanAnhKienNghiDTO
    {
        public int MaPhanAnh { get; set; }
        public string MaHoKhau { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayPhanAnh { get; set; }
        public string TrangThai { get; set; }
    }
}
