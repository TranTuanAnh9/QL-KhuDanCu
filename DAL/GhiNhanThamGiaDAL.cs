using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class GhiNhanThamGiaDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<GhiNhanThamGiaDTO> LayDanhSachGhiNhan()
        {
            List<GhiNhanThamGiaDTO> danhSach = new List<GhiNhanThamGiaDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM GhiNhanThamGia";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GhiNhanThamGiaDTO ghiNhan = new GhiNhanThamGiaDTO
                    {
                        MaGhiNhan = reader["MaGhiNhan"].ToString(),
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        MaSinhHoat = reader["MaSinhHoat"].ToString(),
                        TenBuoiSinhHoat = reader["TenBuoiSinhHoat"].ToString(),
                        TenNguoiThamGia = reader["TenNguoiThamGia"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
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
                string query = "SELECT COUNT(*) FROM GhiNhanThamGia WHERE MaGhiNhan = @MaGhiNhan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGhiNhan", maGhiNhan);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
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
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraTonTaiMaSinhHoat(string maSinhHoat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM SinhHoat WHERE MaSinhHoat = @MaSinhHoat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSinhHoat", maSinhHoat);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraTenBuoiSinhHoatHopLe(string maSinhHoat, string tenBuoiSinhHoat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM SinhHoat WHERE MaSinhHoat = @MaSinhHoat AND TenSinhHoat = @TenSinhHoat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSinhHoat", maSinhHoat);
                cmd.Parameters.AddWithValue("@TenSinhHoat", tenBuoiSinhHoat);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool ThemGhiNhan(GhiNhanThamGiaDTO ghiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemGhiNhanThamGia", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGhiNhan", ghiNhan.MaGhiNhan);
                cmd.Parameters.AddWithValue("@MaHoKhau", ghiNhan.MaHoKhau);
                cmd.Parameters.AddWithValue("@MaSinhHoat", ghiNhan.MaSinhHoat);
                cmd.Parameters.AddWithValue("@TenBuoiSinhHoat", ghiNhan.TenBuoiSinhHoat);
                cmd.Parameters.AddWithValue("@TenNguoiThamGia", ghiNhan.TenNguoiThamGia);
                cmd.Parameters.AddWithValue("@SoDienThoai", ghiNhan.SoDienThoai);
                cmd.Parameters.AddWithValue("@GhiChu", ghiNhan.GhiChu);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaGhiNhan(GhiNhanThamGiaDTO ghiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaGhiNhanThamGia", conn); // Tên proc của bạn
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGhiNhan", ghiNhan.MaGhiNhan);
                cmd.Parameters.AddWithValue("@MaHoKhau", ghiNhan.MaHoKhau);
                cmd.Parameters.AddWithValue("@MaSinhHoat", ghiNhan.MaSinhHoat);
                cmd.Parameters.AddWithValue("@TenBuoiSinhHoat", ghiNhan.TenBuoiSinhHoat);
                cmd.Parameters.AddWithValue("@TenNguoiThamGia", ghiNhan.TenNguoiThamGia);
                cmd.Parameters.AddWithValue("@SoDienThoai", ghiNhan.SoDienThoai);
                cmd.Parameters.AddWithValue("@GhiChu", ghiNhan.GhiChu);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Xóa ghi nhận tham gia
        public bool XoaGhiNhanThamGia(string maGhiNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaGhiNhanThamGia", conn); // Stored procedure tên là XoaGhiNhanThamGia
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGhiNhan", maGhiNhan);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<GhiNhanThamGiaDTO> TimKiemHoDaThamGia(string MaGhiNhan)
        {
            List<GhiNhanThamGiaDTO> ketQua = new List<GhiNhanThamGiaDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemGhiNhanThamGia", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGhiNhan", MaGhiNhan);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GhiNhanThamGiaDTO tg = new GhiNhanThamGiaDTO
                    {
                        MaGhiNhan = reader["MaGhiNhan"].ToString(),
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        MaSinhHoat = reader["MaSinhHoat"].ToString(),
                        TenBuoiSinhHoat = reader["TenBuoiSinhHoat"].ToString(),
                        TenNguoiThamGia = reader["TenNguoiThamGia"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        GhiChu = reader["GhiChu"] == DBNull.Value ? "" : reader["GhiChu"].ToString()
                    };

                    ketQua.Add(tg);
                }

                reader.Close();
            }
            return ketQua;
        }
    }
}
