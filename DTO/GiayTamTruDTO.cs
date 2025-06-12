using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiayTamTruDTO
    {
        public string MaGiayTamTru { get; set; }
        public string MaNguoiThue { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string QueQuan { get; set; }
        public string SoDienThoai { get; set; }
        public string NoiTamTru { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string LyDo { get; set; }
        public string TrangThai { get; set; }
        public int SoNgay { get; set; }
        public byte[] AnhDinhKem9 { get; set; }
        public byte[] AnhDinhKem10 { get; set; } // Trường tính tự động từ SQL (DATEDIFF)
    }
}
