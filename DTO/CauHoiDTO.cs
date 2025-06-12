using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CauHoiDTO
    {
        public int MaCauHoi { get; set; }
        public int MaKhaoSat { get; set; }
        public string NoiDung { get; set; }
        public string Kieu { get; set; }  // "Tự luận" hoặc "Trắc nghiệm"
        public int ThuTu { get; set; }
    }
}
