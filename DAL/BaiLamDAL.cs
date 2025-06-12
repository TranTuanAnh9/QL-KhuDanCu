using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class BaiLamDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        // Thêm bài làm khảo sát
        public int ThemBaiLamKhaoSat(BaiLamKhaoSatDTO dto)
        {
            string query = "INSERT INTO BaiLamKhaoSat (MaUser, MaKhaoSat, NgayNop, TrangThai) " +
                           "OUTPUT INSERTED.MaBaiLam VALUES (@MaUser, @MaKhaoSat, @NgayNop, @TrangThai)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaUser", dto.MaUser);
                cmd.Parameters.AddWithValue("@MaKhaoSat", dto.MaKhaoSat);
                cmd.Parameters.AddWithValue("@NgayNop", dto.NgayNop);
                cmd.Parameters.AddWithValue("@TrangThai", dto.TrangThai);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : -1;
            }
        }

        // Thêm câu trả lời
        public bool ThemCauTraLoi(CauTraLoiDTO dto)
        {
            string query = "INSERT INTO CauTraLoi (MaBaiLam, MaCauHoi, MaDapAn, TraLoiTuLuan) " +
                           "VALUES (@MaBaiLam, @MaCauHoi, @MaDapAn, @TraLoiTuLuan)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaBaiLam", dto.MaBaiLam);
                cmd.Parameters.AddWithValue("@MaCauHoi", dto.MaCauHoi);
                cmd.Parameters.AddWithValue("@MaDapAn", dto.MaDapAn == null ? DBNull.Value : (object)dto.MaDapAn);
                cmd.Parameters.AddWithValue("@TraLoiTuLuan", string.IsNullOrEmpty(dto.TraLoiTuLuan) ? DBNull.Value : (object)dto.TraLoiTuLuan);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}

