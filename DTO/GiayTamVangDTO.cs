using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiayTamVangDTO
    {
        public string MaGiayTamVang { get; set; }
        public string MaNhanKhau { get; set; }
        public string HoTen { get; set; }
        public string CCCD { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string NoiDi { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime NgayVe { get; set; }
        public string LyDo { get; set; }
        public string TrangThai { get; set; }

        // Trường tính toán SoNgay (computed column)
        public int SoNgay { get; set; }
        public byte[] AnhDinhKem4 { get; set; }
        public byte[] AnhDinhKem5 { get; set; }
    }
}
