using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CauTraLoiDTO
    {
        public int MaCauTraLoi { get; set; }
        public int MaBaiLam { get; set; }
        public int MaCauHoi { get; set; }
        public int? MaDapAn { get; set; }
        public string TraLoiTuLuan { get; set; }
    }
}
