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
    public class GiayTamTruDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<GiayTamTruDTO> LayDanhSachGiayTamTru()
        {
            List<GiayTamTruDTO> danhSach = new List<GiayTamTruDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM GiayTamTru";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GiayTamTruDTO gtt = new GiayTamTruDTO
                    {
                        MaGiayTamTru = reader["MaGiayTamTru"].ToString(),
                        MaNguoiThue = reader["MaNguoiThue"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        CCCD = reader["CCCD"].ToString(),
                        QueQuan = reader["QueQuan"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        NoiTamTru = reader["NoiTamTru"].ToString(),
                        NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]),
                        NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]),
                        LyDo = reader["LyDo"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        SoNgay = reader["SoNgay"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoNgay"])
                    };
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem9"] != DBNull.Value)
                    {
                        gtt.AnhDinhKem9 = (byte[])reader["AnhDinhKem9"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        gtt.AnhDinhKem9 = null;
                    }
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem10"] != DBNull.Value)
                    {
                        gtt.AnhDinhKem10 = (byte[])reader["AnhDinhKem10"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        gtt.AnhDinhKem10 = null;
                    }
                    danhSach.Add(gtt);
                }
                reader.Close();
            }
            return danhSach;
        }
        public bool ThemGiayTamTru(GiayTamTruDTO gtt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemGiayTamTru", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGiayTamTru", gtt.MaGiayTamTru);
                cmd.Parameters.AddWithValue("@MaNguoiThue", gtt.MaNguoiThue);
                cmd.Parameters.AddWithValue("@HoTen", gtt.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", gtt.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", gtt.NgaySinh);
                cmd.Parameters.AddWithValue("@CCCD", gtt.CCCD);
                cmd.Parameters.AddWithValue("@QueQuan", gtt.QueQuan);
                cmd.Parameters.AddWithValue("@SoDienThoai", gtt.SoDienThoai);
                cmd.Parameters.AddWithValue("@NoiTamTru", gtt.NoiTamTru);
                cmd.Parameters.AddWithValue("@NgayBatDau", gtt.NgayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", gtt.NgayKetThuc);
                cmd.Parameters.AddWithValue("@LyDo", gtt.LyDo);
                cmd.Parameters.AddWithValue("@TrangThai", gtt.TrangThai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool SuaGiayTamTru(GiayTamTruDTO gtt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaGiayTamTru", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGiayTamTru", gtt.MaGiayTamTru);
                cmd.Parameters.AddWithValue("@MaNguoiThue", gtt.MaNguoiThue);
                cmd.Parameters.AddWithValue("@HoTen", gtt.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", gtt.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", gtt.NgaySinh);
                cmd.Parameters.AddWithValue("@CCCD", gtt.CCCD);
                cmd.Parameters.AddWithValue("@QueQuan", gtt.QueQuan);
                cmd.Parameters.AddWithValue("@SoDienThoai", gtt.SoDienThoai);
                cmd.Parameters.AddWithValue("@NoiTamTru", gtt.NoiTamTru);
                cmd.Parameters.AddWithValue("@NgayBatDau", gtt.NgayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", gtt.NgayKetThuc);
                cmd.Parameters.AddWithValue("@LyDo", gtt.LyDo);
                cmd.Parameters.AddWithValue("@TrangThai", gtt.TrangThai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool XoaGiayTamTru(string maGiayTamTru)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaGiayTamTru", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiayTamTru", maGiayTamTru);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<GiayTamTruDTO> TimKiemGiayTamTru(string MaGiayTamTru)
        {
            List<GiayTamTruDTO> ketQua = new List<GiayTamTruDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemGiayTamTru", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiayTamTru", MaGiayTamTru);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GiayTamTruDTO gtt = new GiayTamTruDTO
                    {
                        MaGiayTamTru = reader["MaGiayTamTru"].ToString(),
                        MaNguoiThue = reader["MaNguoiThue"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        CCCD = reader["CCCD"].ToString(),
                        QueQuan = reader["QueQuan"].ToString(),
                        SoDienThoai = reader["SoDienThoai"] == DBNull.Value ? "" : reader["SoDienThoai"].ToString(),
                        NoiTamTru = reader["NoiTamTru"].ToString(),
                        NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]),
                        NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]),
                        LyDo = reader["LyDo"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        SoNgay = Convert.ToInt32(reader["SoNgay"])
                    };

                    ketQua.Add(gtt);
                }

                reader.Close();
            }
            return ketQua;
        }

        // Kiểm tra trùng mã giấy tạm trú
        public bool KiemTraTrungMaGiayTamTru(string ma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM GiayTamTru WHERE MaGiayTamTru = @Ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ma", ma);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        // Lấy thông tin người thuê trọ theo mã
        public NguoiThueTroDTO LayNguoiThueTheoMa(string maNguoiThue)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NguoiThueTro WHERE MaNguoiThue = @Ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ma", maNguoiThue);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new NguoiThueTroDTO
                    {
                        MaNguoiThue = reader["MaNguoiThue"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        CCCD = reader["CCCD"].ToString(),
                        QueQuan = reader["QueQuan"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString()
                    };
                }
                return null;
            }
        }
        public bool CapNhatAnhNguoixincapTamtru(string maGiayTamTru, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE GiayTamTru SET AnhDinhKem9 = @AnhDinhKem9 WHERE MaGiayTamTru = @MaGiayTamTru";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiayTamTru", maGiayTamTru);
                cmd.Parameters.Add("@AnhDinhKem9", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy ảnh đính kèm theo mã Nhân Khẩu
        public byte[] LayAnhNguoiXinCapTamTru(string maGiayTamTru)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem9 FROM GiayTamTru WHERE MaGiayTamTru = @MaGiayTamTru";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiayTamTru", maGiayTamTru);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
        public bool CapNhapAnhKhuTroTamTru(string maGiayTamTru, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE GiayTamTru SET AnhDinhKem10 = @AnhDinhKem10 WHERE MaGiayTamTru = @MaGiayTamTru";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiayTamTru", maGiayTamTru);
                cmd.Parameters.Add("@AnhDinhKem10", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public byte[] LayAnhKhuTroTamTru(string maGiayTamTru)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem10 FROM GiayTamTru WHERE MaGiayTamTru = @MaGiayTamTru";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiayTamTru", maGiayTamTru);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
        public List<ThongKeGiayTamTruTheoGioiTinhDTO> ThongKeGiayTamTruTheoGioiTinh()
        {
            List<ThongKeGiayTamTruTheoGioiTinhDTO> danhSach = new List<ThongKeGiayTamTruTheoGioiTinhDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeGiayTamTruTheoGioiTinh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeGiayTamTruTheoGioiTinhDTO item = new ThongKeGiayTamTruTheoGioiTinhDTO
                    {
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"])
                    };

                    danhSach.Add(item);
                }

                reader.Close();
            }

            return danhSach;
        }
        public List<ThongKeGiayTamTruTheoSoNgayDTO> ThongKeGiayTamTruTheoSoNgay()
        {
            List<ThongKeGiayTamTruTheoSoNgayDTO> danhSach = new List<ThongKeGiayTamTruTheoSoNgayDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeGiayTamTruTheoSoNgay", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeGiayTamTruTheoSoNgayDTO item = new ThongKeGiayTamTruTheoSoNgayDTO
                    {
                        NhomSoNgay = reader["NhomSoNgay"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"])
                    };

                    danhSach.Add(item);
                }

                reader.Close();
            }

            return danhSach;
        }
    }
}
