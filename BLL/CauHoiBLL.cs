using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class CauHoiBLL
    {
        private CauHoiDAL dal = new CauHoiDAL();

        public List<CauHoiDTO> LayDanhSachCauHoiTheoKhaoSat(int maKhaoSat)
        {
            return dal.LayDanhSachCauHoiTheoKhaoSat(maKhaoSat);
        }
        public int ThemCauHoi(CauHoiDTO ch)
        {
            return dal.ThemCauHoi(ch);
        }
        public bool SuaCauHoi(CauHoiDTO ch)
        {
            return dal.SuaCauHoi(ch);
        }
        public string XoaCauHoi(string macauhoi)
        {
            bool result = dal.XoaCauHoi(macauhoi);
            return result ? "Xóa câu hỏi thành công!" : "Xóa thất bại.";
        }
        public bool KiemTraTrungNoiDung(int maKhaoSat, string noiDung)
        {
            List<CauHoiDTO> danhSach = dal.LayDanhSachCauHoiTheoKhaoSat(maKhaoSat);
            return danhSach.Any(ch =>
                ch.NoiDung.Trim().Equals(noiDung.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
