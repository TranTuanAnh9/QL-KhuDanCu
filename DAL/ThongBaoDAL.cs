using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ThongBaoDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        public int ThemThongBao(ThongBaoDTO tb)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO ThongBao (TieuDe, NoiDung, NgayGui) VALUES (@TieuDe, @NoiDung, @NgayGui); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TieuDe", tb.TieuDe);
                cmd.Parameters.AddWithValue("@NoiDung", tb.NoiDung);
                cmd.Parameters.AddWithValue("@NgayGui", tb.NgayGui);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void ThemThongBaoNguoiNhan(int maThongBao, string maNguoiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO ThongBao_NguoiNhan (MaThongBao, MaNguoiNhan)
                               VALUES (@MaThongBao, @MaNguoiNhan)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaThongBao", maThongBao);
                cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                cmd.ExecuteNonQuery();
            }
        }

        public List<ThongBaoDTO> LayThongBaoTheoNguoiNhan(string maNguoiNhan)
        {
            List<ThongBaoDTO> list = new List<ThongBaoDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT tb.MaThongBao, tb.TieuDe, tb.NoiDung, tb.NgayGui, tbn.DaXem
                               FROM ThongBao tb
                               JOIN ThongBao_NguoiNhan tbn ON tb.MaThongBao = tbn.MaThongBao
                               WHERE tbn.MaNguoiNhan = @MaNguoiNhan
                               ORDER BY tb.NgayGui DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new ThongBaoDTO
                    {
                        MaThongBao = (int)reader["MaThongBao"],
                        TieuDe = reader["TieuDe"].ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        NgayGui = Convert.ToDateTime(reader["NgayGui"])
                    });
                }
            }
            return list;
        }
        public int DemThongBaoChuaDoc(string maNguoiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM ThongBao_NguoiNhan
                               WHERE MaNguoiNhan = @MaNguoiNhan AND DaXem = 0";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                return (int)cmd.ExecuteScalar();
            }
        }
        public void CapNhatDaXem(int maThongBao, string maNguoiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE ThongBao_NguoiNhan
                               SET DaXem = 1
                               WHERE MaThongBao = @MaThongBao AND MaNguoiNhan = @MaNguoiNhan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaThongBao", maThongBao);
                cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                cmd.ExecuteNonQuery();
            }
        }
        public bool KiemTraDaXem(int maThongBao, string maNguoiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT DaXem FROM ThongBao_NguoiNhan
                       WHERE MaThongBao = @MaThongBao AND MaNguoiNhan = @MaNguoiNhan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaThongBao", maThongBao);
                cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToBoolean(result);
                }
                return false;
            }
        }
    }
}
