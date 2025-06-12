using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoKhauDTO
    {
        public string MaHoKhau { get; set; }
        public string TenChuHo { get; set; }
        public string CCCDChuHo { get; set; }
        public string DiaChi { get; set; }
        public int SoThanhVien { get; set; }
        public DateTime NgayLap { get; set; }
        public string TrangThai { get; set; }
        public string MoTa { get; set; }
        public byte[] AnhDinhKem { get; set; } // Thêm dòng này
    }
}
