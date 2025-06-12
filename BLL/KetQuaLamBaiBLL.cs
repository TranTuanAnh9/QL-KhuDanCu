using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KetQuaLamBaiBLL
    {
        private KetQuaLamBaiDAL dal = new KetQuaLamBaiDAL();

        public List<KetQuaLamBaiDTO> LayKetQuaTheoUserVaKhaoSat(int maUser, int maKhaoSat)
        {
            return dal.LayKetQuaTheoUserVaKhaoSat(maUser, maKhaoSat);
        }
    }
}
