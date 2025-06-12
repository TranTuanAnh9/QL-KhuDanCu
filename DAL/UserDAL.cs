using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UserDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<UserDTO> LayDanhSachUser()
        {
            List<UserDTO> danhSach = new List<UserDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [User]";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserDTO user = new UserDTO
                    {
                        MaUser = (int)reader["MaUser"],
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        VaiTro = reader["VaiTro"].ToString()
                    };
                    danhSach.Add(user);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool ThemUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TenDangNhap", user.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
                cmd.Parameters.AddWithValue("@VaiTro", user.VaiTro);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public bool SuaUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaUser", user.MaUser);
                cmd.Parameters.AddWithValue("@TenDangNhap", user.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
                cmd.Parameters.AddWithValue("@VaiTro", user.VaiTro);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public bool XoaUser(string maUser)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaUser", maUser);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<UserDTO> TimKiemUser(string TenDangNhap)
        {
            List<UserDTO> ketQua = new List<UserDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemUserTheoTenDangNhap", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserDTO user = new UserDTO
                    {
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        VaiTro = reader["VaiTro"].ToString(),
                    };

                    ketQua.Add(user);
                }

                reader.Close();
            }
            return ketQua;
        }
        public bool KiemTraTenDangNhapTonTai(string tenDangNhap)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra trong bảng NhanKhau
                string queryNhanKhau = "SELECT COUNT(*) FROM NhanKhau WHERE MaNhanKhau = @TenDangNhap";
                SqlCommand cmdNK = new SqlCommand(queryNhanKhau, conn);
                cmdNK.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                int countNK = (int)cmdNK.ExecuteScalar();

                if (countNK > 0)
                    return true;

                // Kiểm tra trong bảng NguoiThueTro
                string queryNTT = "SELECT COUNT(*) FROM NguoiThueTro WHERE MaNguoiThue = @TenDangNhap";
                SqlCommand cmdNTT = new SqlCommand(queryNTT, conn);
                cmdNTT.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                int countNTT = (int)cmdNTT.ExecuteScalar();

                return countNTT > 0;
            }
        }
    }
}
