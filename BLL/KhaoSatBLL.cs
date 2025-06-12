using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class KhaoSatBLL
    {
        private KhaoSatDAL ksDAL = new KhaoSatDAL();
        public List<KhaoSatDTO> LayDanhSachKhaoSat()
        {
            return ksDAL.LayDanhSachKhaoSat();
        }
        public int ThemKhaoSat(KhaoSatDTO ks)
        {
            return ksDAL.ThemKhaoSat(ks);
        }
        public bool SuaKhaoSat(KhaoSatDTO ks)
        {
            return ksDAL.SuaKhaoSat(ks);
        }
        public bool DangBaiKhaoSat(int maKhaoSat)
        {
            // Có thể thêm logic nghiệp vụ ở đây (nếu cần)
            return ksDAL.DangBaiKhaoSat(maKhaoSat);
        }
        public int DemSoKhaoSatChuaLam(int maUser)
        {
            return ksDAL.DemSoKhaoSatChuaLam(maUser);
        }
        public List<KhaoSatDTO> LayDanhSachKhaoSatDaDang()
        {
            return ksDAL.LayDanhSachKhaoSatDaDang();
        }

        public bool DaLamBaiKhaoSat(int maUser, int maKhaoSat)
        {
            return ksDAL.DaLamBaiKhaoSat(maUser, maKhaoSat);
        }
        public bool XoaKhaoSat(int maKhaoSat)
        {
            return ksDAL.XoaKhaoSat(maKhaoSat);
        }

    }
}
