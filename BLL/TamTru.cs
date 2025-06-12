using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TamTru
    {
        private KhuTroDAL khuTroDAL = new KhuTroDAL();
        private NguoiThueTroDAL nguoithuetroDAL = new NguoiThueTroDAL();

        public TimKiemTamTruDTO TimKiemTheoTuKhoa1(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return null;
            }

            tuKhoa = tuKhoa.Trim();

            if (tuKhoa.StartsWith("KT"))
            {
                var list = khuTroDAL.TimKiemKhuTro(tuKhoa);
                if (list != null && list.Count > 0)
                {
                    return new TimKiemTamTruDTO { Loai = "KhuTro", DuLieu1 = list };
                }
            }
            else if (tuKhoa.StartsWith("NTT"))
            {
                var list = nguoithuetroDAL.TimKiemNguoiThueTro(tuKhoa);
                if (list != null && list.Count > 0)
                {
                    return new TimKiemTamTruDTO { Loai = "NguoiThueTro", DuLieu1 = list };
                }
            }
            return null;
        }
    }
}
