using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhuTroDTO
    {
        public string MaKhuTro { get; set; }
        public string TenKhuTro { get; set; }
        public string DiaChi { get; set; }
        public string HoTenChuTro { get; set; }
        public string SoDienThoaiChuTro { get; set; }
        public string MaNhanKhau { get; set; }
        public int SoPhong { get; set; }
        public int SoPhongTrong { get; set; }
        public string TrangThai { get; set; }
        public byte[] AnhDinhKem8 { get; set; }
    }
}
