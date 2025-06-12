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
    public class NhanKhauDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"; // đổi tên CSDL
        public List<NhanKhauDTO> LayDanhSachNhanKhau()
        {
            List<NhanKhauDTO> danhSach = new List<NhanKhauDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NhanKhauDTO nk = new NhanKhauDTO
                    {
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        QuanHeVoiChuHo = reader["QuanHeVoiChuHo"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        GhiChu = reader["GhiChu"].ToString(),
                        Email = reader["Email"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString()
                    };
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem2"] != DBNull.Value)
                    {
                        nk.AnhDinhKem2 = (byte[])reader["AnhDinhKem2"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        nk.AnhDinhKem2 = null;
                    }
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem3"] != DBNull.Value)
                    {
                        nk.AnhDinhKem3 = (byte[])reader["AnhDinhKem3"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        nk.AnhDinhKem3 = null;
                    }
                    danhSach.Add(nk);
                }

                reader.Close();
            }
            return danhSach;
        }
        public bool ThemNhanKhau(NhanKhauDTO nk)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemNhanKhau", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaNhanKhau", nk.MaNhanKhau);
                cmd.Parameters.AddWithValue("@MaHoKhau", nk.MaHoKhau);
                cmd.Parameters.AddWithValue("@HoTen", nk.HoTen);
                cmd.Parameters.AddWithValue("@CCCD", nk.CCCD);
                cmd.Parameters.AddWithValue("@NgaySinh", nk.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nk.GioiTinh);
                cmd.Parameters.AddWithValue("@QuanHeVoiChuHo", nk.QuanHeVoiChuHo);
                cmd.Parameters.AddWithValue("@TrangThai", nk.TrangThai);
                cmd.Parameters.AddWithValue("@GhiChu", nk.GhiChu ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", nk.Email);
                cmd.Parameters.AddWithValue("@SoDienThoai", nk.SoDienThoai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaNhanKhau(NhanKhauDTO nk)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaNhanKhau", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaNhanKhau", nk.MaNhanKhau);
                cmd.Parameters.AddWithValue("@MaHoKhau", nk.MaHoKhau);
                cmd.Parameters.AddWithValue("@HoTen", nk.HoTen);
                cmd.Parameters.AddWithValue("@CCCD", nk.CCCD);
                cmd.Parameters.AddWithValue("@NgaySinh", nk.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nk.GioiTinh);
                cmd.Parameters.AddWithValue("@QuanHeVoiChuHo", nk.QuanHeVoiChuHo);
                cmd.Parameters.AddWithValue("@TrangThai", nk.TrangThai);
                cmd.Parameters.AddWithValue("@GhiChu", nk.GhiChu ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", nk.Email);
                cmd.Parameters.AddWithValue("@SoDienThoai", nk.SoDienThoai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool XoaNhanKhau(string maNhanKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaNhanKhau", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNhanKhau", maNhanKhau);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<NhanKhauDTO> TimKiemNhanKhau(string tuKhoa1)
        {
            List<NhanKhauDTO> ketQua = new List<NhanKhauDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemNhanKhau", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuKhoa1", tuKhoa1);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NhanKhauDTO nk = new NhanKhauDTO
                    {
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        MaHoKhau = reader["MaHoKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        QuanHeVoiChuHo = reader["QuanHeVoiChuHo"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        Email = reader["Email"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        GhiChu = reader["GhiChu"] == DBNull.Value ? "" : reader["GhiChu"].ToString(),
                    };

                    ketQua.Add(nk);
                }

                reader.Close();
            }

            return ketQua;
        }
        public bool KiemTraTrungMaNhanKhau(string maNhanKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau WHERE MaNhanKhau = @MaNhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanKhau", maNhanKhau);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraTrungCCCD(string cccd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau WHERE CCCD = @CCCD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CCCD", cccd);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraTrungEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool KiemTraTrungSoDienThoai(string soDienThoai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau WHERE SoDienThoai = @SoDienThoai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

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
        public string LayCCCDChuHoTheoMaHoKhau(string maHoKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CCCDChuHo FROM HoKhau WHERE MaHoKhau = @MaHoKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoKhau", maHoKhau);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }
        public string LayHoTenChuHoTheoMaHoKhau(string maHoKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TenChuHo FROM HoKhau WHERE MaHoKhau = @MaHoKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoKhau", maHoKhau);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
        }
        // Cập nhật ảnh đính kèm cho Nhân Khẩu
        public bool CapNhatAnhNhanKhau(string maNhanKhau, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE NhanKhau SET AnhDinhKem2 = @AnhDinhKem WHERE MaNhanKhau = @MaNhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanKhau", maNhanKhau);
                cmd.Parameters.Add("@AnhDinhKem", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy ảnh đính kèm theo mã Nhân Khẩu
        public byte[] LayAnhNhanKhau(string maNhanKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem2 FROM NhanKhau WHERE MaNhanKhau = @MaNhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanKhau", maNhanKhau);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
        public bool CapNhatAnhNhaNhanKhau(string maNhanKhau, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE NhanKhau SET AnhDinhKem3 = @AnhDinhKem WHERE MaNhanKhau = @MaNhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanKhau", maNhanKhau);
                cmd.Parameters.Add("@AnhDinhKem", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public byte[] LayAnhNhaNhanKhau(string maNhanKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem3 FROM NhanKhau WHERE MaNhanKhau = @MaNhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanKhau", maNhanKhau);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
        public List<ThongKeNhanKhauTheoDoTuoiDTO> ThongKeNhanKhauTheoDoTuoi()
        {
            List<ThongKeNhanKhauTheoDoTuoiDTO> danhSach = new List<ThongKeNhanKhauTheoDoTuoiDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeNhanKhauTheoDoTuoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeNhanKhauTheoDoTuoiDTO item = new ThongKeNhanKhauTheoDoTuoiDTO
                    {
                        NhomTuoi = reader["NhomTuoi"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"])
                    };
                    danhSach.Add(item);
                }

                reader.Close();
            }

            return danhSach;
        }
        public List<ThongKeNhanKhauTheoGioiTinhDTO> ThongKeNhanKhauTheoGioiTinh()
        {
            List<ThongKeNhanKhauTheoGioiTinhDTO> danhSach = new List<ThongKeNhanKhauTheoGioiTinhDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeNhanKhauTheoGioiTinh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeNhanKhauTheoGioiTinhDTO item = new ThongKeNhanKhauTheoGioiTinhDTO
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
        public bool KiemTraCCCDNguoiThueTro(string cccd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiThueTro WHERE CCCD = @CCCD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CCCD", cccd);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraEmailNguoiThueTro(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiThueTro WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraSoDienThoaiNguoiThueTro(string sdt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiThueTro WHERE SoDienThoai = @SoDienThoai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", sdt);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public int DemTongNhanKhau()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count;
            }
        }
    }
}
