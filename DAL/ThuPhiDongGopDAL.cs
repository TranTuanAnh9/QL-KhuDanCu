using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ThuPhiDongGopDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<ThuPhiDongGopDTO> LayDanhSachThuPhi()
        {
            List<ThuPhiDongGopDTO> danhSach = new List<ThuPhiDongGopDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ThuPhi";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThuPhiDongGopDTO tp = new ThuPhiDongGopDTO
                    {
                        MaThuPhi = reader["MaThuPhi"].ToString(),
                        TenKhoanThu = reader["TenKhoanThu"].ToString(),
                        SoTien = Convert.ToDecimal(reader["SoTien"]),
                        HanDong = Convert.ToDateTime(reader["HanDong"]),
                        LyDoThu = reader["LyDoThu"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    danhSach.Add(tp);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool KiemTraMaThuPhiDaTonTai(string maThuPhi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ThuPhi WHERE MaThuPhi = @MaThuPhi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThuPhi", maThuPhi);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool ThemThuPhi(ThuPhiDongGopDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemThuPhi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaThuPhi", dto.MaThuPhi);
                cmd.Parameters.AddWithValue("@TenKhoanThu", dto.TenKhoanThu);
                cmd.Parameters.AddWithValue("@SoTien", dto.SoTien);
                cmd.Parameters.AddWithValue("@HanDong", dto.HanDong);
                cmd.Parameters.AddWithValue("@LyDoThu", dto.LyDoThu);
                cmd.Parameters.AddWithValue("@TrangThai", dto.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaThuPhi(ThuPhiDongGopDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaThuPhi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaThuPhi", dto.MaThuPhi);
                cmd.Parameters.AddWithValue("@TenKhoanThu", dto.TenKhoanThu);
                cmd.Parameters.AddWithValue("@SoTien", dto.SoTien);
                cmd.Parameters.AddWithValue("@HanDong", dto.HanDong);
                cmd.Parameters.AddWithValue("@LyDoThu", dto.LyDoThu);
                cmd.Parameters.AddWithValue("@TrangThai", dto.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool XoaThuPhiDongGop(string maThuPhiDongGop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaThuPhiDongGop", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaThuPhi", maThuPhiDongGop);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<ThuPhiDongGopDTO> TimKiemThuPhi(string @MaThuPhi)
        {
            List<ThuPhiDongGopDTO> ketQua = new List<ThuPhiDongGopDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemThuPhi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaThuPhi", @MaThuPhi);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThuPhiDongGopDTO tp = new ThuPhiDongGopDTO
                    {
                        MaThuPhi = reader["MaThuPhi"].ToString(),
                        TenKhoanThu = reader["TenKhoanThu"].ToString(),
                        SoTien = Convert.ToDecimal(reader["SoTien"]),
                        HanDong = Convert.ToDateTime(reader["HanDong"]),
                        LyDoThu = reader["LyDoThu"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };

                    ketQua.Add(tp);
                }

                reader.Close();
            }
            return ketQua;
        }
    }
}
