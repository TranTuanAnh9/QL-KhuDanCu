using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GhiNhanDongGopDTO
    {
        public string MaGhiNhan { get; set; }
        public string MaHoKhau { get; set; }
        public string MaThuPhi { get; set; }
        public string TenNguoiDong { get; set; }
        public DateTime NgayDong { get; set; }
        public decimal SoTienDong { get; set; }
        public string GhiChu { get; set; }
    }
}
