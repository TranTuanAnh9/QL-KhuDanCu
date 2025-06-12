using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauDTO
    {
        public string MaNhanKhau { get; set; }
        public string MaHoKhau { get; set; }
        public string HoTen { get; set; }
        public string CCCD { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string QuanHeVoiChuHo { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }

        // Thêm thuộc tính ảnh đính kèm
        public byte[] AnhDinhKem2 { get; set; }
        public byte[] AnhDinhKem3 { get; set; }
    }
}
