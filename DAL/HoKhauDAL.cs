using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoKhauDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"; // đổi tên CSDL
        public List<HoKhauDTO> LayDanhSachHoKhau()
        {
            List<HoKhauDTO> danhSach = new List<HoKhauDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HoKhau";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HoKhauDTO hk = new HoKhauDTO
                    {
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        TenChuHo = reader["TenChuHo"].ToString(),
                        CCCDChuHo = reader["CCCDChuHo"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        SoThanhVien = Convert.ToInt32(reader["SoThanhVien"]),
                        NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                        TrangThai = reader["TrangThai"].ToString(),
                        MoTa = reader["MoTa"].ToString()
                    };
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem"] != DBNull.Value)
                    {
                        hk.AnhDinhKem = (byte[])reader["AnhDinhKem"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        hk.AnhDinhKem = null;
                    }
                    danhSach.Add(hk);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool ThemHoKhau(HoKhauDTO hk)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemHoKhau", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHoKhau", hk.MaHoKhau);
                cmd.Parameters.AddWithValue("@TenChuHo", hk.TenChuHo);
                cmd.Parameters.AddWithValue("@CCCDChuHo", hk.CCCDChuHo);
                cmd.Parameters.AddWithValue("@DiaChi", hk.DiaChi);
                cmd.Parameters.AddWithValue("@SoThanhVien", hk.SoThanhVien);
                cmd.Parameters.AddWithValue("@NgayLap", hk.NgayLap);
                cmd.Parameters.AddWithValue("@TrangThai", hk.TrangThai);
                cmd.Parameters.AddWithValue("@MoTa", string.IsNullOrEmpty(hk.MoTa) ? (object)DBNull.Value : hk.MoTa);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaHoKhau(HoKhauDTO hk)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaHoKhau", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHoKhau", hk.MaHoKhau);
                cmd.Parameters.AddWithValue("@TenChuHo", hk.TenChuHo);
                cmd.Parameters.AddWithValue("@CCCDChuHo", hk.CCCDChuHo);
                cmd.Parameters.AddWithValue("@DiaChi", hk.DiaChi);
                cmd.Parameters.AddWithValue("@SoThanhVien", hk.SoThanhVien);
                cmd.Parameters.AddWithValue("@NgayLap", hk.NgayLap);
                cmd.Parameters.AddWithValue("@TrangThai", hk.TrangThai);
                cmd.Parameters.AddWithValue("@MoTa", string.IsNullOrEmpty(hk.MoTa) ? (object)DBNull.Value : hk.MoTa);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool XoaHoKhau(string maHoKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaHoKhau", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHoKhau", maHoKhau);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<HoKhauDTO> TimKiemHoKhau(string tuKhoa)
        {
            List<HoKhauDTO> ketQua = new List<HoKhauDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemHoKhau", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HoKhauDTO hk = new HoKhauDTO
                    {
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        TenChuHo = reader["TenChuHo"].ToString(),
                        CCCDChuHo = reader["CCCDChuHo"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        SoThanhVien = Convert.ToInt32(reader["SoThanhVien"]),
                        NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                        TrangThai = reader["TrangThai"].ToString(),
                        MoTa = reader["MoTa"] == DBNull.Value ? "" : reader["MoTa"].ToString()
                    };
                    ketQua.Add(hk);
                }

                reader.Close();
            }
            return ketQua;
        }
        public bool KiemTraTrungMaHoKhau(string maHoKhau)
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
        public bool KiemTraTrungCCCD(string cccd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM HoKhau WHERE CCCDChuHo = @CCCD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CCCD", cccd);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool CapNhatAnhHoKhau(string maHoKhau, byte[] anh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE HoKhau SET AnhDinhKem = @Anh WHERE MaHoKhau = @MaHoKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoKhau", maHoKhau);
                cmd.Parameters.AddWithValue("@Anh", (object)anh ?? DBNull.Value); // Nếu ảnh là null thì dùng DBNull.Value

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public byte[] LayAnhHoKhau(string maHoKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem FROM HoKhau WHERE MaHoKhau = @MaHoKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoKhau", maHoKhau);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null; // Nếu không có ảnh thì trả về null
            }
        }
        public List<ThongKeHoKhauTheoNamDTO> ThongKeHoKhauTheoNam()
        {
            List<ThongKeHoKhauTheoNamDTO> danhSach = new List<ThongKeHoKhauTheoNamDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeHoKhauTheoNam", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeHoKhauTheoNamDTO item = new ThongKeHoKhauTheoNamDTO
                    {
                        Nam = Convert.ToInt32(reader["Nam"]),
                        TongSoHoKhau = Convert.ToInt32(reader["TongSoHoKhau"])
                    };
                    danhSach.Add(item);
                }

                reader.Close();
            }

            return danhSach;
        }
        public List<ThongKeHoKhauTheoTrangThaiDTO> ThongKeHoKhauTheoTrangThai()
        {
            List<ThongKeHoKhauTheoTrangThaiDTO> danhSach = new List<ThongKeHoKhauTheoTrangThaiDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeHoKhauTheoTrangThai", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeHoKhauTheoTrangThaiDTO item = new ThongKeHoKhauTheoTrangThaiDTO
                    {
                        TrangThai = reader["TrangThai"].ToString(),
                        TongSoHoKhau = Convert.ToInt32(reader["TongSoHoKhau"])
                    };
                    danhSach.Add(item);
                }

                reader.Close();
            }

            return danhSach;
        }
        public int DemTongHoKhau()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM HoKhau";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count;
            }
        }
    }
}
