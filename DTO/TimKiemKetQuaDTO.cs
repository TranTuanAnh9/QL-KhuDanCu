using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TimKiemKetQuaDTO
    {
        public string LoaiKetQua { get; set; } // "NhanKhau", "HoKhau", "GiayTamVang"
        public object DuLieu { get; set; }
    }
}
