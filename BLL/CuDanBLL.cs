using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class CuDanBLL
    {
        private NhanKhauDAL nhanKhauDAL = new NhanKhauDAL();
        private HoKhauDAL hoKhauDAL = new HoKhauDAL();
        private GiayTamVangDAl giayTamVangDAL = new GiayTamVangDAl();

        public TimKiemKetQuaDTO TimKiemTheoTuKhoa(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return null;
            }

            tuKhoa = tuKhoa.Trim();

            if (tuKhoa.StartsWith("CT") || tuKhoa.StartsWith("CB") || tuKhoa.StartsWith("CD") || tuKhoa.StartsWith("TT"))
            {
                var list = nhanKhauDAL.TimKiemNhanKhau(tuKhoa);
                if (list != null && list.Count > 0)
                {
                    return new TimKiemKetQuaDTO { LoaiKetQua = "NhanKhau", DuLieu = list };
                }
            }
            else if (tuKhoa.StartsWith("HK"))
            {
                var list = hoKhauDAL.TimKiemHoKhau(tuKhoa);
                if (list != null && list.Count > 0)
                {
                    return new TimKiemKetQuaDTO { LoaiKetQua = "HoKhau", DuLieu = list };
                }
            }
            else if (tuKhoa.StartsWith("GTV"))
            {
                var list = giayTamVangDAL.TimKiemGiayTamVang(tuKhoa);
                if (list != null && list.Count > 0)
                {
                    return new TimKiemKetQuaDTO { LoaiKetQua = "GiayTamVang", DuLieu = list };
                }
            }
            return null;
        }
    }
}
