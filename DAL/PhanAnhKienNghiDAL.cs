using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhanAnhKienNghiDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<PhanAnhKienNghiDTO> LayDanhSachPhanAnh()
        {
            List<PhanAnhKienNghiDTO> danhSach = new List<PhanAnhKienNghiDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PhanAnh";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhanAnhKienNghiDTO pa = new PhanAnhKienNghiDTO
                    {
                        MaPhanAnh = Convert.ToInt32(reader["MaPhanAnh"]),
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        NgayPhanAnh = Convert.ToDateTime(reader["NgayPhanAnh"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    danhSach.Add(pa);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool ThemPhanAnh(PhanAnhKienNghiDTO phanAnh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemPhanAnh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHoKhau", phanAnh.MaHoKhau);
                cmd.Parameters.AddWithValue("@HoTen", phanAnh.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", phanAnh.SoDienThoai);
                cmd.Parameters.AddWithValue("@NoiDung", phanAnh.NoiDung);
                cmd.Parameters.AddWithValue("@NgayPhanAnh", phanAnh.NgayPhanAnh);
                cmd.Parameters.AddWithValue("@TrangThai", phanAnh.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaPhanAnh(PhanAnhKienNghiDTO phanAnh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaPhanAnh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaPhanAnh", phanAnh.MaPhanAnh);
                cmd.Parameters.AddWithValue("@MaHoKhau", phanAnh.MaHoKhau);
                cmd.Parameters.AddWithValue("@HoTen", phanAnh.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", phanAnh.SoDienThoai);
                cmd.Parameters.AddWithValue("@NoiDung", phanAnh.NoiDung);
                cmd.Parameters.AddWithValue("@NgayPhanAnh", phanAnh.NgayPhanAnh);
                cmd.Parameters.AddWithValue("@TrangThai", phanAnh.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool XoaPhanAnh(int maPhanAnh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaPhanAnhKienNghi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPhanAnh", maPhanAnh);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<PhanAnhKienNghiDTO> TimKiemDonPhanAnh(string TuKhoa3)
        {
            List<PhanAnhKienNghiDTO> ketQua = new List<PhanAnhKienNghiDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemPhanAnh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuKhoa3", TuKhoa3);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PhanAnhKienNghiDTO pa = new PhanAnhKienNghiDTO
                    {
                        MaPhanAnh = Convert.ToInt32(reader["MaPhanAnh"]),
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        NgayPhanAnh = Convert.ToDateTime(reader["NgayPhanAnh"]),
                        TrangThai = reader["TrangThai"] == DBNull.Value ? "" : reader["TrangThai"].ToString()
                    };

                    ketQua.Add(pa);
                }

                reader.Close();
            }
            return ketQua;
        }
        public bool KiemTraMaHoKhauTonTai(string maHoKhau)
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
    }
}
