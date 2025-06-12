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
    public class GiayTamVangDAl
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<GiayTamVangDTO> LayDanhSachGiayTamVang()
        {
            List<GiayTamVangDTO> danhSach = new List<GiayTamVangDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM GiayTamVang";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GiayTamVangDTO gtv = new GiayTamVangDTO
                    {
                        MaGiayTamVang = reader["MaGiayTamVang"].ToString(),
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        NoiDi = reader["NoiDi"].ToString(),
                        NgayDi = Convert.ToDateTime(reader["NgayDi"]),
                        NgayVe = Convert.ToDateTime(reader["NgayVe"]),
                        LyDo = reader["LyDo"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        SoNgay = Convert.ToInt32(reader["SoNgay"]),

                    };
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem4"] != DBNull.Value)
                    {
                        gtv.AnhDinhKem4 = (byte[])reader["AnhDinhKem4"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        gtv.AnhDinhKem4 = null;
                    }
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem5"] != DBNull.Value)
                    {
                        gtv.AnhDinhKem5 = (byte[])reader["AnhDinhKem5"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        gtv.AnhDinhKem5 = null;
                    }
                    danhSach.Add(gtv);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool KiemTraTrungMaGiay(string ma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM GiayTamVang WHERE MaGiayTamVang = @ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ma", ma);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // Lấy thông tin nhân khẩu theo mã
        public NhanKhauDTO LayNhanKhauTheoMa(string maNhanKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhanKhau WHERE MaNhanKhau = @ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ma", maNhanKhau);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new NhanKhauDTO
                    {
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString()
                    };
                }
                return null;
            }
        }
        // Gọi stored procedure ThemGiayTamVang
        public bool ThemGiayTamVang(GiayTamVangDTO gtv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemGiayTamVang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGiayTamVang", gtv.MaGiayTamVang);
                cmd.Parameters.AddWithValue("@MaNhanKhau", gtv.MaNhanKhau);
                cmd.Parameters.AddWithValue("@HoTen", gtv.HoTen);
                cmd.Parameters.AddWithValue("@CCCD", gtv.CCCD);
                cmd.Parameters.AddWithValue("@NgaySinh", gtv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gtv.GioiTinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", gtv.SoDienThoai);
                cmd.Parameters.AddWithValue("@NoiDi", gtv.NoiDi);
                cmd.Parameters.AddWithValue("@NgayDi", gtv.NgayDi);
                cmd.Parameters.AddWithValue("@NgayVe", gtv.NgayVe);
                cmd.Parameters.AddWithValue("@LyDo", gtv.LyDo);
                cmd.Parameters.AddWithValue("@TrangThai", gtv.TrangThai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool SuaGiayTamVang(GiayTamVangDTO gtv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaGiayTamVang", conn); // Stored procedure tên là SuaGiayTamVang
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGiayTamVang", gtv.MaGiayTamVang);
                cmd.Parameters.AddWithValue("@MaNhanKhau", gtv.MaNhanKhau);
                cmd.Parameters.AddWithValue("@HoTen", gtv.HoTen);
                cmd.Parameters.AddWithValue("@CCCD", gtv.CCCD);
                cmd.Parameters.AddWithValue("@NgaySinh", gtv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gtv.GioiTinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", gtv.SoDienThoai);
                cmd.Parameters.AddWithValue("@NoiDi", gtv.NoiDi);
                cmd.Parameters.AddWithValue("@NgayDi", gtv.NgayDi);
                cmd.Parameters.AddWithValue("@NgayVe", gtv.NgayVe);
                cmd.Parameters.AddWithValue("@LyDo", gtv.LyDo);
                cmd.Parameters.AddWithValue("@TrangThai", gtv.TrangThai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool XoaGiayTamVang(string maGiayTamVang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaGiayTamVang", conn); // stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiayTamVang", maGiayTamVang);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<GiayTamVangDTO> TimKiemGiayTamVang(string MaGiayTamVang)
        {
            List<GiayTamVangDTO> ketQua = new List<GiayTamVangDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemGiayTamVang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiayTamVang", MaGiayTamVang);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GiayTamVangDTO gtv = new GiayTamVangDTO
                    {
                        MaGiayTamVang = reader["MaGiayTamVang"].ToString(),
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        NoiDi = reader["NoiDi"].ToString(),
                        NgayDi = Convert.ToDateTime(reader["NgayDi"]),
                        NgayVe = Convert.ToDateTime(reader["NgayVe"]),
                        LyDo = reader["LyDo"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        SoNgay = Convert.ToInt32(reader["SoNgay"]) // cột computed column
                    };

                    ketQua.Add(gtv);
                }

                reader.Close();
            }
            return ketQua;
        }
        public bool CapNhatAnhNhanKhau1(string maGiayTamVang, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE GiayTamVang SET AnhDinhKem4 = @AnhDinhKem4 WHERE MaGiayTamVang = @MaGiayTamVang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiayTamVang", maGiayTamVang);
                cmd.Parameters.Add("@AnhDinhKem4", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy ảnh đính kèm theo mã Nhân Khẩu
        public byte[] LayAnhNhanKhau1(string maGiayTamVang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem4 FROM GiayTamVang WHERE MaGiayTamVang = @MaGiayTamVang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiayTamVang", maGiayTamVang);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
        public bool CapNhatAnhNhaNhanKhau1(string maGiayTamVang, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE GiayTamVang SET AnhDinhKem5 = @AnhDinhKem5 WHERE MaGiayTamVang = @MaGiayTamVang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiayTamVang", maGiayTamVang);
                cmd.Parameters.Add("@AnhDinhKem5", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public byte[] LayAnhNhaNhanKhau1(string maGiayTamVang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem5 FROM GiayTamVang WHERE MaGiayTamVang = @MaGiayTamVang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiayTamVang", maGiayTamVang);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
    }
}
