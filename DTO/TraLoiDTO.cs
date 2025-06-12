using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TraLoiDTO
    {
        public int MaCauHoi { get; set; }           // Mã câu hỏi
        public int? MaDapAn { get; set; }           // Nếu là trắc nghiệm (null nếu tự luận)
        public string TraLoiTuLuan { get; set; }    // Nếu là tự luận (null nếu trắc nghiệm)
    }
}
