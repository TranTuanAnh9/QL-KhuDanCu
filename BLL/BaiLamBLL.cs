using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BaiLamBLL
    {
        private BaiLamDAL dal = new BaiLamDAL();

        // Gọi để thêm bài làm
        public int ThemBaiLamKhaoSat(BaiLamKhaoSatDTO dto)
        {
            return dal.ThemBaiLamKhaoSat(dto);
        }

        // Gọi để thêm từng câu trả lời
        public bool ThemCauTraLoi(CauTraLoiDTO dto)
        {
            return dal.ThemCauTraLoi(dto);
        }

        // Gọi để thêm danh sách câu trả lời cùng lúc
        public void ThemDanhSachCauTraLoi(List<CauTraLoiDTO> danhSach)
        {
            foreach (var cauTraLoi in danhSach)
            {
                dal.ThemCauTraLoi(cauTraLoi);
            }
        }
    }
}
