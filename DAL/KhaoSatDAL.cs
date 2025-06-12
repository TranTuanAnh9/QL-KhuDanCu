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
    public class KhaoSatDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        // Lấy danh sách khảo sát
        public List<KhaoSatDTO> LayDanhSachKhaoSat()
        {
            List<KhaoSatDTO> danhSach = new List<KhaoSatDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KhaoSat";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhaoSatDTO ks = new KhaoSatDTO
                    {
                        MaKhaoSat = Convert.ToInt32(reader["MaKhaoSat"]),
                        TieuDe = reader["TieuDe"].ToString(),
                        NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    danhSach.Add(ks);
                }
                reader.Close();
            }

            return danhSach;
        }

        // Thêm khảo sát
        public int ThemKhaoSat(KhaoSatDTO ks)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ThemKhaoSat", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TieuDe", ks.TieuDe);
                cmd.Parameters.AddWithValue("@NgayTao", ks.NgayTao);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
        public bool SuaKhaoSat(KhaoSatDTO ks)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SuaKhaoSat", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaKhaoSat", ks.MaKhaoSat);
                cmd.Parameters.AddWithValue("@TieuDe", ks.TieuDe);
                cmd.Parameters.AddWithValue("@NgayTao", ks.NgayTao);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DangBaiKhaoSat(int maKhaoSat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE KhaoSat SET TrangThai = N'Đã đăng' WHERE MaKhaoSat = @MaKhaoSat";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhaoSat", maKhaoSat);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public int DemSoKhaoSatChuaLam(int maUser)
        {
            int soLuong = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*) 
            FROM KhaoSat ks
            WHERE ks.TrangThai = N'Đã đăng' -- Chỉ đếm bài đã đăng
            AND NOT EXISTS (
                SELECT 1 FROM BaiLamKhaoSat bl
                WHERE bl.MaUser = @MaUser AND bl.MaKhaoSat = ks.MaKhaoSat
            )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaUser", maUser);

                conn.Open();
                soLuong = (int)cmd.ExecuteScalar();
            }
            return soLuong;
        }
        public List<KhaoSatDTO> LayDanhSachKhaoSatDaDang()
        {
            List<KhaoSatDTO> danhSach = new List<KhaoSatDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT * FROM KhaoSat WHERE TrangThai = N'Đã đăng'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhaoSatDTO ks = new KhaoSatDTO
                    {
                        MaKhaoSat = Convert.ToInt32(reader["MaKhaoSat"]),
                        TieuDe = reader["TieuDe"].ToString(),
                        NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    danhSach.Add(ks);
                }
                reader.Close();
            }
            return danhSach;
        }
        public bool DaLamBaiKhaoSat(int maUser, int maKhaoSat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM BaiLamKhaoSat WHERE MaUser = @MaUser AND MaKhaoSat = @MaKhaoSat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaUser", maUser);
                cmd.Parameters.AddWithValue("@MaKhaoSat", maKhaoSat);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool XoaKhaoSat(int maKhaoSat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_XoaKhaoSat", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaKhaoSat", maKhaoSat);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
