using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class CauHoiDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<CauHoiDTO> LayDanhSachCauHoiTheoKhaoSat(int maKhaoSat)
        {
            List<CauHoiDTO> list = new List<CauHoiDTO>();

            string query = "SELECT * FROM CauHoi WHERE MaKhaoSat = @MaKhaoSat ORDER BY ThuTu";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhaoSat", maKhaoSat);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CauHoiDTO ch = new CauHoiDTO
                    {
                        MaCauHoi = Convert.ToInt32(reader["MaCauHoi"]),
                        MaKhaoSat = Convert.ToInt32(reader["MaKhaoSat"]),
                        NoiDung = reader["NoiDung"].ToString(),
                        Kieu = reader["Kieu"].ToString(),
                        ThuTu = Convert.ToInt32(reader["ThuTu"])
                    };
                    list.Add(ch);
                }
            }
            return list;
        }
        public int ThemCauHoi(CauHoiDTO ch)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ThemCauHoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaKhaoSat", ch.MaKhaoSat);
                cmd.Parameters.AddWithValue("@NoiDung", ch.NoiDung);
                cmd.Parameters.AddWithValue("@Kieu", ch.Kieu);
                cmd.Parameters.AddWithValue("@ThuTu", ch.ThuTu);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : -1;
            }
        }
        public bool SuaCauHoi(CauHoiDTO ch)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SuaCauHoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCauHoi", ch.MaCauHoi);
                cmd.Parameters.AddWithValue("@NoiDung", ch.NoiDung);
                cmd.Parameters.AddWithValue("@Kieu", ch.Kieu);
                cmd.Parameters.AddWithValue("@ThuTu", ch.ThuTu);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public bool XoaCauHoi(string macauhoi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_XoaCauHoi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCauHoi", macauhoi);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
