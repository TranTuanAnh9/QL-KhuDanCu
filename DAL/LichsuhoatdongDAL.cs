using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class LichsuhoatdongDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        // Thêm lịch sử hoạt động
        public bool ThemLichSuHoatDong(LichsuhoatdongDTO ls)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemLichSuHoatDong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenDangNhap", ls.TenDangNhap);
                cmd.Parameters.AddWithValue("@ChucVu", ls.ChucVu);
                cmd.Parameters.AddWithValue("@HanhDong", ls.HanhDong);
                cmd.Parameters.AddWithValue("@NoiDung", ls.NoiDung);
                cmd.Parameters.AddWithValue("@ThoiGian", ls.ThoiGian);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy danh sách lịch sử hoạt động (tuỳ chọn có thể lấy tất cả hoặc theo user, thời gian ...)
        public List<LichsuhoatdongDTO> LayDanhSachLichSu()
        {
            List<LichsuhoatdongDTO> danhSach = new List<LichsuhoatdongDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LichSuHoatDong ORDER BY ThoiGian DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LichsuhoatdongDTO ls = new LichsuhoatdongDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        ChucVu = reader["ChucVu"].ToString(),
                        HanhDong = reader["HanhDong"].ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        ThoiGian = Convert.ToDateTime(reader["ThoiGian"])
                    };
                    danhSach.Add(ls);
                }

                reader.Close();
            }

            return danhSach;
        }
        public List<LichsuhoatdongDTO> LayLichSuTheoNgay(DateTime ngayChon)
        {
            List<LichsuhoatdongDTO> danhSach = new List<LichsuhoatdongDTO>();

            DateTime ngayTu = ngayChon.Date; // 00:00:00
            DateTime ngayDen = ngayTu.AddDays(1); // ngày hôm sau (00:00:00)

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM LichSuHoatDong 
                         WHERE ThoiGian >= @NgayTu AND ThoiGian < @NgayDen
                         ORDER BY ThoiGian DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NgayTu", ngayTu);
                cmd.Parameters.AddWithValue("@NgayDen", ngayDen);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LichsuhoatdongDTO ls = new LichsuhoatdongDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        ChucVu = reader["ChucVu"].ToString(),
                        HanhDong = reader["HanhDong"].ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        ThoiGian = Convert.ToDateTime(reader["ThoiGian"])
                    };
                    danhSach.Add(ls);
                }

                reader.Close();
            }

            return danhSach;
        }
    }
}
