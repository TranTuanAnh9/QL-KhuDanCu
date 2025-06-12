using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiThueTroDTO
    {
        public string MaNguoiThue { get; set; }
        public string MaKhuTro { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CCCD { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string QueQuan { get; set; }
        public DateTime NgayBatDauThue { get; set; }
        public string SoPhong { get; set; }
        public byte[] AnhDinhKem6 { get; set; }
        public byte[] AnhDinhKem7 { get; set; }
    }
}
