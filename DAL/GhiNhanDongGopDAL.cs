using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class GhiNhanDongGopDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        public List<GhiNhanDongGopDTO> LayDanhSachGhiNhan()
        {
            List<GhiNhanDongGopDTO> danhSach = new List<GhiNhanDongGopDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM GhiNhanThuPhi";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GhiNhanDongGopDTO ghiNhan = new GhiNhanDongGopDTO
                    {
                        MaGhiNhan = reader["MaGhiNhan"].ToString(),
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        MaThuPhi = reader["MaThuPhi"].ToString(),
                        TenNguoiDong = reader["TenNguoiDong"].ToString(),
                        NgayDong = Convert.ToDateTime(reader["NgayDong"]),
                        SoTienDong = Convert.ToDecimal(reader["SoTienDong"]),
                        GhiChu = reader["GhiChu"].ToString()
                    };

                    danhSach.Add(ghiNhan);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool KiemTraTrungMaGhiNhan(string maGhiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM GhiNhanThuPhi WHERE MaGhiNhan = @MaGhiNhan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGhiNhan", maGhiNhan);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public bool KiemTraTonTaiMaHoKhau(string maHoKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM HoKhau WHERE MaHoKhau = @MaHoKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoKhau", maHoKhau);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public bool KiemTraTonTaiMaThuPhi(string maThuPhi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ThuPhi WHERE MaThuPhi = @MaThuPhi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThuPhi", maThuPhi);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public decimal? LaySoTienThuPhi(string maThuPhi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SoTien FROM ThuPhi WHERE MaThuPhi = @MaThuPhi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThuPhi", maThuPhi);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
                return null;
            }
        }
        public bool ThemGhiNhan(GhiNhanDongGopDTO ghiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemGhiNhanThuPhi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGhiNhan", ghiNhan.MaGhiNhan);
                cmd.Parameters.AddWithValue("@MaHoKhau", ghiNhan.MaHoKhau);
                cmd.Parameters.AddWithValue("@MaThuPhi", ghiNhan.MaThuPhi);
                cmd.Parameters.AddWithValue("@TenNguoiDong", ghiNhan.TenNguoiDong);
                cmd.Parameters.AddWithValue("@NgayDong", ghiNhan.NgayDong);
                cmd.Parameters.AddWithValue("@SoTienDong", ghiNhan.SoTienDong);
                cmd.Parameters.AddWithValue("@GhiChu", ghiNhan.GhiChu ?? "");

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaGhiNhan(GhiNhanDongGopDTO ghiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaGhiNhanThuPhi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGhiNhan", ghiNhan.MaGhiNhan);
                cmd.Parameters.AddWithValue("@MaHoKhau", ghiNhan.MaHoKhau);
                cmd.Parameters.AddWithValue("@MaThuPhi", ghiNhan.MaThuPhi);
                cmd.Parameters.AddWithValue("@TenNguoiDong", ghiNhan.TenNguoiDong);
                cmd.Parameters.AddWithValue("@NgayDong", ghiNhan.NgayDong);
                cmd.Parameters.AddWithValue("@SoTienDong", ghiNhan.SoTienDong);
                cmd.Parameters.AddWithValue("@GhiChu", ghiNhan.GhiChu ?? "");

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool XoaGhiNhanDongGop(string maGhiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaGhiNhanThuPhi", conn); 
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGhiNhan", maGhiNhan);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<GhiNhanDongGopDTO> TimKiemHoDaDongTien(string MaGhiNhan)
        {
            List<GhiNhanDongGopDTO> ketQua = new List<GhiNhanDongGopDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemGhiNhanThuPhi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGhiNhan", MaGhiNhan);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GhiNhanDongGopDTO ghiNhan = new GhiNhanDongGopDTO
                    {
                        MaGhiNhan = reader["MaGhiNhan"].ToString(),
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        MaThuPhi = reader["MaThuPhi"].ToString(),
                        TenNguoiDong = reader["TenNguoiDong"].ToString(),
                        NgayDong = Convert.ToDateTime(reader["NgayDong"]),
                        SoTienDong = Convert.ToDecimal(reader["SoTienDong"]),
                        GhiChu = reader["GhiChu"] == DBNull.Value ? "" : reader["GhiChu"].ToString()
                    };

                    ketQua.Add(ghiNhan);
                }

                reader.Close();
            }
            return ketQua;
        }
    }
}
