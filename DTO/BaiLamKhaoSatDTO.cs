using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaiLamKhaoSatDTO
    {
        public int MaBaiLam { get; set; }
        public int MaUser { get; set; }
        public int MaKhaoSat { get; set; }
        public DateTime NgayNop { get; set; }
        public bool TrangThai { get; set; }
    }
}
