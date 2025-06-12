using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ThongBaoBLL
    {
        private ThongBaoDAL dal = new ThongBaoDAL();
        public int ThemThongBao(ThongBaoDTO tb)
        {
            return dal.ThemThongBao(tb);
        }

        public void ThemThongBaoNguoiNhan(ThongBaoNguoiNhanDTO tbn)
        {
            dal.ThemThongBaoNguoiNhan(tbn.MaThongBao, tbn.MaNguoiNhan);
        }

        public List<ThongBaoDTO> LayThongBaoTheoNguoiNhan(string maNguoiNhan)
        {
            return dal.LayThongBaoTheoNguoiNhan(maNguoiNhan);
        }

        public int DemThongBaoChuaDoc(string maNguoiNhan)
        {
            return dal.DemThongBaoChuaDoc(maNguoiNhan);
        }

        public void CapNhatDaXem(int maThongBao, string maNguoiNhan)
        {
            dal.CapNhatDaXem(maThongBao, maNguoiNhan);
        }
        public bool KiemTraDaXem(int maThongBao, string maNguoiNhan)
        {
            return dal.KiemTraDaXem(maThongBao, maNguoiNhan);
        }
    }
}
