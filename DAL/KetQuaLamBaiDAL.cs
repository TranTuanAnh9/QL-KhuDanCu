using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KetQuaLamBaiDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        public List<KetQuaLamBaiDTO> LayKetQuaTheoUserVaKhaoSat(int maUser, int maKhaoSat)
        {
            List<KetQuaLamBaiDTO> danhSach = new List<KetQuaLamBaiDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_XemKetQuaKhaoSat", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaUser", maUser);
                cmd.Parameters.AddWithValue("@MaKhaoSat", maKhaoSat);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KetQuaLamBaiDTO ketQua = new KetQuaLamBaiDTO
                    {
                        MaCauHoi = Convert.ToInt32(reader["MaCauHoi"]),
                        CauHoi = reader["CauHoi"].ToString(),
                        Kieu = reader["Kieu"].ToString(),
                        DapAnChon = reader["DapAnChon"].ToString(),
                        TraLoiTuLuan = reader["TraLoiTuLuan"].ToString(),
                        MaDapAn = reader["MaDapAn"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaDapAn"])
                    };

                    danhSach.Add(ketQua);
                }

                reader.Close();
            }

            return danhSach;
        }
    }
}
